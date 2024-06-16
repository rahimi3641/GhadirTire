using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace GhadiTire.khoruj
{
    public partial class R_havaleh_khoruj : DevExpress.XtraReports.UI.XtraReport
    {
        public R_havaleh_khoruj()
        {
            InitializeComponent();
             DataSource = khoruj.UC_havaleh_khoruj_details.ds;
            // Parameters[""]
          //  Parameters["test"].Value = 100;
        }

    }
}
