using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Resizing;
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

namespace GhadiTire.khoruj
{
    public partial class Frm_New_havaleh_khoruj_details : DevExpress.XtraEditors.XtraForm
    {
        public Frm_New_havaleh_khoruj_details()
        {
            InitializeComponent();
        }
        DataSet ds_for_insert;

        private void Frm_New_havaleh_khoruj_details_Load(object sender, EventArgs e)
        {
            txt_date_havaleh_khoruj.Text = "14__/__/__";


            //dt_havaleh_vorud_details = new DataTable();
            //// dt_havaleh_vorud_details.Columns.Add("radif", typeof(int));
            //dt_havaleh_vorud_details.Columns.Add("id_kala", typeof(int));
            //dt_havaleh_vorud_details.Columns.Add("tedad_havaleh_vorud_details", typeof(int));
            //dt_havaleh_vorud_details.Columns.Add("mablagh_havaleh_vorud_details", typeof(int));

            //dt_havaleh_vorud_details.Columns.Add("name_type_kala", typeof(string));
            //dt_havaleh_vorud_details.Columns.Add("name_pahna", typeof(string));
            //dt_havaleh_vorud_details.Columns.Add("name_manzar", typeof(string));
            //dt_havaleh_vorud_details.Columns.Add("name_ring", typeof(string));
            //dt_havaleh_vorud_details.Columns.Add("name_karkhaneh", typeof(string));
            //dt_havaleh_vorud_details.Columns.Add("name_keshvar", typeof(string));
            //dt_havaleh_vorud_details.Columns.Add("kod_kala", typeof(string));
            //dt_havaleh_vorud_details.Columns.Add("name_vahed", typeof(string));

            //gridControl_havaleh_vorud_details.DataSource = dt_havaleh_vorud_details;


            var sda = new SqlDataAdapter("A_select_for_insert_havaleh_khoruj_details", Cs_Lib.CON_GhadirTire);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            ds_for_insert = new DataSet();
            sda.Fill(ds_for_insert);


            gridLookUpEdit_kala.Properties.DataSource = ds_for_insert.Tables[0];
            gridLookUpEdit_kala.Properties.DisplayMember = "sharh_kala";
            gridLookUpEdit_kala.Properties.ValueMember = "id_kala";

            gridLookUpEdit_taraf.Properties.DataSource = ds_for_insert.Tables[1];
            gridLookUpEdit_taraf.Properties.DisplayMember = "name_taraf";
            gridLookUpEdit_taraf.Properties.ValueMember = "id_taraf";

            if(ds_for_insert.Tables[2].Rows.Count != 0)
            {
                DataRow dr = ds_for_insert.Tables[2].Rows[0];
              //  txt_sho_havaleh_khoruj_end.Text = dr["id_havaleh_khoruj"] + "";
                txt_id_havaleh_khoruj_end.Text = dr["id_havaleh_khoruj"] + "";
                txt_sho_havaleh_khoruj_end.Text = dr["sho_havaleh_khoruj"] + "";

            }
        }
        DataSet ds_havaleh_vorud_details;
        private void baghi_kala()
        {
            if (gridLookUpEdit_kala.EditValue + "" != "")
            {
                var sda = new SqlDataAdapter(@"A_select_baghi_havaleh_vorud_details", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@id_kala", gridLookUpEdit_kala.EditValue);
                ds_havaleh_vorud_details = new DataSet();
                sda.Fill(ds_havaleh_vorud_details, "A_select_baghi_havaleh_vorud_details");
                ds_havaleh_vorud_details.Tables[0].Columns.Add("tedad_havaleh_khoruj_details", typeof(int));
                ds_havaleh_vorud_details.Tables[0].Columns.Add("mablagh_havaleh_khoruj_details", typeof(int));
                if (ds_havaleh_vorud_details.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds_havaleh_vorud_details.Tables[0].Rows)
                    {
                        dr["mablagh_havaleh_khoruj_details"] = 0;
                        dr["tedad_havaleh_khoruj_details"] = 0;
                    }
                    gridControl_havaleh_khoruj_details.DataSource = ds_havaleh_vorud_details.Tables["A_select_baghi_havaleh_vorud_details"];
                    txt_baghi_tedad_havaleh_vorud_details.Text = ds_havaleh_vorud_details.Tables["A_select_baghi_havaleh_vorud_details"].Compute("SUM(baghi_tedad_havaleh_vorud_details)", "id_kala=" + gridLookUpEdit_kala.EditValue) + "";
                    mohasebeh();
                }
                else
                {
                    gridControl_havaleh_khoruj_details.DataSource = null;

                }

            }
        }
        private void gridLookUpEdit_kala_EditValueChanged(object sender, EventArgs e)
        {
            baghi_kala();
        }

