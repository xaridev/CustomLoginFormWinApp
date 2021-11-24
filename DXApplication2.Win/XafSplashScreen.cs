using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using DevExpress.ExpressApp.Win.Utils;
using DevExpress.Skins;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Svg;
using DevExpress.XtraSplashScreen;

using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace DXApplication2.Win
{
  public partial class XafSplashScreen : SplashScreen
  {
    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn
(
   int nLeftRect,     // x-coordinate of upper-left corner
   int nTopRect,      // y-coordinate of upper-left corner
   int nRightRect,    // x-coordinate of lower-right corner
   int nBottomRect,   // y-coordinate of lower-right corner
   int nWidthEllipse, // height of ellipse
   int nHeightEllipse // width of ellipse
);

    protected override void DrawContent(GraphicsCache graphicsCache, Skin skin)
    {

    }
    protected void UpdateLabelsPosition()
    {

    }
    public XafSplashScreen()
    {
      InitializeComponent();

      Assembly executingAssembly = Assembly.GetExecutingAssembly();

      UpdateLabelsPosition();
      InitializeComponent();
      this.FormBorderStyle = FormBorderStyle.None;
      Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
    }

    #region Overrides

    public override void ProcessCommand(Enum cmd, object arg)
    {
      base.ProcessCommand(cmd, arg);

    }

    private void ImageSlider1_Click(object sender, EventArgs e)
    {
      this.FormBorderStyle = FormBorderStyle.None;
      Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
    }
  }
  #endregion

  public enum SplashScreenCommand
  {
  }

}