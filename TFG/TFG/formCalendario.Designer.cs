
namespace TFG
{
    partial class FormCalendario
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
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Texto de ejemplossssssssssssss"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("eeeeeeeee");
            this.calendarCitas = new System.Windows.Forms.MonthCalendar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // calendarCitas
            // 
            this.calendarCitas.CalendarDimensions = new System.Drawing.Size(3, 1);
            this.calendarCitas.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.calendarCitas.Location = new System.Drawing.Point(456, 18);
            this.calendarCitas.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.calendarCitas.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.calendarCitas.Name = "calendarCitas";
            this.calendarCitas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.calendarCitas.ShowToday = false;
            this.calendarCitas.ShowTodayCircle = false;
            this.calendarCitas.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            listViewItem7.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem7,
            listViewItem8});
            this.listView1.Location = new System.Drawing.Point(12, 18);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(432, 587);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // formCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 622);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.calendarCitas);
            this.Name = "formCalendario";
            this.Text = "Citas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendarCitas;
        private System.Windows.Forms.ListView listView1;
    }
}