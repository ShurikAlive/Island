﻿namespace Island
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
            this.btnLiveWeek = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLiveWeek
            // 
            this.btnLiveWeek.Location = new System.Drawing.Point(43, 44);
            this.btnLiveWeek.Name = "btnLiveWeek";
            this.btnLiveWeek.Size = new System.Drawing.Size(108, 42);
            this.btnLiveWeek.TabIndex = 0;
            this.btnLiveWeek.Text = "Прожить неделю";
            this.btnLiveWeek.UseVisualStyleBackColor = true;
            this.btnLiveWeek.Click += new System.EventHandler(this.btnLiveWeek_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 527);
            this.Controls.Add(this.btnLiveWeek);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLiveWeek;
    }
}

