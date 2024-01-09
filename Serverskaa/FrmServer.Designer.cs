namespace Serverskaa
{
    partial class FrmServer
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
            this.btnPokreniServer = new System.Windows.Forms.Button();
            this.btnUgasiServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPokreniIgru = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPokreniServer
            // 
            this.btnPokreniServer.Location = new System.Drawing.Point(31, 13);
            this.btnPokreniServer.Name = "btnPokreniServer";
            this.btnPokreniServer.Size = new System.Drawing.Size(66, 42);
            this.btnPokreniServer.TabIndex = 0;
            this.btnPokreniServer.Text = "Pokreni server";
            this.btnPokreniServer.UseVisualStyleBackColor = true;
            this.btnPokreniServer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUgasiServer
            // 
            this.btnUgasiServer.Location = new System.Drawing.Point(170, 13);
            this.btnUgasiServer.Name = "btnUgasiServer";
            this.btnUgasiServer.Size = new System.Drawing.Size(74, 39);
            this.btnUgasiServer.TabIndex = 1;
            this.btnUgasiServer.Text = "Ugasi server";
            this.btnUgasiServer.UseVisualStyleBackColor = true;
            this.btnUgasiServer.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "labl1";
            // 
            // btnPokreniIgru
            // 
            this.btnPokreniIgru.Location = new System.Drawing.Point(170, 58);
            this.btnPokreniIgru.Name = "btnPokreniIgru";
            this.btnPokreniIgru.Size = new System.Drawing.Size(74, 23);
            this.btnPokreniIgru.TabIndex = 3;
            this.btnPokreniIgru.Text = "Pokreni igru";
            this.btnPokreniIgru.UseVisualStyleBackColor = true;
            this.btnPokreniIgru.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 146);
            this.Controls.Add(this.btnPokreniIgru);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUgasiServer);
            this.Controls.Add(this.btnPokreniServer);
            this.Name = "FrmServer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPokreniServer;
        private System.Windows.Forms.Button btnUgasiServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPokreniIgru;
    }
}

