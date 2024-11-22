using GUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            var backgroundImage = Resources.RentHubFinal;
            this.BackgroundImage = backgroundImage;
            this.ClientSize = new Size(backgroundImage.Width, backgroundImage.Height);
        }
        private bool mouseDown;
        private Point lastLocation;

        private void SplashScreen_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void SplashScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point( (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void SplashScreen_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
