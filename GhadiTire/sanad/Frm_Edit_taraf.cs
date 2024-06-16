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

namespace GhadiTire.sanad
{
    public partial class Frm_Edit_taraf : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Edit_taraf()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var cmd = new SqlCommand("A_update_taraf", Cs_Lib.CON_GhadirTire);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_taraf", UC_taraf.drv_taraf["id_taraf"]);
            cmd.Parameters.AddWithValue("@name_taraf", txt_name_taraf.Text);
            cmd.Parameters.AddWithValue("@fam_taraf", txt_fam_taraf.Text);
            cmd.Parameters.AddWithValue("@tel_taraf", txt_tel_taraf.Text);
            cmd.Parameters.AddWithValue("@adress", txt_adress.Text);
            cmd.Parameters.AddWithValue("@code_melli_taraf", txt_code_melli_taraf.Text);
            Cs_Lib.CON_GhadirTire.Open();
            cmd.ExecuteNonQuery();
            Cs_Lib.CON_GhadirTire.Close();
            Close();
        }

        private void Frm_Edit_taraf_Load(object sender, EventArgs e)
        {
            txt_name_taraf.Text = UC_taraf.drv_taraf["name_taraf"] .ToString();
            txt_fam_taraf.Text = UC_taraf.drv_taraf["fam_taraf"] + "";
            txt_adress.Text = UC_taraf.drv_taraf["adress"] + "";
            txt_tel_taraf.Text = UC_taraf.drv_taraf["tel_taraf"] + "";
            txt_code_melli_taraf.Text = UC_taraf.drv_taraf["code_melli_taraf"] + "";
        }
    }
}