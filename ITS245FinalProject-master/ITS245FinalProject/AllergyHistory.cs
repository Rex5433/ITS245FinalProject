using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ITS245FinalProject
{
    public partial class AllergyHistory : Form
    {
        SelectedPatient pAlgHist = new SelectedPatient();
        DataTable dt;
        public AllergyHistory()
        {
            InitializeComponent();
            this.VisibleChanged += new EventHandler(Form_VisableChanged);
        }
        private void Form_VisableChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                AllergyHistory_Load(this, EventArgs.Empty);
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

        private void bAlgDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    DBUtils.DeleteAlgHist(conn, pAlgHist);
                    MessageBox.Show("Item successfully deleted!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB Error: " + ex.Message);
                }
            }
        }

        public void AllergyHistory_Load(object sender, EventArgs e)
        {
            MySqlConnection conn;

            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    dt = DBUtils.AlgHistSearch(conn, SelectPatient.pSelect);
                    DataRow row = dt.NewRow();
                    dt.Rows.InsertAt(row, 0);
                    bAlgHist.DataSource = dt;
                    bAlgHist.DisplayMember = "Allergen";

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

        private void bAlgAdd_Click(object sender, EventArgs e)
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
            tAllergyID.ReadOnly = true;
            tAllergyID.BackColor = Color.DarkGray;

            bAlgSave.Enabled = true;
            bAlgDelete.Enabled = true;
            bAlgUndo.Enabled = true;
        }

        private void bAlgModify_Click(object sender, EventArgs e)
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
            tAllergyID.ReadOnly = true;
            tAllergyID.BackColor = Color.DarkGray;

            bAlgSave.Enabled = true;
            bAlgDelete.Enabled = true;
            bAlgUndo.Enabled = true;
        }

        private void bAlgSave_Click(object sender, EventArgs e)
        {
            //When save button is clicked, the data in the text boxes is saved to the database
            SelectedPatient saveAlg = new SelectedPatient();
            if (tAllergyID.Text == string.Empty)
            {
                saveAlg.AllergyID = 111111111.ToString();
            }
            else
            {
                saveAlg.AllergyID = tAllergyID.Text;
            }
            
            saveAlg.PatientIDAllergy = tAlgPatientID.Text;
            saveAlg.Allergen = tAllergen.Text;
            saveAlg.AllergyStartDate = tAllergyStartDate.Text;
            saveAlg.AllergyEndDate = tAllergyEndDate.Text;
            saveAlg.AllergyDescription = tAllergyDescription.Text;

            MySqlConnection conn;
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    DBUtils.SaveAllergy(conn, saveAlg);
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

        private void bAlgUndo_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;

            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    AllergyHistory_Load(this, EventArgs.Empty);

                    MessageBox.Show("Successfully undid changes! Please reselect an item.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB Error: " + ex.Message);
                }
            }
        }

        private void bAlgHist_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn;
            if (bAlgHist.SelectedIndex != 0)
            {
                DataRowView row = (DataRowView)bAlgHist.SelectedItem;
                pAlgHist = new SelectedPatient(Convert.ToInt32(row.Row["AllergyID"].ToString()));
                using (conn = DBUtils.MakeConnection())           
                try
                {
                    pAlgHist = DBUtils.GrabAllergy(conn, pAlgHist.pID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB Error: " + ex.Message);
                }

                tAllergyID.Text = pAlgHist.AllergyID;
                tAlgPatientID.Text = pAlgHist.PatientIDAllergy;
                tAllergen.Text = pAlgHist.Allergen;
                tAllergyStartDate.Text = pAlgHist.AllergyStartDate;
                tAllergyEndDate.Text = pAlgHist.AllergyEndDate;
                tAllergyDescription.Text = pAlgHist.AllergyDescription;

                foreach (Control control in panel1.Controls)
                {
                    TextBox tb = control as TextBox;
                    Label lb = control as Label;
                    if (tb != null && !tb.Visible)
                    {
                        tb.Visible = true;
                    }
                    if (lb != null && !lb.Visible)
                    {
                        lb.Visible = true;
                    }
                }
            }
            
        }

        private void AllergyHistory_FormClosing(object sender, FormClosingEventArgs e)
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
