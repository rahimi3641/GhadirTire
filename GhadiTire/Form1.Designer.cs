namespace GhadiTire
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.br_havaleh_vorud_details = new DevExpress.XtraBars.BarButtonItem();
            this.br_kala = new DevExpress.XtraBars.BarButtonItem();
            this.br_havaleh_khoruj_details = new DevExpress.XtraBars.BarButtonItem();
            this.br_Report_mojudi_kala = new DevExpress.XtraBars.BarButtonItem();
            this.br_full_backup = new DevExpress.XtraBars.BarButtonItem();
            this.bt_sanad = new DevExpress.XtraBars.BarButtonItem();
            this.br_report_sanad = new DevExpress.XtraBars.BarButtonItem();
            this.br_taraf = new DevExpress.XtraBars.BarButtonItem();
            this.br_calculator = new DevExpress.XtraBars.BarButtonItem();
            this.br_restore_backup = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.br_havaleh_vorud_details,
            this.br_kala,
            this.br_havaleh_khoruj_details,
            this.br_Report_mojudi_kala,
            this.br_full_backup,
            this.bt_sanad,
            this.br_report_sanad,
            this.br_taraf,
            this.br_calculator,
            this.br_restore_backup});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 12;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3,
            this.ribbonPage4,
            this.ribbonPage5});
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.br_calculator);
            this.ribbonControl1.Size = new System.Drawing.Size(973, 183);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // br_havaleh_vorud_details
            // 
            this.br_havaleh_vorud_details.Caption = "ورود کالا";
            this.br_havaleh_vorud_details.Id = 1;
            this.br_havaleh_vorud_details.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("br_havaleh_vorud_details.ImageOptions.SvgImage")));
            this.br_havaleh_vorud_details.Name = "br_havaleh_vorud_details";
            this.br_havaleh_vorud_details.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.br_havaleh_vorud_details_ItemClick);
            // 
            // br_kala
            // 
            this.br_kala.Caption = "لیست کالا";
            this.br_kala.Id = 2;
            this.br_kala.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("br_kala.ImageOptions.SvgImage")));
            this.br_kala.Name = "br_kala";
            this.br_kala.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.br_kala_ItemClick);
            // 
            // br_havaleh_khoruj_details
            // 
            this.br_havaleh_khoruj_details.Caption = "خروج کالا";
            this.br_havaleh_khoruj_details.Id = 3;
            this.br_havaleh_khoruj_details.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("br_havaleh_khoruj_details.ImageOptions.SvgImage")));
            this.br_havaleh_khoruj_details.Name = "br_havaleh_khoruj_details";
            this.br_havaleh_khoruj_details.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.br_havaleh_khoruj_details_ItemClick);
            // 
            // br_Report_mojudi_kala
            // 
            this.br_Report_mojudi_kala.Caption = "موجودی";
            this.br_Report_mojudi_kala.Id = 5;
            this.br_Report_mojudi_kala.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("br_Report_mojudi_kala.ImageOptions.SvgImage")));
            this.br_Report_mojudi_kala.Name = "br_Report_mojudi_kala";
            this.br_Report_mojudi_kala.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.br_Report_mojudi_kala_ItemClick);
            // 
            // br_full_backup
            // 
            this.br_full_backup.Caption = "تهیه نسخه پشتیبان";
            this.br_full_backup.Id = 6;
            this.br_full_backup.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("br_full_backup.ImageOptions.SvgImage")));
            this.br_full_backup.Name = "br_full_backup";
            this.br_full_backup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.br_full_backup_ItemClick);
            // 
            // bt_sanad
            // 
            this.bt_sanad.Caption = "سند";
            this.bt_sanad.Id = 7;
            this.bt_sanad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bt_sanad.ImageOptions.SvgImage")));
            this.bt_sanad.Name = "bt_sanad";
            this.bt_sanad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_sanad_ItemClick);
            // 
            // br_report_sanad
            // 
            this.br_report_sanad.Caption = "اسناد ";
            this.br_report_sanad.Id = 8;
            this.br_report_sanad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("br_report_sanad.ImageOptions.SvgImage")));
            this.br_report_sanad.Name = "br_report_sanad";
            this.br_report_sanad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.br_report_sanad_ItemClick);
            // 
            // br_taraf
            // 
            this.br_taraf.Caption = "سرفصل های حسابداری";
            this.br_taraf.Id = 9;
            this.br_taraf.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("br_taraf.ImageOptions.SvgImage")));
            this.br_taraf.Name = "br_taraf";
            this.br_taraf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.br_taraf_ItemClick);
            // 
            // br_calculator
            // 
            this.br_calculator.Caption = "ماشین حساب";
            this.br_calculator.Id = 10;
            this.br_calculator.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("br_calculator.ImageOptions.SvgImage")));
            this.br_calculator.Name = "br_calculator";
            toolTipItem1.Text = "ماشین حساب";
            superToolTip1.Items.Add(toolTipItem1);
            this.br_calculator.SuperTip = superToolTip1;
            this.br_calculator.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.br_calculator_ItemClick);
            // 
            // br_restore_backup
            // 
            this.br_restore_backup.Caption = "بازیابی اطلاعات";
            this.br_restore_backup.Id = 11;
            this.br_restore_backup.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("br_restore_backup.ImageOptions.SvgImage")));
            this.br_restore_backup.Name = "br_restore_backup";
            this.br_restore_backup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.br_restore_backup_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ورود و خروج";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.br_kala);
            this.ribbonPageGroup1.ItemLinks.Add(this.br_havaleh_vorud_details);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ورود";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.br_havaleh_khoruj_details);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "خروج";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "حسابداری";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bt_sanad);
            this.ribbonPageGroup3.ItemLinks.Add(this.br_taraf);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "دریافت و پرداخت";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup6});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "گزارشات";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.br_Report_mojudi_kala);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "کالا";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.br_report_sanad);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "حسابداری";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "امکانات";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.br_full_backup);
            this.ribbonPageGroup5.ItemLinks.Add(this.br_restore_backup);
            this.ribbonPageGroup5.ItemLinks.Add(this.br_calculator);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 558);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(973, 30);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.MenuManager = this.ribbonControl1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "bak";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 588);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem br_havaleh_vorud_details;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem br_kala;
        private DevExpress.XtraBars.BarButtonItem br_havaleh_khoruj_details;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem br_Report_mojudi_kala;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem br_full_backup;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem bt_sanad;
        private DevExpress.XtraBars.BarButtonItem br_report_sanad;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem br_taraf;
        private DevExpress.XtraBars.BarButtonItem br_calculator;
        private DevExpress.XtraBars.BarButtonItem br_restore_backup;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

