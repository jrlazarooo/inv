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
    public partial class frmPurchase : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\\169_Agcanas_JakeRussel_SC\\dbSchoolSuplies.accdb");
   
        string name;
        string price;
        string qntty;

        public frmPurchase(string _name, string _price, string _qntty)
        {
            InitializeComponent();
            name = _name;
            price = _price;
            qntty = _qntty;
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            lblprodName.Text = "Product Name: " + name;
            lblprodPrice.Text = "Product Price: " + price;
            lblQuantity.Text = "Quantity: " + qntty;
            lblTotal.Text = "Total Price: " + Int32.Parse(price) * Int32.Parse(qntty); 
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFname.Text) || !string.IsNullOrWhiteSpace(txtLname.Text) || !string.IsNullOrWhiteSpace(txtcID.Text))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Customer(custID, firstname, lastname) VALUES('" + txtcID.Text + "', '" + txtFname.Text + "', '" + txtLname.Text + "') ";
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Congrats! GASTADOR ka.");
            }
            else
            {
                MessageBox.Show("Sino ka? \nsino tatay mo? \nbakit di kla pa registered?");
            }
        }
    }
}
