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
    public partial class Form1 : Form2
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Creates a list with all the buttons in it
            List<Button> buttons = new List<Button>();
            Random random = new Random();

            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);
            buttons.Add(button17);
            buttons.Add(button18);
            buttons.Add(button19);
            buttons.Add(button20);
            buttons.Add(button21);
            buttons.Add(button22);
            buttons.Add(button23);
            buttons.Add(button24);
            buttons.Add(button25);

            // Makes each button a random color
            foreach (Button button in buttons)
            {
                button.BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            }
        }

        /// <summary>
        /// Gets information from the button and gives it to the load Form method
        /// </summary>
        /// <param name="sender"> The clicked button </param>
        /// <param name="e"> event data </param>
        private void OpenWindow(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button theButton = (Button)sender;

                
                LoadForm(theButton.BackColor);
                
            }
            
        }
    }
}
