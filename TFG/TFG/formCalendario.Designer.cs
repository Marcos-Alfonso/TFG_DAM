
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalendario));
            this.listView1 = new System.Windows.Forms.ListView();
            this.txNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDni = new System.Windows.Forms.Label();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.dtHora = new System.Windows.Forms.DateTimePicker();
            this.lbHora = new System.Windows.Forms.Label();
            this.lbDurecion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtDescripcion = new System.Windows.Forms.RichTextBox();
            this.tbDuracion = new System.Windows.Forms.NumericUpDown();
            this.btAceptar = new System.Windows.Forms.Button();
            this.calendar1 = new Calendar.NET.Calendar();
            this.pdMod = new System.Windows.Forms.PictureBox();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbDuracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdMod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(439, 480);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.otroSeleccionado);
            // 
            // txNombre
            // 
            this.txNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txNombre.Location = new System.Drawing.Point(457, 82);
            this.txNombre.Name = "txNombre";
            this.txNombre.Size = new System.Drawing.Size(262, 27);
            this.txNombre.TabIndex = 1;
            this.txNombre.TextChanged += new System.EventHandler(this.cambioNombre);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(458, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente";
            // 
            // lbDni
            // 
            this.lbDni.AutoSize = true;
            this.lbDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDni.Location = new System.Drawing.Point(721, 59);
            this.lbDni.Name = "lbDni";
            this.lbDni.Size = new System.Drawing.Size(38, 20);
            this.lbDni.TabIndex = 3;
            this.lbDni.Text = "DNI";
            // 
            // tbDni
            // 
            this.tbDni.Enabled = false;
            this.tbDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDni.Location = new System.Drawing.Point(725, 80);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(118, 27);
            this.tbDni.TabIndex = 4;
            this.tbDni.TabStop = false;
            // 
            // cbUsuario
            // 
            this.cbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(460, 132);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(146, 28);
            this.cbUsuario.TabIndex = 5;
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.Location = new System.Drawing.Point(457, 112);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(67, 20);
            this.lbUsuario.TabIndex = 6;
            this.lbUsuario.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(458, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fecha";
            // 
            // dtFecha
            // 
            this.dtFecha.CustomFormat = "dd/MM/yyyy  hh:mm";
            this.dtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(460, 186);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(146, 27);
            this.dtFecha.TabIndex = 9;
            // 
            // dtHora
            // 
            this.dtHora.CustomFormat = "HH:mm";
            this.dtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHora.Location = new System.Drawing.Point(612, 186);
            this.dtHora.Name = "dtHora";
            this.dtHora.ShowUpDown = true;
            this.dtHora.Size = new System.Drawing.Size(107, 27);
            this.dtHora.TabIndex = 11;
            this.dtHora.Value = new System.DateTime(2023, 5, 27, 0, 0, 0, 0);
            // 
            // lbHora
            // 
            this.lbHora.AutoSize = true;
            this.lbHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHora.Location = new System.Drawing.Point(610, 163);
            this.lbHora.Name = "lbHora";
            this.lbHora.Size = new System.Drawing.Size(46, 20);
            this.lbHora.TabIndex = 10;
            this.lbHora.Text = "Hora";
            // 
            // lbDurecion
            // 
            this.lbDurecion.AutoSize = true;
            this.lbDurecion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDurecion.Location = new System.Drawing.Point(721, 163);
            this.lbDurecion.Name = "lbDurecion";
            this.lbDurecion.Size = new System.Drawing.Size(77, 20);
            this.lbDurecion.TabIndex = 13;
            this.lbDurecion.Text = "Duración";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(812, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "min";
            // 
            // rtDescripcion
            // 
            this.rtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtDescripcion.Location = new System.Drawing.Point(460, 219);
            this.rtDescripcion.Name = "rtDescripcion";
            this.rtDescripcion.Size = new System.Drawing.Size(502, 273);
            this.rtDescripcion.TabIndex = 15;
            this.rtDescripcion.Text = "";
            // 
            // tbDuracion
            // 
            this.tbDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDuracion.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.tbDuracion.Location = new System.Drawing.Point(725, 186);
            this.tbDuracion.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.tbDuracion.Name = "tbDuracion";
            this.tbDuracion.Size = new System.Drawing.Size(81, 27);
            this.tbDuracion.TabIndex = 16;
            // 
            // btAceptar
            // 
            this.btAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Location = new System.Drawing.Point(866, 175);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(96, 36);
            this.btAceptar.TabIndex = 20;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Visible = false;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // calendar1
            // 
            this.calendar1.AllowEditingEvents = false;
            this.calendar1.CalendarDate = new System.DateTime(2023, 6, 7, 0, 0, 0, 0);
            this.calendar1.CalendarView = Calendar.NET.CalendarViews.Month;
            this.calendar1.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.calendar1.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.calendar1.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.calendar1.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendar1.DimDisabledEvents = true;
            this.calendar1.HighlightCurrentDay = true;
            this.calendar1.LoadPresetHolidays = true;
            this.calendar1.Location = new System.Drawing.Point(968, 12);
            this.calendar1.Name = "calendar1";
            this.calendar1.ShowArrowControls = true;
            this.calendar1.ShowDashedBorderOnDisabledEvents = true;
            this.calendar1.ShowDateInHeader = true;
            this.calendar1.ShowDisabledEvents = false;
            this.calendar1.ShowEventTooltips = true;
            this.calendar1.ShowTodayButton = false;
            this.calendar1.Size = new System.Drawing.Size(733, 480);
            this.calendar1.TabIndex = 21;
            this.calendar1.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // pdMod
            // 
            this.pdMod.Image = global::TFG.Properties.Resources.modify;
            this.pdMod.Location = new System.Drawing.Point(538, 12);
            this.pdMod.Name = "pdMod";
            this.pdMod.Size = new System.Drawing.Size(32, 32);
            this.pdMod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pdMod.TabIndex = 19;
            this.pdMod.TabStop = false;
            this.pdMod.Click += new System.EventHandler(this.pdMod_Click);
            // 
            // pbDelete
            // 
            this.pbDelete.Image = ((System.Drawing.Image)(resources.GetObject("pbDelete.Image")));
            this.pbDelete.Location = new System.Drawing.Point(500, 12);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(32, 32);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDelete.TabIndex = 18;
            this.pbDelete.TabStop = false;
            this.pbDelete.Click += new System.EventHandler(this.pbDelete_Click);
            // 
            // pbAdd
            // 
            this.pbAdd.Image = ((System.Drawing.Image)(resources.GetObject("pbAdd.Image")));
            this.pbAdd.Location = new System.Drawing.Point(462, 12);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(32, 32);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAdd.TabIndex = 17;
            this.pbAdd.TabStop = false;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // FormCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1713, 504);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.pdMod);
            this.Controls.Add(this.pbDelete);
            this.Controls.Add(this.pbAdd);
            this.Controls.Add(this.tbDuracion);
            this.Controls.Add(this.rtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbDurecion);
            this.Controls.Add(this.dtHora);
            this.Controls.Add(this.lbHora);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.cbUsuario);
            this.Controls.Add(this.tbDni);
            this.Controls.Add(this.lbDni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txNombre);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCalendario";
            this.Text = "Citas";
            ((System.ComponentModel.ISupportInitialize)(this.tbDuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdMod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDni;
        private System.Windows.Forms.TextBox tbDni;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.DateTimePicker dtHora;
        private System.Windows.Forms.Label lbHora;
        private System.Windows.Forms.Label lbDurecion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtDescripcion;
        private System.Windows.Forms.NumericUpDown tbDuracion;
        private System.Windows.Forms.PictureBox pbAdd;
        private System.Windows.Forms.PictureBox pbDelete;
        private System.Windows.Forms.PictureBox pdMod;
        private System.Windows.Forms.Button btAceptar;
        private Calendar.NET.Calendar calendar1;
    }
}