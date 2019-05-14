namespace MailClietn
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
            this.LogButt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.LogOut = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.ToBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ThemeBox = new System.Windows.Forms.TextBox();
            this.MessBox = new System.Windows.Forms.TextBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LogButt
            // 
            this.LogButt.Location = new System.Drawing.Point(546, 13);
            this.LogButt.Name = "LogButt";
            this.LogButt.Size = new System.Drawing.Size(121, 23);
            this.LogButt.TabIndex = 1;
            this.LogButt.Text = "LogIn";
            this.LogButt.UseVisualStyleBackColor = true;
            this.LogButt.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PassBox
            // 
            this.PassBox.Location = new System.Drawing.Point(338, 13);
            this.PassBox.Name = "PassBox";
            this.PassBox.PasswordChar = '$';
            this.PassBox.Size = new System.Drawing.Size(184, 20);
            this.PassBox.TabIndex = 3;
            this.PassBox.UseSystemPasswordChar = true;
            this.PassBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(60, 13);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(213, 20);
            this.LoginBox.TabIndex = 5;
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(12, 10);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(655, 23);
            this.LogOut.TabIndex = 6;
            this.LogOut.Text = "LogOut";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Visible = false;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(12, 39);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(655, 25);
            this.Send.TabIndex = 7;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // ToBox
            // 
            this.ToBox.Location = new System.Drawing.Point(60, 68);
            this.ToBox.Name = "ToBox";
            this.ToBox.Size = new System.Drawing.Size(607, 20);
            this.ToBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "To:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Theme:";
            // 
            // ThemeBox
            // 
            this.ThemeBox.Location = new System.Drawing.Point(60, 94);
            this.ThemeBox.Name = "ThemeBox";
            this.ThemeBox.Size = new System.Drawing.Size(607, 20);
            this.ThemeBox.TabIndex = 10;
            // 
            // MessBox
            // 
            this.MessBox.Location = new System.Drawing.Point(12, 120);
            this.MessBox.Multiline = true;
            this.MessBox.Name = "MessBox";
            this.MessBox.Size = new System.Drawing.Size(424, 213);
            this.MessBox.TabIndex = 12;
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(442, 120);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(225, 213);
            this.LogBox.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 337);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.MessBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ThemeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ToBox);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogButt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogButt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox ToBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ThemeBox;
        private System.Windows.Forms.TextBox MessBox;
        private System.Windows.Forms.TextBox LogBox;
    }
}

