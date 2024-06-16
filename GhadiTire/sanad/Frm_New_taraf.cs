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
    public partial class Frm_New_taraf : DevExpress.XtraEditors.XtraForm
    {
        public Frm_New_taraf()
        {
            InitializeComponent();
        }

        private void Frm_New_taraf_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txt_name_taraf.Text == "")
            {
                XtraMessageBox.Show("درج عنوان الزامی است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            var cmd = new SqlCommand("A_insert_taraf", Cs_Lib.CON_GhadirTire);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name_taraf", txt_name_taraf.Text);
            cmd.Parameters.AddWithValue("@fam_taraf", txt_fam_taraf.Text);
            cmd.Parameters.AddWithValue("@tel_taraf", txt_tel_taraf.Text);
            cmd.Parameters.AddWithValue("@adress", txt_adress.Text);
            cmd.Parameters.AddWithValue("@code_melli_taraf", txt_code_melli_taraf.Text);
            Cs_Lib.CON_GhadirTire.Open();
            cmd.ExecuteNonQuery();
            Cs_Lib.CON_GhadirTire.Close();
            txt_name_taraf.Text = "";
            XtraMessageBox.Show("درج اطلاعات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}