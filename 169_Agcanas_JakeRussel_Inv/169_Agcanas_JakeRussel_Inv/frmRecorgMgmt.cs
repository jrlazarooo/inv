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
    public partial class frmRecorgMgmt : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\\169_Agcanas_JakeRussel_SC\\dbSchoolSuplies.accdb");
        public frmRecorgMgmt()
        {
            InitializeComponent();
        }

        private void frmRecorgMgmt_Load(object sender, EventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search("SELECT Product.*FROM Product WHERE (((Product.ProdID) = '" + txtprodID.Text + "'));");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Product(ProdID, prodName, Quantity, Price) VALUES('"+txtprodID.Text+ "', '" + txtprodName.Text + "', '" + txtQuantity.Text + "', '" + txtPrice.Text + "') ";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT Product.*FROM Product;");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = " UPDATE Product SET prodName = '" + txtprodName.Text + "', Quantity = '" + txtQuantity.Text + "', Price = '" + txtPrice.Text + "' WHERE ProdID = '"+txtprodID.Text+"' ";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT Product.*FROM Product;");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Product WHERE ProdID = '"+txtprodID.Text+"' ";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT Product.*FROM Product;");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtprodID.Clear();
            txtprodName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();

            search("SELECT Product.*FROM Product;");
        }
    }
}
