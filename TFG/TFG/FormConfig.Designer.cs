
namespace TFG
{
    partial class FormConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btFuenteTabla = new System.Windows.Forms.Button();
            this.lbEjemploGrid = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.btColor = new System.Windows.Forms.Button();
            this.panelColor = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.process1 = new System.Diagnostics.Process();
            this.cbOcultar = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuración";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fuente de tabla:";
            // 
            // btFuenteTabla
            // 
            this.btFuenteTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFuenteTabla.Location = new System.Drawing.Point(166, 91);
            this.btFuenteTabla.Name = "btFuenteTabla";
            this.btFuenteTabla.Size = new System.Drawing.Size(102, 28);
            this.btFuenteTabla.TabIndex = 2;
            this.btFuenteTabla.Text = "Cambiar";
            this.btFuenteTabla.UseVisualStyleBackColor = true;
            this.btFuenteTabla.Click += new System.EventHandler(this.btFuenteTabla_Click);
            // 
            // lbEjemploGrid
            // 
            this.lbEjemploGrid.AutoSize = true;
            this.lbEjemploGrid.Location = new System.Drawing.Point(274, 95);
            this.lbEjemploGrid.Name = "lbEjemploGrid";
            this.lbEjemploGrid.Size = new System.Drawing.Size(128, 17);
            this.lbEjemploGrid.TabIndex = 3;
            this.lbEjemploGrid.Text = "Texto de ejemplo...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tu color:";
            // 
            // btColor
            // 
            this.btColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btColor.Location = new System.Drawing.Point(166, 159);
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(102, 28);
            this.btColor.TabIndex = 5;
            this.btColor.Text = "Cambiar";
            this.btColor.UseVisualStyleBackColor = true;
            this.btColor.Click += new System.EventHandler(this.btColor_Click);
            // 
            // panelColor
            // 
            this.panelColor.Location = new System.Drawing.Point(277, 138);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(112, 73);
            this.panelColor.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "¿Ocultar columnas?";
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // cbOcultar
            // 
            this.cbOcultar.AutoSize = true;
            this.cbOcultar.Location = new System.Drawing.Point(237, 239);
            this.cbOcultar.Name = "cbOcultar";
            this.cbOcultar.Size = new System.Drawing.Size(18, 17);
            this.cbOcultar.TabIndex = 8;
            this.cbOcultar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(686, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbOcultar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.btColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbEjemploGrid);
            this.Controls.Add(this.btFuenteTabla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btFuenteTabla;
        private System.Windows.Forms.Label lbEjemploGrid;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btColor;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.Label label4;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.CheckBox cbOcultar;
        private System.Windows.Forms.Button button1;
    }
}