using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace WindowsFormsApp1
{
    public partial class Main_Menu : Form
    {
        private DBcontrol access = new DBcontrol();
        public Main_Menu()
        {
            InitializeComponent();
        }
        DataSheet f1;
        Selection1 s1;
        protected void button1_Click(object sender, EventArgs e)
        {
            f1 = new DataSheet();
            f1.MdiParent = this;
            f1.Show();
            f1.Left = toolStripContainer1.Right;
            f1.Top = toolStripContainer1.Top-30;

        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            s1 = new Selection1();
            s1.MdiParent = this;
            s1.Show();
            s1.Left = toolStripContainer1.Right;
            s1.Top = toolStripContainer1.Top - 30;

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // handle CSV
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    using (TextFieldParser csvParser = new TextFieldParser(file))
                    {
                        csvParser.CommentTokens = new string[] { "#" };
                        csvParser.SetDelimiters(new string[] { "," });
                        csvParser.HasFieldsEnclosedInQuotes = true;

                        // Skip the row with the column names
                        csvParser.ReadLine();

                        while (!csvParser.EndOfData)
                        {
                            // Read current line fields, pointer moves to the next line.
                            string[] fields = csvParser.ReadFields();
                            string Last_Name = fields[0];
                            string First_Name = fields[1];
                            string GMAT = fields[2];
                            string Email = fields[3];
                            string University = fields[4];
                            string Gender = fields[5];
                            string Files_Received = fields[6];
                            Console.WriteLine(Last_Name);
                            Console.WriteLine(First_Name);
                            Console.WriteLine(GMAT);
                            Console.WriteLine(Email);
                            Console.WriteLine(University);
                            Console.WriteLine(Gender);
                            Console.WriteLine(Files_Received);
                        }
                    }
                    Console.WriteLine(file.GetType());
                    string text = File.ReadAllText(file);
                    Console.WriteLine(text);
                    size = text.Length;

                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }
    }
}
