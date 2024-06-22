using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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

namespace GhadiTire.report
{
    public partial class UC_Report_sanad_taraf : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_Report_sanad_taraf()
        {
            InitializeComponent();
        }
        DataSet ds_for_Report_sanad_taraf;
        string  sum_bed;
        string  sum_bes;
        Int64   bed_bes;
        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.VisibleIndex == 1)
            {
                var sda = new SqlDataAdapter("A_Select_for_Report_sanad_taraf", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                ds_for_Report_sanad_taraf = new DataSet();
                sda.Fill(ds_for_Report_sanad_taraf, "A_Select_for_Report_sanad_taraf");
                ds_for_Report_sanad_taraf.Tables[0].Columns.Add ("sum_bed",typeof(Int64)); 
                ds_for_Report_sanad_taraf.Tables[0].Columns.Add ("sum_bes", typeof(Int64)); 
                ds_for_Report_sanad_taraf.Tables[0].Columns.Add ("bed_bes", typeof(Int64));
                ds_for_Report_sanad_taraf.Tables[0].Columns.Add ("noe", typeof(string));

                foreach (DataRow dr in ds_for_Report_sanad_taraf.Tables[0].Rows)
                {
                   
                    sum_bed= ds_for_Report_sanad_taraf.Tables[1].Compute("sum(mablagh_sanad_bed)", "id_taraf=" + dr["id_taraf"])+"";
                    if(sum_bed=="")
                    {
                        sum_bed = "0";
                    }
                    else
                    {
                        Int64.Parse (sum_bed);  
                    }
                    dr["sum_bed"] = sum_bed;

                    sum_bes = ds_for_Report_sanad_taraf.Tables[1].Compute("sum(mablagh_sanad_bes)", "id_taraf=" + dr["id_taraf"]) + "";
                    if (sum_bes== "")
                    {
                        sum_bes = "0";
                    }
                    else
                    {
                        Int64.Parse(sum_bes);
                    }
                    dr["sum_bes"] = sum_bes;

                    bed_bes= Int64.Parse(sum_bed) - Int64.Parse(sum_bes);
                    dr["bed_bes"] = bed_bes;
                    if (bed_bes > 0)
                    {
                        dr["noe"] = "بدهکار";
                    }
                    else
                    {
                        dr["noe"] = "بستانکار";

                    }


                }

                gridControl_taraf.DataSource = ds_for_Report_sanad_taraf.Tables[0];
            }
            if (e.Button.Properties.VisibleIndex == 3)
            {
                DevExpress.XtraPrinting.XlsxExportOptions option = new DevExpress.XtraPrinting.XlsxExportOptions();
                option.SheetName = "لیست  ";
                Cs_Lib.export_gridView_to_excel(this.gridView_taraf, "لیست  ", option);
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
        DataRowView drv_taraf;
        DataView dv_sanad_bed;
        private void gridView_taraf_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                drv_taraf = (DataRowView)this.BindingContext[ds_for_Report_sanad_taraf.Tables[0]].Current;
                dv_sanad_bed = new DataView();
                dv_sanad_bed.Table = ds_for_Report_sanad_taraf.Tables[1];
                dv_sanad_bed.RowFilter = "id_taraf=" + drv_taraf["id_taraf"];

                gridControl_sanad_bed.DataSource=dv_sanad_bed.ToTable();
               
            }
            else
            {
                gridControl_sanad_bed.DataSource = null;

            }
        }
    }
}
