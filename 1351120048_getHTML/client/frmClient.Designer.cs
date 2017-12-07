namespace client
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
            this.components = new System.ComponentModel.Container();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.getData = new System.Windows.Forms.Button();
            this.txtHTML = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCity = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(53, 12);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(328, 20);
            this.txtURL.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL";
            // 
            // getData
            // 
            this.getData.Location = new System.Drawing.Point(387, 10);
            this.getData.Name = "getData";
            this.getData.Size = new System.Drawing.Size(75, 23);
            this.getData.TabIndex = 3;
            this.getData.Text = "Get Data";
            this.getData.UseVisualStyleBackColor = true;
            this.getData.Click += new System.EventHandler(this.getData_Click);
            // 
            // txtHTML
            // 
            this.txtHTML.Location = new System.Drawing.Point(12, 74);
            this.txtHTML.Multiline = true;
            this.txtHTML.Name = "txtHTML";
            this.txtHTML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHTML.Size = new System.Drawing.Size(513, 336);
            this.txtHTML.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "City";
            // 
            // cbCity
            // 
            this.cbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCity.FormattingEnabled = true;
            this.cbCity.Items.AddRange(new object[] {
            "Select the city you want..."});
            this.cbCity.Location = new System.Drawing.Point(53, 42);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(328, 21);
            this.cbCity.TabIndex = 6;
            this.cbCity.SelectedIndexChanged += new System.EventHandler(this.cbCity_SelectedIndexChanged);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 422);
            this.Controls.Add(this.cbCity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHTML);
            this.Controls.Add(this.getData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtURL);
            this.Name = "frmClient";
            this.Text = "HTML Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getData;
        private System.Windows.Forms.TextBox txtHTML;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCity;
    }
}

