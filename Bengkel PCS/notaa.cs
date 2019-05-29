using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_PCS
{
    public partial class notaa : Form
    {
        public notaa()
        {
            InitializeComponent();
            //Cashier cash = new Cashier();
            htrans = Cashier.htrans;
            idcus = Cashier.idcus;
        }
        string htrans;
        string idcus;
        private void notaa_Load(object sender, EventArgs e)
        {
            Nota rep = new Nota();
            rep.SetDatabaseLogon("project", "11");
            rep.SetParameterValue("id_trans", htrans);
            rep.SetParameterValue("id_cust", idcus);
            crystalReportViewer1.ReportSource = rep;
            crystalReportViewer1.Refresh();
        }
    }
}
