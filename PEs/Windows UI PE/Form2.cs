using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_UI_PE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Changes the background color and creates a text with the color information
        /// </summary>
        /// <param name="color"> takes in the color of the back of the button </param>
        public void LoadForm(Color color)
        {
            this.BackColor = color;
            label1.Text = color.ToString();
        }


    }
}
