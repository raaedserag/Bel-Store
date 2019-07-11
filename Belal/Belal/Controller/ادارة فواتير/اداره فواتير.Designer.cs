namespace Belal.Controller.ادارة_فواتير
{
    partial class اداره_فواتير
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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.CLIENTSBUTTON = new System.Windows.Forms.Button();
            this.RECEIPTSBUTTON = new System.Windows.Forms.Button();
            this.PRODUCTSBUTTON = new System.Windows.Forms.Button();
            this.DASHBOARDPANEL = new System.Windows.Forms.Panel();
            this.CATEGORIESBUTTON = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DASHBOARDPANEL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(203, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(349, 74);
            this.button1.TabIndex = 0;
            this.button1.Text = "انشاء فاتورة بيع / مرتجع";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(203, 251);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(349, 73);
            this.button3.TabIndex = 2;
            this.button3.Text = "عرض فواتير سابقة";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CLIENTSBUTTON
            // 
            this.CLIENTSBUTTON.Location = new System.Drawing.Point(157, 0);
            this.CLIENTSBUTTON.Name = "CLIENTSBUTTON";
            this.CLIENTSBUTTON.Size = new System.Drawing.Size(140, 36);
            this.CLIENTSBUTTON.TabIndex = 4;
            this.CLIENTSBUTTON.Text = "العملاء";
            this.CLIENTSBUTTON.UseVisualStyleBackColor = true;
            this.CLIENTSBUTTON.Click += new System.EventHandler(this.PRODUCTSBUTTON_Click);
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
            // PRODUCTSBUTTON
            // 
            this.PRODUCTSBUTTON.Location = new System.Drawing.Point(474, 0);
            this.PRODUCTSBUTTON.Name = "PRODUCTSBUTTON";
            this.PRODUCTSBUTTON.Size = new System.Drawing.Size(140, 36);
            this.PRODUCTSBUTTON.TabIndex = 6;
            this.PRODUCTSBUTTON.Text = "المنتحات";
            this.PRODUCTSBUTTON.UseVisualStyleBackColor = true;
            this.PRODUCTSBUTTON.Click += new System.EventHandler(this.PRODUCTSBUTTON_Click_1);
            // 
            // DASHBOARDPANEL
            // 
            this.DASHBOARDPANEL.Controls.Add(this.CATEGORIESBUTTON);
            this.DASHBOARDPANEL.Controls.Add(this.pictureBox1);
            this.DASHBOARDPANEL.Controls.Add(this.PRODUCTSBUTTON);
            this.DASHBOARDPANEL.Controls.Add(this.CLIENTSBUTTON);
            this.DASHBOARDPANEL.Controls.Add(this.RECEIPTSBUTTON);
            this.DASHBOARDPANEL.Location = new System.Drawing.Point(-1, -1);
            this.DASHBOARDPANEL.Name = "DASHBOARDPANEL";
            this.DASHBOARDPANEL.Size = new System.Drawing.Size(800, 36);
            this.DASHBOARDPANEL.TabIndex = 7;
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
            this.pictureBox1.Location = new System.Drawing.Point(637, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 36);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // اداره_فواتير
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DASHBOARDPANEL);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(820, 493);
            this.MinimumSize = new System.Drawing.Size(20, 493);
            this.Name = "اداره_فواتير";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اداره_فواتير";
            this.Load += new System.EventHandler(this.اداره_فواتير_Load);
            this.DASHBOARDPANEL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button CLIENTSBUTTON;
        private System.Windows.Forms.Button RECEIPTSBUTTON;
        private System.Windows.Forms.Button PRODUCTSBUTTON;
        private System.Windows.Forms.Panel DASHBOARDPANEL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CATEGORIESBUTTON;
    }
}