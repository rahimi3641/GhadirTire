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
    public partial class Frm_New_kala : DevExpress.XtraEditors.XtraForm
    {
        public Frm_New_kala()
        {
            InitializeComponent();
        }


        DataSet ds_for_insert;
        private void Frm_New_kala_Load(object sender, EventArgs e)
        {

            var sda = new SqlDataAdapter("A_select_for_insert_kala", Cs_Lib.CON_GhadirTire);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            ds_for_insert = new DataSet();
            sda.Fill(ds_for_insert);

            gridLookUpEdit_type_kala.Properties.DataSource = ds_for_insert.Tables[0];
            gridLookUpEdit_type_kala.Properties.DisplayMember = "name_type_kala";
            gridLookUpEdit_type_kala.Properties.ValueMember = "id_type_kala";

            gridLookUpEdit_pahna.Properties.DataSource = ds_for_insert.Tables[1];
            gridLookUpEdit_pahna.Properties.DisplayMember = "name_pahna";
            gridLookUpEdit_pahna.Properties.ValueMember = "id_pahna";

            gridLookUpEdit_manzar.Properties.DataSource = ds_for_insert.Tables[2];
            gridLookUpEdit_manzar.Properties.DisplayMember = "name_manzar";
            gridLookUpEdit_manzar.Properties.ValueMember = "id_manzar";

            gridLookUpEdit_ring.Properties.DataSource = ds_for_insert.Tables[3];
            gridLookUpEdit_ring.Properties.DisplayMember = "name_ring";
            gridLookUpEdit_ring.Properties.ValueMember = "id_ring";

            gridLookUpEdit_karkhaneh.Properties.DataSource = ds_for_insert.Tables[4];
            gridLookUpEdit_karkhaneh.Properties.DisplayMember = "name_karkhaneh";
            gridLookUpEdit_karkhaneh.Properties.ValueMember = "id_karkhaneh";

            gridLookUpEdit_keshvar.Properties.DataSource = ds_for_insert.Tables[5];
            gridLookUpEdit_keshvar.Properties.DisplayMember = "name_keshvar";
            gridLookUpEdit_keshvar.Properties.ValueMember = "id_keshvar";

            gridLookUpEdit_vahed.Properties.DataSource = ds_for_insert.Tables[6];
            gridLookUpEdit_vahed.Properties.DisplayMember = "name_vahed";
            gridLookUpEdit_vahed.Properties.ValueMember = "id_vahed";

            gridLookUpEdit_tarh_gol.Properties.DataSource = ds_for_insert.Tables[7];
            gridLookUpEdit_tarh_gol.Properties.DisplayMember = "name_tarh_gol";
            gridLookUpEdit_tarh_gol.Properties.ValueMember = "id_tarh_gol";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txt_kod_kala.Text == "")
            {
                XtraMessageBox.Show("کد کالا الزامی است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (gridLookUpEdit_type_kala.EditValue + "" == "")
            {
                XtraMessageBox.Show("خطا در انتخاب نوع کالا", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (gridLookUpEdit_pahna.EditValue + "" == "")
            {
                XtraMessageBox.Show("خطا در انتخاب پهنا", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (gridLookUpEdit_ring.EditValue + "" == "")
            {
                XtraMessageBox.Show("خطا در انتخاب رینگ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (gridLookUpEdit_manzar.EditValue + "" == "")
            {
                XtraMessageBox.Show("خطا در انتخاب منظر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (gridLookUpEdit_karkhaneh.EditValue + "" == "")
            {
                XtraMessageBox.Show("خطا در انتخاب کارخانه", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (gridLookUpEdit_keshvar.EditValue + "" == "")
            {
                XtraMessageBox.Show("خطا در انتخاب کشور", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (gridLookUpEdit_vahed.EditValue + "" == "")
            {
                XtraMessageBox.Show("خطا در انتخاب واحد شمارش", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (gridLookUpEdit_tarh_gol.EditValue + "" == "")
            {
                XtraMessageBox.Show("خطا در انتخاب طرح گل ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            try
            {
                var cmd = new SqlCommand("A_insert_kala", Cs_Lib.CON_GhadirTire);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@kod_kala", txt_kod_kala.Text);
                cmd.Parameters.AddWithValue("@name_kala", txt_name_kala.Text);

                cmd.Parameters.AddWithValue("@id_type_kala", gridLookUpEdit_type_kala.EditValue);
                cmd.Parameters.AddWithValue("@id_pahna", gridLookUpEdit_pahna.EditValue);
                cmd.Parameters.AddWithValue("@id_ring", gridLookUpEdit_ring.EditValue);
                cmd.Parameters.AddWithValue("@id_manzar", gridLookUpEdit_manzar.EditValue);
                cmd.Parameters.AddWithValue("@id_karkhaneh", gridLookUpEdit_karkhaneh.EditValue);
                cmd.Parameters.AddWithValue("@id_keshvar", gridLookUpEdit_keshvar.EditValue);
                cmd.Parameters.AddWithValue("@id_vahed", gridLookUpEdit_vahed.EditValue);
                cmd.Parameters.AddWithValue("@id_tarh_gol", gridLookUpEdit_tarh_gol.EditValue);


                Cs_Lib.CON_GhadirTire.Open();
                cmd.ExecuteNonQuery();
                Cs_Lib.CON_GhadirTire.Close();
                txt_kod_kala.Text = "";
                XtraMessageBox.Show("درج اطلاعات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                Cs_Lib.CON_GhadirTire.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    MessageBox.Show("کالا تکراری است");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}