namespace DoS
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.txtSuccess = new System.Windows.Forms.TextBox();
            this.txtFailed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(76, 95);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(171, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(76, 60);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(244, 20);
            this.txtURL.TabIndex = 2;
            this.txtURL.Text = "http://localhost/Index.html";
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(73, 165);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(43, 13);
            this.lblResults.TabIndex = 3;
            this.lblResults.Text = "Status: ";
            // 
            // txtSuccess
            // 
            this.txtSuccess.Location = new System.Drawing.Point(146, 199);
            this.txtSuccess.Name = "txtSuccess";
            this.txtSuccess.Size = new System.Drawing.Size(100, 20);
            this.txtSuccess.TabIndex = 4;
            this.txtSuccess.Text = "Success";
            // 
            // txtFailed
            // 
            this.txtFailed.Location = new System.Drawing.Point(146, 246);
            this.txtFailed.Name = "txtFailed";
            this.txtFailed.Size = new System.Drawing.Size(100, 20);
            this.txtFailed.TabIndex = 5;
            this.txtFailed.Text = "Failed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Success";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Failed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 381);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFailed);
            this.Controls.Add(this.txtSuccess);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.TextBox txtSuccess;
        private System.Windows.Forms.TextBox txtFailed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

