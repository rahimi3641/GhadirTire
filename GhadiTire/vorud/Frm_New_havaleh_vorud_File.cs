using DevExpress.Utils.CommonDialogs;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhadiTire.vorud
{
    public partial class Frm_New_havaleh_vorud_File : DevExpress.XtraEditors.XtraForm
    {
        public Frm_New_havaleh_vorud_File()
        {
            InitializeComponent();
        }

        private void Frm_New_sanad_File_Load(object sender, EventArgs e)
        {
            txt_id_havaleh_vorud.Text = UC_havaleh_vorud_details.drv_havaleh_vorud_details["id_havaleh_vorud"] + "";
        }

        private void txt_doc_adress1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            openFileDialog1.InitialDirectory = Cs_Lib.path_doc;
            openFileDialog1.Title = "انتخاب فایل جهت الصاق به سند";
            openFileDialog1.DefaultExt = "bak";
            openFileDialog1.Filter = "All Files (*.*)|*.*";


            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            txt_doc_adress1.Text = openFileDialog1.FileName;
                if (txt_doc_adress1.Text == "")
                {
                    MessageBox.Show("خطا در انتخاب فایل");
                    return;
                }
                if (File.ReadAllBytes(txt_doc_adress1.Text).Length == 0)
                {
                    MessageBox.Show("حجم فایل صفر می باشد");
                    txt_doc_adress1.Text = string.Empty;
                    return;
                }
                if (File.ReadAllBytes(txt_doc_adress1.Text).Length > 1048576)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("حداكثر حجم مجاز 1 مگابايت مي باشد");
                    txt_doc_adress1.Text = string.Empty;
                    return;

                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_doc_adress1.Text == "")
            {
                MessageBox.Show("خطا در انتخاب فایل");
                return;
            }
            if (File.ReadAllBytes(txt_doc_adress1.Text).Length == 0)
            {
                MessageBox.Show("حجم فایل صفر می باشد");
                txt_doc_adress1.Text = string.Empty;
                return;
            }
            if (File.ReadAllBytes(txt_doc_adress1.Text).Length > 1048576)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("حداكثر حجم مجاز 1 مگابايت مي باشد");
                txt_doc_adress1.Text = string.Empty;
                return;

            }


            try
            {
                Cursor = Cursors.WaitCursor;

                SqlCommand cmd = new SqlCommand("A_Insert_havaleh_vorud_file", Cs_Lib.CON_GhadirTire);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_havaleh_vorud ", UC_havaleh_vorud_details.drv_havaleh_vorud_details["id_havaleh_vorud"]);
                cmd.Parameters.AddWithValue("@tozihat_havaleh_vorud_file", Cs_Lib.replace(txt_tozihat_havaleh_vorud_File.Text));
                cmd.Parameters.AddWithValue("@fileSuorce_havaleh_vorud", Cs_Lib.Compress(File.ReadAllBytes(txt_doc_adress1.Text)));
                cmd.Parameters.AddWithValue("@file_ext_havaleh_vorud", openFileDialog1.FileName.Split('.')[openFileDialog1.FileName.Split('.').Length - 1]);
                cmd.Parameters.AddWithValue("@file_name_havaleh_vorud", openFileDialog1.SafeFileName.Split('.')[0]);
                Cs_Lib.CON_GhadirTire.Open();
                cmd.ExecuteNonQuery();
                Cs_Lib.CON_GhadirTire.Close();
                Cursor = Cursors.Default;
                txt_doc_adress1.Text = string.Empty;


            }
            catch (Exception ex)
            {
                Cs_Lib.CON_GhadirTire.Close();
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }
    }
}