namespace GameGui
{
    partial class FormGameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.playerOneNameTextBox = new System.Windows.Forms.TextBox();
            this.playerTwoNameTextBox = new System.Windows.Forms.TextBox();
            this.enablePlayerCheckBox = new System.Windows.Forms.CheckBox();
            this.nUDCols = new System.Windows.Forms.NumericUpDown();
            this.nUDRows = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(43, 188);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(153, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Player 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Player 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Board Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cols:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Rows:";
            // 
            // playerOneNameTextBox
            // 
            this.playerOneNameTextBox.Location = new System.Drawing.Point(107, 50);
            this.playerOneNameTextBox.Name = "playerOneNameTextBox";
            this.playerOneNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.playerOneNameTextBox.TabIndex = 7;
            // 
            // playerTwoNameTextBox
            // 
            this.playerTwoNameTextBox.Enabled = false;
            this.playerTwoNameTextBox.Location = new System.Drawing.Point(107, 78);
            this.playerTwoNameTextBox.Name = "playerTwoNameTextBox";
            this.playerTwoNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.playerTwoNameTextBox.TabIndex = 8;
            this.playerTwoNameTextBox.Text = "[Computer]";
            // 
            // enablePlayerCheckBox
            // 
            this.enablePlayerCheckBox.AutoSize = true;
            this.enablePlayerCheckBox.Location = new System.Drawing.Point(32, 80);
            this.enablePlayerCheckBox.Name = "enablePlayerCheckBox";
            this.enablePlayerCheckBox.Size = new System.Drawing.Size(15, 14);
            this.enablePlayerCheckBox.TabIndex = 9;
            this.enablePlayerCheckBox.UseVisualStyleBackColor = true;
            this.enablePlayerCheckBox.CheckedChanged += new System.EventHandler(this.enablePlayerCheckBox_CheckedChanged);
            // 
            // nUDCols
            // 
            this.nUDCols.Location = new System.Drawing.Point(166, 150);
            this.nUDCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDCols.Name = "nUDCols";
            this.nUDCols.Size = new System.Drawing.Size(40, 20);
            this.nUDCols.TabIndex = 11;
            this.nUDCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDCols.ValueChanged += new System.EventHandler(this.nUDCols_ValueChanged);
            // 
            // nUDRows
            // 
            this.nUDRows.Location = new System.Drawing.Point(74, 150);
            this.nUDRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDRows.Name = "nUDRows";
            this.nUDRows.Size = new System.Drawing.Size(40, 20);
            this.nUDRows.TabIndex = 12;
            this.nUDRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDRows.ValueChanged += new System.EventHandler(this.nUDRows_ValueChanged);
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 223);
            this.Controls.Add(this.nUDRows);
            this.Controls.Add(this.nUDCols);
            this.Controls.Add(this.enablePlayerCheckBox);
            this.Controls.Add(this.playerTwoNameTextBox);
            this.Controls.Add(this.playerOneNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.ShowIcon = false;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.FormGameSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox playerOneNameTextBox;
        private System.Windows.Forms.TextBox playerTwoNameTextBox;
        private System.Windows.Forms.CheckBox enablePlayerCheckBox;
        private System.Windows.Forms.NumericUpDown nUDCols;
        private System.Windows.Forms.NumericUpDown nUDRows;
    }
}