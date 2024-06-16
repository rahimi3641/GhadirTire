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
    public partial class CU_kala : DevExpress.XtraEditors.XtraUserControl
    {
        public CU_kala()
        {
            InitializeComponent();
        }

        private void gridView_kala_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
        DataSet ds_kala;
        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.VisibleIndex == 1)
            {
                var sda = new SqlDataAdapter("A_select_kala", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                ds_kala = new DataSet();
                sda.Fill(ds_kala, "A_select_kala");
                gridControl_kala.DataSource = ds_kala.Tables[0];
            }
            if (e.Button.Properties.VisibleIndex == 2)
            {
                Frm_New_kala obg = new Frm_New_kala();
                obg.ShowDialog();
            }
            if (e.Button.Properties.VisibleIndex == 3)
            {
                DevExpress.XtraPrinting.XlsxExportOptions option = new DevExpress.XtraPrinting.XlsxExportOptions();
                option.SheetName = "لیست  کالا";
                Cs_Lib.export_gridView_to_excel(this.gridView_kala, "لیست  کالا", option);
            }
        }
    }
}
