using DevExpress;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Core;
using DevExpress.ExpressApp.Win.Layout;
using DevExpress.ExpressApp.Win.Templates;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using DevExpress.XtraEditors;
using System.Collections.Generic;

namespace DXApplication2.Win
{
    public partial class LoginForm : PopupFormBase
    {
        protected override XafLayoutControl BottomPanel
        {
            get { return bottomPanel; }
        }
        protected override PanelControl ViewSitePanel
        {
            get { return viewSitePanel; }
        }
        protected override ViewSiteManager ViewSiteManager
        {
            get { return viewSiteManager; }
        }
        protected override FormStateModelSynchronizer FormStateModelSynchronizer
        {
            get { return formStateModelSynchronizer; }
        }
        public override ICollection<IActionContainer> GetContainers()
        {
            return actionContainersManager.GetContainers();
        }
        public override IActionContainer DefaultContainer
        {
            get { return actionContainersManager.DefaultContainer; }
        }
        public ButtonsContainer ButtonsContainer
        {
            get { return buttonsContainer; }
        }
        public ButtonsContainer DiagnosticContainer
        {
            get { return diagnosticContainer; }
        }
        public override object ViewSiteControl
        {
            get { return viewSitePanel; }
        }
        public override DevExpress.XtraBars.BarManager BarManager
        {
            get { return xafBarManager; }
        }
        WinApplication application;
        public LoginForm(WinApplication _application)
        {
            InitializeComponent();
            application = _application;
        }
        protected override void SetClientSizeCore(int x, int y)
        {
            base.SetClientSizeCore(400, 400);
        }
        bool logged;
        private void button1_Click(object sender, System.EventArgs e)
        {
            //logged = ((DXApplication2WindowsFormsApplication)application).ReadLogonParameters(textBox1.Text, textBox2.Text, this);
            if (logged)
                Close();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            //logged = ((DXApplication2WindowsFormsApplication)application).ReadLogonParameters(textBox1.Text, textBox2.Text, this);
            if (logged)
                Close();
        }
    }
}