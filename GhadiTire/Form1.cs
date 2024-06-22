using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using GhadiTire.khoruj;
using GhadiTire.report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GhadiTire
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            this.tabbedView1.QueryControl += tabbedView1_QueryControl;

        }
        void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (e.Control == null)
            {
                e.Control = new Control();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + "    " + "(" + ProductVersion + ")";
            //Cs_Lib.con();
            check_connection_DB();
            Frm_login obg = new Frm_login();
            obg.ShowDialog();
        }
        private void check_connection_DB()
        {
            try
            {
                Cs_Lib.con();
                Cs_Lib.CON_GhadirTire.Open();
                Cs_Lib.CON_GhadirTire.Close();
            }
            catch (Exception ex)
            {



                DevExpress.XtraEditors.XtraMessageBox.Show("خطا در برقراری با سرویس" + "\n" + "با مدیر سیستم تماس گرفته شود" + "\n" + ex.Message);
                Frm_login.close = true;
                Frm_login.let = true;
                System.Windows.Forms.Application.Exit();


            }
        }
        private void br_havaleh_vorud_details_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vorud.UC_havaleh_vorud_details UC = new vorud.UC_havaleh_vorud_details();
            tabbedView1.AddDocument(UC).Caption = e.Item.Caption + " (" + DateTime.Now.ToLongTimeString() + ")";
            tabbedView1.ActivateDocument(UC);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }

        private void br_kala_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vorud.CU_kala UC = new vorud.CU_kala();
            tabbedView1.AddDocument(UC).Caption = e.Item.Caption + " (" + DateTime.Now.ToLongTimeString() + ")";
            tabbedView1.ActivateDocument(UC);
        }

        private void br_havaleh_khoruj_details_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            khoruj.UC_havaleh_khoruj_details UC = new khoruj.UC_havaleh_khoruj_details();
            tabbedView1.AddDocument(UC).Caption = e.Item.Caption + " (" + DateTime.Now.ToLongTimeString() + ")";
            tabbedView1.ActivateDocument(UC);
        }



        private void br_Report_mojudi_kala_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            report.UC_Report_mojudi_kala UC = new report.UC_Report_mojudi_kala();
            tabbedView1.AddDocument(UC).Caption = e.Item.Caption + " (" + DateTime.Now.ToLongTimeString() + ")";
            tabbedView1.ActivateDocument(UC);
        }

        private void br_full_backup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
               
                Cursor = Cursors.WaitCursor;
                SqlCommand cmd = new SqlCommand("Fullbackup", Cs_Lib.CON_GhadirTire);
                cmd.CommandType = CommandType.StoredProcedure;
                Cs_Lib.CON_GhadirTire.Open();
                XtraMessageBox.Show(" تهیه شد "+ cmd.ExecuteScalar()+ "نسخه پشتیبان با موفقیت در مسیر   ");
                Cs_Lib.CON_GhadirTire.Close();
                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                Cs_Lib.CON_GhadirTire.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void bt_sanad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sanad.UC_sanad UC = new sanad.UC_sanad();
            tabbedView1.AddDocument(UC).Caption = e.Item.Caption + " (" + DateTime.Now.ToLongTimeString() + ")";
            tabbedView1.ActivateDocument(UC);
        }

        private void br_report_sanad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            report.UC_Report_sanad UC = new report.UC_Report_sanad();
            tabbedView1.AddDocument(UC).Caption = e.Item.Caption + " (" + DateTime.Now.ToLongTimeString() + ")";
            tabbedView1.ActivateDocument(UC);
        }

        private void br_taraf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sanad.UC_taraf UC = new sanad.UC_taraf();
            tabbedView1.AddDocument(UC).Caption = e.Item.Caption + " (" + DateTime.Now.ToLongTimeString() + ")";
            tabbedView1.ActivateDocument(UC);
        }

        private void br_calculator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Frm_login.close)
                if (DevExpress.XtraEditors.XtraMessageBox.Show("آیا برای خروج از برنامه اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;

                }
        }

        private void br_restore_backup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFileDialog1.InitialDirectory = Cs_Lib.path_doc ;
            openFileDialog1.Title = "انتخاب فایل جهت بازیابی اطلاعات";
            openFileDialog1.DefaultExt = "bak";
            openFileDialog1.Filter = "SqlBackUp (*.bak)|*.bak";

            
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Cursor=Cursors.WaitCursor;
                    if (Cs_Lib.CON_GhadirTire.State == ConnectionState.Closed)
                    {
                        Cs_Lib.CON_GhadirTire.Open();
                    }
                    SqlCommand cmd1 = new SqlCommand("ALTER DATABASE [" + "GhadirTire" + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE ", Cs_Lib.CON_GhadirTire);
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("USE MASTER RESTORE DATABASE [" + "GhadirTire" + "] FROM DISK='" + openFileDialog1.FileName + "' WITH REPLACE", Cs_Lib.CON_GhadirTire);
                    cmd2.ExecuteNonQuery();
                    SqlCommand cmd3 = new SqlCommand("ALTER DATABASE [" + "GhadirTire" + "] SET MULTI_USER", Cs_Lib.CON_GhadirTire);
                    cmd3.ExecuteNonQuery();
                    Cs_Lib.CON_GhadirTire.Close();
                    Cursor = Cursors.Default; ;

                }
                catch (Exception ex)
                {
                    Cs_Lib.CON_GhadirTire.Close();
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message);
                }
                Cs_Lib.CON_GhadirTire.Close();
            }
        }

        private void br_Report_sanad_taraf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                 report.UC_Report_sanad_taraf UC = new report.UC_Report_sanad_taraf();
            tabbedView1.AddDocument(UC).Caption = e.Item.Caption + " (" + DateTime.Now.ToLongTimeString() + ")";
            tabbedView1.ActivateDocument(UC);
        }

 

        private void br_sud_chart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            report.UC_sud_chart UC = new report.UC_sud_chart();
            tabbedView1.AddDocument(UC).Caption = e.Item.Caption + " (" + DateTime.Now.ToLongTimeString() + ")";
            tabbedView1.ActivateDocument(UC);
        }
    }
}
