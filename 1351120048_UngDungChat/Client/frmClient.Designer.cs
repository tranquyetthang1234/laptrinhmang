namespace Client
{
    partial class frmClient
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
            this.txtTyping = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtShow = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioSendto1 = new System.Windows.Forms.RadioButton();
            this.radioSendAll = new System.Windows.Forms.RadioButton();
            this.listboxClient = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTyping
            // 
            this.txtTyping.Enabled = false;
            this.txtTyping.Location = new System.Drawing.Point(12, 362);
            this.txtTyping.Name = "txtTyping";
            this.txtTyping.Size = new System.Drawing.Size(358, 20);
            this.txtTyping.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(376, 360);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtShow
            // 
            this.txtShow.Location = new System.Drawing.Point(12, 12);
            this.txtShow.Multiline = true;
            this.txtShow.Name = "txtShow";
            this.txtShow.ReadOnly = true;
            this.txtShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShow.Size = new System.Drawing.Size(358, 344);
            this.txtShow.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(379, 28);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(226, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(397, 54);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            // 
            // radioSendto1
            // 
            this.radioSendto1.AutoSize = true;
            this.radioSendto1.Location = new System.Drawing.Point(379, 337);
            this.radioSendto1.Name = "radioSendto1";
            this.radioSendto1.Size = new System.Drawing.Size(128, 17);
            this.radioSendto1.TabIndex = 7;
            this.radioSendto1.TabStop = true;
            this.radioSendto1.Text = "Send to selected user";
            this.radioSendto1.UseVisualStyleBackColor = true;
            // 
            // radioSendAll
            // 
            this.radioSendAll.AutoSize = true;
            this.radioSendAll.Checked = true;
            this.radioSendAll.Location = new System.Drawing.Point(379, 314);
            this.radioSendAll.Name = "radioSendAll";
            this.radioSendAll.Size = new System.Drawing.Size(78, 17);
            this.radioSendAll.TabIndex = 8;
            this.radioSendAll.TabStop = true;
            this.radioSendAll.Text = "Send to all ";
            this.radioSendAll.UseVisualStyleBackColor = true;
            // 
            // listboxClient
            // 
            this.listboxClient.FormattingEnabled = true;
            this.listboxClient.Location = new System.Drawing.Point(379, 109);
            this.listboxClient.Name = "listboxClient";
            this.listboxClient.Size = new System.Drawing.Size(226, 199);
            this.listboxClient.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(376, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Online";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(516, 54);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 11;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(530, 311);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmClient
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 401);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listboxClient);
            this.Controls.Add(this.radioSendAll);
            this.Controls.Add(this.radioSendto1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtShow);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtTyping);
            this.Name = "frmClient";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClient_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTyping;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioSendto1;
        private System.Windows.Forms.RadioButton radioSendAll;
        private System.Windows.Forms.ListBox listboxClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnRefresh;
    }
}

