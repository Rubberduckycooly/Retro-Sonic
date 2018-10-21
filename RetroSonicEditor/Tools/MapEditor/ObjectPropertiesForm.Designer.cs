namespace RetroSonicEditor.Tools.MapEditor
{
    partial class ObjectPropertiesForm
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
            this.Byte5NUD = new System.Windows.Forms.NumericUpDown();
            this.Byte5Label = new System.Windows.Forms.Label();
            this.Byte4NUD = new System.Windows.Forms.NumericUpDown();
            this.Byte4Label = new System.Windows.Forms.Label();
            this.Byte3NUD = new System.Windows.Forms.NumericUpDown();
            this.Byte3Label = new System.Windows.Forms.Label();
            this.Byte2NUD = new System.Windows.Forms.NumericUpDown();
            this.Byte2Label = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.Byte1NUD = new System.Windows.Forms.NumericUpDown();
            this.Byte1Label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Byte5NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Byte4NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Byte3NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Byte2NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Byte1NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Byte5NUD);
            this.panel1.Controls.Add(this.Byte5Label);
            this.panel1.Controls.Add(this.Byte4NUD);
            this.panel1.Controls.Add(this.Byte4Label);
            this.panel1.Controls.Add(this.Byte3NUD);
            this.panel1.Controls.Add(this.Byte3Label);
            this.panel1.Controls.Add(this.Byte2NUD);
            this.panel1.Controls.Add(this.Byte2Label);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Controls.Add(this.Byte1NUD);
            this.panel1.Controls.Add(this.Byte1Label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 227);
            this.panel1.TabIndex = 0;
            // 
            // Byte5NUD
            // 
            this.Byte5NUD.Location = new System.Drawing.Point(136, 125);
            this.Byte5NUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Byte5NUD.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.Byte5NUD.Name = "Byte5NUD";
            this.Byte5NUD.Size = new System.Drawing.Size(80, 22);
            this.Byte5NUD.TabIndex = 17;
            this.Byte5NUD.ValueChanged += new System.EventHandler(this.Byte5NUD_ValueChanged);
            // 
            // Byte5Label
            // 
            this.Byte5Label.AutoSize = true;
            this.Byte5Label.Location = new System.Drawing.Point(13, 125);
            this.Byte5Label.Name = "Byte5Label";
            this.Byte5Label.Size = new System.Drawing.Size(117, 17);
            this.Byte5Label.TabIndex = 16;
            this.Byte5Label.Text = "Position Offset Y:";
            // 
            // Byte4NUD
            // 
            this.Byte4NUD.Location = new System.Drawing.Point(136, 97);
            this.Byte4NUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Byte4NUD.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.Byte4NUD.Name = "Byte4NUD";
            this.Byte4NUD.Size = new System.Drawing.Size(80, 22);
            this.Byte4NUD.TabIndex = 15;
            this.Byte4NUD.ValueChanged += new System.EventHandler(this.Byte4NUD_ValueChanged);
            // 
            // Byte4Label
            // 
            this.Byte4Label.AutoSize = true;
            this.Byte4Label.Location = new System.Drawing.Point(13, 97);
            this.Byte4Label.Name = "Byte4Label";
            this.Byte4Label.Size = new System.Drawing.Size(119, 17);
            this.Byte4Label.TabIndex = 14;
            this.Byte4Label.Text = "Chunk Position Y:";
            // 
            // Byte3NUD
            // 
            this.Byte3NUD.Location = new System.Drawing.Point(136, 69);
            this.Byte3NUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Byte3NUD.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.Byte3NUD.Name = "Byte3NUD";
            this.Byte3NUD.Size = new System.Drawing.Size(80, 22);
            this.Byte3NUD.TabIndex = 13;
            this.Byte3NUD.ValueChanged += new System.EventHandler(this.Byte3NUD_ValueChanged);
            // 
            // Byte3Label
            // 
            this.Byte3Label.AutoSize = true;
            this.Byte3Label.Location = new System.Drawing.Point(13, 69);
            this.Byte3Label.Name = "Byte3Label";
            this.Byte3Label.Size = new System.Drawing.Size(117, 17);
            this.Byte3Label.TabIndex = 12;
            this.Byte3Label.Text = "Position Offset X:";
            // 
            // Byte2NUD
            // 
            this.Byte2NUD.Location = new System.Drawing.Point(136, 41);
            this.Byte2NUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Byte2NUD.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.Byte2NUD.Name = "Byte2NUD";
            this.Byte2NUD.Size = new System.Drawing.Size(80, 22);
            this.Byte2NUD.TabIndex = 11;
            this.Byte2NUD.ValueChanged += new System.EventHandler(this.Byte2NUD_ValueChanged);
            // 
            // Byte2Label
            // 
            this.Byte2Label.AutoSize = true;
            this.Byte2Label.Location = new System.Drawing.Point(13, 41);
            this.Byte2Label.Name = "Byte2Label";
            this.Byte2Label.Size = new System.Drawing.Size(119, 17);
            this.Byte2Label.TabIndex = 10;
            this.Byte2Label.Text = "Chunk Position X:";
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(88, 201);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(73, 23);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(167, 201);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(112, 23);
            this.OKButton.TabIndex = 8;
            this.OKButton.Text = "Save Object!";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // Byte1NUD
            // 
            this.Byte1NUD.Location = new System.Drawing.Point(136, 13);
            this.Byte1NUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Byte1NUD.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.Byte1NUD.Name = "Byte1NUD";
            this.Byte1NUD.Size = new System.Drawing.Size(80, 22);
            this.Byte1NUD.TabIndex = 4;
            this.Byte1NUD.ValueChanged += new System.EventHandler(this.Byte1NUD_ValueChanged);
            // 
            // Byte1Label
            // 
            this.Byte1Label.AutoSize = true;
            this.Byte1Label.Location = new System.Drawing.Point(13, 13);
            this.Byte1Label.Name = "Byte1Label";
            this.Byte1Label.Size = new System.Drawing.Size(44, 17);
            this.Byte1Label.TabIndex = 0;
            this.Byte1Label.Text = "Type:";
            // 
            // ObjectPropertiesForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 227);
            this.Controls.Add(this.panel1);
            this.Name = "ObjectPropertiesForm";
            this.Text = "Object Properties";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Byte5NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Byte4NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Byte3NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Byte2NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Byte1NUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.NumericUpDown Byte1NUD;
        private System.Windows.Forms.Label Byte1Label;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        public System.Windows.Forms.NumericUpDown Byte5NUD;
        private System.Windows.Forms.Label Byte5Label;
        public System.Windows.Forms.NumericUpDown Byte4NUD;
        private System.Windows.Forms.Label Byte4Label;
        public System.Windows.Forms.NumericUpDown Byte3NUD;
        private System.Windows.Forms.Label Byte3Label;
        public System.Windows.Forms.NumericUpDown Byte2NUD;
        private System.Windows.Forms.Label Byte2Label;
    }
}