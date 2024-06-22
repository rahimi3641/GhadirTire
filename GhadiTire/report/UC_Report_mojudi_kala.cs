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
    public partial class UC_Report_mojudi_kala : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_Report_mojudi_kala()
        {
            InitializeComponent();
        }
        DataSet ds_Report_mojudi_kala;
        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.VisibleIndex == 1)
            {
                select();
            }
            if (e.Button.Properties.VisibleIndex == 2)
            {
                DevExpress.XtraPrinting.XlsxExportOptions option = new DevExpress.XtraPrinting.XlsxExportOptions();
                option.SheetName = "لیست موجودی";
                Cs_Lib.export_gridView_to_excel(this.gridView_kala, "لیست موجودی", option);
            }
            if (e.Button.Properties.VisibleIndex == 3)
            {
                Cs_Lib.export_gridView_to_pdf(this.gridView_kala, "لیست موجودی");
            }
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
        string  vorud_kala;
        string  khoruj_kala;
        string  sud;
     
        private void select()
        {
            var sda = new SqlDataAdapter("A_select_Report_mojudi_kala", Cs_Lib.CON_GhadirTire);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            ds_Report_mojudi_kala = new DataSet();
            sda.Fill(ds_Report_mojudi_kala, "A_select_Report_mojudi_kala");
            ds_Report_mojudi_kala.Tables[0].Columns.Add("sum_tedad_havaleh_vorud_details", typeof(int));
            ds_Report_mojudi_kala.Tables[0].Columns.Add("sum_tedad_havaleh_khoruj_details", typeof(int));
            ds_Report_mojudi_kala.Tables[0].Columns.Add("baghi_tedad_havaleh_details", typeof(int));
            ds_Report_mojudi_kala.Tables[0].Columns.Add("sud", typeof(int));

            foreach (DataRow dr in ds_Report_mojudi_kala.Tables[0].Rows)
            {

                vorud_kala = ds_Report_mojudi_kala.Tables[1].Compute("SUM(tedad_havaleh_vorud_details)", "id_kala=" + dr["id_kala"])+"";
               khoruj_kala = ds_Report_mojudi_kala.Tables[2].Compute("SUM(tedad_havaleh_khoruj_details)", "id_kala=" + dr["id_kala"]) + "";
                sud = ds_Report_mojudi_kala.Tables[2].Compute("SUM(sud)", "id_kala=" + dr["id_kala"]) + "";



                if (vorud_kala=="")
                {
                    vorud_kala = "0";
                }
                if (khoruj_kala == "")
                {
                    khoruj_kala = "0";

                }
                if (sud == "")
                {
                    sud = "0";

                }
                dr["sum_tedad_havaleh_vorud_details"] = int.Parse(vorud_kala);
                dr["sum_tedad_havaleh_khoruj_details"] = int.Parse(khoruj_kala);
                dr["baghi_tedad_havaleh_details"] = int.Parse(vorud_kala)- int.Parse(khoruj_kala);
                dr["sud"] = int.Parse(sud);





            }
            //foreach (DataRow dr in ds_Report_mojudi_kala.Tables[0].Rows )
            //{

            //}

                gridControl_kala.DataSource = ds_Report_mojudi_kala.Tables[0];
        }
        private void UC_Report_mojudi_kala_Load(object sender, EventArgs e)
        {
            select();
        }
        DataRowView drv;
        private void gridView_kala_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if(e.RowHandle>=0)
            {
                drv = (DataRowView)this.BindingContext[ds_Report_mojudi_kala.Tables[0]].Current;
                var sda = new SqlDataAdapter(@"select * from View_havaleh_vorud_details where id_kala=@id_kala 
select * from View_havaleh_khoruj where id_kala=@id_kala", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@id_kala", drv["id_kala"]);
                DataSet ds_havaleh_vorud_details = new DataSet();
                sda.Fill(ds_havaleh_vorud_details);
                gridControl_havaleh_vorud_details.DataSource = ds_havaleh_vorud_details.Tables[0];
                gridControl_havaleh_khoruj.DataSource = ds_havaleh_vorud_details.Tables[1];
            }
            else
            {
                gridControl_havaleh_vorud_details.DataSource = null;
                gridControl_havaleh_khoruj.DataSource = null;


            }
        }
    }
}
