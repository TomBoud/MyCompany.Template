using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;

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
                var data = revitUi.CreateAppRibbonPushButtonData("MyClass");
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
