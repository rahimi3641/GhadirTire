using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
                vorud.Frm_Edit_havaleh_khoruj obg = new vorud.Frm_Edit_havaleh_khoruj();
                obg.ShowDialog();   
            }
            if (e.Button.Index == 2)
            {
                drv_havaleh_vorud_details = (DataRowView)BindingContext[ds_havaleh_vorud_details.Tables[0]].Current;
                Frm_Edit_havaleh_khoruj_details obg = new Frm_Edit_havaleh_khoruj_details();
                obg.ShowDialog();
            }

        }
    }
}
