namespace WindowsFormsApplication10
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buton_Send = new System.Windows.Forms.Button();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_Subject = new System.Windows.Forms.TextBox();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.label_MailTo = new System.Windows.Forms.Label();
            this.label_MailSubject = new System.Windows.Forms.Label();
            this.label_MailMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buton_Send
            // 
            this.buton_Send.Location = new System.Drawing.Point(250, 391);
            this.buton_Send.Name = "buton_Send";
            this.buton_Send.Size = new System.Drawing.Size(75, 23);
            this.buton_Send.TabIndex = 0;
            this.buton_Send.Text = "button1";
            this.buton_Send.UseVisualStyleBackColor = true;
            this.buton_Send.Click += new System.EventHandler(this.buton_Send_Click);
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(225, 72);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(100, 20);
            this.textBox_Email.TabIndex = 1;
            // 
            // textBox_Subject
            // 
            this.textBox_Subject.Location = new System.Drawing.Point(225, 108);
            this.textBox_Subject.Name = "textBox_Subject";
            this.textBox_Subject.Size = new System.Drawing.Size(100, 20);
            this.textBox_Subject.TabIndex = 2;
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(225, 181);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.Size = new System.Drawing.Size(232, 160);
            this.textBox_Message.TabIndex = 3;
            // 
            // label_MailTo
            // 
            this.label_MailTo.AutoSize = true;
            this.label_MailTo.Location = new System.Drawing.Point(196, 75);
            this.label_MailTo.Name = "label_MailTo";
            this.label_MailTo.Size = new System.Drawing.Size(23, 13);
            this.label_MailTo.TabIndex = 4;
            this.label_MailTo.Text = "To:";
            // 
            // label_MailSubject
            // 
            this.label_MailSubject.AutoSize = true;
            this.label_MailSubject.Location = new System.Drawing.Point(173, 111);
            this.label_MailSubject.Name = "label_MailSubject";
            this.label_MailSubject.Size = new System.Drawing.Size(46, 13);
            this.label_MailSubject.TabIndex = 5;
            this.label_MailSubject.Text = "Subject:";
            // 
            // label_MailMessage
            // 
            this.label_MailMessage.AutoSize = true;
            this.label_MailMessage.Location = new System.Drawing.Point(166, 184);
            this.label_MailMessage.Name = "label_MailMessage";
            this.label_MailMessage.Size = new System.Drawing.Size(53, 13);
            this.label_MailMessage.TabIndex = 6;
            this.label_MailMessage.Text = "Message:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 535);
            this.Controls.Add(this.label_MailMessage);
            this.Controls.Add(this.label_MailSubject);
            this.Controls.Add(this.label_MailTo);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.textBox_Subject);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.buton_Send);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buton_Send;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.TextBox textBox_Subject;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Label label_MailTo;
        private System.Windows.Forms.Label label_MailSubject;
        private System.Windows.Forms.Label label_MailMessage;
    }
}

