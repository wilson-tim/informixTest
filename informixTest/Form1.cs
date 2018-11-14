using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace informixTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text  = "dsn=SHG CMS";
            textBox2.Text = "SELECT * FROM root.dagent";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OdbcConnection cn;
            OdbcCommand cmd;
            String connectionString;
            String selectionString;

            connectionString = textBox1.Text;
            if (connectionString.Equals(""))
            {
                connectionString = "dsn=SHG CMS";
            }

            selectionString = textBox2.Text;
            if (selectionString.Equals(""))
            {
                selectionString = "SELECT * FROM root.dagent";
            }

            cn = new OdbcConnection(connectionString);

            cmd = new OdbcCommand(selectionString, cn);

            cn.Open();

            MessageBox.Show("Connected");

            OdbcDataReader reader = cmd.ExecuteReader();

            int i = 0;

            while (reader.Read() && i < 3)
            {
                MessageBox.Show(reader[0].ToString() + "|" + reader[1].ToString() + "|" + reader[2].ToString());
                i += 1;
            }

            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdbcConnection cn;
            String connectionString;

            try
            {
                connectionString = textBox1.Text;
                if (connectionString.Equals(""))
                {
                    connectionString = "dsn=SHG CMS";
                }
                cn = new OdbcConnection(connectionString);
                cn.Open();
                MessageBox.Show("Connected");
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
