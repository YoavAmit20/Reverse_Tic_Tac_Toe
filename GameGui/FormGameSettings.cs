using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGui
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(this.playerOneNameTextBox.Text) && !string.IsNullOrEmpty(this.playerTwoNameTextBox.Text))
            {
                this.Hide();
                GameBoardForm gameBoardForm = new GameBoardForm(this.playerOneNameTextBox.Text, this.playerTwoNameTextBox.Text, !this.enablePlayerCheckBox.Checked, (int) this.nUDRows.Value);
                gameBoardForm.ShowDialog();
            }

            else
            {
                MessageBox.Show("One of the players name is empty. please enter the name of of the player", "Empty Player Name Error");
            }
            
        }

        private void enablePlayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.playerTwoNameTextBox.Enabled = enablePlayerCheckBox.Checked;
            this.playerTwoNameTextBox.Text = enablePlayerCheckBox.Checked ? "" : "[Computer]";
        }

        private void nUDRows_ValueChanged(object sender, EventArgs e)
        {
            this.nUDCols.Value = nUDRows.Value;
        }

        private void nUDCols_ValueChanged(object sender, EventArgs e) 
        {
             this.nUDRows.Value = nUDCols.Value;
        }

        private void FormGameSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
