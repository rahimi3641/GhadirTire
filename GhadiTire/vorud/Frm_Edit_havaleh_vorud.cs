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
    public partial class Frm_Edit_havaleh_vorud : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Edit_havaleh_vorud()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("A_Update_havaleh_vorud", Cs_Lib.CON_GhadirTire);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_havaleh_vorud", UC_havaleh_vorud_details.drv_havaleh_vorud_details["id_havaleh_vorud"]);
            cmd.Parameters.AddWithValue("@date_havaleh_vorud", txt_date_havaleh_vorud.Text);
            cmd.Parameters.AddWithValue("@sho_havaleh_vorud", txt_sho_havaleh_vorud.Text);
            cmd.Parameters.AddWithValue("@id_taraf", gridLookUpEdit_taraf.EditValue);


            Cs_Lib.CON_GhadirTire.Open();
            cmd.ExecuteNonQuery();
            Cs_Lib.CON_GhadirTire.Close();
            Close();
        }

        private void Frm_Edit_havaleh_vorud_Load(object sender, EventArgs e)
        {
            var sda = new SqlDataAdapter("select * from tb_taraf", Cs_Lib.CON_GhadirTire);
            sda.SelectCommand.CommandType = CommandType.Text;
            DataSet ds_taraf = new DataSet();
            sda.Fill(ds_taraf);
            gridLookUpEdit_taraf.Properties.DataSource = ds_taraf.Tables[0];
            gridLookUpEdit_taraf.Properties.DisplayMember = "name_taraf";
            gridLookUpEdit_taraf.Properties.ValueMember = "id_taraf";

            txt_date_havaleh_vorud.Text = UC_havaleh_vorud_details.drv_havaleh_vorud_details["date_havaleh_vorud"] + "";
            txt_sho_havaleh_vorud.Text = UC_havaleh_vorud_details.drv_havaleh_vorud_details["sho_havaleh_vorud"] + "";
            gridLookUpEdit_taraf.EditValue = int.Parse(UC_havaleh_vorud_details.drv_havaleh_vorud_details["id_taraf"] + "");
        }
    }
}