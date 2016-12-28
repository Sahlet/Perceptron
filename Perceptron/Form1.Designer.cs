namespace Perceptron
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.add_to_study_set_button = new System.Windows.Forms.Button();
            this.clean_picture_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.draw_button = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.identify_picture_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPictureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SavePictureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPerceptronMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SavePerceptronToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studySetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStudySetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perceptronToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.add_to_study_set_button);
            this.panel1.Controls.Add(this.clean_picture_button);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.draw_button);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.identify_picture_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(367, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 333);
            this.panel1.TabIndex = 0;
            // 
            // add_to_study_set_button
            // 
            this.add_to_study_set_button.Enabled = false;
            this.add_to_study_set_button.Location = new System.Drawing.Point(7, 254);
            this.add_to_study_set_button.Name = "add_to_study_set_button";
            this.add_to_study_set_button.Size = new System.Drawing.Size(96, 23);
            this.add_to_study_set_button.TabIndex = 7;
            this.add_to_study_set_button.Text = "add to Study Set";
            this.add_to_study_set_button.UseVisualStyleBackColor = true;
            this.add_to_study_set_button.Click += new System.EventHandler(this.add_to_study_set_button_Click);
            // 
            // clean_picture_button
            // 
            this.clean_picture_button.Enabled = false;
            this.clean_picture_button.Location = new System.Drawing.Point(7, 98);
            this.clean_picture_button.Name = "clean_picture_button";
            this.clean_picture_button.Size = new System.Drawing.Size(52, 23);
            this.clean_picture_button.TabIndex = 6;
            this.clean_picture_button.Text = "clean";
            this.clean_picture_button.UseVisualStyleBackColor = true;
            this.clean_picture_button.Click += new System.EventHandler(this.clean_picture_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 228);
            this.textBox1.MaxLength = 1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // draw_button
            // 
            this.draw_button.Enabled = false;
            this.draw_button.Location = new System.Drawing.Point(7, 283);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(52, 23);
            this.draw_button.TabIndex = 4;
            this.draw_button.Text = "draw";
            this.draw_button.UseVisualStyleBackColor = true;
            this.draw_button.Click += new System.EventHandler(this.draw_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(7, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 90);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // identify_picture_button
            // 
            this.identify_picture_button.Enabled = false;
            this.identify_picture_button.Location = new System.Drawing.Point(7, 127);
            this.identify_picture_button.Name = "identify_picture_button";
            this.identify_picture_button.Size = new System.Drawing.Size(51, 23);
            this.identify_picture_button.TabIndex = 0;
            this.identify_picture_button.Text = " identify";
            this.identify_picture_button.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(367, 333);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.studySetToolStripMenuItem,
            this.perceptronToolStripMenuItem,
            this.fontToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(482, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadPictureMenuItem,
            this.SavePictureMenuItem,
            this.LoadPerceptronMenuItem,
            this.SavePerceptronToolStripMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileMenuItem.Text = "File";
            // 
            // LoadPictureMenuItem
            // 
            this.LoadPictureMenuItem.Name = "LoadPictureMenuItem";
            this.LoadPictureMenuItem.Size = new System.Drawing.Size(161, 22);
            this.LoadPictureMenuItem.Text = "Load Picture";
            this.LoadPictureMenuItem.Click += new System.EventHandler(this.LoadPictureMenuItem_Click);
            // 
            // SavePictureMenuItem
            // 
            this.SavePictureMenuItem.Name = "SavePictureMenuItem";
            this.SavePictureMenuItem.Size = new System.Drawing.Size(161, 22);
            this.SavePictureMenuItem.Text = "Sava Picture";
            this.SavePictureMenuItem.Click += new System.EventHandler(this.SavePictureMenuItem_Click);
            // 
            // LoadPerceptronMenuItem
            // 
            this.LoadPerceptronMenuItem.Name = "LoadPerceptronMenuItem";
            this.LoadPerceptronMenuItem.Size = new System.Drawing.Size(161, 22);
            this.LoadPerceptronMenuItem.Text = "Load Perceptron";
            // 
            // SavePerceptronToolStripMenuItem
            // 
            this.SavePerceptronToolStripMenuItem.Name = "SavePerceptronToolStripMenuItem";
            this.SavePerceptronToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.SavePerceptronToolStripMenuItem.Text = "Save Perceptron";
            // 
            // studySetToolStripMenuItem
            // 
            this.studySetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewStudySetToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.studySetToolStripMenuItem.Name = "studySetToolStripMenuItem";
            this.studySetToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.studySetToolStripMenuItem.Text = "Study Set";
            // 
            // viewStudySetToolStripMenuItem
            // 
            this.viewStudySetToolStripMenuItem.Name = "viewStudySetToolStripMenuItem";
            this.viewStudySetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewStudySetToolStripMenuItem.Text = "View";
            this.viewStudySetToolStripMenuItem.Click += new System.EventHandler(this.viewStudySetToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearToolStripMenuItem.Text = "Clean";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // perceptronToolStripMenuItem
            // 
            this.perceptronToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.studyToolStripMenuItem1,
            this.cleanToolStripMenuItem});
            this.perceptronToolStripMenuItem.Name = "perceptronToolStripMenuItem";
            this.perceptronToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.perceptronToolStripMenuItem.Text = "Perceptron";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // studyToolStripMenuItem1
            // 
            this.studyToolStripMenuItem1.Enabled = false;
            this.studyToolStripMenuItem1.Name = "studyToolStripMenuItem1";
            this.studyToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.studyToolStripMenuItem1.Text = "Study";
            // 
            // cleanToolStripMenuItem
            // 
            this.cleanToolStripMenuItem.Enabled = false;
            this.cleanToolStripMenuItem.Name = "cleanToolStripMenuItem";
            this.cleanToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.cleanToolStripMenuItem.Text = "Clean";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 357);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Perceptron";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadPictureMenuItem;
        private System.Windows.Forms.Button identify_picture_button;
        private System.Windows.Forms.ToolStripMenuItem SavePictureMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadPerceptronMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SavePerceptronToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button draw_button;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button clean_picture_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem studySetToolStripMenuItem;
        private System.Windows.Forms.Button add_to_study_set_button;
        private System.Windows.Forms.ToolStripMenuItem viewStudySetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perceptronToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cleanToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
    }
}

