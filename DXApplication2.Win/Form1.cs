using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2.Win
{
    public partial class Form1 : Form, DevExpress.ExpressApp.Templates.IFrameTemplate, DevExpress.ExpressApp.Templates.IWindowTemplate, DevExpress.XtraBars.Docking2010.IDocumentsHostWindow
    {
        WinApplication application;
        private SecurityStrategyComplex security;
        private IObjectSpaceProvider objectSpaceProvider;
        public Form1(WinApplication _application)
        {
            InitializeComponent();
            this.application = _application;
        }

        public IActionContainer DefaultContainer => null;

        public bool IsSizeable { get; set; }

        public DocumentManager DocumentManager => null;

        public bool DestroyOnRemovingChildren => false;

        public ICollection<IActionContainer> GetContainers()
        {
            return new System.Collections.ObjectModel.Collection<IActionContainer>();
        }

        public void SetCaption(string caption)
        {
           
        }

        public void SetStatus(ICollection<string> statusMessages)
        {
           
        }

        public void SetView(DevExpress.ExpressApp.View view)
        {
           
        }
        bool logged;
        private void button1_Click(object sender, EventArgs e)
        {
            logged = ((DXApplication2WindowsFormsApplication)application).ReadLogonParameters(textBox1.Text, textBox2.Text, this);
            if (logged)
                Close();
        }
        
    }
}
