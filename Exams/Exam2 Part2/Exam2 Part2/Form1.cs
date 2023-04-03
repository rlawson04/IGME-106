using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam2_Part2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the button is clicked, check the user input and then print out the cards 
        /// given that the input string can be parsed
        /// </summary>
        /// <param name="sender"> object sender </param>
        /// <param name="e"> event handler </param>
        private void dealCards_Click(object sender, EventArgs e)
        {
            // Creates a deck and a card stack, then shuffles the deck into the stack
            Deck deck = new Deck();
            CardStack<Card> stack;
            stack = deck.Shuffle();

            // Try to parse the user's input into an integer
            bool success = int.TryParse(userInputBox.Text, out int result);

            // if successful print N cards or print 5 cards from the top of the stack
            if (success)
            {
                // When the user inputs a value below zero or above 52, print the message and show the top 5 cards
                if (result < 0 || result > 52)
                {
                    mainTextBox.Text += "Invalid card count entered, defaulting to 5";

                    for (int i  = 0; i < 5; i++)
                    {
                        mainTextBox.Text += $"\r\n {stack.Pop()}";
                    }
                }

                // If the number is between 0 and 52, display the users input number of cards from the stack
                else
                {
                    mainTextBox.Text += "Cards being dealt:";
                    for (int i = 0; i < result; i++)
                    {
                        mainTextBox.Text += $"\r\n {stack.Pop()}";
                    }
                }

            }

            // If the tryparse is unsuccessful, print a message to the text box
            else
            {
                mainTextBox.Text += "TryParse failed, please enter an integer value";
            }
        }

        /// <summary>
        /// When the button is clicked, clear both text boxes
        /// </summary>
        /// <param name="sender"> object sender </param>
        /// <param name="e"> event handler </param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clears boxes
            userInputBox.Text = string.Empty;
            mainTextBox.Text = string.Empty;
        }

     
    }
}
