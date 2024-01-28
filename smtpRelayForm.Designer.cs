using System;

namespace smtpRelay_Admin
{
    partial class SmtpRelayForm
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void AppendLog(string message)
        {
            if (this.textBoxLog.InvokeRequired)
            {
                this.textBoxLog.Invoke(new Action<string>(AppendLog), new object[] { message });
            }
            else
            {
                // Append new log message and ensure it's visible
                this.textBoxLog.AppendText(message + Environment.NewLine);
                this.textBoxLog.ScrollToCaret();
            }
        }
        private bool IsValidEmail(string email)
        {
            return email.Contains("@");
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmtpRelayForm));
            this.infoBoxConnection = new System.Windows.Forms.GroupBox();
            this.checkBoxAuth = new System.Windows.Forms.CheckBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.textHost = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.textFrom = new System.Windows.Forms.TextBox();
            this.textTo = new System.Windows.Forms.TextBox();
            this.textSubject = new System.Windows.Forms.TextBox();
            this.gBoxEmailConfiguration = new System.Windows.Forms.GroupBox();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gBoxStatus = new System.Windows.Forms.GroupBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.infoBoxConnection.SuspendLayout();
            this.gBoxEmailConfiguration.SuspendLayout();
            this.gBoxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoBoxConnection
            // 
            this.infoBoxConnection.Controls.Add(this.checkBoxAuth);
            this.infoBoxConnection.Controls.Add(this.textPassword);
            this.infoBoxConnection.Controls.Add(this.textUser);
            this.infoBoxConnection.Controls.Add(this.textHost);
            this.infoBoxConnection.Controls.Add(this.labelPassword);
            this.infoBoxConnection.Controls.Add(this.labelUser);
            this.infoBoxConnection.Controls.Add(this.labelHost);
            this.infoBoxConnection.Controls.Add(this.textPort);
            this.infoBoxConnection.Location = new System.Drawing.Point(16, 26);
            this.infoBoxConnection.Name = "infoBoxConnection";
            this.infoBoxConnection.Size = new System.Drawing.Size(751, 259);
            this.infoBoxConnection.TabIndex = 0;
            this.infoBoxConnection.TabStop = false;
            this.infoBoxConnection.Text = "Connection Configuration";
            this.infoBoxConnection.Enter += new System.EventHandler(this.InfoBoxConnection_Enter);
            // 
            // checkBoxAuth
            // 
            this.checkBoxAuth.AutoSize = true;
            this.checkBoxAuth.Location = new System.Drawing.Point(621, 111);
            this.checkBoxAuth.Name = "checkBoxAuth";
            this.checkBoxAuth.Size = new System.Drawing.Size(101, 29);
            this.checkBoxAuth.TabIndex = 9;
            this.checkBoxAuth.Text = "AUTH";
            this.checkBoxAuth.UseVisualStyleBackColor = true;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(152, 165);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.ReadOnly = true;
            this.textPassword.Size = new System.Drawing.Size(447, 31);
            this.textPassword.TabIndex = 5;
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(152, 109);
            this.textUser.Name = "textUser";
            this.textUser.ReadOnly = true;
            this.textUser.Size = new System.Drawing.Size(447, 31);
            this.textUser.TabIndex = 1;
            // 
            // textHost
            // 
            this.textHost.Location = new System.Drawing.Point(152, 51);
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(447, 31);
            this.textHost.TabIndex = 0;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(23, 168);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(106, 25);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Password";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(23, 115);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(57, 25);
            this.labelUser.TabIndex = 7;
            this.labelUser.Text = "User";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(23, 54);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(56, 25);
            this.labelHost.TabIndex = 6;
            this.labelHost.Text = "Host";
            this.labelHost.Click += new System.EventHandler(this.LabelHost_Click);
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(623, 51);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(99, 31);
            this.textPort.TabIndex = 2;
            // 
            // textFrom
            // 
            this.textFrom.Location = new System.Drawing.Point(158, 51);
            this.textFrom.Name = "textFrom";
            this.textFrom.Size = new System.Drawing.Size(564, 31);
            this.textFrom.TabIndex = 0;
            // 
            // textTo
            // 
            this.textTo.Location = new System.Drawing.Point(158, 109);
            this.textTo.Name = "textTo";
            this.textTo.Size = new System.Drawing.Size(562, 31);
            this.textTo.TabIndex = 1;
            // 
            // textSubject
            // 
            this.textSubject.Location = new System.Drawing.Point(158, 165);
            this.textSubject.Name = "textSubject";
            this.textSubject.Size = new System.Drawing.Size(564, 31);
            this.textSubject.TabIndex = 5;
            // 
            // gBoxEmailConfiguration
            // 
            this.gBoxEmailConfiguration.Controls.Add(this.textTo);
            this.gBoxEmailConfiguration.Controls.Add(this.textFrom);
            this.gBoxEmailConfiguration.Controls.Add(this.textSubject);
            this.gBoxEmailConfiguration.Controls.Add(this.textMessage);
            this.gBoxEmailConfiguration.Controls.Add(this.label7);
            this.gBoxEmailConfiguration.Controls.Add(this.label6);
            this.gBoxEmailConfiguration.Controls.Add(this.label5);
            this.gBoxEmailConfiguration.Controls.Add(this.label4);
            this.gBoxEmailConfiguration.Location = new System.Drawing.Point(16, 311);
            this.gBoxEmailConfiguration.Name = "gBoxEmailConfiguration";
            this.gBoxEmailConfiguration.Size = new System.Drawing.Size(751, 459);
            this.gBoxEmailConfiguration.TabIndex = 6;
            this.gBoxEmailConfiguration.TabStop = false;
            this.gBoxEmailConfiguration.Text = "Email Configuration";
            // 
            // textMessage
            // 
            this.textMessage.Location = new System.Drawing.Point(158, 227);
            this.textMessage.Multiline = true;
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(564, 177);
            this.textMessage.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Message";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Subject";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "From";
            // 
            // gBoxStatus
            // 
            this.gBoxStatus.Controls.Add(this.textBoxLog);
            this.gBoxStatus.Location = new System.Drawing.Point(797, 26);
            this.gBoxStatus.Name = "gBoxStatus";
            this.gBoxStatus.Size = new System.Drawing.Size(985, 798);
            this.gBoxStatus.TabIndex = 7;
            this.gBoxStatus.TabStop = false;
            this.gBoxStatus.Text = "Status Information";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(6, 38);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(972, 752);
            this.textBoxLog.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSend.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSend.Location = new System.Drawing.Point(590, 778);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(177, 46);
            this.buttonSend.TabIndex = 10;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = false;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonClear.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(208, 778);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(177, 46);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "Clear Log";
            this.buttonClear.UseVisualStyleBackColor = false;
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonReset.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Location = new System.Drawing.Point(16, 778);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(177, 46);
            this.buttonReset.TabIndex = 12;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            // 
            // SmtpRelayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1791, 848);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.gBoxStatus);
            this.Controls.Add(this.gBoxEmailConfiguration);
            this.Controls.Add(this.infoBoxConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SmtpRelayForm";
            this.Text = "smtpRelay Admin";
            this.Load += new System.EventHandler(this.SmtpRelayForm_Load);
            this.infoBoxConnection.ResumeLayout(false);
            this.infoBoxConnection.PerformLayout();
            this.gBoxEmailConfiguration.ResumeLayout(false);
            this.gBoxEmailConfiguration.PerformLayout();
            this.gBoxStatus.ResumeLayout(false);
            this.gBoxStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox infoBoxConnection;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TextBox textHost;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textFrom;
        private System.Windows.Forms.TextBox textTo;
        private System.Windows.Forms.TextBox textSubject;
        private System.Windows.Forms.GroupBox gBoxEmailConfiguration;
        private System.Windows.Forms.GroupBox gBoxStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.CheckBox checkBoxAuth;
        private System.Windows.Forms.Button buttonReset;
    }
}

