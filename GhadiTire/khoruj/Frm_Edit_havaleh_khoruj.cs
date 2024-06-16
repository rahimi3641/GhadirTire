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

namespace GhadiTire.khoruj
{
    public partial class Frm_Edit_havaleh_khoruj : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Edit_havaleh_khoruj()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("A_Update_havaleh_khoruj", Cs_Lib.CON_GhadirTire);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_havaleh_khoruj", UC_havaleh_khoruj_details.drv_havaleh_khoruj["id_havaleh_khoruj"]);
            cmd.Parameters.AddWithValue("@date_havaleh_khoruj", txt_date_havaleh_khoruj.Text);
            cmd.Parameters.AddWithValue("@sho_havaleh_khoruj", txt_sho_havaleh_khoruj.Text);
            cmd.Parameters.AddWithValue("@id_taraf", gridLookUpEdit_taraf.EditValue);


            Cs_Lib.CON_GhadirTire.Open();
            cmd.ExecuteNonQuery();
            Cs_Lib.CON_GhadirTire.Close();
            Close();
        }

        private void Frm_Edit_havaleh_khoruj_Load(object sender, EventArgs e)
        {
            var sda = new SqlDataAdapter("select * from tb_taraf", Cs_Lib.CON_GhadirTire);
            sda.SelectCommand.CommandType = CommandType.Text;
            DataSet ds_taraf = new DataSet();
            sda.Fill(ds_taraf);
            gridLookUpEdit_taraf.Properties.DataSource = ds_taraf.Tables[0];
            gridLookUpEdit_taraf.Properties.DisplayMember = "name_taraf";
            gridLookUpEdit_taraf.Properties.ValueMember = "id_taraf";

            txt_date_havaleh_khoruj.Text = UC_havaleh_khoruj_details.drv_havaleh_khoruj["date_havaleh_khoruj"] + "";
            txt_sho_havaleh_khoruj.Text = UC_havaleh_khoruj_details.drv_havaleh_khoruj["sho_havaleh_khoruj"] + "";
            gridLookUpEdit_taraf.EditValue = int.Parse(UC_havaleh_khoruj_details.drv_havaleh_khoruj["id_taraf"] + "");
        }
    }
}