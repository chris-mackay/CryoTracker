using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryoTracker
{
    public partial class frmErrorReport : Form
    {
        public frmErrorReport()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("cryotracker.prog@gmail.com");
                mail.To.Add("cryotracker.prog@gmail.com");
                mail.Subject = "Error Report";
                mail.Body = "User email:\n" + txtEmail.Text +
                            "\n----------------------------------------------------------------------------------------------------\n" +
                            "User Description:\n" + txtDescription.Text +
                            "\n----------------------------------------------------------------------------------------------------\n" +
                            "Exception:\n" + txtError.Text;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("cryotracker.prog@gmail.com", "supermeatboy");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("The error report has been sent and will be reviewed\n\nThank you for your patience", "Send Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmErrorReport_Paint(object sender, PaintEventArgs e)
        {
            Module.SetFormColors(this);

            Color borderColor = ColorTranslator.FromHtml(Module.GetSettingsValue(Module.CryoTrackerSettings.AppBorderColor));

            Rectangle rect1 = new Rectangle(txtDescription.Location.X, txtDescription.Location.Y, txtDescription.ClientSize.Width, txtDescription.ClientSize.Height);
            rect1.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, rect1, borderColor, ButtonBorderStyle.Solid);

            Rectangle rect11 = new Rectangle(txtDescription.Location.X, txtDescription.Location.Y, txtDescription.ClientSize.Width, txtDescription.ClientSize.Height);
            rect11.Inflate(3, 3);
            ControlPaint.DrawBorder(e.Graphics, rect11, borderColor, ButtonBorderStyle.Solid);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
