﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using System.Reflection;

/// <summary>
/// Represents a namesapce for managing the user interface in Autodesk Revit.
/// </summary>
namespace MyCompany.Template.RevitAddin.Application
{
    /// <summary>
    /// Represents the RevitUI class for managing the user interface in Autodesk Revit.
    /// </summary>
    public class RevitUI
    {
        /// <summary>
        /// The name of the ribbon tab.
        /// </summary>
        private readonly string _ribbonTabName;
       
        /// <summary>
        /// The name of the ribbon panel.
        /// </summary>
        private readonly string _ribbonPanelName;
       
        /// <summary>
        /// The name of the push button.
        /// </summary>
        private readonly string _pushButtonName;
      
        /// <summary>
        /// The controlled application of Revit.
        /// </summary>
        private readonly UIControlledApplication _application;
      
        /// <summary>
        /// Initializes a new instance of the RevitUI class with the specified controlled application.
        /// </summary>
        /// <param name="application">The controlled application of Revit.</param>
        public RevitUI(UIControlledApplication application)
        {
            _application = application;

            _ribbonTabName = RevitAddin.Properties.AppUI.Default.RibbonName;
            _ribbonPanelName = RevitAddin.Properties.AppUI.Default.PanelName;
            _pushButtonName = RevitAddin.Properties.AppUI.Default.PushButtonName;
        }
     
        /// <summary>
        /// Creates a new ribbon tab in the Revit.exe UI with the name specified in .settings file.
        /// </summary>
        public void CreateAppRibbonTab()
        {
            if (string.IsNullOrEmpty(_ribbonTabName))
            {
                throw new ArgumentException("The ribbon tab name is null or empty, Check the .settings file", nameof(_ribbonTabName));
            }
            _application.CreateRibbonTab(_ribbonTabName);
        }
       
        /// <summary>
        /// Creates a new ribbon panel in the Revit.exe UI with the name specified in .settings file.
        /// </summary>
        /// <returns>The created ribbon panel object for the Revit.exe UI.</returns>
        /// <exception cref="ArgumentException">Thrown when the panel or tab names are either null or empty.</exception>
        public RibbonPanel CreateAppRibbonPanel()
        {
            if (string.IsNullOrEmpty(_ribbonPanelName))
            {
                throw new ArgumentException("The ribbon panel name is null or empty, Check the .settings file", nameof(_ribbonPanelName));
            }
            if (string.IsNullOrEmpty(_ribbonTabName))
            {
                throw new ArgumentException("The ribbon tab name is null or empty, Check the .settings file", nameof(_ribbonTabName));
            
            }
            return _application.CreateRibbonPanel(_ribbonTabName, _ribbonPanelName);
        }
       
        /// <summary>
        /// Creates a new push button in the Revit.exe UI with the name specified in .settings file.
        /// </summary>
        /// <param name="panel">The Ribbon Panel object for which to assign the button.</param>
        /// <param name="classToTriger">The type of the class which the code be redirected to after click event.</param>
        /// <returns>The created PushButton object for the Revit.exe UI.</returns>
        /// <exception cref="ArgumentNullException">Thrown if any argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the push button name is null or empty.</exception>
        public PushButton CreateAppRibbonPushButton(RibbonPanel panel, Type classToTriger)
        {
            if (string.IsNullOrEmpty(_pushButtonName))
            {
                throw new ArgumentException("The push button name is null or empty, Check the .settings file", nameof(_pushButtonName));
            }
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }
            if (classToTriger == null)
            {
                throw new ArgumentNullException(nameof(classToTriger));
            }

            var pushButtonData = new PushButtonData(_pushButtonName, _pushButtonName, classToTriger.Assembly.Location, classToTriger.FullName);
            return panel.AddItem(pushButtonData) as PushButton;
        }
      
        /// <summary>
        /// Configures the specified push button with the provided icon.
        /// </summary>
        /// <param name="button">The push button to configure.</param>
        /// <param name="icon">The icon to set for the push button.</param>
        /// <exception cref="ArgumentNullException">Thrown if any argument is null.</exception>
        public void ConfigAppRibbonPushButton(PushButton button,Bitmap icon)
        {
            if (button == null)
            {
                throw new ArgumentNullException(nameof(button));
            }

            if (icon == null)
            {
                throw new ArgumentNullException(nameof(icon));
            }

            var options = BitmapSizeOptions.FromEmptyOptions();
            var bitMap = icon.GetHbitmap();
            var imgSource = Imaging.CreateBitmapSourceFromHBitmap(bitMap, IntPtr.Zero, Int32Rect.Empty, options);
            button.LargeImage = imgSource;
        }
      
        /// <summary>
        /// Checks if the ribbon panel exists.
        /// </summary>
        /// <returns>True if the ribbon panel exists; otherwise, false.</returns>
        public bool IsRibbonPanelExists()
        {
            return _application.GetRibbonPanels().Any(panel => panel.Name.Equals(_ribbonPanelName));
        }
    }
}
