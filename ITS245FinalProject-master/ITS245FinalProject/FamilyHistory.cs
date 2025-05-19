using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITS245FinalProject
{
    public partial class FamilyHistory : Form
    {
        public static SelectedPatient pFamHis;
        DataTable dt;
        public FamilyHistory()
        {
            InitializeComponent();
            this.VisibleChanged += new EventHandler(Form_VisableChanged);
        }
        private void Form_VisableChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                FamilyHistory_Load(this, EventArgs.Empty);
            }
        }
        //Controls for Navigation Bar between forms
        private void btnHome_Click(object sender, EventArgs e)
        {
            Form selectedForm = Application.OpenForms["SelectPatient"];
            if (selectedForm != null)
            {
                selectedForm.Show();
            }
            else
            {
                Form SelectPatient = new SelectPatient();
                SelectPatient.Show();
            }
            this.Hide();
        }

        private void btnPatDemos_Click(object sender, EventArgs e)
        {
            Form selectedForm = Application.OpenForms["PatientDemographics"];
            if (selectedForm != null)
            {
                selectedForm.Show();
            }
            else
            {
                Form PatientDemographics = new PatientDemographics();
                PatientDemographics.Show();
            }
            this.Hide();
        }

        private void btnGenHist_Click(object sender, EventArgs e)
        {
            Form selectedForm = Application.OpenForms["GeneralMedicalHistory"];
            if (selectedForm != null)
            {
                selectedForm.Show();
            }
            else
            {
                Form GeneralMedicalHistory = new GeneralMedicalHistory();
                GeneralMedicalHistory.Show();
            }
            this.Hide();
        }

        private void BtnAlgHist_Click(object sender, EventArgs e)
        {
            Form selectedForm = Application.OpenForms["AllergyHistory"];
            if (selectedForm != null)
            {
                selectedForm.Show();
            }
            else
            {
                Form AllergyHistory = new AllergyHistory();
                AllergyHistory.Show();
            }
            this.Hide();
        }

        private void btnFamHist_Click(object sender, EventArgs e)
        {
            Form selectedForm = Application.OpenForms["FamilyHistory"];
            if (selectedForm != null)
            {
                selectedForm.Show();
            }
            else
            {
                Form FamilyHistory = new FamilyHistory();
                FamilyHistory.Show();
            }
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Code for extra credit button nav that we haven't done yet
        }

        private void FamilyHistory_Load(object sender, EventArgs e)
        {
            MySqlConnection conn;

            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    dt = DBUtils.FamHisSearch(conn, SelectPatient.pSelect);
                    DataRow row = dt.NewRow();
                    dt.Columns.Add("RelationDisorder", typeof(string), "Relation + ': ' + MajorDisorder");
                    dt.Rows.InsertAt(row, 0);    
                    
                    bFamHis.DataSource = dt;
                    bFamHis.DisplayMember = "RelationDisorder";

                    lSelectedPatient.Text = "Patient: " + PatientDemographics.pBar.PtLastName + ", " + PatientDemographics.pBar.PtFirstName;
                    DateTime today = DateTime.Today;
                    int age = today.Year - PatientDemographics.pBar.DOB.Year;
                    if (PatientDemographics.pBar.DOB > today.AddYears(-age))
                    {
                        age--;
                    }
                    lSelectedPatient2.Text = "Age: " + age.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB Error: " + ex.Message);
                }
            }
        }

        private void bFamHis_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn;
            if (bFamHis.SelectedIndex != 0)
            {
                DataRowView row = (DataRowView)bFamHis.SelectedItem;
                pFamHis = new SelectedPatient(Convert.ToInt32(row.Row["FamilyID"].ToString()));
                using (conn = DBUtils.MakeConnection())
                    try
                    {
                        pFamHis = DBUtils.GrabFamHis(conn, pFamHis.pID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("DB Error: " + ex.Message);
                    }
                tFamilyID.Text = pFamHis.FamilyID;
                tFamPatientID.Text = pFamHis.PatientIDFam;
                tName.Text = pFamHis.Name;
                tRelation.Text = pFamHis.Relation;
                if(pFamHis.Alive == "True")
                {
                    chkbxAliveYes.Checked = true;
                }
                else
                {
                    chkbxAliveYes.Checked = false;
                }
                if(pFamHis.LivesWithPatient == "True")
                {
                    chkbxLivesWithPatient.Checked = true;
                }
                else
                {
                    chkbxLivesWithPatient.Checked = false;
                }
                tMajorDisorder.Text = pFamHis.MajorDisorder;
                tSpecificTypeDisorder.Text = pFamHis.SpecificTypeDisorder;

                foreach (Control control in panel1.Controls)
                {
                    TextBox tb = control as TextBox;
                    Label lb = control as Label;
                    CheckBox cb = control as CheckBox;
                    if (tb != null && !tb.Visible)
                    {
                        tb.Visible = true;
                    }
                    if (lb != null && !lb.Visible)
                    {
                        lb.Visible = true;
                    }
                    if (cb != null && !cb.Visible)
                    {
                        cb.Visible = true;
                    }
                }
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel1.Controls)
            {
                TextBox tb = control as TextBox;
                if (tb != null && tb.ReadOnly)
                {
                    tb.ReadOnly = false;
                    tb.BackColor = Color.White;
                    tb.Text = String.Empty;
                }
            }
            tFamilyID.ReadOnly = true;
            tFamilyID.BackColor = Color.DarkGray;

            bSave.Enabled = true;
            bDelete.Enabled = true;
            bUndo.Enabled = true;
        }

        private void bModify_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel1.Controls)
            {
                TextBox tb = control as TextBox;
                if (tb != null && tb.ReadOnly)
                {
                    tb.ReadOnly = false;
                    tb.BackColor = Color.White;
                }
            }
            tFamilyID.ReadOnly = true;
            tFamilyID.BackColor = Color.DarkGray;

            bSave.Enabled = true;
            bDelete.Enabled = true;
            bUndo.Enabled = true;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SelectedPatient saveFamHis = new SelectedPatient();
            if (tFamilyID.Text == string.Empty)
            {
                saveFamHis.FamilyID = 111111111.ToString();
            }
            else
            {
                saveFamHis.FamilyID = tFamilyID.Text;
            }
            saveFamHis.PatientIDFam = tFamPatientID.Text;
            saveFamHis.Name = tName.Text;
            saveFamHis.Relation = tRelation.Text;
            if (chkbxAliveYes.Checked)
            {
                saveFamHis.Alive = "1";
            }
            else
            {
                saveFamHis.Alive = "0";
            }
            if (chkbxLivesWithPatient.Checked)
            {
                saveFamHis.LivesWithPatient = "1";
            }
            else
            {
                saveFamHis.LivesWithPatient = "0";
            }
            saveFamHis.MajorDisorder = tMajorDisorder.Text;
            saveFamHis.SpecificTypeDisorder = tSpecificTypeDisorder.Text;

            MySqlConnection conn;
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    DBUtils.SaveFamHis(conn, saveFamHis);
                    MessageBox.Show("Item successfully saved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB Error: " + ex.Message);
                }
            }
            foreach (Control control in panel1.Controls)
            {
                TextBox tb = control as TextBox;
                if (tb != null && !tb.ReadOnly)
                {
                    tb.ReadOnly = true;
                    tb.BackColor = Color.DarkGray;
                }
            }
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            FamilyHistory_Load(this, EventArgs.Empty);

            MessageBox.Show("Successfully undid changes! Please reselect an item.");
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    DBUtils.DeleteAlgHist(conn, pFamHis);
                    MessageBox.Show("Item successfully deleted!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB Error: " + ex.Message);
                }
            }
        }

        private void FamilyHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Close();

                SelectPatient selectPatientForm = (SelectPatient)Application.OpenForms["SelectPatient"];
                if (selectPatientForm != null)
                {
                    selectPatientForm.CloseAllForms();
                }
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
