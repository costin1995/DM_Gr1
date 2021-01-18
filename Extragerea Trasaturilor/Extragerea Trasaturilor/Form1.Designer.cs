namespace Extragerea_Trasaturilor
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
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.gbGain = new System.Windows.Forms.GroupBox();
            this.gbNormalizare = new System.Windows.Forms.GroupBox();
            this.btnNormalizare = new System.Windows.Forms.Button();
            this.rbCornellSmart = new System.Windows.Forms.RadioButton();
            this.rbSuma1 = new System.Windows.Forms.RadioButton();
            this.rbNominala = new System.Windows.Forms.RadioButton();
            this.rbBinara = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbKNN = new System.Windows.Forms.GroupBox();
            this.btnKNN = new System.Windows.Forms.Button();
            this.rbManhattan = new System.Windows.Forms.RadioButton();
            this.rbEuclidiana = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImpartireDate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gbGain.SuspendLayout();
            this.gbNormalizare.SuspendLayout();
            this.gbKNN.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Extragerea trasaturilor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(108, 31);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Prag";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gbGain
            // 
            this.gbGain.Controls.Add(this.button2);
            this.gbGain.Controls.Add(this.numericUpDown1);
            this.gbGain.Location = new System.Drawing.Point(96, 54);
            this.gbGain.Name = "gbGain";
            this.gbGain.Size = new System.Drawing.Size(188, 63);
            this.gbGain.TabIndex = 3;
            this.gbGain.TabStop = false;
            this.gbGain.Text = "Gain";
            // 
            // gbNormalizare
            // 
            this.gbNormalizare.Controls.Add(this.btnNormalizare);
            this.gbNormalizare.Controls.Add(this.rbCornellSmart);
            this.gbNormalizare.Controls.Add(this.rbSuma1);
            this.gbNormalizare.Controls.Add(this.rbNominala);
            this.gbNormalizare.Controls.Add(this.rbBinara);
            this.gbNormalizare.Location = new System.Drawing.Point(96, 184);
            this.gbNormalizare.Name = "gbNormalizare";
            this.gbNormalizare.Size = new System.Drawing.Size(188, 119);
            this.gbNormalizare.TabIndex = 4;
            this.gbNormalizare.TabStop = false;
            this.gbNormalizare.Text = "Normalizare";
            // 
            // btnNormalizare
            // 
            this.btnNormalizare.Location = new System.Drawing.Point(108, 43);
            this.btnNormalizare.Name = "btnNormalizare";
            this.btnNormalizare.Size = new System.Drawing.Size(75, 23);
            this.btnNormalizare.TabIndex = 4;
            this.btnNormalizare.Text = "Aplica";
            this.btnNormalizare.UseVisualStyleBackColor = true;
            this.btnNormalizare.Click += new System.EventHandler(this.btnNormalizare_Click);
            // 
            // rbCornellSmart
            // 
            this.rbCornellSmart.AutoSize = true;
            this.rbCornellSmart.Location = new System.Drawing.Point(7, 89);
            this.rbCornellSmart.Name = "rbCornellSmart";
            this.rbCornellSmart.Size = new System.Drawing.Size(87, 17);
            this.rbCornellSmart.TabIndex = 3;
            this.rbCornellSmart.Text = "Cornell-Smart";
            this.rbCornellSmart.UseVisualStyleBackColor = true;
            // 
            // rbSuma1
            // 
            this.rbSuma1.AutoSize = true;
            this.rbSuma1.Location = new System.Drawing.Point(7, 66);
            this.rbSuma1.Name = "rbSuma1";
            this.rbSuma1.Size = new System.Drawing.Size(58, 17);
            this.rbSuma1.TabIndex = 2;
            this.rbSuma1.Text = "Suma1";
            this.rbSuma1.UseVisualStyleBackColor = true;
            // 
            // rbNominala
            // 
            this.rbNominala.AutoSize = true;
            this.rbNominala.Location = new System.Drawing.Point(6, 43);
            this.rbNominala.Name = "rbNominala";
            this.rbNominala.Size = new System.Drawing.Size(69, 17);
            this.rbNominala.TabIndex = 1;
            this.rbNominala.Text = "Nominala";
            this.rbNominala.UseVisualStyleBackColor = true;
            // 
            // rbBinara
            // 
            this.rbBinara.AutoSize = true;
            this.rbBinara.Checked = true;
            this.rbBinara.Location = new System.Drawing.Point(7, 20);
            this.rbBinara.Name = "rbBinara";
            this.rbBinara.Size = new System.Drawing.Size(55, 17);
            this.rbBinara.TabIndex = 0;
            this.rbBinara.TabStop = true;
            this.rbBinara.Text = "Binara";
            this.rbBinara.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Etapa 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Etapa 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Etapa 4:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Etapa 5:";
            // 
            // gbKNN
            // 
            this.gbKNN.Controls.Add(this.btnKNN);
            this.gbKNN.Controls.Add(this.rbManhattan);
            this.gbKNN.Controls.Add(this.rbEuclidiana);
            this.gbKNN.Location = new System.Drawing.Point(96, 319);
            this.gbKNN.Name = "gbKNN";
            this.gbKNN.Size = new System.Drawing.Size(204, 119);
            this.gbKNN.TabIndex = 4;
            this.gbKNN.TabStop = false;
            this.gbKNN.Text = "KNN";
            // 
            // btnKNN
            // 
            this.btnKNN.Location = new System.Drawing.Point(6, 66);
            this.btnKNN.Name = "btnKNN";
            this.btnKNN.Size = new System.Drawing.Size(75, 23);
            this.btnKNN.TabIndex = 4;
            this.btnKNN.Text = "Aplica";
            this.btnKNN.UseVisualStyleBackColor = true;
            this.btnKNN.Click += new System.EventHandler(this.btnKNN_Click);
            // 
            // rbManhattan
            // 
            this.rbManhattan.AutoSize = true;
            this.rbManhattan.Checked = true;
            this.rbManhattan.Location = new System.Drawing.Point(6, 43);
            this.rbManhattan.Name = "rbManhattan";
            this.rbManhattan.Size = new System.Drawing.Size(115, 17);
            this.rbManhattan.TabIndex = 1;
            this.rbManhattan.TabStop = true;
            this.rbManhattan.Text = "Distana Manhattan";
            this.rbManhattan.UseVisualStyleBackColor = true;
            // 
            // rbEuclidiana
            // 
            this.rbEuclidiana.AutoSize = true;
            this.rbEuclidiana.Location = new System.Drawing.Point(7, 20);
            this.rbEuclidiana.Name = "rbEuclidiana";
            this.rbEuclidiana.Size = new System.Drawing.Size(116, 17);
            this.rbEuclidiana.TabIndex = 0;
            this.rbEuclidiana.Text = "Distanta Euclidiana";
            this.rbEuclidiana.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Etapa 3:";
            // 
            // btnImpartireDate
            // 
            this.btnImpartireDate.Location = new System.Drawing.Point(96, 139);
            this.btnImpartireDate.Name = "btnImpartireDate";
            this.btnImpartireDate.Size = new System.Drawing.Size(118, 23);
            this.btnImpartireDate.TabIndex = 10;
            this.btnImpartireDate.Text = "Impartirea Datelor";
            this.btnImpartireDate.UseVisualStyleBackColor = true;
            this.btnImpartireDate.Click += new System.EventHandler(this.btnImpartireDate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 492);
            this.Controls.Add(this.btnImpartireDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbKNN);
            this.Controls.Add(this.gbNormalizare);
            this.Controls.Add(this.gbGain);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gbGain.ResumeLayout(false);
            this.gbNormalizare.ResumeLayout(false);
            this.gbNormalizare.PerformLayout();
            this.gbKNN.ResumeLayout(false);
            this.gbKNN.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbGain;
        private System.Windows.Forms.GroupBox gbNormalizare;
        private System.Windows.Forms.Button btnNormalizare;
        private System.Windows.Forms.RadioButton rbCornellSmart;
        private System.Windows.Forms.RadioButton rbSuma1;
        private System.Windows.Forms.RadioButton rbNominala;
        private System.Windows.Forms.RadioButton rbBinara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbKNN;
        private System.Windows.Forms.Button btnKNN;
        private System.Windows.Forms.RadioButton rbManhattan;
        private System.Windows.Forms.RadioButton rbEuclidiana;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnImpartireDate;
    }
}

