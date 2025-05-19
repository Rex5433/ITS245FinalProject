using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITS245FinalProject
{
    internal class Report
    {
        ////Temporary Console output code for testing:
        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();

        public static void CreateTextFile(SelectedPatient r)
        {

            //Temporary Console output code for testing:
            //AllocConsole();


            // sets the file path for creating a text file
            string dirPath = @"..\..\ITS245FinalProject\FileIO";
            string filename = "PatientReports.txt";
            string fullPath = Path.Combine(dirPath, filename);

            try
            {
                // check if directory exists.
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(dirPath);
                    Console.WriteLine("Created Directory!");
                }
                else
                {
                    Console.WriteLine("Directory already exists!");
                }

                // check if file exists
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    Console.WriteLine("File already exists - deleted the file!");
                }

                Console.WriteLine("Starting to open Filestream channel to the file!");
                // WRITE a new file.
                FileStream outFile = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);
                Console.WriteLine("Opened filestream for writing a file!");

                //Creating an object to utilize stored procedures to grab data to implement into the text file.
                MySqlConnection conn;
                SelectedPatient preport = new SelectedPatient();
                using (conn = DBUtils.MakeConnection())
                {
                    try
                    {
                        preport = DBUtils.GrabPatDemos(conn, r.pID);
                        writer.WriteLine("Patient Demographics\n");
                        writer.WriteLine("Patient ID: " + preport.pID.ToString());
                        writer.WriteLine("Medical Record #: " + preport.HospitalMR.ToString());
                        writer.WriteLine("Last Name: " + preport.PtLastName.ToString());
                        writer.WriteLine("Previous Last Name: " + preport.PtPreviousLastName.ToString());
                        writer.WriteLine("First Name: " + preport.PtFirstName.ToString());
                        writer.WriteLine("Middle Initial: " + preport.PtMiddleInitial.ToString());
                        writer.WriteLine("Suffix: " + preport.Suffix.ToString());
                        writer.WriteLine("Address: " + preport.HomeAddress.ToString());
                        writer.WriteLine("City: " + preport.HomeCity.ToString());
                        writer.WriteLine("State: " + preport.HomeState.ToString());
                        writer.WriteLine("Zip Code: " + preport.HomeZip.ToString());
                        writer.WriteLine("Country: " + preport.Country.ToString());
                        writer.WriteLine("Citizenship: " + preport.Citizenship.ToString());
                        writer.WriteLine("Home Phone Number: " + preport.PtHomePhone.ToString());
                        writer.WriteLine("Emergency Number: " + preport.EmergencyPhoneNumber.ToString());
                        writer.WriteLine("Email Address: " + preport.EmailAddress.ToString());
                        writer.WriteLine("Social Security Number: " + preport.SSN.ToString());
                        writer.WriteLine("Date of Birth: " + preport.DOB.ToString());
                        writer.WriteLine("Gender: " + preport.Gender.ToString());
                        writer.WriteLine("Ethnic Association: " + preport.EthnicAssociation.ToString());
                        writer.WriteLine("Religion: " + preport.Religion.ToString());
                        writer.WriteLine("Maritial Status: " + preport.MaritalStatus.ToString());
                        writer.WriteLine("Employment Status: " + preport.EmploymentStatus.ToString());
                        writer.WriteLine("Date of Expire: " + preport.DateofExpire.ToString());
                        writer.WriteLine("Referral: " + preport.Referral.ToString());
                        writer.WriteLine("Care Provider: " + preport.CurrentPrimaryHCPId.ToString());
                        writer.WriteLine("Comments: " + preport.Comments.ToString());
                        writer.WriteLine("Date Entered: " + preport.DateEntered.ToString());
                        writer.WriteLine("Next of Kin ID: " + preport.NextOfKinID.ToString());
                        writer.WriteLine("Next of Kin Relation: " + preport.NextOfKinRelationshipToPatient.ToString());


                        conn = DBUtils.MakeConnection();
                        preport = DBUtils.GrabGenMed(conn, r.pID);
                        if (preport.GeneralMedicalHistoryID != null)
                        {
                            writer.WriteLine("\n");
                            writer.WriteLine("===============================================");
                            writer.WriteLine("General Medical History\n");

                            writer.WriteLine("General Medical History ID: " + preport.GeneralMedicalHistoryID.ToString());
                            writer.WriteLine("Maritial Status: " + preport.MaritalStatus.ToString());
                            writer.WriteLine("Education: " + preport.Education.ToString());
                            writer.WriteLine("Behavioral History: " + preport.BehavioralHistory.ToString());
                            writer.WriteLine("Tobacco: " + preport.Tobacco.ToString());
                            writer.WriteLine("Tobacco Quantity: " + preport.TobaccoQuantity.ToString());
                            writer.WriteLine("Tobacco Duration: " + preport.TobaccoDuration.ToString());
                            writer.WriteLine("Alcohol: " + preport.Alcohol.ToString());
                            writer.WriteLine("Alcohol Quantity: " + preport.AlcoholQuantity.ToString());
                            writer.WriteLine("Alcohol Duration: " + preport.AlcoholDuration.ToString());
                            writer.WriteLine("Drug: " + preport.Drug.ToString());
                            writer.WriteLine("Drug Type: " + preport.DrugType.ToString());
                            writer.WriteLine("Drug Duration: " + preport.DrugDuration.ToString());
                            writer.WriteLine("Dietary: " + preport.Dietary.ToString());
                            writer.WriteLine("Blood Type: " + preport.BloodType.ToString());
                            writer.WriteLine("RH: " + preport.Rh.ToString());
                            writer.WriteLine("Number of Children: " + preport.NumberOfChildren.ToString());
                            writer.WriteLine("LMP Status: " + preport.LMPStatus.ToString());
                            if (preport.MensesMonthlyYes.ToString() == "1")
                            {
                                writer.WriteLine("Menses Monthly: Yes");
                            }
                            else if (preport.MensesMonthlyNo.ToString() == "1")
                            {
                                writer.WriteLine("Menses Monthly: No");
                            }
                            writer.WriteLine("Menses Frequency: " + preport.MensesFreq.ToString());
                            writer.WriteLine("Medical History Notes: " + preport.MedicalHistoryNotes.ToString());
                            writer.WriteLine("Hx Obtained By: " + preport.HxObtainedBy.ToString());
                        }

                           
                        conn = DBUtils.MakeConnection();
                        preport = DBUtils.GrabFamHis(conn, r.pID);
                        if (preport.FamilyID != null)
                        {
                            writer.WriteLine("\n");
                            writer.WriteLine("===============================================");
                            writer.WriteLine("Family History\n");
                            writer.WriteLine("Family ID: " + preport.FamilyID.ToString());
                            writer.WriteLine("Name: " + preport.Name.ToString());
                            writer.WriteLine("Relation: " + preport.Relation.ToString());
                            writer.WriteLine("Alive: " + preport.Alive.ToString());
                            writer.WriteLine("Lives with Patient: " + preport.LivesWithPatient.ToString());
                            writer.WriteLine("Major Disorder: " + preport.MajorDisorder.ToString());
                            writer.WriteLine("Specific Type Disorder: " + preport.SpecificTypeDisorder.ToString());
                        }
                            
                        conn = DBUtils.MakeConnection();
                        preport = DBUtils.GrabAllergy(conn, r.pID);
                        if (preport.AllergyID != null)
                        {
                            writer.WriteLine("\n");
                            writer.WriteLine("===============================================");
                            writer.WriteLine("Allergy History\n");
                            writer.WriteLine("Allergy ID: " + preport.AllergyID.ToString());
                            writer.WriteLine("Allergen: " + preport.Allergen.ToString());
                            writer.WriteLine("Allergy Start Date: " + preport.AllergyStartDate.ToString());
                            writer.WriteLine("Allergy End Date: " + preport.AllergyEndDate.ToString());
                            writer.WriteLine("Allergy Description: " + preport.AllergyDescription.ToString());
                        }


                        //MessageBox to show a successfully completed text file with the patient data
                        MessageBox.Show("Text File has been created!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("DB Error: " + ex.Message);
                    }
                }

                Console.WriteLine("Finished writing 3 recs to output file!");
                // Close out filestream.
                writer.Close();
                writer.Dispose();
                outFile.Close();
                outFile.Dispose();
                Console.WriteLine("Closed out filestream and disposed of resources!");

                // READ - data that was created above.
                Console.WriteLine("Setting up Filestream READER!");
                FileStream inFile = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                Console.WriteLine("Finished opening channel for reading!");


                //Close out resources.
                inFile.Close();
                inFile.Dispose();
                reader.Close();
                reader.Dispose();
                Console.WriteLine("Closed out resources!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("File I/O Error! Error = ", ex.Message);
            }
        }
    }
}
