using GameLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameGui
{
    public partial class GameBoardForm : Form
    {

        private readonly GameManager r_GameManager;
        private readonly Label r_PlayerOneLabel = new Label();
        private readonly Label r_PlayerTwoLabel = new Label();
        private readonly PlayButton[,] r_PlaybleButtons;


        public GameBoardForm(string i_PlayerOneName, string i_PlayerTwoName, bool i_IsPlayerTwoComputer, int i_SquareBoardDimensions)
        {
            Controls.Add(r_PlayerOneLabel);
            Controls.Add(r_PlayerTwoLabel);
            if (i_IsPlayerTwoComputer)
            {

                r_PlaybleButtons = new PlayButton[i_SquareBoardDimensions + 1, i_SquareBoardDimensions + 1];
            }

            InitializeComponent();
            r_GameManager = GameManager.InitializeGame(i_PlayerOneName, i_PlayerTwoName, i_SquareBoardDimensions, i_IsPlayerTwoComputer);
            initializeForm();
        }

        private void initializeForm()
        {

            createGameBoard();

        }
        private void createGameBoard()
        {

            const int k_ButtonStartPosition = 10;
            const int k_ButtonSize = 50;
            const int k_ButtonSpacing = 5;
            const int k_LabelSize = 20;
            createButtons(k_ButtonStartPosition, k_ButtonSize, k_ButtonSpacing);
            int windowWidth = ((r_GameManager.GameBoard.GetBoardSize() - 1) * k_ButtonSize) + ((r_GameManager.GameBoard.GetBoardSize() - 2) * k_ButtonSpacing) + (2 * k_ButtonStartPosition);

            setPlayerLabels(windowWidth);
            this.ClientSize = new Size(windowWidth, windowWidth + k_LabelSize);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void createButtons(int k_StartPosition, int k_ButtonSize, int k_ButtonSpacing)
        {

            for (int i = 1; i < r_GameManager.GameBoard.GetBoardSize(); i++)
            {

                for (int j = 1; j < r_GameManager.GameBoard.GetBoardSize(); j++)
                {

                    PlayButton playbleButton = new PlayButton(i, j);

                    if (r_GameManager.PlayerTwo.IsAiPlayer)
                    {
                        r_PlaybleButtons[i, j] = playbleButton;
                    }

                    playbleButton.Size = new Size(k_ButtonSize, k_ButtonSize);
                    playbleButton.Location = new Point(k_StartPosition + (k_ButtonSize + k_ButtonSpacing) * (i - 1), k_StartPosition + (k_ButtonSize + k_ButtonSpacing) * (j - 1));
                    playbleButton.Click += this.playButton_Click;
                    playbleButton.TabStop = false;
                    this.Controls.Add(playbleButton);

                }
            }
        }

        private void setPlayerLabels(int i_WindowWidth)
        {

            const int k_LabelsSpacing = 5;
            r_PlayerOneLabel.Text = string.Format("{0}: {1}", r_GameManager.PlayerOne.Name, r_GameManager.PlayerOne.Score);
            r_PlayerOneLabel.AutoSize = true;
            int r_PlayerOneLabelXPoisiton = (i_WindowWidth - r_PlayerOneLabel.Width) / 2;
            r_PlayerOneLabel.Location = new Point(r_PlayerOneLabelXPoisiton, i_WindowWidth);
            r_PlayerTwoLabel.Text = string.Format("{0}: {1}", r_GameManager.PlayerTwo.Name, r_GameManager.PlayerTwo.Score);
            r_PlayerTwoLabel.AutoSize = true;
            r_PlayerTwoLabel.Location = new Point(r_PlayerOneLabelXPoisiton + r_PlayerOneLabel.Width + k_LabelsSpacing, i_WindowWidth);
            setCurrentPlayerLabelTurn();

        }

        private void setCurrentPlayerLabelTurn()
        {

            string currentPlayersTurnName = r_GameManager.CurrentPlayersTurn.Name;

            if (currentPlayersTurnName.Equals(r_PlayerOneLabel.Text.Split(':')[0]))
            {

                r_PlayerOneLabel.Font = new Font(r_PlayerOneLabel.Font, FontStyle.Bold);
                r_PlayerTwoLabel.Font = new Font(r_PlayerTwoLabel.Font, FontStyle.Regular);
            }

            else
            {

                r_PlayerOneLabel.Font = new Font(r_PlayerOneLabel.Font, FontStyle.Regular);
                r_PlayerTwoLabel.Font = new Font(r_PlayerTwoLabel.Font, FontStyle.Bold);
            }

        }

        private void playButton_Click(object sender, EventArgs e)
        {

            PlayButton clickedCell = sender as PlayButton;
            this.r_GameManager.PlacePlayerCell(clickedCell.ButtonPosition);
            clickedCell.Text = r_GameManager.CurrentPlayersTurn.PlayerSymbol.ToString();
            clickedCell.Enabled = false;
            this.r_GameManager.ChangeTurn();

            if (r_GameManager.IsLossingMove(clickedCell.ButtonPosition))
            {

                string message =  string.Format(@"The winner is {0}
Would you like to play another round?", r_GameManager.CurrentPlayersTurn.Name);
                string title = "A Win!";
                r_GameManager.AddPoint();
                endGame(message, title);                

            }

            else if (r_GameManager.CurrentPlayersTurn.IsAiPlayer)
            {
                AiMove();
            }            

            else if (r_GameManager.IsBoardFull())
            {

                string title = "A Tie!";
                string message = @"Tie!
Would you like to play another round?";
                endGame(message, title);

            }
            setCurrentPlayerLabelTurn();

            
        }

        private void AiMove()
        {
            Coordinate aiMoveCoordiante = r_GameManager.AiMove();
            r_PlaybleButtons[aiMoveCoordiante.Row, aiMoveCoordiante.Column].PerformClick();
        }


        private void endGame(string i_Message, string i_Title)
        {

            DialogResult endGameDialog = MessageBox.Show(i_Message, i_Title, MessageBoxButtons.YesNo);

            switch (endGameDialog)
            {
                case DialogResult.Yes:
                    resetGame();
                    break;
                case DialogResult.No:
                    Close();
                    break;
            }
        }


        private void resetGame()
        {

            r_GameManager.Reset();
            foreach(Control control in Controls)
            {

                if (control is PlayButton playbeButton)
                {

                    playbeButton.Text = "";
                    playbeButton.Enabled = true;
                }

            }

            setPlayerLabels(this.ClientSize.Width);
        }

    }
}

