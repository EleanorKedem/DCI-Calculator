namespace DCI_Calculator
{
    partial class SmallItemCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmallItemCalc));
            this.stonesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stonesLabel
            // 
            this.stonesLabel.AutoSize = true;
            this.stonesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stonesLabel.Location = new System.Drawing.Point(35, 35);
            this.stonesLabel.Name = "stonesLabel";
            this.stonesLabel.Size = new System.Drawing.Size(0, 25);
            this.stonesLabel.TabIndex = 0;
            // 
            // SmallItemCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stonesLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SmallItemCalc";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.SmallItemCalc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stonesLabel;
    }
}