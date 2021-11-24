﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.Module.Win
{
    using DevExpress.ExpressApp;
    using DevExpress.ExpressApp.Model;
    using DevExpress.ExpressApp.Security;
    using DevExpress.ExpressApp.Security.ClientServer;
    using DevExpress.ExpressApp.Utils;
    using DevExpress.ExpressApp.Win;
    using DevExpress.ExpressApp.Win.Templates;
    using DevExpress.Persistent.BaseImpl.PermissionPolicy;

    //...
    public class MyFrameTemplateFactory : DefaultLightStyleFrameTemplateFactory
    {
        private WinApplication application;
        //SecurityStrategyComplex security;
        //IObjectSpaceProvider objectSpaceProvider;
        public MyFrameTemplateFactory(WinApplication application)
        {
            Guard.ArgumentNotNull(application, nameof(application));
            this.application = application;
            //AuthenticationStandard authentication = new AuthenticationStandard();
            //security = new SecurityStrategyComplex(typeof(PermissionPolicyUser), typeof(PermissionPolicyRole), authentication);
            //security.RegisterXPOAdapterProviders();
            //objectSpaceProvider = new SecuredObjectSpaceProvider(security, application.ConnectionString, null);
        }
        protected IModelTemplate GetTemplateInfo(TemplateContext templateContext)
        {
            return application.Model.Templates[templateContext.Name];
        }
        //protected override DevExpress.ExpressApp.Templates.IFrameTemplate
        //    CreateApplicationWindowTemplate()
        //{
        //    return new XtraForm2(application);
        //}
        //protected override DevExpress.ExpressApp.Templates.IFrameTemplate CreateViewTemplate()
        //{
        //    return new XtraForm2(application);
        //}
    }
}
