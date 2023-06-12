using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TFG.Properties;

namespace TFG
{
    public partial class FormClienteLog : Form
    {

        string carpetaCliente;
        string carpetaActual;
        string carpetaGeneral;
        string rutaFichero;
        string idCliente;

        public FormClienteLog(String idCliente, String nombre)
        {
            InitializeComponent();

            this.idCliente = idCliente;
            this.Text += nombre;
            initControl();
            loadFiles();

            this.WindowState = FormWindowState.Maximized;
        }
        private void initControl()
        {
            // Creo las rutas que vaya a utilizar
            carpetaGeneral = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "GestionA");
            carpetaCliente = Path.Combine(carpetaGeneral, idCliente);
            carpetaActual = carpetaCliente;
            rutaFichero = Path.Combine(carpetaCliente, "log.rtf");

            if (Directory.Exists(carpetaCliente))
            {
                try
                {
                    richTextBox1.LoadFile(rutaFichero, RichTextBoxStreamType.RichText);

                }
                catch (Exception ex)
                {

                }
            }
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += RichTextBox_DragEnter;
            richTextBox1.DragDrop += RichTextBox_DragDrop;


            zoomDropDownButton.DropDown.Items.Add("20%");
            zoomDropDownButton.DropDown.Items.Add("50%");
            zoomDropDownButton.DropDown.Items.Add("70%");
            zoomDropDownButton.DropDown.Items.Add("100%");
            zoomDropDownButton.DropDown.Items.Add("150%");
            zoomDropDownButton.DropDown.Items.Add("200%");
            zoomDropDownButton.DropDown.Items.Add("300%");
            zoomDropDownButton.DropDown.Items.Add("400%");
            zoomDropDownButton.DropDown.Items.Add("500%");

            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                fontStripComboBox.Items.Add(family.Name);
            }

