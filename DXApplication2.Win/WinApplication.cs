﻿using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using System.Collections.Generic;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Win.Utils;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Templates;
using DXApplication2.Module.Win;
using DXApplication2.Module.Win.Controllers;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace DXApplication2.Win {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWinWinApplicationMembersTopicAll.aspx
    public partial class DXApplication2WindowsFormsApplication : WinApplication {
        #region Default XAF configuration options (https://www.devexpress.com/kb=T501418)
        static DXApplication2WindowsFormsApplication() {
            DevExpress.Persistent.Base.PasswordCryptographer.EnableRfc2898 = true;
            DevExpress.Persistent.Base.PasswordCryptographer.SupportLegacySha512 = false;
			DevExpress.ExpressApp.Utils.ImageLoader.Instance.UseSvgImages = true;
        }
        private void InitializeDefaults() {
            LinkNewObjectToParentImmediately = false;
            OptimizedControllersCreation = true;
            UseLightStyle = true;
			//SplashScreen = new DXSplashScreen(typeof(CoralReef.Login.LoginScreen), new DefaultOverlayFormOptions());
			ExecuteStartupLogicBeforeClosingLogonWindow = true;
        }
        #endregion

        public DXApplication2WindowsFormsApplication() {
            InitializeComponent();
			InitializeDefaults();
            //AuthenticationStandard authentication = new AuthenticationStandard();
            //security = new SecurityStrategyComplex(typeof(PermissionPolicyUser), typeof(PermissionPolicyRole), authentication);
            //security.RegisterXPOAdapterProviders();
            //objectSpaceProvider = new SecuredObjectSpaceProvider(security, ConnectionString, null);

            CreateCustomTemplate += DXApplication2WindowsFormsApplication_CreateCustomTemplate;
        }
        
        //protected override LogonController CreateLogonController()
        //{
        //    return new CustomDialogController();
        //}
        private void DXApplication2WindowsFormsApplication_CreateCustomTemplate(object sender, CreateCustomTemplateEventArgs e)
        {
            if (e.Context == TemplateContext.PopupWindow)
                e.Template = new Form1(this);
        }
        
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) 
        {
            args.ObjectSpaceProviders.Add(new XPObjectSpaceProvider(XPObjectSpaceProvider.GetDataStoreProvider(args.ConnectionString, args.Connection, true), false));
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
        }
        private void DXApplication2WindowsFormsApplication_CustomizeLanguagesList(object sender, CustomizeLanguagesListEventArgs e) {
            string userLanguageName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            if(userLanguageName != "en-US" && e.Languages.IndexOf(userLanguageName) == -1) {
                e.Languages.Add(userLanguageName);
            }
        }
        bool logged;
        public bool ReadLogonParameters(string userName, string password, Form1 popupForm1)
        {
            
            ((AuthenticationStandardLogonParameters)SecuritySystem.LogonParameters).UserName = userName;
            ((AuthenticationStandardLogonParameters)SecuritySystem.LogonParameters).Password = password;
            try
            {
                Logon(null);
                logged = true;
            }
            catch (Exception ex)
            {
                DialogResult dialogResult = XtraMessageBox.Show(ex.Message, "Log in failed", System.Windows.Forms.MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                    //popupForm1.Visible = false;
                    //popupForm1.Close();
                    //popupForm1.ShowDialog();
                    logged = false;
                    
                }
                 
            }
            return logged;
        }

        private void PopupForm1_LostFocus(object sender, EventArgs e)
        {
            ((PopupForm1)sender).Close();
        }

        private void DXApplication2WindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
            e.Updater.Update();
            e.Handled = true;
#else
            if(System.Diagnostics.Debugger.IsAttached) {
                e.Updater.Update();
                e.Handled = true;
            }
            else {
				string message = "The application cannot connect to the specified database, " +
					"because the database doesn't exist, its version is older " +
					"than that of the application or its schema does not match " +
					"the ORM data model structure. To avoid this error, use one " +
					"of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

				if(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
					message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
				}
				throw new InvalidOperationException(message);
            }
#endif
        }
    }
}