namespace Perceptron
{
    partial class PerceptronParametersSeter
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
            this.sinaps_field_width = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.sinaps_field_height = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hidden_layers_count = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.hidden_layer_size = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.epsUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.sinaps_field_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinaps_field_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hidden_layers_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hidden_layer_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // sinaps_field_width
            // 
            this.sinaps_field_width.Location = new System.Drawing.Point(129, 7);
            this.sinaps_field_width.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.sinaps_field_width.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.sinaps_field_width.Name = "sinaps_field_width";
            this.sinaps_field_width.Size = new System.Drawing.Size(47, 20);
            this.sinaps_field_width.TabIndex = 0;
            this.sinaps_field_width.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "x";
            // 
            // sinaps_field_height
            // 
            this.sinaps_field_height.Location = new System.Drawing.Point(200, 7);
            this.sinaps_field_height.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.sinaps_field_height.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.sinaps_field_height.Name = "sinaps_field_height";
            this.sinaps_field_height.Size = new System.Drawing.Size(47, 20);
            this.sinaps_field_height.TabIndex = 2;
            this.sinaps_field_height.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sinaps field size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hidden layers count";
            // 
            // hidden_layers_count
            // 
            this.hidden_layers_count.Location = new System.Drawing.Point(129, 42);
            this.hidden_layers_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hidden_layers_count.Name = "hidden_layers_count";
            this.hidden_layers_count.Size = new System.Drawing.Size(47, 20);
            this.hidden_layers_count.TabIndex = 4;
            this.hidden_layers_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hidden layer size";
            // 
            // hidden_layer_size
            // 
            this.hidden_layer_size.Location = new System.Drawing.Point(129, 70);
            this.hidden_layer_size.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.hidden_layer_size.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.hidden_layer_size.Name = "hidden_layer_size";
            this.hidden_layer_size.Size = new System.Drawing.Size(47, 20);
            this.hidden_layer_size.TabIndex = 8;
            this.hidden_layer_size.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Out layer respone to leters in Study Set.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "View Study Set";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "(accuracy) eps";
            // 
            // epsUpDown
            // 
            this.epsUpDown.DecimalPlaces = 4;
            this.epsUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.epsUpDown.Location = new System.Drawing.Point(129, 101);
            this.epsUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.epsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.epsUpDown.Name = "epsUpDown";
            this.epsUpDown.Size = new System.Drawing.Size(65, 20);
            this.epsUpDown.TabIndex = 18;
            this.epsUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            // 
            // PerceptronParametersSeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 196);
            this.Controls.Add(this.epsUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hidden_layer_size);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hidden_layers_count);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sinaps_field_height);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sinaps_field_width);
            this.Name = "PerceptronParametersSeter";
            this.Text = "PerceptronParametersSeter";
            this.Load += new System.EventHandler(this.PerceptronParametersSeter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sinaps_field_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinaps_field_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hidden_layers_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hidden_layer_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epsUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown sinaps_field_width;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown sinaps_field_height;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown hidden_layers_count;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown hidden_layer_size;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown epsUpDown;
    }
}