namespace Client
{
    partial class Sef
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnEmite = new System.Windows.Forms.Button();
            this.btnGest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.anguserText = new System.Windows.Forms.TextBox();
            this.sarcinaText = new System.Windows.Forms.TextBox();
            this.btnActualiz = new System.Windows.Forms.Button();
            this.btnActSar = new System.Windows.Forms.Button();
            this.btnlogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(445, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tabelul angajatilor activi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tabelul sarcinilor";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(33, 327);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(445, 150);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // btnEmite
            // 
            this.btnEmite.Location = new System.Drawing.Point(600, 311);
            this.btnEmite.Name = "btnEmite";
            this.btnEmite.Size = new System.Drawing.Size(124, 32);
            this.btnEmite.TabIndex = 4;
            this.btnEmite.Text = "Emite Sarcina";
            this.btnEmite.UseVisualStyleBackColor = true;
            this.btnEmite.Click += new System.EventHandler(this.btnEmite_Click);
            // 
            // btnGest
            // 
            this.btnGest.Location = new System.Drawing.Point(600, 393);
            this.btnGest.Name = "btnGest";
            this.btnGest.Size = new System.Drawing.Size(124, 31);
            this.btnGest.TabIndex = 5;
            this.btnGest.Text = "Gestioneaza";
            this.btnGest.UseVisualStyleBackColor = true;
            this.btnGest.Click += new System.EventHandler(this.btnGest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "User Angajat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(555, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sarcina";
            // 
            // anguserText
            // 
            this.anguserText.Location = new System.Drawing.Point(672, 125);
            this.anguserText.Name = "anguserText";
            this.anguserText.Size = new System.Drawing.Size(100, 22);
            this.anguserText.TabIndex = 8;
            // 
            // sarcinaText
            // 
            this.sarcinaText.Location = new System.Drawing.Point(672, 178);
            this.sarcinaText.Name = "sarcinaText";
            this.sarcinaText.Size = new System.Drawing.Size(100, 22);
            this.sarcinaText.TabIndex = 9;
            // 
            // btnActualiz
            // 
            this.btnActualiz.Location = new System.Drawing.Point(302, 22);
            this.btnActualiz.Name = "btnActualiz";
            this.btnActualiz.Size = new System.Drawing.Size(157, 33);
            this.btnActualiz.TabIndex = 10;
            this.btnActualiz.Text = "Actualizeaza Angajati";
            this.btnActualiz.UseVisualStyleBackColor = true;
            this.btnActualiz.Click += new System.EventHandler(this.btnActualiz_Click);
            // 
            // btnActSar
            // 
            this.btnActSar.Location = new System.Drawing.Point(302, 266);
            this.btnActSar.Name = "btnActSar";
            this.btnActSar.Size = new System.Drawing.Size(157, 31);
            this.btnActSar.TabIndex = 11;
            this.btnActSar.Text = "Actualizeaza Sarcini";
            this.btnActSar.UseVisualStyleBackColor = true;
            this.btnActSar.Click += new System.EventHandler(this.btnActSar_Click);
            // 
            // btnlogout
            // 
            this.btnlogout.Location = new System.Drawing.Point(692, 466);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(122, 36);
            this.btnlogout.TabIndex = 12;
            this.btnlogout.Text = "Logout";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // Sef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 530);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.btnActSar);
            this.Controls.Add(this.btnActualiz);
            this.Controls.Add(this.sarcinaText);
            this.Controls.Add(this.anguserText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGest);
            this.Controls.Add(this.btnEmite);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Sef";
            this.Text = "Sef";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnEmite;
        private System.Windows.Forms.Button btnGest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox anguserText;
        private System.Windows.Forms.TextBox sarcinaText;
        private System.Windows.Forms.Button btnActualiz;
        private System.Windows.Forms.Button btnActSar;
        private System.Windows.Forms.Button btnlogout;
    }
}