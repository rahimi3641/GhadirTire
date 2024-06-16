using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Globalization;

namespace GhadiTire
{
    internal class Cs_Lib
    {
        public static StreamReader wr;
        private static Byte[] KEY = { 0x54, 0x54, 0x98, 079, 0x35, 0x48, 0x97, 0x12 };
        private static Byte[] IV = { 0x08, 0x19, 0x24, 0x87, 0x39, 0x43, 0x16, 0x71, 0x38, 0x62, 0x93, 0x55, 0x29, 0x32, 0x95, 0x97 };
        public static SqlConnection CON_GhadirTire;
        private static string str;
        public static string ConnectionString;
        public static string path_exe = System.Windows.Forms.Application.StartupPath;
        public static string path_doc = Environment.CurrentDirectory;
        public static void con()
        {
            try
            {
                ConnectionString = Cs_Lib.constring("GhadirTire");

                CON_GhadirTire = new SqlConnection();

                CON_GhadirTire.ConnectionString = ConnectionString;
            }
            catch (Exception ex)
            {
                wr.Close();

                DevExpress.XtraEditors.XtraMessageBox.Show("خطا در برقراری با سرور" + "\n" + "با مدیر سیستم تماس گرفته شود" + "\n" + ex.Message);
                Frm_login.close = true;
                Frm_login.let = true;

                //MessageBox.Show(ex.Message );
                Application.Exit();
            }
        }
        public static string constring(string dbname)
        {
            wr = File.OpenText(System.Windows.Forms.Application.StartupPath + "\\info.txt");

            var ConnectionString = Cs_Lib.Decrypt(wr.ReadToEnd());
            var str1 = ConnectionString.Split(';');
            var str2 = str1[1].Split('=');

            if (str1.Length == 5)
            {
                str = str1[0] + ";" + str2[0] + "=" + dbname + ";" + str1[2] + ";" + str1[3] + ";" + str1[4];
            }
            if (str1.Length == 6)
            {
                str = str1[0] + ";" + str2[0] + "=" + dbname + ";" + str1[2] + ";" + str1[3] + ";" + str1[4] + ";" + str1[5];
            }

            return str;
        }
        public static string Decrypt(String Text)
        {
            if (Text != string.Empty)
            {
                try
                {
                    var TextBytes = Convert.FromBase64String(Text);

                    var rijKey = new RijndaelManaged();

                    rijKey.Mode = CipherMode.CBC;

                    var decryptor = rijKey.CreateDecryptor(KEY, IV);

                    var memoryStream = new MemoryStream(TextBytes);

                    var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                    var pTextBytes = new byte[TextBytes.Length];

                    var decryptedByteCount = cryptoStream.Read(pTextBytes, 0, pTextBytes.Length);

                    memoryStream.Close();

                    cryptoStream.Close();

                    var plainText = Encoding.UTF8.GetString(pTextBytes, 0, decryptedByteCount);

                    Text = string.Empty;

                    rijKey.Clear();

                    decryptor.Dispose();

                    memoryStream.Dispose();

                    cryptoStream.Dispose();

                    return plainText;
                }

                catch
                {
                    var t = string.Empty;

                    return t;
                }
            }

            else
            {
                return Text;
            }
        }
        public static string Get_Date_Farsi_Server()
        {
            var sda = new SqlDataAdapter("Get_Date_Server", Cs_Lib.CON_GhadirTire);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds, "Get_Date_Server");
            DataRow dr = ds.Tables["Get_Date_Server"].Rows[0];
            return farsi.GetYear((DateTime)dr["date"]) + "/" + farsi.GetMonth((DateTime)dr["date"]).ToString("00") + "/" + farsi.GetDayOfMonth((DateTime)dr["date"]).ToString("00");

        }
        public static string Encrypt(String Text)
        {
            if (Text != string.Empty)
            {
                try
                {
                    var TextBytes = Encoding.UTF8.GetBytes(Text);

                    var rijKey = new RijndaelManaged();

                    rijKey.Mode = CipherMode.CBC;

                    var encryptor = rijKey.CreateEncryptor(KEY, IV);

                    var memoryStream = new MemoryStream();

                    var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                    cryptoStream.Write(TextBytes, 0, TextBytes.Length);

                    cryptoStream.FlushFinalBlock();

                    var cipherTextBytes = memoryStream.ToArray();

                    memoryStream.Close();

                    cryptoStream.Close();

                    var cipherText = Convert.ToBase64String(cipherTextBytes);

                    Text = string.Empty;

                    rijKey.Clear();

                    encryptor.Dispose();

                    memoryStream.Dispose();

                    cryptoStream.Dispose();

                    return cipherText;
                }

                catch
                {
                    var t = string.Empty;

                    return t;
                }
            }

            else
            {
                return Text;
            }
        }
        public static bool sehat_kodmelli(string kod_melli)
        {
            try
            {
                var chArray = kod_melli.ToCharArray();
                var numArray = new int[chArray.Length];
                for (var i = 0; i < chArray.Length; i++)
                {
                    numArray[i] = (int)char.GetNumericValue(chArray[i]);
                }
                var num2 = numArray[9];
                switch (kod_melli)
                {
                    case "0000000000":
                    case "1111111111":
                    case "22222222222":
                    case "33333333333":
                    case "4444444444":
                    case "5555555555":
                    case "6666666666":
                    case "7777777777":
                    case "8888888888":
                    case "9999999999":
                        DevExpress.XtraEditors.XtraMessageBox.Show("کد ملی وارد شده صحیح نمی باشد");
                        return false;
                }
                var num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                var num4 = num3 - ((num3 / 11) * 11);
                if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
                {
                    return true;
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("کد ملی نا معتبر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                    return false;
                }
            }
            catch (Exception)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("کد ملی نا معتبر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                return false;
            }
        }
        public static bool sehat_kodmelli_for_excel(string kod_melli)
        {
            try
            {
                var chArray = kod_melli.ToCharArray();
                var numArray = new int[chArray.Length];
                for (var i = 0; i < chArray.Length; i++)
                {
                    numArray[i] = (int)char.GetNumericValue(chArray[i]);
                }
                var num2 = numArray[9];
                switch (kod_melli)
                {
                    case "0000000000":
                    case "1111111111":
                    case "22222222222":
                    case "33333333333":
                    case "4444444444":
                    case "5555555555":
                    case "6666666666":
                    case "7777777777":
                    case "8888888888":
                    case "9999999999":

                        return false;
                }
                var num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                var num4 = num3 - ((num3 / 11) * 11);
                if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string replace(string s)
        {
            string t;
            t = s.Replace('ي', 'ی');
            return t.Replace('ك', 'ک');
        }

        public static void Set_GridLookUpEdit(DevExpress.XtraEditors.GridLookUpEdit GridLookUpEdit, string onvan)
        {
            var dt = new DataTable();
            GridLookUpEdit.Properties.DataSource = dt;
            GridLookUpEdit.Properties.NullValuePromptShowForEmptyValue = true;
            GridLookUpEdit.Properties.NullValuePrompt = onvan;
        }

        public static void Set_GridLookUpEdit_by_null_value(DevExpress.XtraEditors.GridLookUpEdit GridLookUpEdit, string onvan)
        {
            var dt = new DataTable();
            GridLookUpEdit.Properties.DataSource = dt;
            GridLookUpEdit.Properties.NullValuePromptShowForEmptyValue = true;
            GridLookUpEdit.Properties.NullValuePrompt = onvan;
            GridLookUpEdit.EditValue = null;
        }
        public static void Set_GridLookUpEdit_by_edit_value(DevExpress.XtraEditors.GridLookUpEdit GridLookUpEdit, string onvan, int edit_value)
        {
            var dt = new DataTable();
            GridLookUpEdit.Properties.DataSource = dt;
            GridLookUpEdit.Properties.NullValuePromptShowForEmptyValue = true;
            GridLookUpEdit.Properties.NullValuePrompt = onvan;
            GridLookUpEdit.EditValue = edit_value;
        }
        //public static void Set_GridLookUpEdit_by_edit_value(DevExpress.XtraEditors.GridLookUpEdit GridLookUpEdit, string onvan, string  edit_value)
        //{
        //    var dt = new DataTable();
        //    GridLookUpEdit.Properties.DataSource = dt;
        //    GridLookUpEdit.Properties.NullValuePromptShowForEmptyValue = true;
        //    GridLookUpEdit.Properties.NullValuePrompt = onvan;
        //    GridLookUpEdit.EditValue = edit_value;
        //}


















































































        public static string StrSet(string S1)
        {
            var S = string.Empty;
            var T = string.Empty;
            S = S1.Replace(",", string.Empty);
            var i = S.Length - 3;
            if (S.Length > 3)
            {
                while (i > 0)
                {
                    T = S.Insert(i, "،");
                    S = T;
                    i -= 3;
                }
                S1 = T;
            }
            return S1;
        }
        public static string ClearStrSet(string S1)
        {
            var str = string.Empty;
            foreach (char c in S1)
            {
                if (c != '،')
                {
                    str += c;
                }
            }
            return str;
        }
        public static string ClearStrSet_Virgul(string S1)
        {
            var str = string.Empty;
            foreach (char c in S1)
            {
                if (c != ',')
                {
                    str += c;
                }
            }
            return str;
        }
        public static byte[] Compress(byte[] data)
        {
            var output = new MemoryStream();
            using (var gzip = new GZipStream(output, CompressionMode.Compress, true))
            {
                gzip.Write(data, 0, data.Length);

                gzip.Close();
            }
            return output.ToArray();
        }
        public static byte[] Decompress(byte[] data)
        {
            var output = new MemoryStream();
            var input = new MemoryStream();
            input.Write(data, 0, data.Length);
            input.Position = 0;

            using (var gzip = new GZipStream(input, CompressionMode.Decompress, true))
            {
                try
                {
                    var buff = new byte[64];
                    var read = gzip.Read(buff, 0, buff.Length);
                    while (read > 0)
                    {
                        output.Write(buff, 0, read);
                        read = gzip.Read(buff, 0, buff.Length);
                    }
                    gzip.Close();
                }
                catch
                {
                    MessageBox.Show("با توجه به تغييرات نسخه جديد نرم افزار جهت مشاهده تصوير با پشتيباني تماس بگيريد");
                }
            }
            return output.ToArray();
        }
        public static string replace_date_time_now()
        {
            var s = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString();
            var ss = s.Replace("/", "_");
            var sss = ss.Replace(":", "_");
            return sss;
        }
        public static void export_gridView_to_excel(DevExpress.XtraGrid.Views.Grid.GridView Grid_view, string name_file, DevExpress.XtraPrinting.XlsxExportOptions option)
        {
            var s = replace_date_time_now();
            //DevExpress.XtraPrinting.XlsxExportOptions o = new DevExpress.XtraPrinting.XlsxExportOptions();
            //o.SheetName = "test";

            Grid_view.ExportToXlsx(path_doc + "//Export to excel//LIST_" + name_file + "_" + s + ".xlsx", option);
            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = path_doc + "//Export to excel//LIST_" + name_file + "_" + s + ".xlsx";
            p.Start();
        }
        public static void export_treelist_to_excel(DevExpress.XtraTreeList.TreeList treelist, string name_file)
        {
            var s = replace_date_time_now();
    

            treelist.ExportToXlsx(path_doc + "//Export to excel//LIST_" + name_file + "_" + s + ".xlsx");
            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = path_doc + "//Export to excel//LIST_" + name_file + "_" + s + ".xlsx";
            p.Start();
        }
        public static string GET_IP()
        {
            var iphostinfo = Dns.Resolve(Dns.GetHostName());





            return iphostinfo.AddressList[0].ToString();
        }
        //public static void ExportToExcell(DataGridView dgv, string caption)
        //{
        //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        //    var excelApp = new Microsoft.Office.Interop.Excel.Application();
        //    var excelbook = excelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);


        //    var excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)(excelbook.Worksheets[1]);
        //    excelWorksheet.DisplayRightToLeft = true;

        //    var rngg = new Microsoft.Office.Interop.Excel.Range[1];
        //    var CellAddresscaption = Convert.ToString(Convert.ToChar(Convert.ToByte(65))) + "1";
        //    rngg[0] = excelWorksheet.get_Range(CellAddresscaption, CellAddresscaption);
        //    rngg[0].Value2 = caption;










        //    var ClmnCnt = dgv.Columns.Count;

        //    var rng = new Microsoft.Office.Interop.Excel.Range[ClmnCnt];


        //    for (var x = 0; x < ClmnCnt; x++)
        //    {
        //        if (x + 65 < 91)
        //        {
        //            var CellAddress = Convert.ToString(Convert.ToChar(Convert.ToByte(x + 65))) + "2";
        //            rng[x] = excelWorksheet.get_Range(CellAddress, CellAddress);
        //            rng[x].Value2 = dgv.Columns[x].HeaderText;
        //        }
        //        else
        //        {
        //            var CellAddress = "A" + Convert.ToString(Convert.ToChar(Convert.ToByte(x + 39))) + "2";
        //            rng[x] = excelWorksheet.get_Range(CellAddress, CellAddress);
        //            rng[x].Value2 = dgv.Columns[x].HeaderText;
        //        }
        //    }

        //    var j = 3;


        //    try
        //    {
        //        foreach (DataGridViewRow r in dgv.Rows)
        //        {
        //            for (var k = 0; k < ClmnCnt; k++)
        //            {
        //                if (k + 65 < 91)
        //                {
        //                    var CellAdress = Convert.ToString(Convert.ToChar(Convert.ToByte(k + 65))) + j.ToString();
        //                    rng[k] = excelWorksheet.get_Range(CellAdress, CellAdress);



        //                    if (r.Cells[k].Value == null)
        //                    {
        //                        r.Cells[k].Value = " ";
        //                    }




        //                    if (r.Cells[k].Value.ToString() == "False")
        //                    {
        //                        rng[k].Value2 = string.Empty;
        //                    }

        //                    if (r.Cells[k].Value.ToString() == "True")
        //                    {
        //                        rng[k].Value2 = dgv.Columns[k].HeaderText;
        //                    }
        //                    //if (r.Cells[k].Value.ToString().Contains('='))
        //                    //{
        //                    //    r.Cells[k].Value = string.Empty;
        //                    //}
        //                    //r.Cells[k].Value.ToString().Replace('=', ' ');
        //                    //r.Cells[k].Value.ToString().Replace('"', ' ');
        //                    //rng[k].Value2 = Cs_Lib.ClearStrSet(r.Cells[k].Value.ToString());
        //                    if (r.Cells[k].Value.ToString().Contains('='))
        //                    {
        //                        r.Cells[k].Value.ToString().Replace('=', ' ');
        //                    }
        //                    if (r.Cells[k].Value.ToString().Contains('"'))
        //                    {
        //                        r.Cells[k].Value.ToString().Replace('"', ' ');
        //                    }
        //                    rng[k].Value2 = Cs_Lib.ClearStrSet(r.Cells[k].Value.ToString());



        //                }
        //                else
        //                {
        //                    var CellAdress = "A" + Convert.ToString(Convert.ToChar(Convert.ToByte(k + 39))) + j.ToString();

        //                    rng[k] = excelWorksheet.get_Range(CellAdress, CellAdress);

        //                    if (r.Cells[k].Value == null)
        //                    {
        //                        r.Cells[k].Value = " ";
        //                    }



        //                    if (r.Cells[k].Value.ToString() == "False")
        //                    {
        //                        r.Cells[k].Value = string.Empty;
        //                    }

        //                    if (r.Cells[k].Value.ToString() == "True")
        //                    {
        //                        r.Cells[k].Value = dgv.Columns[k].HeaderText;
        //                    }

        //                    if (r.Cells[k].Value.ToString().Contains('='))
        //                    {
        //                        r.Cells[k].Value.ToString().Replace('=', ' ');
        //                    }
        //                    if (r.Cells[k].Value.ToString().Contains('"'))
        //                    {
        //                        r.Cells[k].Value.ToString().Replace('"', ' ');
        //                    }
        //                    rng[k].Value2 = Cs_Lib.ClearStrSet(r.Cells[k].Value.ToString());

        //                }
        //            }
        //            j++;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("خطادر ردیف " + "   " + (j - 2) + " \n" + ex.Message);


        //    }


        //    excelApp.Visible = true;
        //}
        public static void row_number_datagridview(DataGridView dgv)
        {
            //int counter=1;

            foreach (DataGridViewRow drw in dgv.Rows)
            {
                drw.Cells[0].Value = (drw.Index + 1).ToString();
            }
        }
        public static DateTime convert_date_shamsi_to_miladi(string date_shamsi)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            try
            {
                string[] date = date_shamsi.Split('/');
                return pc.ToDateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), 0, 0, 0, 0);
            }
            catch
            {
                MessageBox.Show("خطا در تاریخ ورودی");
                return pc.ToDateTime(1395, 1, 1, 0, 0, 0, 0);

            }


        }

