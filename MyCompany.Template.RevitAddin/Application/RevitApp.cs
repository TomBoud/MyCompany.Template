﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using MyCompany.Template.RevitAddin.Commands;
using MyCompany.Template.DataAccess.Autodesk.AppStore;

/// <summary>
/// Represents a namesapce for managing the user interface in Autodesk Revit.
/// </summary>
namespace MyCompany.Template.RevitAddin.Application
{
    /// <summary>
    /// Represents the main entrance point for the Revit add-in.
    /// </summary>
    [Regeneration(RegenerationOption.Manual)]
    public class RevitApp : IExternalApplication
    {
        /// <summary>
        /// Called when the add-in is started up.
        /// </summary>
        /// <param name="application">The Revit.exe application object.</param>
        /// <returns>The result of the startup operation.</returns>
        public Result OnStartup(UIControlledApplication application)
        {
            var revitUi = new RevitUI(application);

            if(revitUi.AppRibbonTabExists() is false)
            {
                revitUi.CreateAppRibbonTab();
            }

            if(revitUi.AppRibbonPanelExists() is false)
            {
                revitUi.CreateAppRibbonPanel();
            }

            var panel = revitUi.GetAppRibbonPanel();
            var button = revitUi.CreateAppRibbonPushButton(panel, typeof(RevitCmd));
            revitUi.ConfigAppRibbonPushButton(button, Properties.Resources.TemplateIcon.ToBitmap());

            return Result.Succeeded;
        }

        /// <summary>
        /// Called when the add-in is shut down.
        /// </summary>
        /// <param name="application">The Revit.exe application object.</param>
        /// <returns>The result of the shutdown operation.</returns>
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
