using DevExpress.ExpressApp;
using System.Drawing;
using DevExpress.ExpressApp.Security;
using DevExpress.XtraLayout;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Win;

namespace DXApplication2.Module.Win.Controllers
{
    public class CustomWinController : ViewController
    {
        SimpleAction simpleAction;
        public CustomWinController()
        {
            TargetObjectType = typeof(AuthenticationStandardLogonParameters);
            TargetViewType = ViewType.DetailView;
            simpleAction = new SimpleAction(this, "Log In", DevExpress.Persistent.Base.PredefinedCategory.PopupActions);
            simpleAction.Execute += SimpleAction_Execute;
        }

        private void SimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ((WinApplication)Application).LoggedOn += CustomWinController_LoggedOn;
        }

        private void CustomWinController_LoggedOn(object sender, LogonEventArgs e)
        {
           
        }
        
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            DetailView view = (DetailView)View;
            LayoutControl layoutControl = ((LayoutControl)view.Control);
            foreach(object obj in layoutControl.Items)
            {
                if(obj is DevExpress.XtraLayout.LayoutControlItem)
                {
                    LayoutControlItem layoutControlItem = (LayoutControlItem)obj;
                    FontFamily fontFamily1 = new FontFamily("Comic Sans MS");
                    layoutControlItem.AppearanceItemCaption.Font = new Font(fontFamily1, 25);

                    layoutControlItem.Control.Height = 300;
                    layoutControlItem.Control.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                }
            }
        }
    }
}
