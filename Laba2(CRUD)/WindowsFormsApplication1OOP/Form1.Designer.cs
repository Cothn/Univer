namespace CRUD_OOP2
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
            this.ListView1 = new System.Windows.Forms.ListView();
            this.Create = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.ObjectBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ListView1
            // 
            this.ListView1.Location = new System.Drawing.Point(3, 4);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(327, 273);
            this.ListView1.TabIndex = 0;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.List;
            // 
            // Create
            // 
            this.Create.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Create.Location = new System.Drawing.Point(336, 4);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(161, 29);
            this.Create.TabIndex = 1;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = false;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Edit.Location = new System.Drawing.Point(336, 40);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(80, 31);
            this.Edit.TabIndex = 2;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Delete.Location = new System.Drawing.Point(422, 40);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 31);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // ObjectBox
            // 
            this.ObjectBox.FormattingEnabled = true;
            this.ObjectBox.Location = new System.Drawing.Point(336, 78);
            this.ObjectBox.Name = "ObjectBox";
            this.ObjectBox.Size = new System.Drawing.Size(161, 21);
            this.ObjectBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(505, 279);
            this.Controls.Add(this.ObjectBox);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.ListView1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(521, 318);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListView1;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.ComboBox ObjectBox;
    }
}

