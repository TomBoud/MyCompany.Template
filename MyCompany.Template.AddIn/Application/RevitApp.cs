using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using MyCompany.Template.AddIn.Commands;

namespace MyCompany.Template.AddIn.Application
{
    [Regeneration(RegenerationOption.Manual)]
    public class RevitApp : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            var revitUi = new RevitUI(application);

            revitUi.CreateAppRibbonTab();

            if(!revitUi.IsRibbonPanelExists())
            {
                var panel = revitUi.CreateAppRibbonPanel();
                var data = revitUi.CreateAppRibbonPushButtonData(typeof(RevitCmd));
                var button = revitUi.CreateAppRibbonPushButton(panel, data);

                revitUi.ConfigAppRibbonPushButton(button, Properties.Resources.TemplateIcon.ToBitmap());
            }

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
