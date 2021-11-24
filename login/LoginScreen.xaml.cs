using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Core;
using DevExpress.ExpressApp.Templates;

namespace CoralReef.Login
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : System.Windows.Window, ISplash, DevExpress.ExpressApp.Templates.IFrameTemplate, DevExpress.ExpressApp.Templates.IWindowTemplate
  {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var connectionString = string.Empty; // DbCommon.CreateConnectionString();
            ValueManager.ValueManagerType = typeof(MultiThreadValueManager<>).GetGenericTypeDefinition();
        }
    static private LoginScreen form;
    private static bool isStarted = false;
    public void Start()
    {
      isStarted = true;
      form = new LoginScreen();
      form.Show();
     // Application.DoEvents();
    }
    public void Stop()
    {
      if (form != null)
      {
        form.Hide();
        form.Close();
        form = null;
      }
      isStarted = false;
    }
    public void SetDisplayText(string displayText)
    {
    }

    public ICollection<IActionContainer> GetContainers()
    {
      return new System.Collections.ObjectModel.Collection<IActionContainer>();
    }

    public void SetView(View view)
    {
      
    }

    public void SetStatus(ICollection<string> statusMessages)
    {
     
    }

    public void SetCaption(string caption)
    {
      
    }

    public bool IsStarted
    {
      get { return isStarted; }
    }

    public IActionContainer DefaultContainer => null;

    public bool IsSizeable { get; set; }
  }
}
