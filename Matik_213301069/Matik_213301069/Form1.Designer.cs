namespace Matik_213301069
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button2 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(323, 343);
            button1.Name = "button1";
            button1.Size = new Size(214, 86);
            button1.TabIndex = 0;
            button1.Text = "Oyuna Giriş";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(193, 9);
            label1.Name = "label1";
            label1.Size = new Size(435, 74);
            label1.TabIndex = 1;
            label1.Text = "MATİK OYUNU";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(245, 101);
            label2.Name = "label2";
            label2.Size = new Size(319, 37);
            label2.TabIndex = 2;
            label2.Text = "OYUNA HOŞGELDİNİZ";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(325, 444);
            label3.Name = "label3";
            label3.Size = new Size(212, 50);
            label3.TabIndex = 3;
            label3.Text = "Başlamak için tıklayın  !\r\n\r\n";
            label3.Click += label3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(87, 266);
            button2.Name = "button2";
            button2.Size = new Size(109, 38);
            button2.TabIndex = 4;
            button2.Text = "Nasıl Oynanır";
            button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(51, 234);
            label4.Name = "label4";
            label4.Size = new Size(206, 29);
            label4.TabIndex = 5;
            label4.Text = "Oyun Kuralları";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 503);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button2;
        private Label label4;
    }
}