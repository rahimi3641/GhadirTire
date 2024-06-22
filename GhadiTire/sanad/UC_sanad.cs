using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using GhadiTire.khoruj;
using GhadiTire.report;
using GhadiTire.vorud;
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

namespace GhadiTire.sanad
{
    public partial class UC_sanad : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_sanad()
        {
            InitializeComponent();
        }
        DataSet ds_sanad;
        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.VisibleIndex == 1)
            {
                var sda = new SqlDataAdapter("A_select_sanad", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                ds_sanad = new DataSet();
                sda.Fill(ds_sanad, "A_select_sanad");
                gridControl_sanad.DataSource = ds_sanad.Tables[0];
            }
            if (e.Button.Properties.VisibleIndex == 2)
            {
                Frm_New_sanad obg = new Frm_New_sanad();
                obg.ShowDialog();
            }
            if (e.Button.Properties.VisibleIndex == 3)
            {
                //DevExpress.XtraPrinting.XlsxExportOptions option = new DevExpress.XtraPrinting.XlsxExportOptions();
                //option.SheetName = "لیست  کالا";
                //Cs_Lib.export_gridView_to_excel(this.gridView_kala, "لیست  کالا", option);
            }
        }

        private void gridView_sanad_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
        DataRowView drw;
        DataRowView drw_details;
        DataSet ds_details;
        private void gridView_sanad_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                drw = (DataRowView)this.BindingContext[ds_sanad .Tables[0]].Current;
                var sda = new SqlDataAdapter(@"select id_sanad_bed as id_sanad_bed_bes,mablagh_sanad_bed,0 as mablagh_sanad_bes,sharh_sanad_bed as sharh_sanad_bed_bes,name_taraf   from View_sanad_bed where id_sanad=@id_sanad
union all  
select id_sanad_bes as id_sanad_bed_bes,0 as mablagh_sanad_bed,mablagh_sanad_bes,sharh_sanad_bes as sharh_sanad_bed_bes,name_taraf from View_sanad_bes where id_sanad=@id_sanad 
select id_sanad_file,id_sanad,tozihat_sanad_file,file_name,flie_ext
from tb_sanad_file where id_sanad=@id_sanad", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@id_sanad", drw["id_sanad"]);
                ds_details = new DataSet();
                sda.Fill(ds_details);
                gridControl_sanad_bed.DataSource = ds_details.Tables[0];
                gridControl_sanad_file.DataSource = ds_details.Tables[1];
                // gridControl_havaleh_khoruj.DataSource = ds_havaleh_vorud_details.Tables[1];
            }
            else
            {
                gridControl_sanad_bed.DataSource = null;
               // gridControl_havaleh_khoruj.DataSource = null;


            }
        }

        private void gridView_sanad_bed_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public static DataRowView drv_sanad;
        private void r_p_btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index==0)
            {
                drv_sanad = (DataRowView)this.BindingContext[ds_sanad.Tables[0]].Current;
                Frm_New_sanad_File obg = new Frm_New_sanad_File();
                obg.ShowDialog(); 
            }
        }

        private void rp_btn_edit_file_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index==0)
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                drw_details =(DataRowView)BindingContext[ ds_details.Tables[1]].Current; 
                var sda = new SqlDataAdapter("select file_Suorce,file_name,flie_ext from tb_sanad_file where id_sanad_file=@id_sanad_file", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@id_sanad_file",drw_details["id_sanad_file"]);
                DataSet ds = new DataSet();
                sda.Fill(ds, "tb_sanad_file");
                DataRow dr = ds.Tables["tb_sanad_file"].Rows[0];


                if (dr["file_Suorce"] != DBNull.Value)
                {

                    string adress_file;
                    adress_file = Cs_Lib.save_file(dr["file_name"] + "", dr["flie_ext"] + "");
                    if (adress_file != "")
                    {



                        FileStream fs = File.Create(adress_file);
                        fs.Write(Cs_Lib.Decompress((byte[])dr["file_Suorce"]), 0, Cs_Lib.Decompress((byte[])dr["file_Suorce"]).Length);
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
