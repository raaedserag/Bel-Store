﻿namespace Belal.Presentation_Layer.Mains
{
    partial class العملاء
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DASHBOARDPANEL = new System.Windows.Forms.Panel();
            this.CATEGORIESBUTTON = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PRODUCTSBUTTON = new System.Windows.Forms.Button();
            this.CLIENTSBUTTON = new System.Windows.Forms.Button();
            this.RECEIPTSBUTTON = new System.Windows.Forms.Button();
            this.DASHBOARDPANEL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(596, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(274, 143);
            this.button2.TabIndex = 14;
            this.button2.Text = "دفع نقدي";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(144, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(274, 143);
            this.button1.TabIndex = 13;
            this.button1.Text = "إدارة حسابات العملاء";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DASHBOARDPANEL
            // 
            this.DASHBOARDPANEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DASHBOARDPANEL.Controls.Add(this.CATEGORIESBUTTON);
            this.DASHBOARDPANEL.Controls.Add(this.pictureBox1);
            this.DASHBOARDPANEL.Controls.Add(this.PRODUCTSBUTTON);
            this.DASHBOARDPANEL.Controls.Add(this.CLIENTSBUTTON);
            this.DASHBOARDPANEL.Controls.Add(this.RECEIPTSBUTTON);
            this.DASHBOARDPANEL.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DASHBOARDPANEL.Location = new System.Drawing.Point(172, 27);
            this.DASHBOARDPANEL.Name = "DASHBOARDPANEL";
            this.DASHBOARDPANEL.Size = new System.Drawing.Size(612, 36);
            this.DASHBOARDPANEL.TabIndex = 12;
            // 
            // CATEGORIESBUTTON
            // 
            this.CATEGORIESBUTTON.Location = new System.Drawing.Point(0, 0);
            this.CATEGORIESBUTTON.Name = "CATEGORIESBUTTON";
            this.CATEGORIESBUTTON.Size = new System.Drawing.Size(140, 36);
            this.CATEGORIESBUTTON.TabIndex = 8;
            this.CATEGORIESBUTTON.Text = "الأصناف";
            this.CATEGORIESBUTTON.UseVisualStyleBackColor = true;
            this.CATEGORIESBUTTON.Click += new System.EventHandler(this.CATEGORIESBUTTON_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(620, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 36);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // PRODUCTSBUTTON
            // 
            this.PRODUCTSBUTTON.Location = new System.Drawing.Point(462, -1);
            this.PRODUCTSBUTTON.Name = "PRODUCTSBUTTON";
            this.PRODUCTSBUTTON.Size = new System.Drawing.Size(135, 36);
            this.PRODUCTSBUTTON.TabIndex = 6;
            this.PRODUCTSBUTTON.Text = "المنتجات";
            this.PRODUCTSBUTTON.UseVisualStyleBackColor = true;
            this.PRODUCTSBUTTON.Click += new System.EventHandler(this.PRODUCTSBUTTON_Click);
            // 
            // CLIENTSBUTTON
            // 
            this.CLIENTSBUTTON.Location = new System.Drawing.Point(157, 0);
            this.CLIENTSBUTTON.Name = "CLIENTSBUTTON";
            this.CLIENTSBUTTON.Size = new System.Drawing.Size(140, 36);
            this.CLIENTSBUTTON.TabIndex = 4;
            this.CLIENTSBUTTON.Text = "العملاء";
            this.CLIENTSBUTTON.UseVisualStyleBackColor = true;
            this.CLIENTSBUTTON.Click += new System.EventHandler(this.CLIENTSBUTTON_Click);
            // 
            // RECEIPTSBUTTON
            // 
            this.RECEIPTSBUTTON.Location = new System.Drawing.Point(316, 0);
            this.RECEIPTSBUTTON.Name = "RECEIPTSBUTTON";
            this.RECEIPTSBUTTON.Size = new System.Drawing.Size(140, 36);
            this.RECEIPTSBUTTON.TabIndex = 5;
            this.RECEIPTSBUTTON.Text = "فواتير";
            this.RECEIPTSBUTTON.UseVisualStyleBackColor = true;
            this.RECEIPTSBUTTON.Click += new System.EventHandler(this.RECEIPTSBUTTON_Click);
            // 
            // العملاء
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(948, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DASHBOARDPANEL);
            this.Name = "العملاء";
            this.Text = "العملاء";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.العملاء_FormClosing);
            this.Load += new System.EventHandler(this.العملاء_Load);
            this.DASHBOARDPANEL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel DASHBOARDPANEL;
        private System.Windows.Forms.Button CATEGORIESBUTTON;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button PRODUCTSBUTTON;
        private System.Windows.Forms.Button CLIENTSBUTTON;
        private System.Windows.Forms.Button RECEIPTSBUTTON;
    }
}