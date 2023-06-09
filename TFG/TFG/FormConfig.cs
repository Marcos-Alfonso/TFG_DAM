using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
            Settings1.Default.Reload();
            initConfig();
            this.Closed += (s, args) => Settings1.Default.Reload();
        }

        private void initConfig()
        {

            lbEjemploGrid.Font = Settings1.Default.gridFont;
            panelColor.BackColor = Settings1.Default.myColor;
            cbOcultar.Checked = Settings1.Default.hideColumns;
        }

        private void btFuenteTabla_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = Settings1.Default.gridFont;
            DialogResult dr = fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Settings1.Default.gridFont = fontDialog1.Font;
                initConfig();
            }
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Settings1.Default.myColor;
            DialogResult dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Settings1.Default.myColor = colorDialog1.Color;
                
                initConfig();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Settings1.Default.hideColumns = cbOcultar.Checked;
            Settings1.Default.Save();

            this.Close();
        }
    }
}
