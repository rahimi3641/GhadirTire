using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using GhadiTire.khoruj;
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

namespace GhadiTire.sanad
{
    public partial class UC_taraf : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_taraf()
        {
            InitializeComponent();
        }
        DataSet ds_taraf;
        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.VisibleIndex == 1)
            {
                var sda = new SqlDataAdapter("A_select_taraf", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                ds_taraf = new DataSet();
                sda.Fill(ds_taraf, "A_select_taraf");
                gridControl_taraf.DataSource = ds_taraf.Tables[0];
            }
            if (e.Button.Properties.VisibleIndex == 2)
            {
                Frm_New_taraf obg = new Frm_New_taraf();
                obg.ShowDialog();
            }
            if (e.Button.Properties.VisibleIndex == 3)
            {
                DevExpress.XtraPrinting.XlsxExportOptions option = new DevExpress.XtraPrinting.XlsxExportOptions();
                option.SheetName = "سرفصل حساب ها";
                Cs_Lib.export_gridView_to_excel(this.gridView_taraf, "سرفصل حساب ها", option);
            }
        }

        private void gridView_taraf_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
        public static DataRowView drv_taraf;
        private void rp_btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
               
                drv_taraf = (DataRowView)this.BindingContext[ds_taraf.Tables["A_select_taraf"]].Current;
                Frm_Edit_taraf obg = new Frm_Edit_taraf();
                obg.ShowDialog();

            }
        }
    }
}
