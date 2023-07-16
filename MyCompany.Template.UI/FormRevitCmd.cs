
using System;
using System.Windows.Forms;
using MyCompany.Template.Abstractions;

namespace MyCompany.Template.UI
{
    public partial class FormRevitCmd : Form
    {
        private readonly IDocumnet _document;

        public string Result { get; private set; }

        public FormRevitCmd(IDocumnet doc)
        {
            InitializeComponent();
            _document = doc;
        }

        private void FormRevitCmd_Load(object sender, EventArgs e)
        {
            Result = "Result of user interaction" + _document.Title;
        }
    }
}
