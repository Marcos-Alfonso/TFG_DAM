
namespace TFG
{
    partial class formCalendario
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
            this.calendarCitas = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // calendarCitas
            // 
            this.calendarCitas.BoldedDates = new System.DateTime[] {
        new System.DateTime(2023, 5, 19, 0, 0, 0, 0)};
            this.calendarCitas.CalendarDimensions = new System.Drawing.Size(3, 2);
            this.calendarCitas.Dock = System.Windows.Forms.DockStyle.Right;
            this.calendarCitas.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.calendarCitas.Location = new System.Drawing.Point(132, 0);
            this.calendarCitas.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.calendarCitas.Name = "calendarCitas";
            this.calendarCitas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.calendarCitas.TabIndex = 0;
            // 
            // formCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.calendarCitas);
            this.Name = "formCalendario";
            this.Text = "Citas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendarCitas;
    }
}