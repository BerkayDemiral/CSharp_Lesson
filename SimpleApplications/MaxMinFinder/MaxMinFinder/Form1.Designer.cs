namespace MaxMinFinder
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumber1 = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.txtNumber2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumber3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLowestNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHighestNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number 1";
            // 
            // txtNumber1
            // 
            this.txtNumber1.Location = new System.Drawing.Point(77, 84);
            this.txtNumber1.Name = "txtNumber1";
            this.txtNumber1.Size = new System.Drawing.Size(100, 20);
            this.txtNumber1.TabIndex = 1;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(89, 211);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 2;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // txtNumber2
            // 
            this.txtNumber2.Location = new System.Drawing.Point(77, 128);
            this.txtNumber2.Name = "txtNumber2";
            this.txtNumber2.Size = new System.Drawing.Size(100, 20);
            this.txtNumber2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number 2";
            // 
            // txtNumber3
            // 
            this.txtNumber3.Location = new System.Drawing.Point(77, 173);
            this.txtNumber3.Name = "txtNumber3";
            this.txtNumber3.Size = new System.Drawing.Size(100, 20);
            this.txtNumber3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number 2";
            // 
            // txtLowestNumber
            // 
            this.txtLowestNumber.Location = new System.Drawing.Point(77, 317);
            this.txtLowestNumber.Name = "txtLowestNumber";
            this.txtLowestNumber.Size = new System.Drawing.Size(100, 20);
            this.txtLowestNumber.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Lowest Number";
            // 
            // txtHighestNumber
            // 
            this.txtHighestNumber.Location = new System.Drawing.Point(77, 273);
            this.txtHighestNumber.Name = "txtHighestNumber";
            this.txtHighestNumber.Size = new System.Drawing.Size(100, 20);
            this.txtHighestNumber.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Highest Number";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(89, 357);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(260, 473);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtLowestNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHighestNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumber3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumber2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.txtNumber1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "MaxMinFinder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber1;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.TextBox txtNumber2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumber3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLowestNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHighestNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
    }
}

