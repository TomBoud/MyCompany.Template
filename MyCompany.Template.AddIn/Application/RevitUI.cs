using System;
using System.Drawing;
using System.Linq;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using System.Reflection;

namespace MyCompany.Template.AddIn.Application
{
    public class RevitUI
    {
        private readonly string _ribbonTabName;
        private readonly string _ribbonPanelName;
        private readonly string _pushButtonName;

        private readonly UIControlledApplication _application;

        public RevitUI(UIControlledApplication application)
        {
            _application = application;

            _ribbonTabName = Properties.Settings.Default.RibbonName;
            _ribbonPanelName = Properties.Settings.Default.PanelName;
            _pushButtonName = Properties.Settings.Default.PushButtonName;
        }

        public bool IsRibbonPanelExists()
        {
            return _application.GetRibbonPanels().Any(panel => panel.Name.Equals(_ribbonPanelName));
        }

        public void CreateAppRibbonTab()
        {
            if(string.IsNullOrEmpty(_ribbonTabName)) { return; }
            _application.CreateRibbonTab(_ribbonTabName);
        }

        public RibbonPanel CreateAppRibbonPanel()
        {
            if (string.IsNullOrEmpty(_ribbonPanelName)) { return null; }
            return _application.CreateRibbonPanel(_ribbonTabName, _ribbonPanelName);
        }

        public PushButton CreateAppRibbonPushButton(RibbonPanel panel, PushButtonData data)
        {
            if (string.IsNullOrEmpty(_pushButtonName)) { return null; }
            return panel.AddItem(data) as PushButton;
        }
        
        public PushButtonData CreateAppRibbonPushButtonData(string classToTrigger)
        {
            if (string.IsNullOrEmpty(classToTrigger)) { return null; }
            return new PushButtonData(_pushButtonName, _pushButtonName, Assembly.GetExecutingAssembly().Location, classToTrigger);
        }

        public void ConfigAppRibbonPushButton(PushButton button,Bitmap icon)
        {
            if (button == null || icon == null) { return; }
            button.LargeImage = Imaging.CreateBitmapSourceFromHBitmap(icon.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
