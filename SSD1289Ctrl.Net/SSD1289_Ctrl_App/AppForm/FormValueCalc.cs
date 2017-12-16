using SSD1289.Net;
using SSD1289_Ctrl_App.SSD1289;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSD1289_Ctrl_App.AppForm
{
    public partial class FormValueCalc : Form
    {
        public FormValueCalc()
        {
            InitializeComponent();
        }

        private void FormValueCalc_Load(object sender, EventArgs e)
        {
            List<SSD1289Register> regTemplates = AppUtil.LoadRegister<SSD1289Register>("ssd1289.json");
            ucRegValue.RegisterTemplates = regTemplates;
        }
    }
}
