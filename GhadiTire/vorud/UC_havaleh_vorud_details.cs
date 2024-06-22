using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using GhadiTire.sanad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace GhadiTire.vorud
{
    public partial class UC_havaleh_vorud_details : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_havaleh_vorud_details()
        {
            InitializeComponent();
        }

        private void gridControl_havaleh_vorud_details_Click(object sender, EventArgs e)
        {

        }

        private void gridView_havaleh_vorud_details_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "ردیف")
            {
                if (e.ListSourceRowIndex >= 0)
                {
                    GridView g = (GridView)sender;
                    e.DisplayText = (g.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();
                }

            }
        }
        DataSet ds_havaleh_vorud_details;
        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.VisibleIndex == 1)
            {
                var sda = new SqlDataAdapter("A_select_havaleh_vorud_details", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                ds_havaleh_vorud_details = new DataSet();
                sda.Fill(ds_havaleh_vorud_details, "A_select_havaleh_vorud_details");
                gridControl_havaleh_vorud_details.DataSource = ds_havaleh_vorud_details.Tables[0];
            }
            if (e.Button.Properties.VisibleIndex == 2)
            {
                Frm_New_havaleh_vorud_details obg = new Frm_New_havaleh_vorud_details();
                obg.ShowDialog();
            }
            if (e.Button.Properties.VisibleIndex == 3)
            {
                DevExpress.XtraPrinting.XlsxExportOptions option = new DevExpress.XtraPrinting.XlsxExportOptions();
                option.SheetName = "لیست ورودی کالا";
                Cs_Lib.export_gridView_to_excel(this.gridView_havaleh_vorud_details, "لیست ورودی کال", option);
            }
            if (e.Button.Properties.VisibleIndex == 4)
            {


                var sda = new SqlDataAdapter("select top 1 darsad_sud,darsad_maliat from tb_info_app", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                sda.Fill(ds, "tb_info_app");
                DataRow dr = ds.Tables[0].Rows[0];


                //Part 1
                System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                //Part 2
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelbook = excelApp.Workbooks.Add(Cs_Lib.path_exe + "//محاسبه فی فروش.xltx");
                Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Worksheet)(excelbook.Worksheets[1]);
                excelWorksheet.DisplayRightToLeft = true;
                //
                //مقدار ردیف 1
                Range[] rngg = new Range[1];

                string CellAddresscaption = Convert.ToString(Convert.ToChar(Convert.ToByte(65))) + "1";
                rngg[0] = excelWorksheet.get_Range(CellAddresscaption, CellAddresscaption);
                if (drv_havaleh_vorud_details != null)
                {
                    rngg[0].Value2 = "محاسبه با فی تک حلقه"+"  "+ drv_havaleh_vorud_details["sharh_kala"];

                }
                else
                {
                    rngg[0].Value2 = "محاسبه با فی تک حلقه";

                }

                //مقدار ردیف 3
                Range[] rngg0 = new Range[3];

                string CellAddresscaption0 = Convert.ToString(Convert.ToChar(Convert.ToByte(65))) + "3";
                rngg0[0] = excelWorksheet.get_Range(CellAddresscaption0, CellAddresscaption0);

                string CellAddresscaption1 = Convert.ToString(Convert.ToChar(Convert.ToByte(67))) + "3";
                rngg0[1] = excelWorksheet.get_Range(CellAddresscaption1, CellAddresscaption1);

                string CellAddresscaption2 = Convert.ToString(Convert.ToChar(Convert.ToByte(70))) + "3";
                rngg0[2] = excelWorksheet.get_Range(CellAddresscaption2, CellAddresscaption2);


                if (drv_havaleh_vorud_details!=null)
                {
                    rngg0[0].Value2 = drv_havaleh_vorud_details["mablagh_havaleh_vorud_details"] + "";

                }
                else
                {
                    rngg0[0].Value2 = "100";
                    

                }
                rngg0[1].Value2 = dr["darsad_sud"] + "";
                rngg0[2].Value2 = dr["darsad_maliat"] + "";

                //مقدار ردیف 6
                Range[] rngg1 = new Range[3];

                string CellAddresscaption00 = Convert.ToString(Convert.ToChar(Convert.ToByte(66))) + "6";
                rngg1[0] = excelWorksheet.get_Range(CellAddresscaption00, CellAddresscaption00);


                string CellAddresscaption11 = Convert.ToString(Convert.ToChar(Convert.ToByte(67))) + "6";
                rngg1[1] = excelWorksheet.get_Range(CellAddresscaption11, CellAddresscaption11);

                string CellAddresscaption22 = Convert.ToString(Convert.ToChar(Convert.ToByte(70))) + "6";
                rngg1[2] = excelWorksheet.get_Range(CellAddresscaption22, CellAddresscaption22);


                if (drv_havaleh_vorud_details != null)
                {
                    rngg1[0].Value2 = Int64.Parse(drv_havaleh_vorud_details["mablagh_havaleh_vorud_details"] + "") * 2;

                }
                else
                {
                    rngg1[0].Value2 = "200";

                }
                rngg1[1].Value2 = dr["darsad_sud"] + "";
                rngg1[2].Value2 = dr["darsad_maliat"] + "";
                //
                excelApp.Visible = true;

            }
        }
        public static DataRowView drv_havaleh_vorud_details;
        private void rp_btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                if (XtraMessageBox.Show("آیا از حذف  مطمئن هستید؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataRowView drv = (DataRowView)BindingContext[ds_havaleh_vorud_details.Tables[0]].Current;
                    SqlCommand cmd = new SqlCommand("A_Del_havaleh_vorud_details", Cs_Lib.CON_GhadirTire);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_havaleh_vorud", drv["id_havaleh_vorud"]);
                    cmd.Parameters.AddWithValue("@id_havaleh_vorud_details", drv["id_havaleh_vorud_details"]);
                    Cs_Lib.CON_GhadirTire.Open();
                    cmd.ExecuteNonQuery();
                    Cs_Lib.CON_GhadirTire.Close();
                    drv.Delete();
                }
            }
            if (e.Button.Index == 1)
            {
                drv_havaleh_vorud_details = (DataRowView)BindingContext[ds_havaleh_vorud_details.Tables[0]].Current;
                vorud.Frm_Edit_havaleh_vorud obg = new vorud.Frm_Edit_havaleh_vorud();
                obg.ShowDialog();   
            }
            if (e.Button.Index == 2)
            {
                drv_havaleh_vorud_details = (DataRowView)BindingContext[ds_havaleh_vorud_details.Tables[0]].Current;
                Frm_Edit_havaleh_vorud_details obg = new Frm_Edit_havaleh_vorud_details();
                obg.ShowDialog();
            }
            if (e.Button.Index == 3)
            {
                drv_havaleh_vorud_details = (DataRowView)BindingContext[ds_havaleh_vorud_details.Tables[0]].Current;
                Frm_New_havaleh_vorud_File obg = new Frm_New_havaleh_vorud_File();
                obg.ShowDialog();
            }
        }
        DataSet ds_file;
        private void gridView_havaleh_vorud_details_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                drv_havaleh_vorud_details = (DataRowView)this.BindingContext[ds_havaleh_vorud_details.Tables[0]].Current;

                Clipboard.SetText(drv_havaleh_vorud_details["mablagh_havaleh_vorud_details"] +"");


                var sda = new SqlDataAdapter(@"select id_havaleh_vorud_file,id_havaleh_vorud,tozihat_havaleh_vorud_file,
file_name_havaleh_vorud,file_ext_havaleh_vorud
from tb_havaleh_vorud_file where id_havaleh_vorud=@id_havaleh_vorud", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@id_havaleh_vorud", drv_havaleh_vorud_details["id_havaleh_vorud"]);
                ds_file = new DataSet();
                sda.Fill(ds_file);
                gridControl_havaleh_vorud_file.DataSource = ds_file.Tables[0];
            }
            else
            {
                gridControl_havaleh_vorud_file.DataSource = null;


            }
        }
        DataRowView drw_file;
        private void rp_btn_edit_file_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                drw_file = (DataRowView)BindingContext[ds_file.Tables[0]].Current;
                var sda = new SqlDataAdapter("select fileSuorce_havaleh_vorud,file_name_havaleh_vorud,file_ext_havaleh_vorud from tb_havaleh_vorud_file where id_havaleh_vorud_file=@id_havaleh_vorud_file", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@id_havaleh_vorud_file", drw_file["id_havaleh_vorud_file"]);
                DataSet ds = new DataSet();
                sda.Fill(ds, "tb_havaleh_vorud_file");
                DataRow dr = ds.Tables["tb_havaleh_vorud_file"].Rows[0];


                if (dr["fileSuorce_havaleh_vorud"] != DBNull.Value)
                {

                    string adress_file;
                    adress_file = Cs_Lib.save_file(dr["file_name_havaleh_vorud"] + "", dr["file_ext_havaleh_vorud"] + "");
                    if (adress_file != "")
                    {



                        FileStream fs = File.Create(adress_file);
                        fs.Write(Cs_Lib.Decompress((byte[])dr["fileSuorce_havaleh_vorud"]), 0, Cs_Lib.Decompress((byte[])dr["fileSuorce_havaleh_vorud"]).Length);
                        fs.Close();
                        //WebBrowser w = new WebBrowser();
                        //w.Navigate(adress_file);
                        System.Diagnostics.Process.Start(adress_file);
                        Cursor = System.Windows.Forms.Cursors.Default;
                    }


                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("فایلی جهت دریافت موجود نمی باشد");
                }
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
    }
}
