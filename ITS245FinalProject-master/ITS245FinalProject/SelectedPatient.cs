using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS245FinalProject
{
    public class SelectedPatient
    {
        public int pID { get; set; }
        public string HospitalMR { get; set; }
        public string PtLastName { get; set; }
        public string PtPreviousLastName { get; set; }
        public string PtFirstName { get; set; }
        public string PtMiddleInitial { get; set; }
        public string Suffix { get; set; }
        public string HomeAddress { get; set; }
        public string HomeCity { get; set; }
        public string HomeState { get; set; }
        public string HomeZip { get; set; }
        public string Country { get; set; }
        public string Citizenship { get; set; }
        public string PtHomePhone { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string SSN { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string EthnicAssociation { get; set; }
        public string Religion { get; set; }
        public string MaritalStatus { get; set; }
        public string EmploymentStatus { get; set; }
        public DateTime DateofExpire { get; set; }
        public string Referral { get; set; }
        public string CurrentPrimaryHCPId { get; set; }
        public string Comments { get; set; }
        public DateTime DateEntered { get; set; }
        public string NextOfKinID { get; set; }
        public string NextOfKinRelationshipToPatient { get; set; }

        // Below is General Medical History Objects (unconfirmed on whether these should stay here or not)
        public string GeneralMedicalHistoryID { get; set; }
        public string PatientIDGenMed { get; set; }
        public string MaritialStatus { get; set; }
        public string Education { get; set; }
        public string BehavioralHistory { get; set; }
        public string Tobacco { get; set; }
        public string TobaccoQuantity { get; set; }
        public string TobaccoDuration { get; set; }
        public string Alcohol { get; set; }
        public string AlcoholQuantity { get; set; }
        public string AlcoholDuration { get; set; }
        public string Drug { get; set; }
        public string DrugType { get; set; }
        public string DrugDuration { get; set; }
        public string Dietary { get; set; }
        public string BloodType { get; set; }
        public string Rh { get; set; }
        public string NumberOfChildren { get; set; }
        public string LMPStatus { get; set; }
        public string MensesMonthlyYes { get; set; }
        public string MensesMonthlyNo { get; set; }
        public string MensesFreq { get; set; }
        public string MedicalHistoryNotes { get; set; }
        public string HxObtainedBy { get; set; }

        // Below is Family History Objects (unconfirmed on whether these should stay here or not)
        public string FamilyID { get; set; }
        public string PatientIDFam { get; set; }
        public string Name { get; set; }
        public string Relation { get; set; }
        public string Alive { get; set; }
        public string LivesWithPatient { get; set; }
        public string MajorDisorder { get; set; }
        public string SpecificTypeDisorder { get; set; }

        // Below is Allergy History Objects (unconfirmed on whether these should stay here or not)
        public string AllergyID { get; set; }
        public string PatientIDAllergy { get; set; }
        public string Allergen { get; set; }
        public string AllergyStartDate { get; set; }
        public string AllergyEndDate { get; set; }
        public string AllergyDescription { get; set; }


        public SelectedPatient()
        {

        }
        public SelectedPatient(int pID)
        {
            this.pID = pID;
        }
        public SelectedPatient(int pID, string ptLastName, string ptFirstName, DateTime DOB)
        {
            this.pID = pID;
            this.PtLastName = ptLastName;
            this.PtFirstName = ptFirstName;
            this.DOB = DOB;
        }
    }
}
