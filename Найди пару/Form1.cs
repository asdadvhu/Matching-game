using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найди_пару
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;

        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "с", "с", "е", "е", "ы", "ы", "й", "й",
        "ц", "ц", "r", "r", "u", "u", "h", "h"
        };
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;


            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                if (secondClicked == null)
                {
                    secondClicked = clickedLabel;
                    secondClicked.ForeColor = Color.Black;
                    timer1.Start();
                    CheckForWinner();
                    return;
                }

                

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }
        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("Вы открыли все иконки!", "Вы молодец!");
            Close();
        }
    }
}