        public static bool Sehat_date_shamsi(string date_shamsi)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DateTime d;
            try
            {
                string[] date = date_shamsi.Split('/');
                d= pc.ToDateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), 0, 0, 0, 0);
                return true;
            }
            catch
            {
                return false;

            }


        }
        public static int CountDayInDate(string date_s, string date_p)
        {

            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            string[] dateper1;
            string[] dateper2;
            try
            {

                dateper1 = date_s.Split('/');
                dateper2 = date_p.Split('/');
                DateTime dt1 = pc.ToDateTime(int.Parse(dateper1[0]), int.Parse(dateper1[1]), int.Parse(dateper1[2]), 0, 0, 0, 0);
                DateTime dt2 = pc.ToDateTime(int.Parse(dateper2[0]), int.Parse(dateper2[1]), int.Parse(dateper2[2]), 0, 0, 0, 0);
                return int.Parse(((dt2 - dt1).TotalDays + 1).ToString());
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("تاریخ را درست وارد نمایید" + "\n" + date_s + "*" + date_p + "\n" + ex.Message);
                return 0;
            }

        }
        public static string add_day_to_date(string date, int day)
        {
            string s;
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DateTime dt;
            int year_s = int.Parse(date.Split('/')[0]);
            int mount_s = int.Parse(date.Split('/')[1]);
            int d_s = int.Parse(date.Split('/')[2]);
            dt = pc.ToDateTime(year_s, mount_s, d_s, 0, 0, 0, 0).AddDays(day);
            string d_p = pc.GetDayOfMonth(dt).ToString();
            string mount_p = pc.GetMonth(dt).ToString();

            if (d_p.Length == 1)
            {
                d_p = "0" + d_p;
            }
            if (mount_p.Length == 1)
            {
                mount_p = "0" + mount_p;
            }
            s = pc.GetYear(dt) + "/" + mount_p + "/" + d_p;

            // MessageBox.Show(pc.GetYear(dt) + "/0" + mount_p + "/0" + d_p);
            return s;
        }
        /// <summary>
        /// به ترتیب عدد اول تا چهارم وارد شود
        /// </summary>
        public static bool comparision_4_number(int a, int b, int c, int d)
        {
            if (a <= b && b < c && c <= d)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static DataTable dt_Cells_Selected;
        public static DataTable Grid_Cells_Selected(DevExpress.XtraGrid.Views.Base.GridCell[] GridCell, DevExpress.XtraGrid.Views.Grid.GridView GridView)
        {
            dt_Cells_Selected = new DataTable();
            dt_Cells_Selected.Columns.Add("number", typeof(double));
            for (int i = 0; i < GridCell.Length; i++)
            {
                DataRow dr = GridView.GetDataRow(GridCell[i].RowHandle);
                string s = ClearStrSet_Virgul(ClearStrSet(dr[GridCell[i].Column.ColumnHandle].ToString()));
                double d;
                if (double.TryParse(s, out d))
                {
                    dt_Cells_Selected.Rows.Add(d);
                }

            }
            return dt_Cells_Selected;
        }
        public static void Back_Up_DB(int id_user)
        {
            //this.Cursor = Cursors.WaitCursor;

            try
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                string day = pc.GetDayOfMonth(DateTime.Now).ToString();
                if (day.Length < 2)
                    day = "0" + day;
                string mounth = pc.GetMonth(DateTime.Now).ToString();
                if (mounth.Length < 2)
                    mounth = "0" + mounth;
                string year = pc.GetYear(DateTime.Now).ToString();
                string time = DateTime.Now.ToLongTimeString();

                time = time.Substring(0, 2) + time.Substring(3, 2) + time.Substring(6, 2);
                //string adres = "E:\\BIEH ONLINE 2008\\Back Up\\BACKUPBIMEH_" + year + "_" + mounth + "_" + day + "_" + "_" + id_user.ToString() + ".bak";
                string adres = "E:\\Backup job\\CBS Backup\\CBS_HARA_backup_2017021510.bak";



                SqlCommand cmd = new SqlCommand("_BACKUP", Cs_Lib.CON_GhadirTire);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Adress", adres);
                Cs_Lib.CON_GhadirTire.Open();
                cmd.ExecuteNonQuery();
                Cs_Lib.CON_GhadirTire.Close();



                //this.Cursor = Cursors.Default;
                MessageBox.Show("تهيه نسخه پشتيبان از اطلا عات با موفقيت انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cs_Lib.CON_GhadirTire.Close();
            }







        }

        /// <summary>
        /// بررسی اینکه رشته ورودی  INT 32 می باشد
        /// </summary>
        public static bool sehat_int(string number)
        {
            int i;
            if (int.TryParse(number, out i))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string s;

        public static string nam_mah(Int16 mah)


        {
            switch (mah)
            {
                case 1:
                    s = "فروردین";
                    break;
                case 2:
                    s = "اردیبهشت";
                    break;
                case 3:
                    s = "خرداد";
                    break;
                case 4:
                    s = "تیر";
                    break;
                case 5:
                    s = "مرداد";
                    break;
                case 6:
                    s = "شهریور";
                    break;
                case 7:
                    s = "مهر";
                    break;
                case 8:
                    s = "آبان";
                    break;
                case 9:
                    s = "آذر";
                    break;
                case 10:
                    s = "دی";
                    break;
                case 11:
                    s = "بهمن";
                    break;
                case 12:
                    s = "اسفند";
                    break;
            }

            return s;
        }
        /// <summary>
        /// محاسبه سال کبیسه.
        /// </summary>
        public static bool kabiseh_days_of_mount(Int16 sal)
        {
            int a = (sal - 1391) % 4;
            //MessageBox.Show(sal + "");
            //MessageBox.Show(a + "");

            if (a == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// محاسبه تعداد روز ماه.
        /// </summary>
        public static Int16 kabiseh_days_of_mount(Int16 sal, Int16 mount)
        {
            if (mount > 0 && mount < 13)
            {

                if (kabiseh_days_of_mount(sal))
                {
                    if (mount < 7)
                    {
                        return 31;
                    }
                    else
                    {
                        return 30;
                    }
                }

                else
                {
                    if (mount < 7)
                    {
                        return 31;
                    }
                    else
                    {
                        if (mount > 6 && mount < 12)
                        {
                            return 30;

                        }
                        else
                        {
                            if (mount == 12)
                            {
                                return 29;
                            }
                            else
                            {
                                MessageBox.Show("خطا در بررسی شماره ماه");

                                return -2;
                            }


                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("خطا در درج شماره ماه");
                return -1;

            }

        }
        /// <summary>
        /// حرکت بر روی سلول های دیتاگریدویو با دکمه اینتر
        /// </summary>
        public static void Move_Focus_On_Next_Cell_in_a_datagridview_On_Enter_Key(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{up}");
                SendKeys.Send("{left}");
            }
        }
        public static double Compute_data_table(DataSet ds, int table, string expression, string filter)

        {
            if (ds.Tables[table].Compute(expression, filter) + "" == "")
            {
                return 0;
            }
            else
            {
                return (double)ds.Tables[table].Compute(expression, filter);
            }

        }


        public static Int64 Compute_data_table_int_64(DataSet ds, int table, string expression, string filter)

        {
            if (ds.Tables[table].Compute(expression, filter) + "" == "")
            {
                return 0;
            }
            else
            {
                return (Int64)ds.Tables[table].Compute(expression, filter);
            }

        }

        //public static float Compute_data_table_float(DataSet ds, int table, string expression, string filter)

        //{
        //    if (ds.Tables[table].Compute(expression, filter) + "" == "")
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return (float)ds.Tables[table].Compute(expression, filter);
        //    }

        //}





        //public static string string_for_select_IN;

        //public static string  create_string_for_select_IN(DataSet ds,int table,string column_if,string column_s)
        //{
        //    string_for_select_IN = "";
        //    foreach (DataRow dr in ds.Tables[table].Rows)
        //    {
        //        if ((bool)dr[column_if])
        //        {
        //            string_for_select_IN = string_for_select_IN + dr[column_s] +",";
        //        }
        //    }
        //    return string_for_select_IN.Remove(string_for_select_IN.Length -1, 1);
        //}
        public static double Compute_data_table(DataTable dt, string expression, string filter)

        {
            if (dt.Compute(expression, filter) + "" == "")
            {
                return 0;
            }
            else
            {
                return (double)dt.Compute(expression, filter);
            }

        }
        public static string save_file(string FileName, string Filter)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = FileName;
            sfd.Filter = "|." + Filter;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }
            else
            {
                return "";
            }

        }
        public static Int64 convert_date_to_int(string date)
        {
            string[] s = date.Split('/');
            try
            {
                return Int64.Parse(s[0] + s[1] + s[2]);

            }
            catch
            {

                return convert_date_to_int("0/0/0");
            }
        }
        public static void counter_upload(int id_porojeh_asnad)
        {
            SqlCommand cmd = new SqlCommand("A_counter_upload", Cs_Lib.CON_GhadirTire);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_porojeh_asnad", id_porojeh_asnad);
            Cs_Lib.CON_GhadirTire.Open();
            cmd.ExecuteNonQuery();
            Cs_Lib.CON_GhadirTire.Close();
        }
        public static System.Globalization.PersianCalendar farsi = new System.Globalization.PersianCalendar();

        public static string Get_Date_Farsi_Server(DateTime dt)
        {

            return farsi.GetYear(dt) + "/" + farsi.GetMonth(dt).ToString("00") + "/" + farsi.GetDayOfMonth(dt).ToString("00");

        }

        public static double mohasebeh_bimeh_pardakhtani_dasti_peymankar(bool omrani, double mablagh_nakhales, double dasti_bimeh)
        {
            if (omrani)
                return Math.Round((0.016 * 100 * mablagh_nakhales) / 100, 0);
            else
                return Math.Round((0.166666667 * dasti_bimeh  * mablagh_nakhales) / 100, 0);


        }
        public static double mohasebeh_bimeh_pardakhtani_mekaniki_karfarma(bool omrani, double mablagh_nakhales, double mekaniki_bimeh)
        {
            if (omrani)
                return Math.Round((0.05 * 100 * mablagh_nakhales) / 100, 0);
            else
                return Math.Round((0.077777778 * mekaniki_bimeh * mablagh_nakhales) / 100, 0);
        }
        public static bool control_125_gharadad(double mablagh_gharardad,double mablagh_surat_vazeat)
        {
            if (mablagh_gharardad * 125 / 100>= mablagh_surat_vazeat)

                return true ;
            else
                return false;
        }
        public static string Name_Mount_Farsi;
        public static string Get_Name_Mount_Farsi(string Date_Farsi)
        {

            string[] s = Date_Farsi.Split('/');
            int i;
            try
            {
                i = int.Parse(s[1].ToString());
                switch (i)
                {
                    case 1:
                        Name_Mount_Farsi = "فروردین";
                        break;
                    case 2:
                        Name_Mount_Farsi = "اردیبهشت";
                        break;
                    case 3:
                        Name_Mount_Farsi = "خرداد";
                        break;
                    case 4:
                        Name_Mount_Farsi = "تیر";
                        break;
                    case 5:
                        Name_Mount_Farsi = "مرداد";
                        break;
                    case 6:
                        Name_Mount_Farsi = "شهریور";
                        break;
                    case 7:
                        Name_Mount_Farsi = "مهر";
                        break;
                    case 8:
                        Name_Mount_Farsi = "آبان";
                        break;
                    case 9:
                        Name_Mount_Farsi = "آذر";
                        break;
                    case 10:
                        Name_Mount_Farsi = "دی";
                        break;
                    case 11:
                        Name_Mount_Farsi = "بهمن";
                        break;
                    case 12:
                        Name_Mount_Farsi = "اسفند";
                        break;


                }

            }
            catch
            {

                return "خطای نام ماه";

            }
            return Name_Mount_Farsi;

        }
        public static string date_arzyabi_avallieh(string kod_melli)
        {
            
            SqlDataAdapter sda = new SqlDataAdapter(@"select top 1 id_arzyabi_avallieh from tb_arzyabi_avallieh where 
kod_melli=@kod_melli  order by date_arzyabi_avallieh desc", Cs_Lib.CON_GhadirTire);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Parameters.AddWithValue("@kod_melli", kod_melli);          
            DataSet ds = new DataSet();
            sda.Fill(ds, "tb_arzyabi_avallieh");
            if(ds.Tables["tb_arzyabi_avallieh"].Rows.Count==0)
            {
                return "";
            }
            else
            {
                DataRow dr = ds.Tables["tb_arzyabi_avallieh"].Rows[0];
                return dr["date_arzyabi_avallieh"] + "";

            }
           // return ds.Tables["tb_arzyabi_avallieh"].Rows.Count;

        }
       public static  char t;

        public static string Replace_Decimal_Symbol(string s)
        {
            foreach (char c in s )
            {
                if(!char.IsDigit(c))
                {
                    t = c;
                }
            }
            return s.Replace(t, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
        }
    }
}
