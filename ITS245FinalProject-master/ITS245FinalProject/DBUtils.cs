using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITS245FinalProject
{
    public static class DBUtils
    {
        public static MySqlConnection MakeConnection() // Allows a connection to Database. For some reason, root login doesn't work right now...
        {
            string connStr = "server=34.229.164.213; uid=program; pwd=programlogin12022023; database=patienthistory";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public static DataTable GetSelectPatient(MySqlConnection conn) // Uses stored procedure to fill the data table for Select Patient
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand("SelectPatient", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public static DataTable SearchBox(MySqlConnection conn, string search) // Uses stored procedure to search for Select Patient
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand("SelectPatientSearch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@search", search);
            da.SelectCommand = cmd;
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public static DataTable AlgHistSearch(MySqlConnection conn, SelectedPatient s) // Uses stored procedure to fill the data table for Select Patient
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand("AlgHistSearch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", s.pID);
            da.SelectCommand = cmd;
            da.Fill(dt);

            return dt;
        }
        public static DataTable FamHisSearch(MySqlConnection conn, SelectedPatient s) // Uses stored procedure to fill the data table for Select Patient
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand("FamHisSearch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", s.pID);
            da.SelectCommand = cmd;
            da.Fill(dt);

            return dt;
        }
        public static SelectedPatient savePatSearch(MySqlConnection conn, SelectedPatient s)
        {
            using (MySqlCommand cmd = new MySqlCommand("savePatSearch", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LN", s.PtLastName);
                cmd.Parameters.AddWithValue("@FN", s.PtFirstName);
                cmd.Parameters.AddWithValue("@DOB", s.DOB);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        s.pID = Convert.ToInt32(reader["PatientID"]);
                    }
                }
            }
                return s;
        }

        public static SelectedPatient GrabPatDemos(MySqlConnection conn, int id)
        {
            SelectedPatient pRead = new SelectedPatient();
            using (MySqlCommand cmd = new MySqlCommand("GrabPatDemos", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pRead.pID = Convert.ToInt32(reader["PatientID"]);
                        pRead.HospitalMR = reader["HospitalMR#"].ToString();
                        pRead.PtLastName = reader["PtLastName"].ToString();
                        pRead.PtPreviousLastName = reader["PtPreviousLastName"].ToString();
                        pRead.PtFirstName = reader["PtFirstName"].ToString();
                        pRead.PtMiddleInitial = reader["PtMiddleInitial"].ToString();
                        pRead.Suffix = reader["Suffix"].ToString();
                        pRead.HomeAddress = reader["HomeAddress"].ToString();
                        pRead.HomeCity = reader["HomeCity"].ToString();
                        pRead.HomeState = reader["HomeState/Province/Region"].ToString();
                        pRead.HomeZip = reader["HomeZip"].ToString();
                        pRead.Country = reader["Country"].ToString();
                        pRead.Citizenship = reader["Citizenship"].ToString();
                        pRead.PtHomePhone = reader["PtHomePhone"].ToString();
                        pRead.EmergencyPhoneNumber = reader["EmergencyPhoneNumber"].ToString();
                        pRead.EmailAddress = reader["EmailAddress"].ToString();
                        pRead.SSN = reader["SSN"].ToString();
                        pRead.DOB = Convert.ToDateTime(reader["DOB"]);
                        pRead.Gender = reader["Gender"].ToString();
                        pRead.EthnicAssociation = reader["EthnicAssociation"].ToString();
                        pRead.Religion = reader["Religion"].ToString();
                        pRead.MaritalStatus = reader["MaritalStatus"].ToString();
                        pRead.EmploymentStatus = reader["EmploymentStatus"].ToString();
                        pRead.DateofExpire = Convert.ToDateTime(reader["DateofExpire"]);
                        pRead.Referral = reader["Referral"].ToString();
                        pRead.CurrentPrimaryHCPId = reader["CurrentPrimaryHCPId"].ToString();
                        pRead.Comments = reader["Comments"].ToString();
                        pRead.DateEntered = Convert.ToDateTime(reader["DateEntered"]);
                        pRead.NextOfKinID = reader["NextOfKinID"].ToString();
                        pRead.NextOfKinRelationshipToPatient = reader["NextOfKinRelationshipToPatient"].ToString();
                    }
                }
            }
            conn.Close();
            return pRead;
        }
        public static SelectedPatient GrabGenMed(MySqlConnection conn, int id)
        {
            SelectedPatient pRead = new SelectedPatient();
            using (MySqlCommand cmd = new MySqlCommand("GrabGenMed", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // General Medical History Objects below here
                        pRead.GeneralMedicalHistoryID = reader["GeneralMedicalHistoryID"].ToString();
                        pRead.PatientIDGenMed = reader["PatientID"].ToString();
                        pRead.MaritalStatus = reader["MaritalStatus"].ToString();
                        pRead.Education = reader["Education"].ToString();
                        pRead.BehavioralHistory = reader["BehavioralHistory"].ToString();
                        pRead.Tobacco = reader["Tobacco"].ToString();
                        pRead.TobaccoQuantity = reader["TobaccoQuantity"].ToString();
                        pRead.TobaccoDuration = reader["TobaccoDuration"].ToString();
                        pRead.Alcohol = reader["Alcohol"].ToString();
                        pRead.AlcoholQuantity = reader["AlcoholQuantity"].ToString();
                        pRead.AlcoholDuration = reader["AlcoholDuration"].ToString();
                        pRead.Drug = reader["Drug"].ToString();
                        pRead.DrugType = reader["DrugType"].ToString();
                        pRead.DrugDuration = reader["DrugDuration"].ToString();
                        pRead.Dietary = reader["Dietary"].ToString();
                        pRead.BloodType = reader["BloodType"].ToString();
                        pRead.Rh = reader["Rh"].ToString();
                        pRead.NumberOfChildren = reader["NumberOfChildren"].ToString();
                        pRead.LMPStatus = reader["LMPStatus"].ToString();
                        pRead.MensesMonthlyYes = reader["MensesMonthlyYes"].ToString();
                        pRead.MensesMonthlyNo = reader["MensesMonthlyNo"].ToString();
                        pRead.MensesFreq = reader["MensesFreq"].ToString();
                        pRead.MedicalHistoryNotes = reader["MedicalHistoryNotes"].ToString();
                        pRead.HxObtainedBy = reader["HxObtainedBy"].ToString();
                    }
                }
            }
            conn.Close();
            return pRead;
        }

        public static SelectedPatient GrabFamHis(MySqlConnection conn, int id)
        {
            SelectedPatient pRead = new SelectedPatient();
            using (MySqlCommand cmd = new MySqlCommand("GrabFamHis", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Family History Objects below here
                        pRead.FamilyID = reader["FamilyID"].ToString();
                        pRead.PatientIDFam = reader["PatientID"].ToString();
                        pRead.Name = reader["Name"].ToString();
                        pRead.Relation = reader["Relation"].ToString();
                        pRead.Alive = reader["Alive"].ToString();
                        pRead.LivesWithPatient = reader["Lives with patient"].ToString();
                        pRead.MajorDisorder = reader["MajorDisorder"].ToString();
                        pRead.SpecificTypeDisorder = reader["SpecificTypeDisorder"].ToString();
                    }
                }
            }
            conn.Close();
            return pRead;
        }

        public static SelectedPatient GrabAllergy(MySqlConnection conn, int id)
        {
            SelectedPatient pRead = new SelectedPatient();
            using (MySqlCommand cmd = new MySqlCommand("GrabAllergy", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Allergy History Objects below here
                        pRead.AllergyID = reader["AllergyID"].ToString();
                        pRead.PatientIDAllergy = reader["PatientID"].ToString();
                        pRead.Allergen = reader["Allergen"].ToString();
                        pRead.AllergyStartDate = reader["AllergyStartDate"].ToString();
                        pRead.AllergyEndDate = reader["AllergyEndDate"].ToString();
                        pRead.AllergyDescription = reader["AllergyDescription"].ToString();
                    }
                }
            }
            conn.Close();
            return pRead;
        }

        public static void SavePatDemos(MySqlConnection conn, SelectedPatient s)
        {
            using (MySqlCommand cmd = new MySqlCommand("SavePatDemos", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", s.pID);
                cmd.Parameters.AddWithValue("@MR", s.HospitalMR);
                cmd.Parameters.AddWithValue("@LN", s.PtLastName);
                cmd.Parameters.AddWithValue("@PLN", s.PtPreviousLastName);
                cmd.Parameters.AddWithValue("@FN", s.PtFirstName);
                cmd.Parameters.AddWithValue("@MI", s.PtMiddleInitial);
                cmd.Parameters.AddWithValue("@SUF", s.Suffix);
                cmd.Parameters.AddWithValue("@HA", s.HomeAddress);
                cmd.Parameters.AddWithValue("@HC", s.HomeCity);
                cmd.Parameters.AddWithValue("@HS", s.HomeState);
                cmd.Parameters.AddWithValue("@HZ", s.HomeZip);
                cmd.Parameters.AddWithValue("@CON", s.Country);
                cmd.Parameters.AddWithValue("@CIT", s.Citizenship);
                cmd.Parameters.AddWithValue("@HP", s.PtHomePhone);
                cmd.Parameters.AddWithValue("@EPN", s.EmergencyPhoneNumber);
                cmd.Parameters.AddWithValue("@EA", s.EmailAddress);
                cmd.Parameters.AddWithValue("@SN", s.SSN);
                cmd.Parameters.AddWithValue("@DB", s.DOB);
                cmd.Parameters.AddWithValue("@GEN", s.Gender);
                cmd.Parameters.AddWithValue("@ETA", s.EthnicAssociation);
                cmd.Parameters.AddWithValue("@RLG", s.Religion);
                cmd.Parameters.AddWithValue("@MS", s.MaritalStatus);
                cmd.Parameters.AddWithValue("@ES", s.EmploymentStatus);
                cmd.Parameters.AddWithValue("@DOE", s.DateofExpire);
                cmd.Parameters.AddWithValue("@REF", s.Referral);
                cmd.Parameters.AddWithValue("@HCP", s.CurrentPrimaryHCPId);
                cmd.Parameters.AddWithValue("@COM", s.Comments);
                cmd.Parameters.AddWithValue("@DE", s.DateEntered);
                cmd.Parameters.AddWithValue("@NKID", s.NextOfKinID);
                cmd.Parameters.AddWithValue("@NKIDP", s.NextOfKinRelationshipToPatient);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public static void SaveGenMed(MySqlConnection conn, SelectedPatient s)
        {
            using (MySqlCommand cmd = new MySqlCommand("SaveGenMed", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", s.PatientIDGenMed);
                cmd.Parameters.AddWithValue("@MS", s.MaritalStatus);
                cmd.Parameters.AddWithValue("@EDU", s.Education);
                cmd.Parameters.AddWithValue("@BH", s.BehavioralHistory);
                cmd.Parameters.AddWithValue("@TOB", s.Tobacco);
                cmd.Parameters.AddWithValue("@TQ", s.TobaccoQuantity);
                cmd.Parameters.AddWithValue("@TD", s.TobaccoDuration);
                cmd.Parameters.AddWithValue("@ALC", s.Alcohol);
                cmd.Parameters.AddWithValue("@ALCQ", s.AlcoholQuantity);
                cmd.Parameters.AddWithValue("@ALCD", s.AlcoholDuration);
                cmd.Parameters.AddWithValue("@DR", s.Drug);
                cmd.Parameters.AddWithValue("@DRT", s.DrugType);
                cmd.Parameters.AddWithValue("@DRD", s.DrugDuration);
                cmd.Parameters.AddWithValue("@DIET", s.Dietary);
                cmd.Parameters.AddWithValue("@BT", s.BloodType);
                cmd.Parameters.AddWithValue("@RH", s.Rh);
                cmd.Parameters.AddWithValue("@NUMCHILD", s.NumberOfChildren);
                cmd.Parameters.AddWithValue("@LMP", s.LMPStatus);
                cmd.Parameters.AddWithValue("@MNY", s.MensesMonthlyYes);
                cmd.Parameters.AddWithValue("@MNN", s.MensesMonthlyNo);
                cmd.Parameters.AddWithValue("@MF", s.MensesFreq);
                cmd.Parameters.AddWithValue("@MH", s.MedicalHistoryNotes);
                cmd.Parameters.AddWithValue("@HX", s.HxObtainedBy);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public static void SaveFamHis(MySqlConnection conn, SelectedPatient s)
        {
            using (MySqlCommand cmd = new MySqlCommand("SaveFamHis", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", s.PatientIDFam);
                cmd.Parameters.AddWithValue("@FMID", s.FamilyID);
                cmd.Parameters.AddWithValue("@NM", s.Name);
                cmd.Parameters.AddWithValue("@RL", s.Relation);
                cmd.Parameters.AddWithValue("@AL", s.Alive);
                cmd.Parameters.AddWithValue("@LWPT", s.LivesWithPatient);
                cmd.Parameters.AddWithValue("@MJDSR", s.MajorDisorder);
                cmd.Parameters.AddWithValue("@STDSR", s.SpecificTypeDisorder);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public static void SaveAllergy(MySqlConnection conn, SelectedPatient s)
        {
            using (MySqlCommand cmd = new MySqlCommand("SaveAllergy", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", s.PatientIDAllergy);
                cmd.Parameters.AddWithValue("@AID", s.AllergyID);
                cmd.Parameters.AddWithValue("@AG", s.Allergen);
                cmd.Parameters.AddWithValue("@SD", s.AllergyStartDate);
                cmd.Parameters.AddWithValue("@ED", s.AllergyEndDate);
                cmd.Parameters.AddWithValue("@AD", s.AllergyDescription);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public static void Delete(MySqlConnection conn, SelectedPatient d)
        {
            using (MySqlCommand cmd = new MySqlCommand("setDelete", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", d.pID);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public static void DeleteGenMed(MySqlConnection conn, SelectedPatient d)
        {
            using (MySqlCommand cmd = new MySqlCommand("setDeleteGenMed", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", d.GeneralMedicalHistoryID);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public static void DeleteAlgHist(MySqlConnection conn, SelectedPatient d)
        {
            using (MySqlCommand cmd = new MySqlCommand("setDeleteAlgHist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", d.AllergyID);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public static void DeleteFamHis(MySqlConnection conn, SelectedPatient d)
        {
            using (MySqlCommand cmd = new MySqlCommand("setDeleteFamHis", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", d.FamilyID);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
