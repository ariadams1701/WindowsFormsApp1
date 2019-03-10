using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
namespace WindowsFormsApp1
{
    public partial class DataSheet : Form
    {
        private DBcontrol access = new DBcontrol();
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        UserCredential credential;
        public DataSheet()
        {
            InitializeComponent();
        }

        private void DataSheet_Load(object sender, EventArgs e)
        {

            IList<IList<Object>> values = access.Google_sheets();
            if (values != null && values.Count > 0)
            {
                dataGridView1.ColumnCount = 8;
                dataGridView1.Columns[0].Name = "Last Name";
                dataGridView1.Columns[1].Name = "First Name";
                dataGridView1.Columns[2].Name = "GMAT";
                dataGridView1.Columns[3].Name = "Email";
                dataGridView1.Columns[4].Name = "University";
                dataGridView1.Columns[5].Name = "Gender";
                dataGridView1.Columns[6].Name = "Files Received";
                Int16 i = 0;
                foreach (var row in values)
                {
                    // Print columns A and E, which correspond to indices 0 and 4.
                    // string items = (row[0]).ToString(); test stuff
                    i += 1;
                    if (row.Count > 0)
                    {
                        string row1 = row[0].ToString();
                        string row2 = row[1].ToString();
                        string row3 = row[2].ToString();
                        string row4 = row[3].ToString();
                        string row5 = row[4].ToString();
                        string row6 = row[5].ToString();
                        string row7 = row[6].ToString();
                        string[] rows = new string[] { row1, row2, row3, row4, row5, row6, row7 };
                        dataGridView1.Rows.Add(rows);
                    }
                    else
                    {
                        dataGridView1.Rows.Add("");
                    }
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
