using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace DXApplication2.Module.Win.Controllers
{
    public partial class CenterPopupWindowsController : WindowController
    {
        public CenterPopupWindowsController()
        {
            TargetWindowType = WindowType.Any;
            // Target required Windows (via the TargetXXX properties) and create their Actions.
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            Window.TemplateChanged += Window_TemplateChanged;

            // Perform various tasks depending on the target Window.
        }

        private void Window_TemplateChanged(object sender, EventArgs e)
        {

            IWindowTemplate formTemplate = Window.Template as IWindowTemplate;
            if (formTemplate != null && formTemplate is Form && Window.Context == TemplateContext.ViewContextName)
            {
                if (formTemplate is ISupportStoreSettings)
                {
                    ((ISupportStoreSettings)formTemplate).SettingsReloaded += (sender1, e1) => {
                        ((Form)sender1).StartPosition = FormStartPosition.CenterScreen;
                        double widthPercent = (double)Screen.PrimaryScreen.Bounds.Width / 1000;
                        double heigthPercent = (double)Screen.PrimaryScreen.Bounds.Height / 700;
                        double width = Screen.PrimaryScreen.Bounds.Width / widthPercent;
                        double heigth = Screen.PrimaryScreen.Bounds.Height / heigthPercent;
                        ((Form)sender1).Size = new Size((int)width, (int)heigth);
                    };

                }
                else
                {
                    ((Form)formTemplate).StartPosition = FormStartPosition.CenterScreen;
                    double widthPercent = (double)Screen.PrimaryScreen.Bounds.Width / 1000;
                    double heigthPercent = (double)Screen.PrimaryScreen.Bounds.Height / 700;
                    double width = Screen.PrimaryScreen.Bounds.Width / widthPercent;
                    double heigth = Screen.PrimaryScreen.Bounds.Height / heigthPercent;
                    ((Form)formTemplate).Size = new Size((int)width, (int)heigth);
                }
            }

        }
        //private void OnFormReadyForCustomizations(object sender, EventArgs e)
        //{
        //    //if (YourCustomBusinessCondition(Window.View))
        //    //{
        //    ((System.Windows.Forms.Form)sender).Width = 600;
        //    //}
        //}
        //private bool YourCustomBusinessCondition(DevExpress.ExpressApp.View view)
        //{
        ////    return view != null && view.CurrentObject;
        //}

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            Window.TemplateChanged -= Window_TemplateChanged;
            base.OnDeactivated();
        }
    }
}
