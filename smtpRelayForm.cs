using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace smtpRelay_Admin
{
    public partial class SmtpRelayForm : Form
    {

        public SmtpRelayForm()
        {
            InitializeComponent();
            this.checkBoxAuth.Click += new EventHandler(CheckBoxAuth_CheckedChanged);
            this.buttonSend.Click += new EventHandler(ButtonSend_Click);
            this.buttonClear.Click += new EventHandler(ButtonClear_Click);
            this.buttonReset.Click += new EventHandler(ButtonReset_Click);

        }
        private void ButtonSend_Click(object sender, EventArgs e)
        {
            SaveLastInput();
            string smtpServer = textHost.Text;
            int port = int.Parse(textPort.Text);
            string username = textUser.Text;
            string password = textPassword.Text;
            bool useAuth = checkBoxAuth.Checked;

            if (!TextBoxValidation(out bool isValidFrom, out bool isValidTo))
            {
                // Fields are not filled or contain invalid email addresses, display appropriate messages
                string errorMessage = "Please fill in the following fields:\n";
                if (string.IsNullOrWhiteSpace(textHost.Text)) errorMessage += "- Host\n";
                if (string.IsNullOrWhiteSpace(textPort.Text)) errorMessage += "- Port\n";

                if (!isValidFrom) errorMessage += "- Invalid 'From' email address\n";
                if (!isValidTo) errorMessage += "- Invalid 'To' email address\n";

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AppendLog("Starting mailing process...");
            if (useAuth)
            {
                try
                {
                    AppendLog($"Connecting to Server {smtpServer} over Port {port}...");
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    using (var client = new TcpClient(smtpServer, port))
                    using (var stream = client.GetStream())
                    {
                        AppendLog("Connection successful. Initialize StartTLS...");
                        using (var reader = new StreamReader(stream, Encoding.ASCII))
                        using (var writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true })
                        {
                            // Send EHLO and read all responses
                            AppendLog("Sending EHLO...");
                            writer.WriteLine("EHLO " + smtpServer);
                            ReadAllResponses(reader);

                            // Start TLS
                            AppendLog("Sending STARTTLS command...");
                            writer.WriteLine("STARTTLS");
                            ValidateServerResponse(reader, "220");

                            AppendLog("Initialize secure SSL/TLS connection...");
                            using (var sslStream = new SslStream(stream, false,
                                new RemoteCertificateValidationCallback((s, certificate, chain, sslPolicyErrors) => sslPolicyErrors == SslPolicyErrors.None)))
                            {
                                sslStream.AuthenticateAsClient(smtpServer, new X509CertificateCollection(), SslProtocols.Tls12, false);
                                AppendLog("SSL/TLS authentication successful.");

                                using (var secureWriter = new StreamWriter(sslStream, Encoding.ASCII) { AutoFlush = true })
                                using (var secureReader = new StreamReader(sslStream, Encoding.ASCII))
                                {
                                    AppendLog("Send EHLO to STARTTLS...");
                                    secureWriter.WriteLine("EHLO " + smtpServer);
                                    AppendLog(secureReader.ReadLine());

                                    AppendLog("Start AUTH LOGIN Process...");
                                    secureWriter.WriteLine("AUTH LOGIN");
                                    AppendLog(secureReader.ReadLine());

                                    AppendLog("Send Username...");
                                    secureWriter.WriteLine(Convert.ToBase64String(Encoding.ASCII.GetBytes(username)));
                                    AppendLog(secureReader.ReadLine());

                                    AppendLog("Send Password...");
                                    secureWriter.WriteLine(Convert.ToBase64String(Encoding.ASCII.GetBytes(password)));
                                    AppendLog(secureReader.ReadLine());

                                    // EHLO after STARTTLS
                                    AppendLog("Sending EHLO after STARTTLS...");
                                    secureWriter.WriteLine("EHLO " + smtpServer);
                                    ReadAllResponses(secureReader);

                                    // MAIL FROM
                                    AppendLog("Sending MAIL FROM...");
                                    secureWriter.WriteLine("MAIL FROM:<" + textFrom.Text + ">");
                                    ValidateServerResponse(secureReader, "250");

                                    // RCPT TO
                                    AppendLog("Sending RCPT TO...");
                                    secureWriter.WriteLine("RCPT TO:<" + textTo.Text + ">");
                                    ValidateServerResponse(secureReader, "250");

                                    // DATA
                                    AppendLog("Sending DATA...");
                                    secureWriter.WriteLine("DATA");
                                    ValidateServerResponse(secureReader, "354");

                                    // Send Message
                                    AppendLog("Sending the message...");
                                    secureWriter.WriteLine("From: " + textFrom.Text);
                                    secureWriter.WriteLine("To: " + textTo.Text);
                                    secureWriter.WriteLine("Subject: " + textSubject.Text);
                                    secureWriter.WriteLine();
                                    secureWriter.WriteLine(textMessage.Text);
                                    secureWriter.WriteLine(".");
                                    ValidateServerResponse(secureReader, "250");

                                    // QUIT
                                    AppendLog("Sending QUIT...");
                                    secureWriter.WriteLine("QUIT");
                                    ValidateServerResponse(secureReader, "221");
                                }
                            }
                        }
                    }
                    AppendLog("Email was sent successfully.");
                }
                catch (Exception ex)
                {
                    AppendLog("Error while sending E-Mail: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    AppendLog($"Connecting to server {smtpServer} via port {port}...");

                    using (var client = new TcpClient(smtpServer, port))
                    using (var stream = client.GetStream())
                    {
                        AppendLog("Connection successful.");
                        using (var reader = new StreamReader(stream, Encoding.ASCII))
                        using (var writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true })
                        {
                            // Send EHLO and read all responses
                            AppendLog("Sending EHLO...");
                            writer.WriteLine("EHLO " + smtpServer);
                            ReadAllResponses(reader);

                            // MAIL FROM
                            AppendLog("Sending MAIL FROM...");
                            writer.WriteLine("MAIL FROM:<" + textFrom.Text + ">");
                            ValidateServerResponse(reader, "250");

                            // RCPT TO
                            AppendLog("Sending RCPT TO...");
                            writer.WriteLine("RCPT TO:<" + textTo.Text + ">");
                            ValidateServerResponse(reader, "250");

                            // DATA
                            AppendLog("Sending DATA...");
                            writer.WriteLine("DATA");
                            ValidateServerResponse(reader, "354");

                            // Send Message
                            AppendLog("Sending the message...");
                            writer.WriteLine("From: " + textFrom.Text);
                            writer.WriteLine("To: " + textTo.Text);
                            writer.WriteLine("Subject: " + textSubject.Text);
                            writer.WriteLine();
                            writer.WriteLine(textMessage.Text);
                            writer.WriteLine(".");
                            ValidateServerResponse(reader, "250");

                            // QUIT
                            AppendLog("Sending QUIT...");
                            writer.WriteLine("QUIT");
                            ValidateServerResponse(reader, "221");
                        }
                    }


                    AppendLog("Email was successfully sent.");
                }
                catch (Exception ex)
                {
                    AppendLog("Error sending the email: " + ex.Message);
                }
            }
        }
        void ReadAllResponses(StreamReader reader)
        {
            string line;
            do
            {
                line = reader.ReadLine();
                AppendLog(line);
            } while (line != null && !line.StartsWith("250 "));
        }
        void ValidateServerResponse(StreamReader reader, string expectedCode)
        {
            string response = reader.ReadLine();
            AppendLog(response);
            if (!response.StartsWith(expectedCode))
            {
                throw new InvalidOperationException($"Server response did not start with expected code {expectedCode}: {response}");
            }
        }
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            this.textBoxLog.Text = string.Empty;
        }
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            textHost.Clear();
            textPort.Text = "587";
            textUser.Clear();
            textPassword.Clear();
            textFrom.Clear();
            textTo.Clear();
            textSubject.Clear();
            textMessage.Clear();
            textBoxLog.Clear();
            checkBoxAuth.Checked = false;
        }
        private void CheckBoxAuth_CheckedChanged(object sender, EventArgs e)
        {
            textUser.ReadOnly = !checkBoxAuth.Checked;
            textPassword.ReadOnly = !checkBoxAuth.Checked;
        }
        private void InfoBoxConnection_Enter(object sender, EventArgs e)
        {

        }
        private void LabelHost_Click(object sender, EventArgs e)
        {

        }
        private void SmtpRelayForm_Load(object sender, EventArgs e)
        {
            LoadLastInput();
        }
        private void SaveLastInput()
        {
            Properties.Settings.Default.LastSmtpServer = textHost.Text;
            Properties.Settings.Default.LastUsername = textUser.Text;
            Properties.Settings.Default.LastFrom = textFrom.Text;
            Properties.Settings.Default.LastTo = textTo.Text;
            Properties.Settings.Default.LastSubject = textSubject.Text;
            Properties.Settings.Default.Save();
        }
        private void LoadLastInput()
        {
            textHost.Text = Properties.Settings.Default.LastSmtpServer;
            textPort.Text = Properties.Settings.Default.LastPort.ToString();
            textUser.Text = Properties.Settings.Default.LastUsername;
            textFrom.Text = Properties.Settings.Default.LastFrom.ToString();
            textTo.Text = Properties.Settings.Default.LastTo.ToString();
            textSubject.Text = Properties.Settings.Default.LastSubject;
        }
        private bool TextBoxValidation(out bool isValidFrom, out bool isValidTo)
        {
            bool isFromValid = !string.IsNullOrWhiteSpace(textFrom.Text);
            bool isToValid = !string.IsNullOrWhiteSpace(textTo.Text);

            bool isHostFilled = !string.IsNullOrWhiteSpace(textHost.Text);
            bool isPortFilled = !string.IsNullOrWhiteSpace(textPort.Text);

            isValidFrom = true;
            isValidTo = true;


            if (isFromValid)
            {
                try
                {
                    MailAddress toAddress = new MailAddress(textFrom.Text);
                    isFromValid = true;
                }
                catch (FormatException)
                {
                    // Invalid "To" email address
                    isValidFrom = false;
                }
            }
            else
            {
                // Handle the case where 'To' email address is empty
                isValidFrom = false;
            }
            if (isToValid)
            {
                try
                {
                    MailAddress toAddress = new MailAddress(textTo.Text);
                    isToValid = true;
                }
                catch (FormatException)
                {
                    // Invalid "To" email address
                    isValidTo = false;
                }
            }
            else
            {
                // Handle the case where 'To' email address is empty
                isValidTo = false;
            }

            return isHostFilled && isPortFilled && isFromValid && isToValid;
        }
    }
}
