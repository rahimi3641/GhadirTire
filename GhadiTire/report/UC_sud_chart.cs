using DevExpress.XtraEditors;
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
    public partial class UC_sud_chart : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_sud_chart()
        {
            InitializeComponent();
        }
        int year_s;
        int year_p;
        string sud;
        string mount;
        private void UC_sud_chart_Load(object sender, EventArgs e)
        {
            var sda = new SqlDataAdapter(@"select (fi_havaleh_khoruj_kol+avg_maliat_havaleh_khoruj_kol)-fi_havaleh_vorud_kol as sud,
id_kala,date_havaleh_khoruj,sum_tedad_havaleh_khoruj_details as tedad_havaleh_khoruj_details ,
avg_maliat_havaleh_khoruj_kol from View_havaleh_khoruj order by date_havaleh_khoruj", Cs_Lib.CON_GhadirTire);
            sda.SelectCommand.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            sda.Fill(ds, "View_havaleh_khoruj");
            ds.Tables[0].Columns.Add("mount", typeof(int));
            ds.Tables[0].Columns.Add("year", typeof(string));
            DataRow dr_s = ds.Tables[0].Rows[0];
            DataRow dr_p = ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1];
            year_s = int.Parse(dr_s["date_havaleh_khoruj"].ToString().Split('/')[0]);
            year_p = int.Parse(dr_p["date_havaleh_khoruj"].ToString().Split('/')[0]);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["year"] = dr["date_havaleh_khoruj"].ToString().Split('/')[0];
                dr["mount"] = int.Parse(dr["date_havaleh_khoruj"].ToString().Split('/')[1] + "");
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("sud", typeof(Int64));
            dt.Columns.Add("name", typeof(string));
            sud = "0";
            for (int i = year_s; i <= year_p; i++)
            {

                for (int j = 1; j <= 12; j++)
                {
                    sud = ds.Tables[0].Compute("sum(sud)", "year= '" + i + "' and mount=" + j) + "";
                    if (sud == "")
                    {
                        sud = "0";
                    }


                    if (j == 1)
                    {
                        mount = "فروردین" + i;
                    }
                    if (j == 2)
                    {
                        mount = "اردیبهشت" + i;
                    }
                    if (j == 3)
                    {
                        mount = "خرداد" + i;
                    }
                    if (j == 4)
                    {
                        mount = "تیر" + i;
                    }
                    if (j == 5)
                    {
                        mount = "مرداد" + i;
                    }
                    if (j == 6)
                    {
                        mount = "شهریور" + i;
                    }
                    if (j == 7)
                    {
                        mount = "مهر" + i;
                    }
                    if (j == 8)
                    {
                        mount = "آبان" + i;
                    }
                    if (j == 9)
                    {
                        mount = "آذر" + i;
                    }
                    if (j == 10)
                    {
                        mount = "دی" + i;
                    }
                    if (j == 11)
                    {
                        mount = "بهمن" + i;
                    }
                    if (j == 12)
                    {
                        mount = "اسفند" + i;
                    }
                    dt.Rows.Add(Int64.Parse(sud), mount);


                }


            }
            chartControl1.DataSource = dt;
        }
    }
}
