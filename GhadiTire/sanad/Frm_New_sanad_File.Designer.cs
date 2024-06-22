namespace GhadiTire.sanad
{
    partial class Frm_New_sanad_File
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_New_sanad_File));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_doc_adress1 = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_id_sanad = new DevExpress.XtraEditors.TextEdit();
            this.txt_tozihat_sanad_file = new DevExpress.XtraEditors.MemoEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_ok = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_doc_adress1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_id_sanad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tozihat_sanad_file.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(871, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 32);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "سریال سند:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(873, 156);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 32);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "توضیحات:";
            // 
            // txt_doc_adress1
            // 
            this.txt_doc_adress1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_doc_adress1.Location = new System.Drawing.Point(40, 87);
            this.txt_doc_adress1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_doc_adress1.Name = "txt_doc_adress1";
            this.txt_doc_adress1.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt_doc_adress1.Properties.Appearance.Options.UseFont = true;
            this.txt_doc_adress1.Properties.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions1.SvgImage")));
            this.txt_doc_adress1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txt_doc_adress1.Properties.ReadOnly = true;
            this.txt_doc_adress1.Size = new System.Drawing.Size(827, 50);
            this.txt_doc_adress1.TabIndex = 81;
            this.txt_doc_adress1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txt_doc_adress1_ButtonClick);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(871, 95);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(86, 32);
            this.labelControl4.TabIndex = 80;
            this.labelControl4.Text = "انتخاب فایل:";
            // 
            // txt_id_sanad
            // 
            this.txt_id_sanad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_id_sanad.Location = new System.Drawing.Point(690, 18);
            this.txt_id_sanad.Name = "txt_id_sanad";
            this.txt_id_sanad.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt_id_sanad.Properties.Appearance.Options.UseFont = true;
            this.txt_id_sanad.Properties.AutoHeight = false;
            this.txt_id_sanad.Properties.ReadOnly = true;
            this.txt_id_sanad.Size = new System.Drawing.Size(177, 50);
            this.txt_id_sanad.TabIndex = 82;
            // 
            // txt_tozihat_sanad_file
            // 
            this.txt_tozihat_sanad_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tozihat_sanad_file.Location = new System.Drawing.Point(40, 155);
            this.txt_tozihat_sanad_file.Name = "txt_tozihat_sanad_file";
            this.txt_tozihat_sanad_file.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt_tozihat_sanad_file.Properties.Appearance.Options.UseFont = true;
            this.txt_tozihat_sanad_file.Size = new System.Drawing.Size(827, 254);
            this.txt_tozihat_sanad_file.TabIndex = 83;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_ok.Appearance.Options.UseFont = true;
            this.btn_ok.Location = new System.Drawing.Point(40, 433);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(94, 39);
            this.btn_ok.TabIndex = 84;
            this.btn_ok.Text = "ثبت";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // Frm_New_sanad_File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 518);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_tozihat_sanad_file);
            this.Controls.Add(this.txt_id_sanad);
            this.Controls.Add(this.txt_doc_adress1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "Frm_New_sanad_File";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_New_sanad_File";
            this.Load += new System.EventHandler(this.Frm_New_sanad_File_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_doc_adress1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_id_sanad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tozihat_sanad_file.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit txt_doc_adress1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_id_sanad;
        private DevExpress.XtraEditors.MemoEdit txt_tozihat_sanad_file;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.SimpleButton btn_ok;
    }
}