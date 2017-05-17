namespace Train_game
{
    partial class Form2
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
            this.stoneNumber = new System.Windows.Forms.NumericUpDown();
            this.saveStones = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playerName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.stoneNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // stoneNumber
            // 
            this.stoneNumber.Location = new System.Drawing.Point(93, 17);
            this.stoneNumber.Name = "stoneNumber";
            this.stoneNumber.Size = new System.Drawing.Size(89, 20);
            this.stoneNumber.TabIndex = 0;
            // 
            // saveStones
            // 
            this.saveStones.Location = new System.Drawing.Point(74, 91);
            this.saveStones.Name = "saveStones";
            this.saveStones.Size = new System.Drawing.Size(90, 27);
            this.saveStones.TabIndex = 1;
            this.saveStones.Text = "Set game";
            this.saveStones.UseVisualStyleBackColor = true;
            this.saveStones.Click += new System.EventHandler(this.saveStones_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stones:";
            // 
            // playerName
            // 
            this.playerName.Location = new System.Drawing.Point(93, 51);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(89, 20);
            this.playerName.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 130);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveStones);
            this.Controls.Add(this.stoneNumber);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.stoneNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown stoneNumber;
        private System.Windows.Forms.Button saveStones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox playerName;
    }
}