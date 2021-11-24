using DevExpress.ExpressApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.Module.Win.Controllers
{
    public class MyAuthenticationStandard:AuthenticationStandard
    {
        public override bool AskLogonParametersViaUI
        {
            get
            {
                return !this.Security.IsAuthenticated;
            }
        }
    }
}
