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
using System.Runtime.InteropServices;
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

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Form1(WinApplication _application)
        {
            InitializeComponent();
            this.application = _application;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
