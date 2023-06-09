
namespace TFG
{
    partial class FormClientes
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientes));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dtFiltro = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dtClientes = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verArchivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClienteLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExportDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCitas = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusError = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusRegistro = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonmodify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFiltro = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCitas = new System.Windows.Forms.ToolStripButton();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonExportar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClientes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 37);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.Panel1MinSize = 38;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtClientes);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 27);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1549, 654);
            this.splitContainer1.SplitterDistance = 38;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 50);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer2.Panel1.Controls.Add(this.dtFiltro);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(150, 0);
            this.splitContainer2.SplitterDistance = 121;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 1;
            // 
            // dtFiltro
            // 
            this.dtFiltro.AllowUserToAddRows = false;
            this.dtFiltro.AllowUserToDeleteRows = false;
            this.dtFiltro.AllowUserToResizeColumns = false;
            this.dtFiltro.AllowUserToResizeRows = false;
            this.dtFiltro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFiltro.Location = new System.Drawing.Point(0, 0);
            this.dtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.dtFiltro.Name = "dtFiltro";
            this.dtFiltro.RowHeadersWidth = 51;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtFiltro.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtFiltro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtFiltro.Size = new System.Drawing.Size(121, 0);
            this.dtFiltro.TabIndex = 0;
            this.dtFiltro.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.cambioFiltro);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(24, 0);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dtClientes
            // 
            this.dtClientes.AllowUserToAddRows = false;
            this.dtClientes.AllowUserToDeleteRows = false;
            this.dtClientes.AllowUserToOrderColumns = true;
            this.dtClientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            this.dtClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtClientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dtClientes.Location = new System.Drawing.Point(0, 0);
            this.dtClientes.Margin = new System.Windows.Forms.Padding(4);
            this.dtClientes.Name = "dtClientes";
            this.dtClientes.RowHeadersWidth = 51;
            this.dtClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtClientes.Size = new System.Drawing.Size(1549, 627);
            this.dtClientes.TabIndex = 0;
            this.dtClientes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.cambioGrid);
            this.dtClientes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtClientes_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verClienteToolStripMenuItem,
            this.verArchivosToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.modificarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 108);
            // 
            // verClienteToolStripMenuItem
            // 
            this.verClienteToolStripMenuItem.Image = global::TFG.Properties.Resources.icons8_user_48;
            this.verClienteToolStripMenuItem.Name = "verClienteToolStripMenuItem";
            this.verClienteToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.verClienteToolStripMenuItem.Text = "&Ver Cliente";
            this.verClienteToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // verArchivosToolStripMenuItem
            // 
            this.verArchivosToolStripMenuItem.Image = global::TFG.Properties.Resources.icons8_log_50;
            this.verArchivosToolStripMenuItem.Name = "verArchivosToolStripMenuItem";
            this.verArchivosToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.verArchivosToolStripMenuItem.Text = "&Ver archivos";
            this.verArchivosToolStripMenuItem.Click += new System.EventHandler(this.toolClienteLog_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::TFG.Properties.Resources.icons8_minus_50;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.eliminarToolStripMenuItem.Text = "&Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.bajaToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Image = global::TFG.Properties.Resources.modify;
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.modificarToolStripMenuItem.Text = "&Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.abreModificar);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem,
            this.bajaToolStripMenuItem,
            this.modToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.filtroToolStripMenuItem,
            this.tsmConfig,
            this.toolClienteLog,
            this.toolStripMenuItemExportDB,
            this.toolStripMenuItemCitas});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1549, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // altaToolStripMenuItem
            // 
            this.altaToolStripMenuItem.AutoSize = false;
            this.altaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("altaToolStripMenuItem.Image")));
            this.altaToolStripMenuItem.Name = "altaToolStripMenuItem";
            this.altaToolStripMenuItem.Size = new System.Drawing.Size(42, 34);
            this.altaToolStripMenuItem.ToolTipText = "Agregar";
            this.altaToolStripMenuItem.Click += new System.EventHandler(this.abreAdmod);
            // 
            // bajaToolStripMenuItem
            // 
            this.bajaToolStripMenuItem.AutoSize = false;
            this.bajaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bajaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bajaToolStripMenuItem.Image")));
            this.bajaToolStripMenuItem.Name = "bajaToolStripMenuItem";
            this.bajaToolStripMenuItem.Size = new System.Drawing.Size(42, 34);
            this.bajaToolStripMenuItem.ToolTipText = "Eliminar";
            this.bajaToolStripMenuItem.Click += new System.EventHandler(this.bajaToolStripMenuItem_Click);
            // 
            // modToolStripMenuItem
            // 
            this.modToolStripMenuItem.AutoSize = false;
            this.modToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modToolStripMenuItem.Image")));
            this.modToolStripMenuItem.Name = "modToolStripMenuItem";
            this.modToolStripMenuItem.Size = new System.Drawing.Size(42, 34);
            this.modToolStripMenuItem.ToolTipText = "Modificar";
            this.modToolStripMenuItem.Click += new System.EventHandler(this.abreAdmod);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.AutoSize = false;
            this.guardarToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripMenuItem.Image")));
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(42, 34);
            this.guardarToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.guardarToolStripMenuItem.ToolTipText = "Guardar datos";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardar);
            // 
            // filtroToolStripMenuItem
            // 
            this.filtroToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filtroToolStripMenuItem.Image")));
            this.filtroToolStripMenuItem.Name = "filtroToolStripMenuItem";
            this.filtroToolStripMenuItem.Size = new System.Drawing.Size(44, 34);
            this.filtroToolStripMenuItem.ToolTipText = "Filtro";
            this.filtroToolStripMenuItem.Click += new System.EventHandler(this.abreFiltro);
            // 
            // tsmConfig
            // 
            this.tsmConfig.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmConfig.Image = ((System.Drawing.Image)(resources.GetObject("tsmConfig.Image")));
            this.tsmConfig.Name = "tsmConfig";
            this.tsmConfig.Size = new System.Drawing.Size(44, 34);
            this.tsmConfig.ToolTipText = "Filtro";
            this.tsmConfig.Click += new System.EventHandler(this.tsmConfig_Click);
            // 
            // toolClienteLog
            // 
            this.toolClienteLog.Image = global::TFG.Properties.Resources.icons8_log_50;
            this.toolClienteLog.Name = "toolClienteLog";
            this.toolClienteLog.Size = new System.Drawing.Size(44, 34);
            this.toolClienteLog.ToolTipText = "Log de Cliente";
            this.toolClienteLog.Click += new System.EventHandler(this.toolClienteLog_Click);
            // 
            // toolStripMenuItemExportDB
            // 
            this.toolStripMenuItemExportDB.Image = global::TFG.Properties.Resources.icons8_exportar_30;
            this.toolStripMenuItemExportDB.Name = "toolStripMenuItemExportDB";
            this.toolStripMenuItemExportDB.Size = new System.Drawing.Size(44, 34);
            this.toolStripMenuItemExportDB.ToolTipText = "Exportar";
            this.toolStripMenuItemExportDB.Click += new System.EventHandler(this.toolStripMenuItemExportDB_Click);
            // 
            // toolStripMenuItemCitas
            // 
            this.toolStripMenuItemCitas.Image = global::TFG.Properties.Resources.icons8_date_50;
            this.toolStripMenuItemCitas.Name = "toolStripMenuItemCitas";
            this.toolStripMenuItemCitas.Size = new System.Drawing.Size(44, 34);
            this.toolStripMenuItemCitas.ToolTipText = "Citas";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusError,
            this.toolStripStatusRegistro});
            this.statusStrip1.Location = new System.Drawing.Point(0, 691);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1549, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(133, 23);
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(20, 20);
            this.toolStripStatusLabel1.Visible = false;
            // 
            // toolStripStatusError
            // 
            this.toolStripStatusError.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusError.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusError.Image")));
            this.toolStripStatusError.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusError.Name = "toolStripStatusError";
            this.toolStripStatusError.Size = new System.Drawing.Size(20, 20);
            this.toolStripStatusError.Visible = false;
            // 
            // toolStripStatusRegistro
            // 
            this.toolStripStatusRegistro.Name = "toolStripStatusRegistro";
            this.toolStripStatusRegistro.Size = new System.Drawing.Size(0, 16);
            this.toolStripStatusRegistro.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonDelete,
            this.toolStripButtonmodify,
            this.toolStripSeparator3,
            this.toolStripButtonFiltro,
            this.toolStripSeparator1,
            this.toolStripButtonUndo,
            this.toolStripButtonSave,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButtonLog,
            this.toolStripButtonCitas,
            this.tsbSettings,
            this.toolStripSeparator4,
            this.toolStripButtonExportar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1549, 37);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = global::TFG.Properties.Resources.icons8_add_48;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(34, 34);
            this.toolStripButtonAdd.Text = "Añadir";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = global::TFG.Properties.Resources.icons8_minus_50;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(34, 34);
            this.toolStripButtonDelete.Text = "Eliminar";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.bajaToolStripMenuItem_Click);
            // 
            // toolStripButtonmodify
            // 
            this.toolStripButtonmodify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonmodify.Image = global::TFG.Properties.Resources.mod;
            this.toolStripButtonmodify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonmodify.Name = "toolStripButtonmodify";
            this.toolStripButtonmodify.Size = new System.Drawing.Size(34, 34);
            this.toolStripButtonmodify.Text = "Modificar";
            this.toolStripButtonmodify.Click += new System.EventHandler(this.abreModificar);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripButtonFiltro
            // 
            this.toolStripButtonFiltro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFiltro.Image = global::TFG.Properties.Resources.filtro;
            this.toolStripButtonFiltro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFiltro.Name = "toolStripButtonFiltro";
            this.toolStripButtonFiltro.Size = new System.Drawing.Size(34, 34);
            this.toolStripButtonFiltro.Text = "Guardar";
            this.toolStripButtonFiltro.Click += new System.EventHandler(this.abreVentanaFiltro);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Image = global::TFG.Properties.Resources.icons8_rollback_48;
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(34, 34);
            this.toolStripButtonUndo.Text = "Deshacer Cambios";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.toolStripButtonUndo_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Enabled = false;
            this.toolStripButtonSave.Image = global::TFG.Properties.Resources.guardar;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(34, 34);
            this.toolStripButtonSave.Text = "Guardar";
            this.toolStripButtonSave.Click += new System.EventHandler(this.guardar);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TFG.Properties.Resources.icons8_user_48;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 34);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonLog
            // 
            this.toolStripButtonLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLog.Image = global::TFG.Properties.Resources.icons8_log_50;
            this.toolStripButtonLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLog.Name = "toolStripButtonLog";
            this.toolStripButtonLog.Size = new System.Drawing.Size(34, 34);
            this.toolStripButtonLog.Text = "Archivos del cliente";
            this.toolStripButtonLog.Click += new System.EventHandler(this.toolClienteLog_Click);
            // 
            // toolStripButtonCitas
            // 
            this.toolStripButtonCitas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCitas.Image = global::TFG.Properties.Resources.icons8_date_50;
            this.toolStripButtonCitas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCitas.Name = "toolStripButtonCitas";
            this.toolStripButtonCitas.Size = new System.Drawing.Size(34, 34);
            this.toolStripButtonCitas.Text = "Citas con clientes";
            this.toolStripButtonCitas.Click += new System.EventHandler(this.verTodasLasCitasToolStripMenuItem_Click);
            // 
            // tsbSettings
            // 
            this.tsbSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSettings.Image = global::TFG.Properties.Resources.icons8_config_24;
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(34, 34);
            this.tsbSettings.Text = "toolStripButton2";
            this.tsbSettings.Click += new System.EventHandler(this.tsmConfig_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripButtonExportar
            // 
            this.toolStripButtonExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportar.Image = global::TFG.Properties.Resources.icons8_database_export_50;
            this.toolStripButtonExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportar.Name = "toolStripButtonExportar";
            this.toolStripButtonExportar.Size = new System.Drawing.Size(34, 34);
            this.toolStripButtonExportar.Text = "Exportar Base de Datos";
            this.toolStripButtonExportar.Click += new System.EventHandler(this.toolStripMenuItemExportDB_Click);
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 713);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormClientes";
            this.Text = "GestorA Clientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closing);
            this.ResizeEnd += new System.EventHandler(this.cambioResize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClientes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtClientes;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem filtroToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusError;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusRegistro;
        private System.Windows.Forms.DataGridView dtFiltro;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem tsmConfig;
        private System.Windows.Forms.ToolStripMenuItem toolClienteLog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExportDB;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCitas;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonmodify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonFiltro;
        private System.Windows.Forms.ToolStripButton toolStripButtonLog;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportar;
        private System.Windows.Forms.ToolStripButton toolStripButtonCitas;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verArchivosToolStripMenuItem;
    }
}

