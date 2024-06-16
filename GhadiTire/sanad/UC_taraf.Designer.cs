namespace GhadiTire.sanad
{
    partial class UC_taraf
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_taraf));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_taraf = new DevExpress.XtraGrid.GridControl();
            this.gridView_taraf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rp_btn_edit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_taraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_taraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_btn_edit)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl_taraf);
            buttonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonImageOptions1.SvgImage")));
            buttonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonImageOptions2.SvgImage")));
            buttonImageOptions3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonImageOptions3.SvgImage")));
            this.groupControl1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", 1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", 2, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", 3, true, null, true, false, true, null, -1)});
            this.groupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.BeforeText;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(847, 466);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.groupControl1_CustomButtonClick);
            // 
            // gridControl_taraf
            // 
            this.gridControl_taraf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_taraf.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridControl_taraf.Location = new System.Drawing.Point(2, 54);
            this.gridControl_taraf.MainView = this.gridView_taraf;
            this.gridControl_taraf.Name = "gridControl_taraf";
            this.gridControl_taraf.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rp_btn_edit});
            this.gridControl_taraf.Size = new System.Drawing.Size(843, 410);
            this.gridControl_taraf.TabIndex = 0;
            this.gridControl_taraf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_taraf});
            // 
            // gridView_taraf
            // 
            this.gridView_taraf.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.gridView_taraf.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.gridView_taraf.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView_taraf.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.gridView_taraf.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.gridView_taraf.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView_taraf.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.gridView_taraf.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView_taraf.Appearance.Empty.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.gridView_taraf.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.gridView_taraf.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.gridView_taraf.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView_taraf.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.gridView_taraf.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView_taraf.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(153)))), ((int)(((byte)(73)))));
            this.gridView_taraf.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView_taraf.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(154)))), ((int)(((byte)(91)))));
            this.gridView_taraf.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView_taraf.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.gridView_taraf.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.gridView_taraf.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView_taraf.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.gridView_taraf.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.gridView_taraf.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView_taraf.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.gridView_taraf.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.gridView_taraf.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView_taraf.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.gridView_taraf.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView_taraf.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.gridView_taraf.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.gridView_taraf.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView_taraf.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.gridView_taraf.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.gridView_taraf.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView_taraf.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(183)))), ((int)(((byte)(125)))));
            this.gridView_taraf.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.gridView_taraf.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.gridView_taraf.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
            this.gridView_taraf.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.gridView_taraf.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView_taraf.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(146)))), ((int)(((byte)(78)))));
            this.gridView_taraf.Appearance.Preview.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.Preview.Options.UseFont = true;
            this.gridView_taraf.Appearance.Preview.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.gridView_taraf.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.gridView_taraf.Appearance.Row.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridView_taraf.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView_taraf.Appearance.Row.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.Row.Options.UseBorderColor = true;
            this.gridView_taraf.Appearance.Row.Options.UseFont = true;
            this.gridView_taraf.Appearance.Row.Options.UseForeColor = true;
            this.gridView_taraf.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.gridView_taraf.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView_taraf.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(167)))), ((int)(((byte)(103)))));
            this.gridView_taraf.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView_taraf.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView_taraf.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.gridView_taraf.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView_taraf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn14,
            this.gridColumn27,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn6});
            this.gridView_taraf.GridControl = this.gridControl_taraf;
            this.gridView_taraf.Name = "gridView_taraf";
            this.gridView_taraf.OptionsView.ColumnAutoWidth = false;
            this.gridView_taraf.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView_taraf.OptionsView.EnableAppearanceOddRow = true;
            this.gridView_taraf.OptionsView.ShowAutoFilterRow = true;
            this.gridView_taraf.OptionsView.ShowFooter = true;
            this.gridView_taraf.OptionsView.ShowGroupPanel = false;
            this.gridView_taraf.PaintStyleName = "Style3D";
            this.gridView_taraf.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView_taraf_CustomColumnDisplayText);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ردیف";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 62;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "سریال ";
            this.gridColumn4.FieldName = "id_taraf";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "عنوان";
            this.gridColumn2.FieldName = "name_taraf";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 233;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "نام";
            this.gridColumn14.FieldName = "fam_taraf";
            this.gridColumn14.MinWidth = 25;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 94;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "آدرس";
            this.gridColumn27.FieldName = "adress_taraf";
            this.gridColumn27.MinWidth = 25;
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.OptionsColumn.AllowFocus = false;
            this.gridColumn27.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "name_type_kala", "{0}")});
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 3;
            this.gridColumn27.Width = 94;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "تلفن";
            this.gridColumn5.FieldName = "tel_taraf";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "کد ملی";
            this.gridColumn3.FieldName = "code_melli_taraf";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 108;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "عملیات";
            this.gridColumn6.ColumnEdit = this.rp_btn_edit;
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 94;
            // 
            // rp_btn_edit
            // 
            this.rp_btn_edit.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions1.SvgImage")));
            this.rp_btn_edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rp_btn_edit.Name = "rp_btn_edit";
            this.rp_btn_edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rp_btn_edit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rp_btn_edit_ButtonClick);
            // 
            // UC_taraf
            // 
            this.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UC_taraf";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(847, 466);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_taraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_taraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_btn_edit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl_taraf;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_taraf;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rp_btn_edit;
    }
}
