
namespace lab3
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
            this.alg1 = new System.Windows.Forms.Panel();
            this.alg2 = new System.Windows.Forms.Panel();
            this.alg3 = new System.Windows.Forms.Panel();
            this.tab3 = new System.Windows.Forms.Panel();
            this.tab2 = new System.Windows.Forms.Panel();
            this.tab1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inp_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // alg1
            // 
            this.alg1.Location = new System.Drawing.Point(10, 80);
            this.alg1.Name = "alg1";
            this.alg1.Size = new System.Drawing.Size(100, 410);
            this.alg1.TabIndex = 0;
            this.alg1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // alg2
            // 
            this.alg2.Location = new System.Drawing.Point(110, 80);
            this.alg2.Name = "alg2";
            this.alg2.Size = new System.Drawing.Size(100, 410);
            this.alg2.TabIndex = 2;
            this.alg2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // alg3
            // 
            this.alg3.Location = new System.Drawing.Point(210, 80);
            this.alg3.Name = "alg3";
            this.alg3.Size = new System.Drawing.Size(100, 410);
            this.alg3.TabIndex = 3;
            this.alg3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // tab3
            // 
            this.tab3.Location = new System.Drawing.Point(525, 80);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(100, 410);
            this.tab3.TabIndex = 6;
            this.tab3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // tab2
            // 
            this.tab2.Location = new System.Drawing.Point(425, 80);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(100, 410);
            this.tab2.TabIndex = 5;
            this.tab2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // tab1
            // 
            this.tab1.Location = new System.Drawing.Point(325, 80);
            this.tab1.Name = "tab1";
            this.tab1.Size = new System.Drawing.Size(100, 410);
            this.tab1.TabIndex = 4;
            this.tab1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(325, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Табличный";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Алгоритмический";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inp_panel
            // 
            this.inp_panel.Location = new System.Drawing.Point(650, 80);
            this.inp_panel.Name = "inp_panel";
            this.inp_panel.Size = new System.Drawing.Size(100, 410);
            this.inp_panel.TabIndex = 9;
            this.inp_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(650, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ввод";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 508);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inp_panel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tab3);
            this.Controls.Add(this.tab2);
            this.Controls.Add(this.tab1);
            this.Controls.Add(this.alg3);
            this.Controls.Add(this.alg2);
            this.Controls.Add(this.alg1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel alg1;
        private System.Windows.Forms.Panel alg2;
        private System.Windows.Forms.Panel alg3;
        private System.Windows.Forms.Panel tab3;
        private System.Windows.Forms.Panel tab2;
        private System.Windows.Forms.Panel tab1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel inp_panel;
        private System.Windows.Forms.Label label1;
    }
}

