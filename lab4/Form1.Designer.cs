
namespace lab4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.aInp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bInp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sigInp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.muInp = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pInp = new System.Windows.Forms.TextBox();
            this.DTButton = new System.Windows.Forms.Button();
            this.EventButton = new System.Windows.Forms.Button();
            this.lenOut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // aInp
            // 
            this.aInp.Location = new System.Drawing.Point(258, 38);
            this.aInp.Margin = new System.Windows.Forms.Padding(5);
            this.aInp.Name = "aInp";
            this.aInp.Size = new System.Drawing.Size(116, 40);
            this.aInp.TabIndex = 0;
            this.aInp.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Генератор";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "a:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "b:";
            // 
            // bInp
            // 
            this.bInp.Location = new System.Drawing.Point(432, 38);
            this.bInp.Margin = new System.Windows.Forms.Padding(5);
            this.bInp.Name = "bInp";
            this.bInp.Size = new System.Drawing.Size(116, 40);
            this.bInp.TabIndex = 3;
            this.bInp.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 33);
            this.label4.TabIndex = 5;
            this.label4.Text = "Очередь";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 33);
            this.label5.TabIndex = 10;
            this.label5.Text = "σ:";
            // 
            // sigInp
            // 
            this.sigInp.Location = new System.Drawing.Point(432, 116);
            this.sigInp.Margin = new System.Windows.Forms.Padding(5);
            this.sigInp.Name = "sigInp";
            this.sigInp.Size = new System.Drawing.Size(116, 40);
            this.sigInp.TabIndex = 9;
            this.sigInp.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 33);
            this.label6.TabIndex = 8;
            this.label6.Text = "μ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 33);
            this.label7.TabIndex = 7;
            this.label7.Text = "ОА";
            // 
            // muInp
            // 
            this.muInp.Location = new System.Drawing.Point(258, 116);
            this.muInp.Margin = new System.Windows.Forms.Padding(5);
            this.muInp.Name = "muInp";
            this.muInp.Size = new System.Drawing.Size(116, 40);
            this.muInp.TabIndex = 6;
            this.muInp.Text = "3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 33);
            this.label9.TabIndex = 13;
            this.label9.Text = "P:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(195, 33);
            this.label10.TabIndex = 12;
            this.label10.Text = "Обратная связь";
            // 
            // pInp
            // 
            this.pInp.Location = new System.Drawing.Point(258, 196);
            this.pInp.Margin = new System.Windows.Forms.Padding(5);
            this.pInp.Name = "pInp";
            this.pInp.Size = new System.Drawing.Size(116, 40);
            this.pInp.TabIndex = 11;
            this.pInp.Text = "0.0";
            // 
            // DTButton
            // 
            this.DTButton.Location = new System.Drawing.Point(298, 360);
            this.DTButton.Name = "DTButton";
            this.DTButton.Size = new System.Drawing.Size(250, 40);
            this.DTButton.TabIndex = 14;
            this.DTButton.Text = "Метод Δt";
            this.DTButton.UseVisualStyleBackColor = true;
            this.DTButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // EventButton
            // 
            this.EventButton.Location = new System.Drawing.Point(20, 360);
            this.EventButton.Name = "EventButton";
            this.EventButton.Size = new System.Drawing.Size(270, 40);
            this.EventButton.TabIndex = 15;
            this.EventButton.Text = "Событийный метод";
            this.EventButton.UseVisualStyleBackColor = true;
            this.EventButton.Click += new System.EventHandler(this.EventButton_Click);
            // 
            // lenOut
            // 
            this.lenOut.Location = new System.Drawing.Point(258, 277);
            this.lenOut.Margin = new System.Windows.Forms.Padding(5);
            this.lenOut.Name = "lenOut";
            this.lenOut.ReadOnly = true;
            this.lenOut.Size = new System.Drawing.Size(290, 40);
            this.lenOut.TabIndex = 16;
            this.lenOut.Text = "0.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 424);
            this.Controls.Add(this.lenOut);
            this.Controls.Add(this.EventButton);
            this.Controls.Add(this.DTButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pInp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sigInp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.muInp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bInp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aInp);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Лабораторная работа 4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox aInp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bInp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sigInp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox muInp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox pInp;
        private System.Windows.Forms.Button DTButton;
        private System.Windows.Forms.Button EventButton;
        private System.Windows.Forms.TextBox lenOut;
    }
}

