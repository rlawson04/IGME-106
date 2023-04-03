namespace Exam2_Part2
{
    partial class Form1
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
            dealCards = new Button();
            mainLabel = new Label();
            clearButton = new Button();
            userInputBox = new TextBox();
            mainTextBox = new TextBox();
            SuspendLayout();
            // 
            // dealCards
            // 
            dealCards.BackColor = SystemColors.ControlLightLight;
            dealCards.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dealCards.Location = new Point(270, 526);
            dealCards.Margin = new Padding(4);
            dealCards.Name = "dealCards";
            dealCards.Size = new Size(193, 70);
            dealCards.TabIndex = 2;
            dealCards.Text = "Deal Cards";
            dealCards.UseVisualStyleBackColor = false;
            dealCards.Click += dealCards_Click;
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mainLabel.Location = new Point(163, 69);
            mainLabel.Margin = new Padding(4, 0, 4, 0);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(186, 21);
            mainLabel.TabIndex = 3;
            mainLabel.Text = "Number of Cards to Deal:\r\n";
            // 
            // clearButton
            // 
            clearButton.BackColor = SystemColors.ControlLightLight;
            clearButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            clearButton.Location = new Point(607, 526);
            clearButton.Margin = new Padding(4);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(193, 70);
            clearButton.TabIndex = 4;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += clearButton_Click;
            // 
            // userInputBox
            // 
            userInputBox.Location = new Point(380, 69);
            userInputBox.Margin = new Padding(4);
            userInputBox.Name = "userInputBox";
            userInputBox.Size = new Size(127, 29);
            userInputBox.TabIndex = 5;
            // 
            // mainTextBox
            // 
            mainTextBox.BackColor = SystemColors.ActiveCaption;
            mainTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mainTextBox.Location = new Point(60, 151);
            mainTextBox.Margin = new Padding(4);
            mainTextBox.Multiline = true;
            mainTextBox.Name = "mainTextBox";
            mainTextBox.ReadOnly = true;
            mainTextBox.ScrollBars = ScrollBars.Vertical;
            mainTextBox.Size = new Size(926, 353);
            mainTextBox.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1029, 630);
            Controls.Add(mainTextBox);
            Controls.Add(userInputBox);
            Controls.Add(clearButton);
            Controls.Add(mainLabel);
            Controls.Add(dealCards);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Deal Cards";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button dealCards;
        private Label mainLabel;
        private Button clearButton;
        private TextBox userInputBox;
        private TextBox mainTextBox;
    }
}