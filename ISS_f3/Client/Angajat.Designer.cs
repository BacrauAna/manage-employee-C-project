namespace Client
{
    partial class Angajat
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPreiaS = new System.Windows.Forms.Button();
            this.btnUpdS = new System.Windows.Forms.Button();
            this.btnTrimiteS = new System.Windows.Forms.Button();
            this.btnlogout = new System.Windows.Forms.Button();
            this.btnSarcininoi = new System.Windows.Forms.Button();
            this.textId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(49, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(423, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(49, 309);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(337, 155);
            this.dataGridView2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tabelul De Sarcini";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stari";
            // 
            // btnPreiaS
            // 
            this.btnPreiaS.Location = new System.Drawing.Point(584, 106);
            this.btnPreiaS.Name = "btnPreiaS";
            this.btnPreiaS.Size = new System.Drawing.Size(113, 31);
            this.btnPreiaS.TabIndex = 4;
            this.btnPreiaS.Text = "Preia Sarcina";
            this.btnPreiaS.UseVisualStyleBackColor = true;
            this.btnPreiaS.Click += new System.EventHandler(this.btnPreiaS_Click);
            // 
            // btnUpdS
            // 
            this.btnUpdS.Location = new System.Drawing.Point(584, 201);
            this.btnUpdS.Name = "btnUpdS";
            this.btnUpdS.Size = new System.Drawing.Size(113, 34);
            this.btnUpdS.TabIndex = 5;
            this.btnUpdS.Text = "UpdateStare";
            this.btnUpdS.UseVisualStyleBackColor = true;
            this.btnUpdS.Click += new System.EventHandler(this.btnUpdS_Click);
            // 
            // btnTrimiteS
            // 
            this.btnTrimiteS.Location = new System.Drawing.Point(584, 288);
            this.btnTrimiteS.Name = "btnTrimiteS";
            this.btnTrimiteS.Size = new System.Drawing.Size(113, 37);
            this.btnTrimiteS.TabIndex = 6;
            this.btnTrimiteS.Text = "Trimite Sarcina";
            this.btnTrimiteS.UseVisualStyleBackColor = true;
            this.btnTrimiteS.Click += new System.EventHandler(this.btnTrimiteS_Click);
            // 
            // btnlogout
            // 
            this.btnlogout.Location = new System.Drawing.Point(584, 384);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(113, 34);
            this.btnlogout.TabIndex = 7;
            this.btnlogout.Text = "Logout";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // btnSarcininoi
            // 
            this.btnSarcininoi.Location = new System.Drawing.Point(298, 24);
            this.btnSarcininoi.Name = "btnSarcininoi";
            this.btnSarcininoi.Size = new System.Drawing.Size(132, 29);
            this.btnSarcininoi.TabIndex = 8;
            this.btnSarcininoi.Text = "Sarcini noi";
            this.btnSarcininoi.UseVisualStyleBackColor = true;
            this.btnSarcininoi.Click += new System.EventHandler(this.btnSarcininoi_Click);
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(332, 251);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(54, 22);
            this.textId.TabIndex = 9;
            // 
            // Angajat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 486);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.btnSarcininoi);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.btnTrimiteS);
            this.Controls.Add(this.btnUpdS);
            this.Controls.Add(this.btnPreiaS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Angajat";
            this.Text = "Angajat";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPreiaS;
        private System.Windows.Forms.Button btnUpdS;
        private System.Windows.Forms.Button btnTrimiteS;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Button btnSarcininoi;
        private System.Windows.Forms.TextBox textId;
    }
}