using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCompany.Template.UI.Views;
using MyCompany.Template.UI.Models;
using MyCompany.Template.UI.Repositories;
using MyCompany.Template.UI.Presenters;

namespace MyCompany.Template.UI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();

            IElementView view = new ElementView();
            IElementRepo repo = new ElementRepo();

            new ElementPresenter(view, repo);

            Application.Run((Form)view);

        }
    }
}
