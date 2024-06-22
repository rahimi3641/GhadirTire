using DevExpress.Emf;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using GhadiTire.vorud;
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
    public partial class Frm_New_sanad : DevExpress.XtraEditors.XtraForm
    {
        public Frm_New_sanad()
        {
            InitializeComponent();
        }
        DataSet ds_for_insert;
        DataTable dt_bed_bes;
        private void Frm_New_sanad_Load(object sender, EventArgs e)
        {
            txt_date_sanad.Text = "14__/__/__";

            var sda = new SqlDataAdapter("A_select_for_insert_sanad", Cs_Lib.CON_GhadirTire);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            ds_for_insert = new DataSet();
            sda.Fill(ds_for_insert);


            rp_GridLookUpEdit_taraf.DataSource = ds_for_insert.Tables[0];
            rp_GridLookUpEdit_taraf.DisplayMember = "name_taraf";
            rp_GridLookUpEdit_taraf.ValueMember = "id_taraf";

            dt_bed_bes = new DataTable();
            dt_bed_bes.Columns.Add("id_taraf", typeof(int));
            dt_bed_bes.Columns.Add("mablagh_bed", typeof(Int64));
            dt_bed_bes.Columns.Add("mablagh_bes", typeof(Int64));
            dt_bed_bes.Columns.Add("sharh_bed_bes", typeof(string));
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.VisibleIndex == 1)
            {
                dt_bed_bes.Rows.Add(0, 0, 0, "");
                gridControl_bed_bes.DataSource = dt_bed_bes;
            }
        }

        private void repositoryItemGridLookUpEdit_View_taraf_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "ردیف")
            {
                if (e.ListSourceRowIndex >= 0)
                {
                    GridView g = (GridView)sender;
                    e.DisplayText = (g.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();
                }

            }
        }

        private void rp_del_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRowView drv = (DataRowView)BindingContext[dt_bed_bes].Current;
            drv.Delete();
        }
        Int64 sum_mablagh_bed;
        Int64 sum_mablagh_bes;
        private void btn_visible()
        {
            sum_mablagh_bed = 0;
            sum_mablagh_bes = 0;
            if (dt_bed_bes.Rows.Count == 0)
            {
                btn_ok.Visible = false;
            }
            else
            {
                foreach (DataRow dr in dt_bed_bes.Rows)
                {
                    sum_mablagh_bed = sum_mablagh_bed + Int64.Parse(dr["mablagh_bed"] + "");
                    sum_mablagh_bes = sum_mablagh_bes + Int64.Parse(dr["mablagh_bes"] + "");
                }
                //  MessageBox.Show(sum_mablagh_bed + "");
                //MessageBox.Show(sum_mablagh_bes + "");
                if (sum_mablagh_bed == 0)
                {
                    btn_ok.Visible = false;
                    return;
                }
                if (sum_mablagh_bes == 0)
                {
                    btn_ok.Visible = false;
                    return;
                }

                if (sum_mablagh_bes == sum_mablagh_bed)
                {
                    btn_ok.Visible = true;
                }
                else
                {
                    btn_ok.Visible = false;

                }
            }

        }
        int End_id_sanad;
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_date_sanad.Text.Contains("_"))
            {
                XtraMessageBox.Show("خطا در درج تاریخ سند", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (txt_sho_sanad.Text == "")
            {
                XtraMessageBox.Show("خطا در درج شماره سند", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            sum_mablagh_bed = 0;
            sum_mablagh_bes = 0;
            foreach (DataRow dr in dt_bed_bes.Rows)
            {
                //MessageBox.Show(dt_bed_bes.Compute("COUNT(id_taraf)", "") + "id_taraf=" + dr["id_taraf"]);
                //return;
                if (dt_bed_bes.Compute("COUNT(id_taraf)","id_taraf="+dr["id_taraf"])+""!="1")
                {
                    XtraMessageBox.Show("خطای تکرار سرفصل حسابداری ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                    return;
                }

                if (dr["mablagh_bed"] == dr["mablagh_bes"])
                {
                    XtraMessageBox.Show("خطا در  ثبت مبالغ کد خطا 01 ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (dr["mablagh_bed"] + "" == "0" && dr["mablagh_bes"] + "" == "0")
                {
                    XtraMessageBox.Show("خطا در  ثبت مبالغ کد خطا 02 ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (dr["id_taraf"] + "" == "0")
                {
                    XtraMessageBox.Show(" انتخاب سرفصل حساب الزامی است ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                sum_mablagh_bed = sum_mablagh_bed + Int64.Parse(dr["mablagh_bed"] + "");
                sum_mablagh_bes = sum_mablagh_bes + Int64.Parse(dr["mablagh_bes"] + "");
            }
            if (sum_mablagh_bes != sum_mablagh_bed)
            {
                XtraMessageBox.Show("بدهکار برابر با بستانکار نیست ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            try
            {

                var cmd = new SqlCommand("A_insert_sanad", Cs_Lib.CON_GhadirTire);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date_sanad", txt_date_sanad.Text);
                cmd.Parameters.AddWithValue("@sharh_sanad", txt_sharh_sanad.Text);
                cmd.Parameters.AddWithValue("@sho_sanad", txt_sho_sanad.Text);
                Cs_Lib.CON_GhadirTire.Open();
                End_id_sanad = int.Parse(cmd.ExecuteScalar() + "");
                Cs_Lib.CON_GhadirTire.Close();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                Cs_Lib.CON_GhadirTire.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    MessageBox.Show("شماره سند تکراری است");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
                return;

            }

            foreach (DataRow dr in dt_bed_bes.Rows)
            {
                if (dr["mablagh_bed"] + "" != "0")
                {
                    var cmd_bed = new SqlCommand("A_insert_sanad_bed", Cs_Lib.CON_GhadirTire);
                    cmd_bed.CommandType = CommandType.StoredProcedure;
                    cmd_bed.Parameters.AddWithValue("@id_sanad", End_id_sanad);
                    cmd_bed.Parameters.AddWithValue("@sharh_sanad_bed", dr["sharh_bed_bes"]);
                    cmd_bed.Parameters.AddWithValue("@mablagh_sanad_bed", dr["mablagh_bed"]);
                    cmd_bed.Parameters.AddWithValue("@id_taraf", dr["id_taraf"]);
                    Cs_Lib.CON_GhadirTire.Open();
                    cmd_bed.ExecuteNonQuery();
                    Cs_Lib.CON_GhadirTire.Close();
                }
                if (dr["mablagh_bes"] + "" != "0")
                {
                    var cmd_bes = new SqlCommand("A_insert_sanad_bes", Cs_Lib.CON_GhadirTire);
                    cmd_bes.CommandType = CommandType.StoredProcedure;
                    cmd_bes.Parameters.AddWithValue("@id_sanad", End_id_sanad);
                    cmd_bes.Parameters.AddWithValue("@sharh_sanad_bes", dr["sharh_bed_bes"]);
                    cmd_bes.Parameters.AddWithValue("@mablagh_sanad_bes", dr["mablagh_bes"]);
                    cmd_bes.Parameters.AddWithValue("@id_taraf", dr["id_taraf"]);
                    Cs_Lib.CON_GhadirTire.Open();
                    cmd_bes.ExecuteNonQuery();
                    Cs_Lib.CON_GhadirTire.Close();
                }
            }
            dt_bed_bes.Rows.Clear();
            gridControl_bed_bes.DataSource = dt_bed_bes;
            XtraMessageBox.Show("درج اطلاعات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            btn_ok.Visible = false;
        }

        private void repositoryItemGridLookUpEdit_View_taraf_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {


        }

        private void gridView_bed_bes_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gridView_bed_bes_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {



            if (e.Column.FieldName == "mablagh_bed")
            {
                if (gridView_bed_bes.GetRowCellValue(e.RowHandle, "mablagh_bed") + "" != "0")
                {
                    gridView_bed_bes.SetRowCellValue(e.RowHandle, "mablagh_bes", 0);

                }

            }
            if (e.Column.FieldName == "mablagh_bes")
            {
                if (gridView_bed_bes.GetRowCellValue(e.RowHandle, "mablagh_bes") + "" != "0")
                {
                    gridView_bed_bes.SetRowCellValue(e.RowHandle, "mablagh_bed", 0);

                }

            }
            sum_mablagh_bed = 0;
            sum_mablagh_bes = 0;
            foreach (DataRow dr in dt_bed_bes.Rows)
            {
                sum_mablagh_bed = sum_mablagh_bed + Int64.Parse(dr["mablagh_bed"] + "");
                sum_mablagh_bes = sum_mablagh_bes + Int64.Parse(dr["mablagh_bes"] + "");
            }
            if (sum_mablagh_bed == 0)
            {
                btn_ok.Visible = false;
                return;
            }
            if (sum_mablagh_bes == 0)
            {
                btn_ok.Visible = false;
                return;
            }

            if (sum_mablagh_bes == sum_mablagh_bed)
            {
                btn_ok.Visible = true;
            }
            else
            {
                btn_ok.Visible = false;

            }
            //DataRowView drv = (DataRowView)this.BindingContext[dt_bed_bes].Current;
            //if (e.Column.FieldName == "mablagh_bes")

            //{
            //    //  gridView_bed_bes.SetRowCellValue(e.RowHandle, "mablagh_bed", 0);
            //    drv["mablagh_bed"] = 0;
            //    btn_visible();
            //}
            //if (e.Column.FieldName == "mablagh_bed")
            //{
            //  //  gridView_bed_bes.SetRowCellValue(e.RowHandle, "mablagh_bes", 0);
            //    btn_visible();
            //}
            //MessageBox.Show(sum_mablagh_bed + "");
            //MessageBox.Show(sum_mablagh_bes + "");
        }
    }
}