namespace Neo4JApp
{
    partial class GlavnaForma
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
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRezervisi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxFilm = new System.Windows.Forms.ComboBox();
            this.cbxVreme = new System.Windows.Forms.ComboBox();
            this.cbxBioskop = new System.Windows.Forms.ComboBox();
            this.cbxSala = new System.Windows.Forms.ComboBox();
            this.cbxDatum = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(125, 213);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Izaberite film:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Izaberite bioskop:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(383, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 32);
            this.label4.TabIndex = 20;
            this.label4.Text = "Cinema Manager";
            // 
            // btnRezervisi
            // 
            this.btnRezervisi.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezervisi.Location = new System.Drawing.Point(201, 400);
            this.btnRezervisi.Margin = new System.Windows.Forms.Padding(4);
            this.btnRezervisi.Name = "btnRezervisi";
            this.btnRezervisi.Size = new System.Drawing.Size(164, 44);
            this.btnRezervisi.TabIndex = 19;
            this.btnRezervisi.Tag = "";
            this.btnRezervisi.Text = "Rezervisi!";
            this.btnRezervisi.UseVisualStyleBackColor = true;
            this.btnRezervisi.Click += new System.EventHandler(this.btnRezervisi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 312);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "Izaberite salu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(108, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "Izaberite datum:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(108, 265);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 23);
            this.label6.TabIndex = 26;
            this.label6.Text = "Izaberite vreme:";
            // 
            // cbxFilm
            // 
            this.cbxFilm.FormattingEnabled = true;
            this.cbxFilm.Location = new System.Drawing.Point(292, 214);
            this.cbxFilm.Margin = new System.Windows.Forms.Padding(4);
            this.cbxFilm.Name = "cbxFilm";
            this.cbxFilm.Size = new System.Drawing.Size(208, 24);
            this.cbxFilm.TabIndex = 27;
            this.cbxFilm.SelectedIndexChanged += new System.EventHandler(this.cbxFilm_SelectedIndexChanged);
            // 
            // cbxVreme
            // 
            this.cbxVreme.FormattingEnabled = true;
            this.cbxVreme.Location = new System.Drawing.Point(292, 266);
            this.cbxVreme.Margin = new System.Windows.Forms.Padding(4);
            this.cbxVreme.Name = "cbxVreme";
            this.cbxVreme.Size = new System.Drawing.Size(208, 24);
            this.cbxVreme.TabIndex = 28;
            this.cbxVreme.SelectedIndexChanged += new System.EventHandler(this.cbxVreme_SelectedIndexChanged);
            // 
            // cbxBioskop
            // 
            this.cbxBioskop.FormattingEnabled = true;
            this.cbxBioskop.Location = new System.Drawing.Point(292, 66);
            this.cbxBioskop.Margin = new System.Windows.Forms.Padding(4);
            this.cbxBioskop.Name = "cbxBioskop";
            this.cbxBioskop.Size = new System.Drawing.Size(208, 24);
            this.cbxBioskop.TabIndex = 29;
            this.cbxBioskop.SelectedIndexChanged += new System.EventHandler(this.cbxBioskop_SelectedIndexChanged);
            // 
            // cbxSala
            // 
            this.cbxSala.FormattingEnabled = true;
            this.cbxSala.Location = new System.Drawing.Point(292, 313);
            this.cbxSala.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSala.Name = "cbxSala";
            this.cbxSala.Size = new System.Drawing.Size(208, 24);
            this.cbxSala.TabIndex = 30;
            this.cbxSala.SelectedIndexChanged += new System.EventHandler(this.cbxSala_SelectedIndexChanged);
            // 
            // cbxDatum
            // 
            this.cbxDatum.FormattingEnabled = true;
            this.cbxDatum.Location = new System.Drawing.Point(292, 118);
            this.cbxDatum.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDatum.Name = "cbxDatum";
            this.cbxDatum.Size = new System.Drawing.Size(208, 24);
            this.cbxDatum.TabIndex = 31;
            this.cbxDatum.SelectedIndexChanged += new System.EventHandler(this.cbxDatum_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(292, 163);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(148, 27);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "Cekirajte za 3D";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(79, 163);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 23);
            this.label7.TabIndex = 33;
            this.label7.Text = "Izaberite projekciju:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(591, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(471, 489);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Izaberite sedista:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(185, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 35;
            this.label8.Text = "PLATNO";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 89);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(50, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(50, 50);
            this.flowLayoutPanel1.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(197, 357);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 23);
            this.label9.TabIndex = 35;
            this.label9.Text = "Cena:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(288, 357);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 23);
            this.label10.TabIndex = 37;
            this.label10.Text = "cena";
            this.label10.Visible = false;
            // 
            // GlavnaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 582);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxFilm);
            this.Controls.Add(this.cbxSala);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cbxDatum);
            this.Controls.Add(this.cbxBioskop);
            this.Controls.Add(this.cbxVreme);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRezervisi);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GlavnaForma";
            this.Load += new System.EventHandler(this.GlavnaForma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRezervisi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxFilm;
        private System.Windows.Forms.ComboBox cbxVreme;
        private System.Windows.Forms.ComboBox cbxBioskop;
        private System.Windows.Forms.ComboBox cbxSala;
        private System.Windows.Forms.ComboBox cbxDatum;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label10;
    }
}