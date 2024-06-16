using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhadiTire
{
    public partial class Frm_login : DevExpress.XtraEditors.XtraForm
    {
        public Frm_login()
        {
            InitializeComponent();
        }
        public static bool close;
        public static bool let;
        public static string[] ARGS = new string[1];

        private void Frm_login_Load(object sender, EventArgs e)
        {

        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            close = false;


            //نگه داشتن نام کاربریtskarbar
          //  CBS_HARA.Properties.Settings.Default.nam_karbar = this.txt_nam_user.Text;
            Properties.Settings.Default.Save();

          //  select_user_row();

            //if (ds_select_user_for_inter.Tables["sp_select_user_for_inter"].Rows.Count != 0)
            //{
            //    check_and_update_vesion();
            //    user_access(ds_select_user_for_inter.Tables["sp_select_user_for_inter"].Rows[0]);

            //    insert_user_savabegh();

                let = true;
                this.Close();

            //}
            //else
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show("نام كاربري يا رمز عبور اشتباه است ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            //    this.txt_nam_user.Select();
            //}


        }

        private void Frm_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (let != true)
            {
                e.Cancel = true;

            }
        }
    }
}