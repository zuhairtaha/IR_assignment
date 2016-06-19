namespace IR_assignment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SelectDocsBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // SelectDocsBtn
            // 
            this.SelectDocsBtn.Image = global::IR_assignment.Properties.Resources.app;
            this.SelectDocsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SelectDocsBtn.Location = new System.Drawing.Point(123, 116);
            this.SelectDocsBtn.Name = "SelectDocsBtn";
            this.SelectDocsBtn.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.SelectDocsBtn.Size = new System.Drawing.Size(229, 41);
            this.SelectDocsBtn.TabIndex = 0;
            this.SelectDocsBtn.Text = "اختيار وثائق وإضافتها للفهرس";
            this.SelectDocsBtn.UseVisualStyleBackColor = true;
            this.SelectDocsBtn.Click += new System.EventHandler(this.SelectDocsBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 264);
            this.Controls.Add(this.SelectDocsBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "برنامج فهرسة وبحث ضمن نظام استرجاع معلومات ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectDocsBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

