using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITS245FinalProject
{
    public partial class PatientDemographics : Form
    {
        public static SelectedPatient pdemo;
        public static SelectedPatient pBar;
        
        public PatientDemographics()
        {
            InitializeComponent();
            this.VisibleChanged += new EventHandler(Form_VisableChanged);
        }
        private void Form_VisableChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                PatientDemographics_Load(this, EventArgs.Empty);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PatientDemographics_Load(object sender, EventArgs e)
        {
            //Demo code on how to get Patient ID info passed in so a SQL query can be done to load in all data.
            MySqlConnection conn;
            //SelectedPatient pdemo = new SelectedPatient();
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    pdemo = DBUtils.GrabPatDemos(conn, SelectPatient.pSelect.pID);
                    tPatientID.Text = pdemo.pID.ToString();
                    tHospitalMR.Text = pdemo.HospitalMR.ToString();
                    tLastName.Text = pdemo.PtLastName.ToString();
                    tPreviousLastName.Text = pdemo.PtPreviousLastName.ToString();
                    tFirstName.Text = pdemo.PtFirstName.ToString();
                    tMiddleInitial.Text = pdemo.PtMiddleInitial.ToString();
                    tSuffix.Text = pdemo.Suffix.ToString();
                    tAddress.Text = pdemo.HomeAddress.ToString();
                    tCity.Text = pdemo.HomeCity.ToString();
                    tState.Text = pdemo.HomeState.ToString();
                    tZipCode.Text = pdemo.HomeZip.ToString();
                    tCountry.Text = pdemo.Country.ToString();
                    tCitizenship.Text = pdemo.Citizenship.ToString();
                    tHomePhone.Text = pdemo.PtHomePhone.ToString();
                    tEmergencyPhone.Text = pdemo.EmergencyPhoneNumber.ToString();
                    tEmail.Text = pdemo.EmailAddress.ToString();
                    tSSN.Text = pdemo.SSN.ToString();
                    tDOB.Text = pdemo.DOB.ToString("yyyy/MM/dd hh:mm:ss tt");
                    tGender.Text = pdemo.Gender.ToString();
                    tEthnicAssociation.Text = pdemo.EthnicAssociation.ToString();
                    tReligion.Text = pdemo.Religion.ToString();
                    tMaritalStatus.Text = pdemo.MaritalStatus.ToString();
                    tEmployment.Text = pdemo.EmploymentStatus.ToString();
                    tDateofExpire.Text = pdemo.DateofExpire.ToString("yyyy/MM/dd hh:mm:ss tt");
                    tReferral.Text = pdemo.Referral.ToString();
                    tCareProvider.Text = pdemo.CurrentPrimaryHCPId.ToString();
                    tComments.Text = pdemo.Comments.ToString();
                    tDateEntered.Text = pdemo.DateEntered.ToString("yyyy/MM/dd hh:mm:ss tt");
                    tNextofKin.Text = pdemo.NextOfKinID.ToString();
                    tNextofKinRelation.Text = pdemo.NextOfKinRelationshipToPatient.ToString();

                    pBar = new SelectedPatient(pdemo.pID, pdemo.PtLastName, pdemo.PtFirstName, pdemo.DOB);
                    lSelectedPatient.Text = "Patient: " + pBar.PtLastName + ", " + pBar.PtFirstName;
                    DateTime today = DateTime.Today;
                    int age = today.Year - pBar.DOB.Year;
                    if (pBar.DOB > today.AddYears(-age))
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
            //These can be copy and pasted for each form, just update the names for the panels when needed
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
            tPatientID.ReadOnly = true;
            tPatientID.BackColor = Color.DarkGray;
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
            
            lSelectedPatient.Text = "Patient: NA";
            lSelectedPatient2.Text = "DOB: NA";
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
            tPatientID.ReadOnly = true;
            tPatientID.BackColor = Color.DarkGray;
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
            //Same code from when form loads as undo just resets it back to the orginal view
            MySqlConnection conn;
            //SelectedPatient pdemo = new SelectedPatient();
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    PatientDemographics_Load(this, EventArgs.Empty);

                    MessageBox.Show("Successfully undid changes!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB Error: " + ex.Message);
                }
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            DateTime dob;
            DateTime dateOfExpire;
            DateTime dateEntered;
            if (tFirstName.Text == string.Empty || tLastName.Text == string.Empty || tDOB.Text == string.Empty)
            {
                MessageBox.Show("Please enter a first name, last name, and date of birth.");
                return;
            }
            else
            {
                SelectedPatient save = new SelectedPatient();
                if (tPatientID.Text == string.Empty)
                {
                    save.pID = 111111111;
                }
                else
                {
                    save.pID = Convert.ToInt32(tPatientID.Text);
                }
                save.HospitalMR = tHospitalMR.Text;
                save.PtLastName = tLastName.Text;
                save.PtPreviousLastName = tPreviousLastName.Text;
                save.PtFirstName = tFirstName.Text;
                save.PtMiddleInitial = tMiddleInitial.Text;
                save.Suffix = tSuffix.Text;
                save.HomeAddress = tAddress.Text;
                save.HomeCity = tCity.Text;
                save.HomeState = tState.Text;
                save.HomeZip = tZipCode.Text;
                save.Country = tCountry.Text;
                save.Citizenship = tCitizenship.Text;
                save.PtHomePhone = tHomePhone.Text;
                save.EmergencyPhoneNumber = tEmergencyPhone.Text;
                save.EmailAddress = tEmail.Text;
                save.SSN = tSSN.Text;
                if (DateTime.TryParseExact(tDOB.Text, "yyyy/MM/dd hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                {
                    save.DOB = dob;
                    save.Gender = tGender.Text;
                    save.EthnicAssociation = tEthnicAssociation.Text;
                    save.Religion = tReligion.Text;
                    save.MaritalStatus = tMaritalStatus.Text;
                    save.EmploymentStatus = tEmployment.Text;
                    if (DateTime.TryParseExact(tDateofExpire.Text, "yyyy/MM/dd hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfExpire))
                    {
                        save.DateofExpire = dateOfExpire;
                        save.Referral = tReferral.Text;
                        save.CurrentPrimaryHCPId = tCareProvider.Text;
                        save.Comments = tComments.Text;
                        
                        if (DateTime.TryParseExact(tDateEntered.Text, "yyyy/MM/dd hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateEntered))
                        {
                            save.DateEntered = dateEntered;                        
                            save.NextOfKinID = tNextofKin.Text;
                            save.NextOfKinRelationshipToPatient = tNextofKinRelation.Text;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid date for Date Entered: yyyy/MM/dd HH:mm:ss AM/PM");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid date for Date of Expire: yyyy/MM/dd HH:mm:ss AM/PM");
                        return;
                    }                   
                }
                else
                {
                    MessageBox.Show("Please enter a valid date of birth: yyyy/MM/dd HH:mm:ss AM/PM");
                    return;
                }
                

                MySqlConnection conn;
                using (conn = DBUtils.MakeConnection())
                {
                    try
                    {
                        DBUtils.SavePatDemos(conn, save);
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

                bSave.Enabled = false;
                bDelete.Enabled = false;
                bUndo.Enabled = false;

                using (conn = DBUtils.MakeConnection())
                {
                    try
                    {
                        SelectPatient.pSelect = DBUtils.savePatSearch(conn, save);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("DB Error: " + ex.Message);
                    }
                }
                PatientDemographics_Load(this, EventArgs.Empty);
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            using (conn = DBUtils.MakeConnection())
            {
                try
                {
                    DBUtils.Delete(conn, pdemo);
                    MessageBox.Show("Item successfully deleted!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB Error: " + ex.Message);
                }
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
            //When button is pressed, this will open the SelectPatient form and close out of all other forms
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
            if(selectedForm != null)
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

        private void PatientDemographics_FormClosing(object sender, FormClosingEventArgs e)
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