        int c;
        private void mohasebeh()
        {

            if(ds_havaleh_vorud_details==null)
            {
                XtraMessageBox.Show("خطا در انتخاب کالا", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (ds_havaleh_vorud_details.Tables[0].Rows.Count == 0)
            {
                XtraMessageBox.Show("خطا در نعداد ردیف حواله ورود کالا", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (gridControl_havaleh_khoruj_details.DataSource == null)
            {
                XtraMessageBox.Show("خطا در نعداد ردیف حواله ورود کالا", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            c = 0;
            foreach (DataRow dr in ds_havaleh_vorud_details.Tables[0].Rows)
            {
                dr["tedad_havaleh_khoruj_details"] = 0;
               // dr["mablagh_havaleh_khoruj_details"] = txt_mablagh_havaleh_khoruj_details.EditValue;
                dr["mablagh_havaleh_khoruj_details"] =0;
            }
            if (txt_tedad_havaleh_khoruj_details.Text == "")
                txt_tedad_havaleh_khoruj_details.Text = "0";
            if (int.Parse(txt_tedad_havaleh_khoruj_details.EditValue + "") > int.Parse(txt_baghi_tedad_havaleh_vorud_details.EditValue + ""))
            {
                txt_tedad_havaleh_khoruj_details.EditValue= "0";
                XtraMessageBox.Show("مقدار خروج بیش از موجودی است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            txt_mablagh_havaleh_khoruj_details_kol.Text = (int.Parse(txt_mablagh_havaleh_khoruj_details.EditValue + "") * int.Parse(txt_tedad_havaleh_khoruj_details.EditValue + "")) + "";

            for (int i = 0; i < ds_havaleh_vorud_details.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds_havaleh_vorud_details.Tables[0].Rows[i];

                if (i == 0)
                {
                    c = int.Parse(txt_tedad_havaleh_khoruj_details.EditValue+"") - int.Parse(dr["baghi_tedad_havaleh_vorud_details"] + "");
                    if (c <= 0)
                    {

                        dr["tedad_havaleh_khoruj_details"] = txt_tedad_havaleh_khoruj_details.EditValue;
                        dr["mablagh_havaleh_khoruj_details"] = txt_mablagh_havaleh_khoruj_details.EditValue;

                        return;
                    }
                    else
                    {

                        dr["tedad_havaleh_khoruj_details"] = dr["baghi_tedad_havaleh_vorud_details"];
                        dr["mablagh_havaleh_khoruj_details"] = txt_mablagh_havaleh_khoruj_details.EditValue;

                    }

                }
                else
                {
                    if (c - int.Parse(dr["baghi_tedad_havaleh_vorud_details"] + "") <= 0)
                    {
                        dr["tedad_havaleh_khoruj_details"] = c;
                        dr["mablagh_havaleh_khoruj_details"] = txt_mablagh_havaleh_khoruj_details.EditValue;

                        return;
                    }
                    else
                    {
                        dr["tedad_havaleh_khoruj_details"] = dr["baghi_tedad_havaleh_vorud_details"];
                        dr["mablagh_havaleh_khoruj_details"] = txt_mablagh_havaleh_khoruj_details.EditValue;
                        c = c - int.Parse(dr["baghi_tedad_havaleh_vorud_details"] + "");
                    }
                }

            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridLookUpEdit_taraf.EditValue + "" == "")
            { XtraMessageBox.Show("خطا در انتخاب طرف حساب حواله", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
               
            }

            if (txt_date_havaleh_khoruj.Text.Contains("_"))
            {
                XtraMessageBox.Show("خطا در درج تاریخ حواله", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (txt_sho_havaleh_khoruj.Text == "")
            {
                XtraMessageBox.Show("خطا در شماره حواله", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (ds_havaleh_vorud_details.Tables[0].Rows.Count == 0)
            {
                XtraMessageBox.Show("خطا در تعداد ردیف حواله", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            c = 0;
            foreach (DataRow dr in ds_havaleh_vorud_details.Tables[0].Rows)
            {
                if ((int)dr["mablagh_havaleh_khoruj_details"] != 0)
                {
                    c++;
                }

            }
            if(c==0)
            {
                XtraMessageBox.Show("مبلغ  حواله نمی تواند صفر باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            c= 0;
            foreach (DataRow dr in ds_havaleh_vorud_details.Tables[0].Rows)
            {
                if ((int)dr["tedad_havaleh_khoruj_details"] != 0)
                {
                    c++;
                }
            }
            if (c == 0)
            {
                XtraMessageBox.Show("تعداد خروجی  کالا نمی تواند صفر باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            foreach (DataRow dr in ds_havaleh_vorud_details.Tables[0].Rows)
            {
                if ((int)dr["tedad_havaleh_khoruj_details"] != 0)
                {
                    try
                    {
                        this.Cursor= Cursors.WaitCursor;    

                        var cmd = new SqlCommand("A_inssert_havaleh_khoruj_details", Cs_Lib.CON_GhadirTire);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sho_havaleh_khoruj", txt_sho_havaleh_khoruj.Text);
                        cmd.Parameters.AddWithValue("@date_havaleh_khoruj", txt_date_havaleh_khoruj.Text);
                        cmd.Parameters.AddWithValue("@sharh_havaleh_khoruj", Cs_Lib.replace ( txt_sharh_havaleh_khoruj.Text));
                        cmd.Parameters.AddWithValue("@id_taraf", gridLookUpEdit_taraf.EditValue);
                        cmd.Parameters.AddWithValue("@id_havaleh_vorud_details", int.Parse(dr["id_havaleh_vorud_details"] + ""));
                        cmd.Parameters.AddWithValue("@tedad_havaleh_khoruj_details", int.Parse(dr["tedad_havaleh_khoruj_details"] + ""));
                        cmd.Parameters.AddWithValue("@mablagh_havaleh_khoruj_details", int.Parse(dr["mablagh_havaleh_khoruj_details"] + ""));
                        Cs_Lib.CON_GhadirTire.Open();
                       cmd.ExecuteNonQuery();


                        var sda = new SqlDataAdapter(@"select * from View_havaleh_khoruj where date_havaleh_khoruj=@date_havaleh_khoruj and sho_havaleh_khoruj=@sho_havaleh_khoruj and id_taraf=@id_taraf
 select * from View_havaleh_khoruj_details where date_havaleh_khoruj=@date_havaleh_khoruj and sho_havaleh_khoruj=@sho_havaleh_khoruj and id_taraf=@id_taraf ", Cs_Lib.CON_GhadirTire);
                        sda.SelectCommand.CommandType = CommandType.Text;
                        sda.SelectCommand.Parameters.AddWithValue("@date_havaleh_khoruj",txt_date_havaleh_khoruj.Text);
                        sda.SelectCommand.Parameters.AddWithValue("@sho_havaleh_khoruj", txt_sho_havaleh_khoruj.Text);
                        sda.SelectCommand.Parameters.AddWithValue("@id_taraf", gridLookUpEdit_taraf.EditValue);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ds.Tables[0].Columns.Add ("sud",typeof(int)); 
                        foreach (DataRow d in ds.Tables[0].Rows)
                        {
                            d["sud"] = int.Parse(d["fi_havaleh_khoruj_kol"] +"") - int.Parse(d["fi_havaleh_vorud_kol"] + "");
                        }
                        gridControl_havaleh_khoruj.DataSource = ds.Tables[0];
                        gridControl_havaleh_khoruj_details_1.DataSource = ds.Tables[1];

                        Cs_Lib.CON_GhadirTire.Close();
                        this.Cursor = Cursors.Default;

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;

                        Cs_Lib.CON_GhadirTire.Close();

                        if (ex.Message.Contains("UNIQUE KEY"))
                        {
                            MessageBox.Show("خروجی کالا تکراری است");
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }

              
            }
            MessageBox.Show("ok");
            baghi_kala();
        }

        private void gridView_havaleh_khoruj_details_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "tedad_havaleh_khoruj_details")
            {

                if (int.Parse(gridView_havaleh_khoruj_details.GetRowCellValue(e.RowHandle, "tedad_havaleh_khoruj_details") + "") > int.Parse(gridView_havaleh_khoruj_details.GetRowCellValue(e.RowHandle, "baghi_tedad_havaleh_vorud_details") + ""))
                {
                    XtraMessageBox.Show("تعداد خروجی بیش از موجودی نمی تواند باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                    gridView_havaleh_khoruj_details.SetRowCellValue(e.RowHandle, "tedad_havaleh_khoruj_details", 0);
                }
            }
        }

        private void gridControl_havaleh_khoruj_details_1_Click(object sender, EventArgs e)
        {

        }

        private void gridLookUpEdit1View_kala_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridView_havaleh_khoruj_details_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void gridView_havaleh_khoruj_details_1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void txt_tedad_havaleh_khoruj_details_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void txt_mablagh_havaleh_khoruj_details_kol_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_tedad_havaleh_khoruj_details_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void txt_tedad_havaleh_khoruj_details_EditValueChanged(object sender, EventArgs e)
        {
            mohasebeh();

        }

        private void txt_mablagh_havaleh_khoruj_details_EditValueChanged(object sender, EventArgs e)
        {
            mohasebeh();

        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if(e.Button.Properties.VisibleIndex == 0) { 
            dockPanel_baghi_havaleh_vorud_details.Show();
            }
            if (e.Button.Properties.VisibleIndex == 0)
            {
                dockPanel_havaleh_khoruj_details_1.Show();
            }
        }

        private void dockPanel_havaleh_khoruj_details_1_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_id_havaleh_khoruj_end_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index==0)
            {
                var sda = new SqlDataAdapter(@"select * from View_havaleh_khoruj where id_havaleh_khoruj=@id_havaleh_khoruj
 select * from View_havaleh_khoruj_details where id_havaleh_khoruj=@id_havaleh_khoruj ", Cs_Lib.CON_GhadirTire);
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@id_havaleh_khoruj", txt_id_havaleh_khoruj_end.Text);
       
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ds.Tables[0].Columns.Add("sud", typeof(int));
                foreach (DataRow d in ds.Tables[0].Rows)
                {
                    d["sud"] = int.Parse(d["fi_havaleh_khoruj_kol"] + "") - int.Parse(d["fi_havaleh_vorud_kol"] + "");
                }
                gridControl_havaleh_khoruj.DataSource = ds.Tables[0];
                gridControl_havaleh_khoruj_details_1.DataSource = ds.Tables[1];
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

        private void txt_date_havaleh_khoruj_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelControl19_Click(object sender, EventArgs e)
        {

        }
    }
}