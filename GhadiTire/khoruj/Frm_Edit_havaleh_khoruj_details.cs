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
    public partial class Frm_Edit_havaleh_khoruj_details : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Edit_havaleh_khoruj_details()
        {
            InitializeComponent();
        }

        private void Frm_Edit_havaleh_vorud_details_Load(object sender, EventArgs e)
        {
            txt_mablagh_havaleh_khoruj_details.Text = UC_havaleh_khoruj_details.drv_havaleh_khoruj["avg_mablagh_havaleh_khoruj_details"] + "";
        
        }
 

        private void simpleButton1_Click(object sender, EventArgs e)
        {
   
            SqlCommand cmd = new SqlCommand("A_Update_havaleh_khoruj_details", Cs_Lib.CON_GhadirTire);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_havaleh_khoruj", UC_havaleh_khoruj_details.drv_havaleh_khoruj["id_havaleh_khoruj"]);
            cmd.Parameters.AddWithValue("@id_kala", UC_havaleh_khoruj_details.drv_havaleh_khoruj["id_kala"]);
            cmd.Parameters.AddWithValue("@mablagh_havaleh_khoruj_details", txt_mablagh_havaleh_khoruj_details.EditValue);
            Cs_Lib.CON_GhadirTire.Open();
            cmd.ExecuteNonQuery();
            Cs_Lib.CON_GhadirTire.Close();
            Close();
        }
    }
}