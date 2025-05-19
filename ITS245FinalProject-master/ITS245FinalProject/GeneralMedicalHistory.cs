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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace ITS245FinalProject
{
    
    public partial class GeneralMedicalHistory : Form
    {
        public static SelectedPatient pGenMed;
        public GeneralMedicalHistory()
        {
            InitializeComponent();
            this.VisibleChanged += new EventHandler(Form_VisableChanged);
        }
        private void Form_VisableChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                GeneralMedicalHistory_Load(this, EventArgs.Empty);
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

        private void GeneralMedicalHistory_Load(object sender, EventArgs e)
        {
            //Method to load data from database into form text boxes
            MySqlConnection conn;
            
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    pGenMed = DBUtils.GrabGenMed(conn, SelectPatient.pSelect.pID);
                    tHospitalMR.Text = pGenMed.GeneralMedicalHistoryID;
                    tPatientID.Text = pGenMed.PatientIDGenMed;
                    tMaritalStatus.Text = pGenMed.MaritalStatus;
                    tEducation.Text = pGenMed.Education;
                    tBehavioralHistory.Text = pGenMed.BehavioralHistory;
                    tTobacco.Text = pGenMed.Tobacco;
                    tTobaccoQuantity.Text = pGenMed.TobaccoQuantity;
                    tTobaccoDuration.Text = pGenMed.TobaccoDuration;
                    tAlcohol.Text = pGenMed.Alcohol;
                    tAlcoholQuantity.Text = pGenMed.AlcoholQuantity;
                    tAlcoholDuration.Text = pGenMed.AlcoholDuration;
                    tDrug.Text = pGenMed.Drug;
                    tDrugType.Text = pGenMed.DrugType;
                    tDrugDuration.Text = pGenMed.DrugDuration;
                    tDietary.Text = pGenMed.Dietary;
                    tBloodType.Text = pGenMed.BloodType;
                    tRh.Text = pGenMed.Rh;
                    tNumberOfChildren.Text = pGenMed.NumberOfChildren;
                    tLMPStatus.Text = pGenMed.LMPStatus;
                    if (pGenMed.MensesMonthlyYes == "1")
                    {
                        chkbxMensesMonthlyYes.Checked = true;
                    }
                    else if (pGenMed.MensesMonthlyNo == "1")
                    {
                        chkbxMensesMonthlyNo.Checked = true;
                    }
                    tMensesFreq.Text = pGenMed.MensesFreq;
                    tMedicalHistoryNotes.Text = pGenMed.MedicalHistoryNotes;
                    tHxObtainedBy.Text = pGenMed.HxObtainedBy;

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
            tHospitalMR.ReadOnly = true;
            tHospitalMR.BackColor = Color.DarkGray;
            foreach (Control control in panel2.Controls)
            {
                TextBox tb = control as TextBox;
                if (tb != null && tb.ReadOnly)
                {
                    tb.ReadOnly = false;
                    tb.BackColor = Color.White;
                    tb.Text = String.Empty;
                }
            }
            bSave.Enabled = true;
            bDelete.Enabled = true;
            bUndo.Enabled = true;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            //When save button is select, it will collect all data from the text boxes, save it to an object, where it will then be saved to the database through the SaveGenMed method
            SelectedPatient saveGenMed = new SelectedPatient();
            if (tHospitalMR.Text == string.Empty)
            {
                saveGenMed.HospitalMR = 111111111.ToString();
            }
            else
            {
                saveGenMed.HospitalMR = tPatientID.Text;
            }
            saveGenMed.PatientIDGenMed = tPatientID.Text;
            saveGenMed.MaritalStatus = tMaritalStatus.Text;
            saveGenMed.Education = tEducation.Text;
            saveGenMed.BehavioralHistory = tBehavioralHistory.Text;
            saveGenMed.Tobacco = tTobacco.Text;
            saveGenMed.TobaccoQuantity = tTobaccoQuantity.Text;
            saveGenMed.TobaccoDuration = tTobaccoDuration.Text;
            saveGenMed.Alcohol = tAlcohol.Text;
            saveGenMed.AlcoholQuantity = tAlcoholQuantity.Text;
            saveGenMed.AlcoholDuration = tAlcoholDuration.Text;
            saveGenMed.Drug = tDrug.Text;
            saveGenMed.DrugType = tDrugType.Text;
            saveGenMed.DrugDuration = tDrugDuration.Text;
            saveGenMed.Dietary = tDietary.Text;
            saveGenMed.BloodType = tBloodType.Text;
            saveGenMed.Rh = tRh.Text;
            saveGenMed.NumberOfChildren = tNumberOfChildren.Text;
            saveGenMed.LMPStatus = tLMPStatus.Text;
            if (chkbxMensesMonthlyYes.Checked)
            {
                saveGenMed.MensesMonthlyYes = "1";
            }
            else if (chkbxMensesMonthlyNo.Checked)
            {
                saveGenMed.MensesMonthlyNo = "1";
            }
            saveGenMed.MensesFreq = tMensesFreq.Text;
            saveGenMed.MedicalHistoryNotes = tMedicalHistoryNotes.Text;
            saveGenMed.HxObtainedBy = tHxObtainedBy.Text;

            MySqlConnection conn;
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    DBUtils.SaveGenMed(conn, saveGenMed);
                    MessageBox.Show("Items saved successfully!");
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
            foreach (Control control in panel2.Controls)
            {
                TextBox tb = control as TextBox;
                if (tb != null && !tb.ReadOnly)
                {
                    tb.ReadOnly = true;
                    tb.BackColor = Color.DarkGray;
                }
            }
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
            tHospitalMR.ReadOnly = true;
            tHospitalMR.BackColor = Color.DarkGray;
            foreach (Control control in panel2.Controls)
            {
                TextBox tb = control as TextBox;
                if (tb != null && tb.ReadOnly)
                {
                    tb.ReadOnly = false;
                    tb.BackColor = Color.White;
                }
            }
            bSave.Enabled = true;
            bDelete.Enabled = true;
            bUndo.Enabled = true;
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;

            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    GeneralMedicalHistory_Load(this, EventArgs.Empty);

                    MessageBox.Show("Successfully undid changes!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB Error: " + ex.Message);
                }
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    DBUtils.DeleteGenMed(conn, pGenMed);
                    MessageBox.Show("Item successfully deleted!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB Error: " + ex.Message);
                }
            }
        }

        private void GeneralMedicalHistory_FormClosing(object sender, FormClosingEventArgs e)
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
