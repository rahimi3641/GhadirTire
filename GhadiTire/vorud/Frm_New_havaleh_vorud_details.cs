using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GhadiTire.vorud
{
    public partial class Frm_New_havaleh_vorud_details : DevExpress.XtraEditors.XtraForm
    {
        public Frm_New_havaleh_vorud_details()
        {
            InitializeComponent();
            txt_date_havaleh_vorud.Text = "14__/__/__";
        }
        // cs
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        DataSet ds_for_insert;
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        DataTable dt_havaleh_vorud_details;
        private void Frm_New_havaleh_vorud_details_Load(object sender, EventArgs e)
        {
            dt_havaleh_vorud_details = new DataTable();
           // dt_havaleh_vorud_details.Columns.Add("radif", typeof(int));
            dt_havaleh_vorud_details.Columns.Add("id_kala", typeof(int));
            dt_havaleh_vorud_details.Columns.Add("tedad_havaleh_vorud_details", typeof(int));
            dt_havaleh_vorud_details.Columns.Add("mablagh_havaleh_vorud_details", typeof(int));

            dt_havaleh_vorud_details.Columns.Add("name_type_kala", typeof(string));
            dt_havaleh_vorud_details.Columns.Add("name_pahna", typeof(string));
            dt_havaleh_vorud_details.Columns.Add("name_manzar", typeof(string));
            dt_havaleh_vorud_details.Columns.Add("name_ring", typeof(string));
            dt_havaleh_vorud_details.Columns.Add("name_karkhaneh", typeof(string));
            dt_havaleh_vorud_details.Columns.Add("name_keshvar", typeof(string));
            dt_havaleh_vorud_details.Columns.Add("kod_kala", typeof(string));
            dt_havaleh_vorud_details.Columns.Add("name_vahed", typeof(string));

            dt_havaleh_vorud_details.Columns.Add("fi", typeof(int));


            gridControl_havaleh_vorud_details.DataSource = dt_havaleh_vorud_details;


            select_kala();
        }
        private void select_kala()
        {
            var sda = new SqlDataAdapter("A_select_for_insert_havaleh_vorud_details", Cs_Lib.CON_GhadirTire);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            ds_for_insert = new DataSet();
            sda.Fill(ds_for_insert);


            rp_GridLookUpEdit_kala.DataSource = ds_for_insert.Tables[0];
            rp_GridLookUpEdit_kala.DisplayMember = "sharh_kala";
            rp_GridLookUpEdit_kala.ValueMember = "id_kala";

            gridLookUpEdit_taraf.Properties.DataSource = ds_for_insert.Tables[1];
            gridLookUpEdit_taraf.Properties.DisplayMember = "name_taraf";
            gridLookUpEdit_taraf.Properties.ValueMember = "id_taraf";
        }
        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.VisibleIndex == 2)
            {
                dt_havaleh_vorud_details.Rows.Add(0,0,0, "", "", "", "", "", "","","",0);
            }
            if (e.Button.Properties.VisibleIndex == 3)
            {
                Frm_New_kala obg=new Frm_New_kala();
                obg.ShowDialog();
            }
            if (e.Button.Properties.VisibleIndex == 4)
            {
                select_kala();
            }
        }

        private void rp_del_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)BindingContext[dt_havaleh_vorud_details].Current;
            drv.Delete();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridLookUpEdit_taraf.EditValue+""=="")
            {
                XtraMessageBox.Show("خطا در انتخاب طرف حساب حواله", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (txt_date_havaleh_vorud.Text.Contains("_"))
            {
                XtraMessageBox.Show("خطا در درج تاریخ حواله", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (dt_havaleh_vorud_details.Rows.Count==0)
            {
                XtraMessageBox.Show("خطا در تعداد ردیف حواله", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (txt_sho_havaleh_vorud.Text == "")
            {
                XtraMessageBox.Show("خطا در شماره حواله", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("id_kala",typeof(int) );   
            dt.Columns.Add("tedad_havaleh_vorud_details", typeof(int) );   
            dt.Columns.Add("mablagh_havaleh_vorud_details", typeof(Int64) );   
            foreach (DataRow dr in dt_havaleh_vorud_details.Rows )
            {

                if ((int)dr["mablagh_havaleh_vorud_details"] ==0)
                {
                    XtraMessageBox.Show("مبلغ ردیف حواله نمی تواند صفر باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                if ((int)dr["tedad_havaleh_vorud_details"] == 0)
                {
                    XtraMessageBox.Show("تعداد ردیف حواله نمی تواند صفر باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                if ((int)dr["id_kala"] == 0)
                {
                    XtraMessageBox.Show("خظا در انتخاب کالا", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                dt.Rows.Add(dr["id_kala"], dr["tedad_havaleh_vorud_details"] , dr["mablagh_havaleh_vorud_details"]);
            }
            var cmd = new SqlCommand("A_inssert_havaleh_vorud_details", Cs_Lib.CON_GhadirTire);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@sho_havaleh_vorud", txt_sho_havaleh_vorud.Text);
            cmd.Parameters.AddWithValue("@date_havaleh_vorud",txt_date_havaleh_vorud.Text);
            cmd.Parameters.AddWithValue("@sharh_havaleh_vorud",Cs_Lib.replace ( txt_sharh_havaleh_vorud.Text));
            cmd.Parameters.AddWithValue("@id_taraf", gridLookUpEdit_taraf.EditValue);


            SqlParameter sqlParam_elzam = cmd.Parameters.AddWithValue("@TVP_havaleh_vorud_details", dt);
            sqlParam_elzam.SqlDbType = SqlDbType.Structured;

            Cs_Lib.CON_GhadirTire.Open();
            cmd.ExecuteNonQuery();
            Cs_Lib.CON_GhadirTire.Close();
            txt_sho_havaleh_vorud.Text = "";
            XtraMessageBox.Show("درج اطلاعات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            dt_havaleh_vorud_details.Rows.Clear();
        }

        private void gridView_havaleh_vorud_details_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void gridView_taraf_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void repositoryItemGridLookUpEdit1View_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void repositoryItemGridLookUpEdit1View_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if(e.FocusedRowHandle>=0)
            {
                DataRowView drv = (DataRowView)BindingContext[dt_havaleh_vorud_details].Current;
                DataRowView dr = (DataRowView)e.Row;
                drv["name_pahna"] = dr["name_pahna"];
                drv["name_ring"] = dr["name_ring"];
                drv["name_vahed"] = dr["name_vahed"];
                drv["name_keshvar"] = dr["name_keshvar"];
                drv["name_karkhaneh"] = dr["name_karkhaneh"];
                drv["name_manzar"] = dr["name_manzar"];
                drv["name_type_kala"] = dr["name_type_kala"];
                drv["kod_kala"] = dr["kod_kala"];

            }
  

        }

        private void txt_sho_havaleh_vorud_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl20_Click(object sender, EventArgs e)
        {

        }

        private void txt_date_havaleh_vorud_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridView_havaleh_vorud_details_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName== "tedad_havaleh_vorud_details" | e.Column.FieldName== "mablagh_havaleh_vorud_details")
            {
                gridView_havaleh_vorud_details.SetRowCellValue(e.RowHandle, "fi", int.Parse(gridView_havaleh_vorud_details.GetRowCellValue(e.RowHandle, "mablagh_havaleh_vorud_details") +"")*int.Parse(gridView_havaleh_vorud_details.GetRowCellValue(e.RowHandle, "tedad_havaleh_vorud_details") + ""));
            }
        }
    }
}