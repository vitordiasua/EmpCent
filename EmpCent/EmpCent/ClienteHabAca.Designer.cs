
namespace EmpCent
{
    partial class ClienteHabAca
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
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(67, 290);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(287, 35);
            this.button4.TabIndex = 64;
            this.button4.Text = "Adicionar Habilitação";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(203, 196);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 24);
            this.comboBox5.TabIndex = 63;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(203, 230);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(149, 22);
            this.textBox12.TabIndex = 62;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(64, 230);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 17);
            this.label24.TabIndex = 61;
            this.label24.Text = "Nota Final";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "to do"});
            this.comboBox4.Location = new System.Drawing.Point(203, 77);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 24);
            this.comboBox4.TabIndex = 60;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(64, 80);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(133, 17);
            this.label23.TabIndex = 59;
            this.label23.Text = "Nível de Habilitação";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(62, 199);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(123, 17);
            this.label20.TabIndex = 58;
            this.label20.Text = "Ano de Conclusão";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(203, 159);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(149, 22);
            this.textBox13.TabIndex = 57;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(64, 159);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 17);
            this.label21.TabIndex = 56;
            this.label21.Text = "Instituição";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(203, 122);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(149, 22);
            this.textBox14.TabIndex = 55;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(64, 122);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(106, 17);
            this.label22.TabIndex = 54;
            this.label22.Text = "Nome do Curso";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(62, 37);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(230, 37);
            this.label19.TabIndex = 53;
            this.label19.Text = "Habilitações Académicas";
            // 
            // ClienteHabAca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 367);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label19);
            this.Name = "ClienteHabAca";
            this.Text = "Adicionar Habilitação Académica";
            this.Load += new System.EventHandler(this.ClienteHabAca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
    }
}