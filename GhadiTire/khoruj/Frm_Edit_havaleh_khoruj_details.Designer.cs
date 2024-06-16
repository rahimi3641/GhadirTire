namespace GhadiTire.khoruj
{
    partial class Frm_Edit_havaleh_khoruj_details
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
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txt_mablagh_havaleh_khoruj_details = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mablagh_havaleh_khoruj_details.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(581, 112);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 32);
            this.labelControl4.TabIndex = 69;
            this.labelControl4.Text = "مبلغ:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(59, 335);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(106, 32);
            this.simpleButton1.TabIndex = 71;
            this.simpleButton1.Text = "ثبت";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txt_mablagh_havaleh_khoruj_details
            // 
            this.txt_mablagh_havaleh_khoruj_details.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_mablagh_havaleh_khoruj_details.Location = new System.Drawing.Point(59, 109);
            this.txt_mablagh_havaleh_khoruj_details.Name = "txt_mablagh_havaleh_khoruj_details";
            this.txt_mablagh_havaleh_khoruj_details.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt_mablagh_havaleh_khoruj_details.Properties.Appearance.Options.UseFont = true;
            this.txt_mablagh_havaleh_khoruj_details.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txt_mablagh_havaleh_khoruj_details.Properties.MaskSettings.Set("mask", "n0");
            this.txt_mablagh_havaleh_khoruj_details.Properties.MaskSettings.Set("valueType", typeof(int));
            this.txt_mablagh_havaleh_khoruj_details.Properties.UseMaskAsDisplayFormat = true;
            this.txt_mablagh_havaleh_khoruj_details.Size = new System.Drawing.Size(517, 38);
            this.txt_mablagh_havaleh_khoruj_details.TabIndex = 76;
            // 
            // Frm_Edit_havaleh_khoruj_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 392);
            this.Controls.Add(this.txt_mablagh_havaleh_khoruj_details);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl4);
            this.Name = "Frm_Edit_havaleh_khoruj_details";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Edit_havaleh_vorud_details";
            this.Load += new System.EventHandler(this.Frm_Edit_havaleh_vorud_details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_mablagh_havaleh_khoruj_details.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txt_mablagh_havaleh_khoruj_details;
    }
}