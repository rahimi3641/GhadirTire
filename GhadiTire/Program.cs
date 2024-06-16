using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Threading;

namespace GhadiTire
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            bool ok;
            var m = new Mutex(true, "GhadirTire", out ok);

            if (!ok)
            {
                MessageBox.Show("یک نسخه از برنامه در حال اجرا می باشد");

                return;
            }


            if (args.Length != 0)
            {
                Frm_login.ARGS[0] = args[0];

            }
            else
            {
                Frm_login.ARGS[0] = "--doupdate";
            }
            //MessageBox.Show(args[0] + "3");
            //MessageBox.Show(Frm_login.ARGS[0] + "4");
            //فارسی کردن صفحه کلید
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("fa-ir"));
            // System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("fa-ir");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //فارسی ساز
            CultureInfo culture = CultureInfo.CreateSpecificCulture("fa-IR");
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            //

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new Form1());
            GC.KeepAlive(m);

        }
    }
}
