using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _169_Agcanas_JakeRussel_Inv
{
    public partial class frmMain : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\\169_Agcanas_JakeRussel_SC\\dbSchoolSuplies.accdb");
        Form rform = new frmRecorgMgmt();
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            rform.ShowDialog();
        }
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                string name = dtgrRecords.SelectedCells[1].Value.ToString();
                string price = dtgrRecords.SelectedCells[3].Value.ToString();
                string qntty = txtQuantity.Text;

                Form pform = new frmPurchase(name, price, qntty);
                pform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ate ilan ang i-buy ng self?");
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            search("SELECT Product.*FROM Product;");
        }

        void search(string _query)
        {
            OleDbCommand cmd = new OleDbCommand(_query, conn);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dtgrRecords.DataSource = dt;
        }

      
    }
}
