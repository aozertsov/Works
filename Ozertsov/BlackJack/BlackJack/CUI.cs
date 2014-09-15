using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class CUI : Form
    {
        public CUI()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start.Visible = false;
            CardReverse.Visible = true;
        }
    }
}
