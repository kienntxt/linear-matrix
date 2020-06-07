namespace CalcTools
{
    partial class MainFrm
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.panInput = new System.Windows.Forms.Panel();
            this.radDistance = new System.Windows.Forms.RadioButton();
            this.radArea = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.panCalc = new System.Windows.Forms.Panel();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panInput.SuspendLayout();
            this.panCalc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "> &Value";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtValue.Location = new System.Drawing.Point(345, 14);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(111, 20);
            this.txtValue.TabIndex = 3;
            // 
            // btnInput
            // 
            this.btnInput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInput.Location = new System.Drawing.Point(462, 12);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(111, 23);
            this.btnInput.TabIndex = 4;
            this.btnInput.Text = "&Add";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // panInput
            // 
            this.panInput.Controls.Add(this.radDistance);
            this.panInput.Controls.Add(this.radArea);
            this.panInput.Controls.Add(this.btnClear);
            this.panInput.Controls.Add(this.btnSave);
            this.panInput.Controls.Add(this.btnLoad);
            this.panInput.Controls.Add(this.btnInput);
            this.panInput.Controls.Add(this.txtValue);
            this.panInput.Controls.Add(this.label3);
            this.panInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panInput.Location = new System.Drawing.Point(0, 0);
            this.panInput.Name = "panInput";
            this.panInput.Size = new System.Drawing.Size(678, 76);
            this.panInput.TabIndex = 0;
            // 
            // radDistance
            // 
            this.radDistance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radDistance.AutoSize = true;
            this.radDistance.Location = new System.Drawing.Point(190, 15);
            this.radDistance.Name = "radDistance";
            this.radDistance.Size = new System.Drawing.Size(100, 17);
            this.radDistance.TabIndex = 1;
            this.radDistance.Text = "Distance (&K - m)";
            this.radDistance.UseVisualStyleBackColor = true;
            // 
            // radArea
            // 
            this.radArea.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radArea.AutoSize = true;
            this.radArea.Checked = true;
            this.radArea.Location = new System.Drawing.Point(99, 15);
            this.radArea.Name = "radArea";
            this.radArea.Size = new System.Drawing.Size(85, 17);
            this.radArea.TabIndex = 0;
            this.radArea.TabStop = true;
            this.radArea.Text = "Area (&R - ha)";
            this.radArea.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.Location = new System.Drawing.Point(462, 41);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panCalc
            // 
            this.panCalc.Controls.Add(this.btnCalculate);
            this.panCalc.Controls.Add(this.txtLevel);
            this.panCalc.Controls.Add(this.label4);
            this.panCalc.Controls.Add(this.txtDistance);
            this.panCalc.Controls.Add(this.label2);
            this.panCalc.Controls.Add(this.txtArea);
            this.panCalc.Controls.Add(this.label1);
            this.panCalc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panCalc.Location = new System.Drawing.Point(0, 341);
            this.panCalc.Name = "panCalc";
            this.panCalc.Size = new System.Drawing.Size(678, 50);
            this.panCalc.TabIndex = 2;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCalculate.Location = new System.Drawing.Point(359, 16);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(111, 23);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "&Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtLevel
            // 
            this.txtLevel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLevel.Location = new System.Drawing.Point(529, 18);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new System.Drawing.Size(100, 20);
            this.txtLevel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(475, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = ">> Level";
            // 
            // txtDistance
            // 
            this.txtDistance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDistance.Location = new System.Drawing.Point(253, 18);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(100, 20);
            this.txtDistance.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Distance";
            // 
            // txtArea
            // 
            this.txtArea.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtArea.Location = new System.Drawing.Point(88, 18);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(100, 20);
            this.txtArea.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ar&ea";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 76);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 100;
            this.dgvData.Size = new System.Drawing.Size(678, 265);
            this.dgvData.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoad.Location = new System.Drawing.Point(228, 41);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(111, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(345, 41);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 391);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panCalc);
            this.Controls.Add(this.panInput);
            this.Name = "MainFrm";
            this.Text = "Water level calculator";
            this.panInput.ResumeLayout(false);
            this.panInput.PerformLayout();
            this.panCalc.ResumeLayout(false);
            this.panCalc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panInput;
        private System.Windows.Forms.Panel panCalc;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.RadioButton radDistance;
        private System.Windows.Forms.RadioButton radArea;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}

