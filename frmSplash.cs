using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
namespace College_Management_System
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        private void frmSplash_Load(object sender, EventArgs e)
        {


            this.label6.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelX1.Text = AssemblyCopyright;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            progressBar1.Visible = true;

            this.progressBar1.Value = this.progressBar1.Value + 2;
            if (this.progressBar1.Value ==10){
                label1.Text="Reading modules..";
            }
            else if (this.progressBar1.Value == 20)
            {
                label1.Text = "Turning on modules...";
            }
            else if (this.progressBar1.Value == 40)
            {
                label1.Text = "Starting modules....";
            }
            else if (this.progressBar1.Value == 60)
            {
                label1.Text = "Loading modules.....";
            }
            else if (this.progressBar1.Value == 80)
            {
                label1.Text = "Done Loading modules......";
            }
            else if (this.progressBar1.Value == 100)
            {
                frm.Show();
                timer1.Enabled = false;
                this.Hide();
            }
        }
    }
}

