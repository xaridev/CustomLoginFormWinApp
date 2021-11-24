using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
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

namespace DXApplication2.Module.Win
{
    public partial class XtraForm2 : DevExpress.XtraEditors.XtraForm, DevExpress.ExpressApp.Templates.IFrameTemplate, DevExpress.ExpressApp.Templates.IWindowTemplate
    {
        private SecurityStrategyComplex security;
        private IObjectSpaceProvider objectSpaceProvider;
        WinApplication application;
        public XtraForm2(WinApplication _application)
        {
            InitializeComponent();
            this.application = _application;
            AuthenticationStandard authentication = new AuthenticationStandard();
            security = new SecurityStrategyComplex(typeof(PermissionPolicyUser), typeof(PermissionPolicyRole), authentication);
            security.RegisterXPOAdapterProviders();
            objectSpaceProvider = new SecuredObjectSpaceProvider(security, application.ConnectionString, null);
            application.LoggedOn += Application_LoggedOn;
        }

        private void Application_LoggedOn(object sender, LogonEventArgs e)
        {
            XafApplication app = (XafApplication)sender;
            IModelApplicationNavigationItems navigationItems = (IModelApplicationNavigationItems)app.Model;
            string targetViewId = "PermissionPolicyUser_DetailView";
            IModelNavigationItem targetNavigationItem = navigationItems.NavigationItems.AllItems.FirstOrDefault(
                item => item.View != null & item.View.Id == targetViewId);
            if (targetNavigationItem != null)
            {
                navigationItems.NavigationItems.StartupNavigationItem = targetNavigationItem;
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
           
            string userName = userNameEdit.Text;
            string password = passwordEdit.Text;
            ((SecurityStrategyComplex)application.Security).Authentication.SetLogonParameters(new AuthenticationStandardLogonParameters(userName, password));
            objectSpaceProvider = new SecuredObjectSpaceProvider(((SecurityStrategyComplex)application.Security), application.ConnectionString, null);
            IObjectSpace logonObjectSpace = objectSpaceProvider.CreateObjectSpace();
            ((SecurityStrategyComplex)application.Security).Logon(logonObjectSpace);
            if (application.Security.IsAuthenticated)
            {
                
                ShowViewParameters svp = new ShowViewParameters();
                IObjectSpace os = application.CreateObjectSpace(typeof(PermissionPolicyUser));
                object theObjectToBeShown = os.FindObject<PermissionPolicyUser>(new BinaryOperator("Oid", Guid.Parse(application.Security.UserId.ToString())));
                DetailView dv = application.CreateDetailView(os, theObjectToBeShown, true);
                dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
                svp.CreatedView = dv;
                application.ShowViewStrategy.ShowView(svp, new ShowViewSource(application.CreateFrame(TemplateContext.View), null));
                //this.SetView(dv);
                //application.ShowViewStrategy.ShowStartupWindow();
            }


            //try
            //{
            //    ((SecurityStrategyComplex)application.Security).Logon(logonObjectSpace);
            //    //if (application.Security.IsAuthenticated)
            //    //    XtraMessageBox.Show("Authenticated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    //DialogResult = DialogResult.OK;
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //IModelApplicationNavigationItems navigationItems = (IModelApplicationNavigationItems)application.Model;
            //string targetViewId = "PermissionPolicyUser_DetailView";
            //IModelNavigationItem targetNavigationItem = navigationItems.NavigationItems.AllItems.FirstOrDefault(
            //    item => item.View != null & item.View.Id == targetViewId);
            //if (targetNavigationItem != null)
            //{
            //    navigationItems.NavigationItems.StartupNavigationItem = targetNavigationItem;
            //}
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainDemoWinApplication_LoggedOn(object sender, LogonEventArgs e)
        {
            
        }
        private void UserNameEdit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string message = string.IsNullOrEmpty(userNameEdit.Text) ? "The user name must not be empty. Try Admin or User." : string.Empty;
            dxErrorProvider1.SetError(userNameEdit, message);
        }
        public IActionContainer DefaultContainer => null;

        public bool IsSizeable { get; set; }

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
    }
}
