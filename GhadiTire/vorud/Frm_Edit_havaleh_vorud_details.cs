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

namespace GhadiTire.vorud
{
    public partial class Frm_Edit_havaleh_khoruj_details : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Edit_havaleh_khoruj_details()
        {
            InitializeComponent();
        }

        private void Frm_Edit_havaleh_vorud_details_Load(object sender, EventArgs e)
        {
            txt_sharh_kala.Text = UC_havaleh_vorud_details.drv_havaleh_vorud_details["sharh_kala"] + "";
            txt_mablagh_havaleh_vorud_details.Text = UC_havaleh_vorud_details.drv_havaleh_vorud_details["mablagh_havaleh_vorud_details"] + "";
            txt_tedad_havaleh_vorud_details.Text = UC_havaleh_vorud_details.drv_havaleh_vorud_details["tedad_havaleh_vorud_details"] + "";
            DataRow dr = select_baghi();
            txt_baghi_tedad_havaleh_vorud_details.Text = dr["baghi_tedad_havaleh_vorud_details"] + "";
            txt_sum_tedad_havaleh_khoruj_details.Text = dr["sum_tedad_havaleh_khoruj_details"] + "";
        }
        private DataRow  select_baghi()
        {
            var sda = new SqlDataAdapter(@"select * from View_sum_tedad_havaleh_khoruj_details_baghi where id_havaleh_vorud_details=@id_havaleh_vorud_details ", Cs_Lib.CON_GhadirTire);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Parameters.AddWithValue("@id_havaleh_vorud_details", UC_havaleh_vorud_details.drv_havaleh_vorud_details["id_havaleh_vorud_details"]);
            DataSet ds = new DataSet();
            sda.Fill(ds, "View_sum_tedad_havaleh_khoruj_details_baghi");
            return ds.Tables[0].Rows[0];
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRow dr = select_baghi();
            if (int.Parse(dr["sum_tedad_havaleh_khoruj_details"] + "") > int.Parse(txt_tedad_havaleh_vorud_details.Text))
            {
                XtraMessageBox.Show("تعداد ورودی نمی تواند کمتر از مقدار خروجی باشد ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                return;
            }

            SqlCommand cmd = new SqlCommand("A_Update_havaleh_vorud_details", Cs_Lib.CON_GhadirTire);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_havaleh_vorud_details", UC_havaleh_vorud_details.drv_havaleh_vorud_details["id_havaleh_vorud_details"]);
            cmd.Parameters.AddWithValue("@mablagh_havaleh_vorud_details", txt_mablagh_havaleh_vorud_details.EditValue);
            cmd.Parameters.AddWithValue("@tedad_havaleh_vorud_details", txt_tedad_havaleh_vorud_details.Text);
            Cs_Lib.CON_GhadirTire.Open();
            cmd.ExecuteNonQuery();
            Cs_Lib.CON_GhadirTire.Close();
            Close();
        }
    }
}