            for (int i = 8; i < 80; i += 2)
            {
                fontSizeComboBox.Items.Add(i);
            }

        }


        //********************************
        //Metodos de el Listview
        //********************************

        private void loadFiles()
        {
            listView1.Items.Clear();
            if (Directory.Exists(carpetaCliente))
            {
                string[] carpetas = Directory.GetDirectories(carpetaActual);

                ImageList il = new ImageList();
                il.ImageSize = new Size(50, 50);
                ImageList small = new ImageList();
                small.ImageSize = new Size(20, 20);
                int count = 0;

                foreach (string carpeta in carpetas)
                {
                    ListViewItem i = listView1.Items.Add(Path.GetFileName(carpeta), count++);

                    i.Tag = "carpeta";

                    DirectoryInfo directorio = new DirectoryInfo(carpeta);
                    long tamanoEnBytes = directorio.EnumerateFiles("*.*", SearchOption.AllDirectories)
                                                .Sum(f => f.Length);
                    i.SubItems.Add(formatoTamanio(tamanoEnBytes));

                    int cantidad = Directory.GetFiles(carpeta).Length + Directory.GetDirectories(carpeta).Length;
                    i.SubItems.Add(cantidad.ToString());

                    var files = Directory.GetFiles(carpeta).Length;
                    if (files > 0)
                    {
                        il.Images.Add(Resources.folderFull);
                        small.Images.Add(Resources.folderFull);

                    }
                    else
                    {
                        il.Images.Add(Resources.folder);
                        small.Images.Add(Resources.folder);
                    }
                }

                //cargo archivos
                string[] archivos = Directory.GetFiles(carpetaActual);

                foreach (string archivo in archivos)
                {
                    string nombreArchivo = Path.GetFileName(archivo);

                    Icon icono = Icon.ExtractAssociatedIcon(archivo);

                    Image imagen = icono.ToBitmap();


                    ListViewItem i = listView1.Items.Add(nombreArchivo, nombreArchivo, count++);
                    FileInfo fi = new FileInfo(archivo);
                    float size = (float)fi.Length;
                    i.SubItems.Add(formatoTamanio(size));

                    i.Tag = "archivo";
                    il.Images.Add(imagen);
                    small.Images.Add(imagen);

                }
                listView1.LargeImageList = il;
                listView1.SmallImageList = small;

                listView1.Columns.Clear();
                listView1.Columns.Add("Nombre").AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.Columns.Add("Tamaño").AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.Columns.Add("Nº").AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            }
            if (carpetaActual != carpetaCliente)
            {
                string subCarpetaActual = carpetaActual.Substring(carpetaActual.LastIndexOf(idCliente)+idCliente.Length);
                labelCarpeta.Text = subCarpetaActual;
                labelCarpeta.Enabled = true;
            }
            else
            {
                labelCarpeta.Text = "Carpeta Raíz";
                labelCarpeta.Enabled = false;
            }
            toolStripButtonBack.Enabled = (carpetaActual != carpetaCliente);

        }

        private string formatoTamanio(float size)
        {
            if (size < 999.0)
            {
                return size + " bytes";
            }
            else if (size < 999999.0)
            {
                return (int)(size / 1000) + " KB";
            }
            else
            {
                return (int)(size / 1000000) + " MB";
            }

            return "~";
        }

        void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
            {
                // Abrir la carpeta en el explorador de archivos
                try
                {
                    // Verificar si el elemento es una carpeta
                    if (item.Tag != null && item.Tag.ToString() == "carpeta")
                    {

                        carpetaActual = Path.Combine(carpetaActual, item.Text);
                        loadFiles();

                    }
                    else
                    {

                        string filePath = Path.Combine(carpetaActual, item.Text);
                        Process.Start(filePath);

                    }
                }
                catch (Exception)
                {
                }

            }
            else
            {
                this.listView1.SelectedItems.Clear();
                MessageBox.Show("No se seleccionó objeto");
            }
        }

        private void listItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);



        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listView1.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    scaraToolStripMenuItem.Enabled = !(carpetaCliente == carpetaActual);

                    contextMenuStripFile.Show(Cursor.Position);
                }

            }
        }
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = listView1.HitTest(e.Location);
                if (hitTestInfo.Item == null)
                {
                    contextMenuStripList.Show(Cursor.Position);
                }
            }
        }
        private void renombrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                selectedItem.BeginEdit();
            }
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                string oldFileName = Path.Combine(carpetaActual, listView1.Items[e.Item].Text);
                string newFileName = Path.Combine(carpetaActual, e.Label);

                if (Path.GetExtension(oldFileName) != Path.GetExtension(newFileName))
                {
                    DialogResult result = MessageBox.Show("Está modificando la extensión del archivo. ¿Desea continuar?", "Confirmar cambio de extensión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        e.CancelEdit = true;
                        return;
                    }
                }

                if (File.Exists(oldFileName) && !string.IsNullOrEmpty(e.Label))
                {
                    try
                    {
                        File.Move(oldFileName, newFileName);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al renombrar el archivo: " + ex.Message);
                    }
                }
                if (Directory.Exists(oldFileName))
                {
                    try
                    {
                        Directory.Move(oldFileName, newFileName);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al renombrar la carpeta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void verEnExploradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(carpetaActual))
                {
                    string archivoLog = Path.Combine(carpetaActual, listView1.SelectedItems[0].Text);

                    if (File.Exists(archivoLog))
                    {
                        Process.Start("explorer.exe", $"/select,\"{archivoLog}\"");
                    }
                }
            }
            catch (Exception ex)
            {
                //Se controla por si no se tiene acceso al archivo, ya que el select del process start lo pueden bloquear antivirus
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems[0].Tag == "archivo")
                {
                    Process.Start(Path.Combine(carpetaActual, listView1.SelectedItems[0].Text));
                }
                else
                {
                    carpetaActual = Path.Combine(carpetaActual, listView1.SelectedItems[0].Text);
                    loadFiles();
                }
            }
            catch (Exception)
            { }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(carpetaActual))
            {
                Process.Start(carpetaActual);
            }

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //primera version Solo elimina uno:
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string fileName = selectedItem.Text;

                string filePath = Path.Combine(carpetaActual, fileName);

                if (selectedItem.Tag == "carpeta" && Directory.Exists(filePath))
                {
                    if (Directory.GetFiles(filePath).Length == 0 && Directory.GetDirectories(filePath).Length == 0)
                    {
                        Directory.Delete(filePath);
                        loadFiles();
                        return;
                    }

                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar la carpeta y todos sus archivos?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.Yes)
                    {
                        Directory.Delete(filePath, true);
                        loadFiles();
                    }
                }
                else if (File.Exists(filePath))
                {

                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el archivo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        File.Delete(filePath);
                        loadFiles();
                    }
                }

            }


            if (listView1.SelectedItems.Count > 1)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar los elementos seleccionados?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem selectedItem in listView1.SelectedItems)
                    {
                        string fileName = selectedItem.Text;
                        string filePath = Path.Combine(carpetaActual, fileName);

                        if (selectedItem.Tag == "carpeta" && Directory.Exists(filePath))
                        {
                            if (Directory.GetFiles(filePath).Length == 0 && Directory.GetDirectories(filePath).Length == 0)
                            {
                                Directory.Delete(filePath);
                            }
                            else
                            {
                                Directory.Delete(filePath, true);
                            }
                        }
                        else if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }

                    loadFiles();
                }
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                e.Effect = DragDropEffects.Copy;
            }
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Move;

            }

        }


        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);



            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {

                Point dropLocation = listView1.PointToClient(new Point(e.X, e.Y));

                ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

                ListViewItem targetItem = listView1.GetItemAt(dropLocation.X, dropLocation.Y);

                if (targetItem != null && targetItem.Tag == "carpeta")
                {

                    string rutaArchivo = Path.Combine(carpetaActual, draggedItem.Text);

                    string carpetaDestino = Path.Combine(carpetaActual, targetItem.Text);

                    try
                    {
                        if (draggedItem.Tag == "carpeta")
                        {
                            if (rutaArchivo == carpetaDestino)
                            {
                                return;
                            }
                            Directory.Move(rutaArchivo, Path.Combine(carpetaDestino, draggedItem.Text));
                        }
                        else if (draggedItem.Text != "log.rtf")
                        {
                            File.Move(rutaArchivo, Path.Combine(carpetaDestino, draggedItem.Text));
                        }


                        loadFiles();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al mover el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

            if (filePaths == null)
            {
                return;
            }

            if (filePaths.Length > 0)
            {
                foreach (string path in filePaths)
                {
                    string rutaOrigen = path;
                    string rutaDestino = Path.Combine(carpetaActual, Path.GetFileName(rutaOrigen));

                    Directory.CreateDirectory(carpetaGeneral);
                    Directory.CreateDirectory(carpetaCliente);

                    try
                    {
                        File.Copy(rutaOrigen, rutaDestino, true);
                    }
                    catch (Exception)
                    { }

                }
                loadFiles();
            }
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            string carpetaPadre = Path.GetDirectoryName(carpetaActual);

            // Verificar si la carpeta padre es válida
            if (!string.IsNullOrEmpty(carpetaPadre))
            {
                carpetaActual = carpetaPadre;
                loadFiles();
            }
        }
        private void nuevaCarpetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nuevaCarpeta = "Nueva Carpeta";
            string carpetaCompleta = Path.Combine(carpetaActual, nuevaCarpeta);
            int contador = 1;

            while (Directory.Exists(carpetaCompleta))
            {
                nuevaCarpeta = "Nueva Carpeta " + contador.ToString();
                carpetaCompleta = Path.Combine(carpetaActual, nuevaCarpeta);
                contador++;
            }
            Directory.CreateDirectory(carpetaCompleta);
            loadFiles();

            ListViewItem itemNuevaCarpeta = listView1.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Text == nuevaCarpeta);

            if (itemNuevaCarpeta != null)
            {
                itemNuevaCarpeta.BeginEdit();
            }
        }
        private void toolStripButtonreload_Click(object sender, EventArgs e)
        {
            loadFiles();
        }


        private void adjuntarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //openFileDialog.Filter = "Archivos|*.txt;*.doc;*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string archivoSeleccionado = openFileDialog.FileName;
                string nombreArchivo = Path.GetFileName(archivoSeleccionado);
                string rutaDestino = Path.Combine(carpetaActual, nombreArchivo);

                if (File.Exists(rutaDestino))
                {
                    string nombreSinExtension = Path.GetFileNameWithoutExtension(nombreArchivo);
                    string extension = Path.GetExtension(nombreArchivo);
                    int contador = 1;

                    while (File.Exists(rutaDestino))
                    {
                        string nuevoNombre = $"{nombreSinExtension} ({contador}){extension}";
                        rutaDestino = Path.Combine(carpetaActual, nuevoNombre);
                        contador++;
                    }
                }

                File.Copy(archivoSeleccionado, rutaDestino);

                loadFiles();
            }
        }

        private void exportartoolStripButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                // Configurar el diálogo de selección de carpeta
                dialog.Description = "Seleccione la carpeta de destino";
                dialog.RootFolder = Environment.SpecialFolder.Desktop;

                // Mostrar el diálogo y obtener el resultado
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string carpetaDestino = dialog.SelectedPath;
                    string archivoComprimido = Path.Combine(carpetaDestino, idCliente + ".zip");

                    if (File.Exists(archivoComprimido))
                    {
                        MessageBox.Show("El archivo comprimido ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try
                    {


                        // Comprimir la carpetaCliente en un archivo comprimido
                        ZipFile.CreateFromDirectory(carpetaCliente, archivoComprimido);

                        // Eliminar el archivo "log.rtf" del archivo ZIP
                        using (ZipArchive zip = ZipFile.Open(archivoComprimido, ZipArchiveMode.Update))
                        {
                            ZipArchiveEntry entry = zip.GetEntry("log.rtf");
                            if (entry != null)
                            {
                                entry.Delete();
                            }
                            zip.Dispose();
                        }

                        MessageBox.Show("Carpeta comprimida exitosamente.");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        private void toolStripButtonImportar_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos ZIP (*.zip)|*.zip";
            openFileDialog.Title = "Seleccionar archivo ZIP";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string archivoZip = openFileDialog.FileName;
                try
                {

                    Directory.CreateDirectory(carpetaGeneral);
                    Directory.CreateDirectory(carpetaCliente);

                    using (ZipArchive archive = ZipFile.OpenRead(archivoZip))
                    {
                        foreach (ZipArchiveEntry file in archive.Entries)
                        {
                            string completeFileName = Path.Combine(carpetaCliente, file.FullName);
                            string directory = Path.GetDirectoryName(completeFileName);

                            if (!Directory.Exists(directory))
                                Directory.CreateDirectory(directory);

                            if (file.Name != "")
                                file.ExtractToFile(completeFileName, true);
                        }
                    }

                    loadFiles();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al descomprimir el archivo ZIP: " + ex.Message, "Importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void scaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    //ListViewItem selectedItem = listView1.SelectedItems[0];
                    string selectedItemText = selectedItem.Text;
                    string selectedItemPath = Path.Combine(carpetaActual, selectedItemText);

                    string carpetaPadre = Directory.GetParent(carpetaActual).FullName;

                    // Mover el item a la carpeta padre
                    string nuevoPath = Path.Combine(carpetaPadre, selectedItemText);

                    try // en caso de que ya exista una carpeta o fichero con el nombre
                    {
                        if (selectedItem.Tag == "carpeta")
                        {
                            Directory.Move(selectedItemPath, nuevoPath);
                        }
                        else
                        {
                            File.Move(selectedItemPath, nuevoPath);
                        }

                    }
                    catch (Exception)
                    {
                    }


                }

                loadFiles(); // Actualizar la vista del ListView
            }
        }
        //********************************
        //Metodos de el RichTextBox   STOP
        //********************************
        private void saveStripButton_Click(object sender, EventArgs e)
        {
            try
            {

                Directory.CreateDirectory(carpetaGeneral);
                Directory.CreateDirectory(carpetaCliente);

                richTextBox1.SaveFile(rutaFichero, RichTextBoxStreamType.RichText);
                loadFiles();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
            }
        }


        private void printStripButton_Click(object sender, EventArgs e)
        {
            PrintDocument documento = new PrintDocument();

            documento.PrintPage += printDocument_PrintPage;

            PrintDialog dialogoImpresion = new PrintDialog();
            dialogoImpresion.Document = documento;

            if (dialogoImpresion.ShowDialog() == DialogResult.OK)
            {

                documento.Print();
            }


        }

        private void printPreviewStripButton_Click(object sender, EventArgs e)
        {
            /*
            PrintDocument documento = new PrintDocument();

            documento.PrintPage += printDocument_PrintPage;

            PrintPreviewDialog vistaPrevia = new PrintPreviewDialog();
            vistaPrevia.Document = documento;

            */
            printPreviewDialog1.ShowDialog();
        }

        private void undoStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void fontStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {

                richTextBox1.SelectionFont = new Font(fontStripComboBox.Text, richTextBox1.Font.Size);
            }

            richTextBox1.SelectionFont = new Font(fontStripComboBox.Text, richTextBox1.SelectionFont.Size);
        }

        private void fontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                return;
            }

            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, Convert.ToInt32(fontSizeComboBox.Text), richTextBox1.SelectionFont.Style);
        }

        private void increaseStripButton_Click(object sender, EventArgs e)
        {
            string fontSizeNum = fontSizeComboBox.Text;
            try
            {
                /*
                int size = Convert.ToInt32(fontSizeNum) + 1;    
                if (richTextBox1.SelectionFont == null)
                {
                    return;
                }
                // sets the updated font size
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
                fontSizeComboBox.Text = size.ToString();    
                */
                if (richTextBox1.SelectionLength > 0)
                {
                    int start = richTextBox1.SelectionStart;
                    int end = start + richTextBox1.SelectionLength;

                    for (int i = start; i < end; i++)
                    {
                        richTextBox1.Select(i, 1);
                        Font charFont = richTextBox1.SelectionFont;

                        if (charFont != null)
                        {
                            float fontSize = charFont.Size;
                            richTextBox1.SelectionFont = new Font(charFont.FontFamily, fontSize + 1, charFont.Style);
                        }
                    }

                    richTextBox1.Select(start, end - start);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // show error message
            }

        }

        private void decreaseStripButton_Click(object sender, EventArgs e)
        {/*
            string fontSizeNum = fontSizeComboBox.Text;            
            try
            {
                int size = Convert.ToInt32(fontSizeNum) - 1;   
                if (richTextBox1.SelectionFont == null)
                {
                    return;
                }
                // sets the updated font size
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
                fontSizeComboBox.Text = size.ToString();    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // show error message
            }

            */
            if (richTextBox1.SelectionLength > 0)
            {
                int start = richTextBox1.SelectionStart;
                int end = start + richTextBox1.SelectionLength;

                for (int i = start; i < end; i++)
                {
                    richTextBox1.Select(i, 1);
                    Font charFont = richTextBox1.SelectionFont;

                    if (charFont != null)
                    {
                        float fontSize = charFont.Size;
                        if (fontSize == 1)
                        {
                            continue;
                        }
                        richTextBox1.SelectionFont = new Font(charFont.FontFamily, fontSize - 1, charFont.Style);
                    }
                }

                richTextBox1.Select(start, end - start);

            }
        }

        private void lowercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToLower();
        }

        private void capsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToUpper();
        }


        private void boldStripButton_Click(object sender, EventArgs e)
        {
            if (boldStripButton3.Checked == false)
            {
                boldStripButton3.Checked = true;
            }
            else if (boldStripButton3.Checked == true)
            {
                boldStripButton3.Checked = false;
            }

            if (richTextBox1.SelectionFont == null)
            {
                return;
            }

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
            }
            else
            {
                style |= FontStyle.Bold;

            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void italicStripButton_Click(object sender, EventArgs e)
        {
            if (italicStripButton.Checked == false)
            {
                italicStripButton.Checked = true;
            }
            else if (italicStripButton.Checked == true)
            {
                italicStripButton.Checked = false;
            }

            if (richTextBox1.SelectionFont == null)
            {
                return;
            }

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
            }
            else
            {
                style |= FontStyle.Italic;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void underlineStripButton_Click(object sender, EventArgs e)
        {
            if (underlineStripButton.Checked == false)
            {
                underlineStripButton.Checked = true;
            }
            else if (underlineStripButton.Checked == true)
            {
                underlineStripButton.Checked = false;
            }

            if (richTextBox1.SelectionFont == null)
            {
                return;
            }

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
            }
            else
            {
                style |= FontStyle.Underline;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void leftAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            centerAlignStripButton.Checked = false;
            rightAlignStripButton.Checked = false;
            if (leftAlignStripButton.Checked == false)
            {
                leftAlignStripButton.Checked = true;
            }
            else if (leftAlignStripButton.Checked == true)
            {
                leftAlignStripButton.Checked = false;
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void centerAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            leftAlignStripButton.Checked = false;
            rightAlignStripButton.Checked = false;
            if (centerAlignStripButton.Checked == false)
            {
                centerAlignStripButton.Checked = true;
            }
            else if (centerAlignStripButton.Checked == true)
            {
                centerAlignStripButton.Checked = false;
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void rightAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            leftAlignStripButton.Checked = false;
            centerAlignStripButton.Checked = false;

            if (rightAlignStripButton.Checked == false)
            {
                rightAlignStripButton.Checked = true;
            }
            else if (rightAlignStripButton.Checked == true)
            {
                rightAlignStripButton.Checked = false;
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void bulletListStripButton_Click(object sender, EventArgs e)
        {
            if (bulletListStripButton.Checked == false)
            {
                bulletListStripButton.Checked = true;
                richTextBox1.SelectionBullet = true;
            }
            else if (bulletListStripButton.Checked == true)
            {
                bulletListStripButton.Checked = false;
                richTextBox1.SelectionBullet = false;
            }
        }

        private void zoomDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            float zoomPercent = Convert.ToSingle(e.ClickedItem.Text.Trim('%'));
            richTextBox1.ZoomFactor = zoomPercent / 100;
            zoomDropDownButton.Text = "Zoom " + zoomPercent + "%";
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Crear la carpeta si no existe
                Directory.CreateDirectory(carpetaGeneral);
                Directory.CreateDirectory(carpetaCliente);

                // Guardar el contenido del RichTextBox en el archivo en formato RTF
                richTextBox1.SaveFile(rutaFichero, RichTextBoxStreamType.RichText);
                loadFiles();

                statusStrip1.Visible = true;

                Timer timer = new Timer();
                timer.Interval = 3000;
                timer.Tick += (sender2, e2) =>
                {
                    statusStrip1.Visible = false;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
            }
            finally
            {
                // Restaurar el cursor predeterminado
                this.Cursor = Cursors.Default;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
            richTextBox1.Focus();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private int linesPrinted;
        private string[] lines;
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(richTextBox1.ForeColor);

            while (linesPrinted < lines.Length)
            {
                e.Graphics.DrawString(lines[linesPrinted++],
                    richTextBox1.Font, brush, x, y);
                y += 15;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            linesPrinted = 0;
            e.HasMorePages = false;
        }
        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            char[] param = { '\n' };

            if (printDialog1.PrinterSettings.PrintRange == PrintRange.Selection)
            {
                lines = richTextBox1.SelectedText.Split(param);
            }
            else
            {
                lines = richTextBox1.Text.Split(param);
            }

            int i = 0;
            char[] trimParam = { '\r' };
            foreach (string s in lines)
            {
                lines[i++] = s.TrimEnd(trimParam);
            }
        }


        private void cambioSeleccion(object sender, EventArgs e)
        {


            if (richTextBox1.SelectionFont == null)
            {
                fontStripComboBox.Text = "";

            }
            else
            {
                fontStripComboBox.Text = richTextBox1.SelectionFont.Name;
                fontSizeComboBox.Text = Convert.ToString(richTextBox1.SelectionFont.Size);

                boldStripButton3.Checked = richTextBox1.SelectionFont.Bold;
                italicStripButton.Checked = richTextBox1.SelectionFont.Italic;
                underlineStripButton.Checked = richTextBox1.SelectionFont.Underline;
            }

            bulletListStripButton.Checked = richTextBox1.SelectionBullet;
            leftAlignStripButton.Checked = false;
            centerAlignStripButton.Checked = false;
            rightAlignStripButton.Checked = false;

            switch (richTextBox1.SelectionAlignment)
            {
                case HorizontalAlignment.Left:
                    leftAlignStripButton.Checked = true;
                    break;
                case HorizontalAlignment.Right:
                    rightAlignStripButton.Checked = true;

                    break;
                case HorizontalAlignment.Center:
                    centerAlignStripButton.Checked = true;
                    break;
                default:
                    break;
            }


        }

        private void colorStripDropDownButton_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = c.Color;
            }
        }




        private void RichTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                e.Effect = DragDropEffects.Copy;
            }
        }

        private void RichTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                var item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

                string text = item.Text;

                richTextBox1.SelectedText = text;
            }

            if (filePaths == null)
            {
                return;
            }

            if (filePaths.Length > 0)
            {
                string rutaOrigen = filePaths[0];
                string rutaDestino = Path.Combine(carpetaCliente, Path.GetFileName(rutaOrigen));

                Directory.CreateDirectory(carpetaGeneral);
                Directory.CreateDirectory(carpetaCliente);

                File.Copy(rutaOrigen, rutaDestino, true);
                loadFiles();

                /*
                // Verifica si el archivo es una imagen.
                if (IsImageFile(filePaths[0]))
                {
                    // Crea un objeto Image a partir del archivo de imagen.
                    Image image = Image.FromFile(filePaths[0]);

                    // Inserta la imagen en el RichTextBox.
                    Clipboard.SetImage(image);
                    ((RichTextBox)sender).Paste();
                }
                */
            }
        }

        private static bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            string[] validExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

            return validExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (listView1.View == View.LargeIcon)
            {
                listView1.View = View.Details;
                //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                foreach (ColumnHeader column in listView1.Columns)
                {
                    column.Width = -2;
                }
            }
            else
            {
                listView1.View = View.LargeIcon;
            }
            toolStripButtonDetalles.Checked = !toolStripButtonDetalles.Checked;
        }
    }
}
