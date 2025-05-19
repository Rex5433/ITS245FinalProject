using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;

namespace ITS245FinalProject
{

    public partial class SelectPatient : Form
    {
        MySqlConnection conn;
        DataTable dt;
        public static SelectedPatient pSelect;
        public static SelectedPatient pExport;
        public SelectPatient()
        {
            InitializeComponent();
        }

        private void SelectPatient_Load(object sender, EventArgs e)
        {
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    dt = DBUtils.GetSelectPatient(conn);
                    this.gridPatient.DataSource = dt;
                    this.gridPatient.Columns["PatientID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textSearch.Text))
            {
                using (conn = DBUtils.MakeConnection())
                {
                    try
                    {
                        string search = textSearch.Text;
                        dt = DBUtils.SearchBox(conn, search);
                        gridPatient.DataSource = dt;
                        this.gridPatient.Columns["PatientID"].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid Option: Please enter text in the search bar.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    dt = DBUtils.GetSelectPatient(conn);
                    this.gridPatient.DataSource = dt;
                    this.gridPatient.Columns["PatientID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        public void gridPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            DataGridViewRow row = gridPatient.Rows[e.RowIndex];

            if (row.Cells["PatientID"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["PatientID"].Value.ToString()))
            {
                pSelect = new SelectedPatient(Convert.ToInt32(row.Cells["PatientID"].Value));
                Form PatientDemographics = new PatientDemographics();
                PatientDemographics.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a valid option");
            }
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //Does the same code as the search button but allows the user to press enter instead of clicking the button
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(textSearch.Text))
                {
                    using (conn = DBUtils.MakeConnection())
                    {
                        try
                        {
                            string search = textSearch.Text;
                            dt = DBUtils.SearchBox(conn, search);
                            gridPatient.DataSource = dt;
                            this.gridPatient.Columns["PatientID"].Visible = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Database Error: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Option: Please enter text in the search bar.");
                }
            }
        }

        private void SelectPatient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Cancel the close operation
                e.Cancel = true;
                // Close the form instead of hiding it
                this.Close();
            }
            else
            {
                // If the closing is not triggered by the user, let the form close
                e.Cancel = false;
            }
        }
        public void CloseAllForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form != this)
                {
                    form.Close();
                }
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            Report.CreateTextFile(pExport);
            //Temporary Console output code for testing:
            //AllocConsole();
        }

        private void gridPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gridPatient.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue;
            DataGridViewRow row = gridPatient.Rows[e.RowIndex];
            pExport = new SelectedPatient(Convert.ToInt32(row.Cells["PatientID"].Value));
        }
    }
}
