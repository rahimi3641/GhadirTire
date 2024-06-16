using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using GhadiTire.vorud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhadiTire.khoruj
{
    public partial class UC_havaleh_khoruj_details : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_havaleh_khoruj_details()
        {
            InitializeComponent();
        }
        DataSet ds_havaleh_khoruj_details;
        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.VisibleIndex == 1)
            {
                var sda = new SqlDataAdapter("A_select_havaleh_khoruj_details", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                ds_havaleh_khoruj_details = new DataSet();
                sda.Fill(ds_havaleh_khoruj_details, "A_select_havaleh_khoruj_details");

                ds_havaleh_khoruj_details.Tables[0].Columns.Add("sud", typeof(int));
                foreach (DataRow d in ds_havaleh_khoruj_details.Tables[0].Rows)
                {
                    d["sud"] = int.Parse(d["fi_havaleh_khoruj_kol"] + "") - int.Parse(d["fi_havaleh_vorud_kol"] + "");
                }
                gridControl_havaleh_khoruj.DataSource = ds_havaleh_khoruj_details.Tables[0];
                gridControl_havaleh_khoruj_details.DataSource = ds_havaleh_khoruj_details.Tables[1];
            }
            if (e.Button.Properties.VisibleIndex == 2)
            {
                Frm_New_havaleh_khoruj_details obg = new Frm_New_havaleh_khoruj_details();
                obg.ShowDialog();
            }
            if (e.Button.Properties.VisibleIndex == 3)
            {
                DevExpress.XtraPrinting.XlsxExportOptions option = new DevExpress.XtraPrinting.XlsxExportOptions();
                option.SheetName = "لیست خروجی کالا";
                Cs_Lib.export_gridView_to_excel(this.gridView_havaleh_khoruj_details, "لیست خروجی کالا", option);
            }
            
        }
        public static DataRowView drv_havaleh_khoruj;
      

        private void gridControl_havaleh_khoruj_details_Click(object sender, EventArgs e)
        {

        }

        private void gridView_havaleh_khoruj_details_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
        public static DataSet ds;
        private void rp_btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void dockPanel_havaleh_khoruj_Click(object sender, EventArgs e)
        {

        }

        private void gridView_havaleh_khoruj_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                DataRowView drv;
                drv = (DataRowView)this.BindingContext[ds_havaleh_khoruj_details.Tables[0]].Current;
                var sda = new SqlDataAdapter(@"select * from View_havaleh_khoruj where id_havaleh_khoruj=@id_havaleh_khoruj", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@id_havaleh_khoruj", drv["id_havaleh_khoruj"]);            
                ds = new DataSet();
                sda.Fill(ds, "View_havaleh_khoruj");
                R_havaleh_khoruj report = new R_havaleh_khoruj();
                report.RequestParameters = false;
                report.Parameters["sho_havaleh_khoruj"].Value ="سریال فاکتور:"+" "+ drv["id_havaleh_khoruj"];
                report.Parameters["name_taraf"].Value = "طرف حساب:"+" "+drv["name_taraf"];
                report.Parameters["date_havaleh_khoruj"].Value ="تاریخ:"+" "+ drv["date_havaleh_khoruj"];
                report.Parameters["sum_fi_havaleh_khoruj_kol"].Value = ds.Tables[0].Compute("SUM(fi_havaleh_khoruj_kol)", "id_havaleh_khoruj="+drv["id_havaleh_khoruj"]);
                report.Parameters["sum_fi_havaleh_khoruj_kol"].Value = ds.Tables[0].Compute("SUM(fi_havaleh_khoruj_kol)", "id_havaleh_khoruj="+drv["id_havaleh_khoruj"]);
                ReportPrintTool tool = new ReportPrintTool(report);
                tool.AutoShowParametersPanel = false;

                tool.ShowRibbonPreview();

            }
        }

        private void rp_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                if (XtraMessageBox.Show("آیا از حذف  مطمئن هستید؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataRowView drv = (DataRowView)BindingContext[ds_havaleh_khoruj_details.Tables[0]].Current;
                    SqlCommand cmd = new SqlCommand("A_Del_havaleh_khoruj_details", Cs_Lib.CON_GhadirTire);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_havaleh_khoruj", drv["id_havaleh_khoruj"]);
                    cmd.Parameters.AddWithValue("@id_kala", drv["id_kala"]);
                    Cs_Lib.CON_GhadirTire.Open();
                    cmd.ExecuteNonQuery();
                    Cs_Lib.CON_GhadirTire.Close();
                    drv.Delete();
                }
            }
            if (e.Button.Index == 1)
            {

                drv_havaleh_khoruj = (DataRowView)BindingContext[ds_havaleh_khoruj_details.Tables[0]].Current;
                Frm_Edit_havaleh_khoruj obg = new Frm_Edit_havaleh_khoruj();
                obg.ShowDialog();
            }
            if (e.Button.Index == 2)
            {

                drv_havaleh_khoruj = (DataRowView)BindingContext[ds_havaleh_khoruj_details.Tables[0]].Current;
                Frm_Edit_havaleh_khoruj_details obg = new Frm_Edit_havaleh_khoruj_details();
                obg.ShowDialog();
            }
        }

        private void gridControl_havaleh_khoruj_Click(object sender, EventArgs e)
        {

        }
    }
}
