using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection OleDbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='D:\Courses\C# 25\Dictionary\Db_Dictionary.md'");
        Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            int num, count = 0;
            num = random.Next(1, 2490);

            OleDbConnection.Open();
            OleDbCommand command = new OleDbCommand("select ingilizce, turkce from dictinary where id = @p1", OleDbConnection);
            command.Parameters.AddWithValue("@p1", num);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                txtEng.Text = reader.GetString(0);
                lblWord.Text = reader.GetString(1);
            }
            if (txtTur.Text == lblWord.Text)
            {
                count++;
                lblCount.Text = count.ToString();
            }
        }
    }
}
