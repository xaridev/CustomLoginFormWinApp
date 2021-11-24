using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Templates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2.Module.Win.Controllers
{
    public class CustomDialogController:LogonController
    {
        SimpleAction simpleAction;
        public CustomDialogController()
        {
            simpleAction = new SimpleAction(this, "Custom", DevExpress.Persistent.Base.PredefinedCategory.PopupActions);
            simpleAction.Execute += SimpleAction_Execute;
        }

        protected override void OnWindowTemplateChanged()
        {
            //IWindowTemplate formTemplate = Window.Template as IWindowTemplate;
            //if (formTemplate != null && formTemplate is Form && Window.Context.Name == TemplateContext.PopupWindowContextName)
            //{
            //    ((ISupportStoreSettings)formTemplate).SettingsReloaded += CustomDialogController_SettingsReloaded;
               
            //    //if (formTemplate is ISupportStoreSettings)
            //    //{
            //    //    ((ISupportStoreSettings)formTemplate).SettingsReloaded += (sender1, e1) => {
            //    //        ((Form)sender1).StartPosition = FormStartPosition.CenterScreen;
            //    //        double widthPercent = (double)Screen.PrimaryScreen.Bounds.Width / 1000;
            //    //        double heigthPercent = (double)Screen.PrimaryScreen.Bounds.Height / 700;
            //    //        double width = Screen.PrimaryScreen.Bounds.Width / widthPercent;
            //    //        double heigth = Screen.PrimaryScreen.Bounds.Height / heigthPercent;
            //    //        ((Form)sender1).Size = new Size((int)width, (int)heigth);
            //    //    };

            //    //}
            //    //else
            //    //{
            //    //    ((Form)formTemplate).StartPosition = FormStartPosition.CenterScreen;
            //    //    double widthPercent = (double)Screen.PrimaryScreen.Bounds.Width / 1000;
            //    //    double heigthPercent = (double)Screen.PrimaryScreen.Bounds.Height / 700;
            //    //    double width = Screen.PrimaryScreen.Bounds.Width / widthPercent;
            //    //    double heigth = Screen.PrimaryScreen.Bounds.Height / heigthPercent;
            //    //    ((Form)formTemplate).Size = new Size((int)width, (int)heigth);
            //    //}
            //}
        }

        private void CustomDialogController_SettingsReloaded(object sender, EventArgs e)
        {
            ((Form)sender).StartPosition = FormStartPosition.CenterScreen;
            double widthPercent = (double)Screen.PrimaryScreen.Bounds.Width / 1000;
            double heigthPercent = (double)Screen.PrimaryScreen.Bounds.Height / 700;
            double width = Screen.PrimaryScreen.Bounds.Width / widthPercent;
            double heigth = Screen.PrimaryScreen.Bounds.Height / heigthPercent;
            ((Form)sender).Size = new Size((int)width, (int)heigth);
        }

        private void SimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            this.AcceptAction.DoExecute();
        }
    }
}
