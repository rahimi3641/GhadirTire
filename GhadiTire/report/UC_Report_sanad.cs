using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using GhadiTire.sanad;
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

namespace GhadiTire.report
{
    public partial class UC_Report_sanad : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_Report_sanad()
        {
            InitializeComponent();
        }
        DataSet ds_sanad_bed_bes;
        private void groupControl1_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {

        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.VisibleIndex == 1)
            {
                var sda = new SqlDataAdapter("A_Select_sanad_bed_bes", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                ds_sanad_bed_bes = new DataSet();
                sda.Fill(ds_sanad_bed_bes, "A_Select_sanad_bed_bes");     
                gridControl_sanad_bed_bes.DataSource = ds_sanad_bed_bes.Tables["A_Select_sanad_bed_bes"];
            }
        }
        DataRow d;

        private void gridView_sanad_bed_bes_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
    }
}
