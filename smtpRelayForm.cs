using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace smtpRelay_Admin
{
    public partial class smtpRelayForm : Form
    {
        public smtpRelayForm()
        {
            InitializeComponent();
            // Event handlers for buttons
            this.buttonSend.Click += new EventHandler(buttonSend_Click);
            this.buttonClear.Click += new EventHandler(buttonClear_Click);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidEmail(textFrom.Text) || !IsValidEmail(textTo.Text))
                {
                    AppendLog("Invalid email address. Please check the 'From' and 'To' fields.");
                    return;
                }
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                SmtpClient client = new SmtpClient(textHost.Text)
                {
                    Port = int.Parse(textPort.Text),
                    EnableSsl = checkSsl.Checked,
                    Credentials = new NetworkCredential(textUser.Text, textPassword.Text)
                };


                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(textFrom.Text),
                    Subject = textSubject.Text,
                    Body = textMessage.Text
                };
                mailMessage.To.Add(textTo.Text);

                client.Send(mailMessage);
                MessageBox.Show("Email sent successfully.");

                client.Send(mailMessage);
                AppendLog("Email sent successfully.");
            }
            catch (Exception ex)
            {
                AppendLog("Failed to send email. " + ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.gBoxStatus.Controls.Clear();
        }

        private void checkBoxTls_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void gBoxConnection_Enter(object sender, EventArgs e)
        {

        }
        private void labelHost_Click(object sender, EventArgs e)
        {

        }
        private void smtpRelayForm_Load(object sender, EventArgs e)
        {

        }
    }
}
