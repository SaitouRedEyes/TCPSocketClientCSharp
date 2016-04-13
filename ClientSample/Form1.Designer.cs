using System.Windows.Forms;

namespace ClientSample
{
    partial class Client
    {
        private TextBox send;
        private TextBox show;

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
            this.send = new System.Windows.Forms.TextBox();
            this.show = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(8, 12);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(264, 20);
            this.send.TabIndex = 0;
            this.send.Text = "Send to Server here:";
            this.send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.send_KeyDown);
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(8, 40);
            this.show.Multiline = true;
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(264, 218);
            this.show.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Escreva \"FIM\" para se desconectar do servidor";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 301);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.send);
            this.Controls.Add(this.show);
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
    }
}

