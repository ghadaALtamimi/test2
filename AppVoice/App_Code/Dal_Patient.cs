using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class Dal_Patient
    {
        private MySqlConnection con;

        public Dal_Patient()
        {
            con = new MySqlConnection(CONSTANT.STR);
        }


        /*************************************************** PATIENT FUNCTIONS ***************************************************/



        public bool addPatient(Patient patient)
        {

            //add if new
            con.Open();
            //String addDetails = "INSERT INTO Patient VALUES('" + patient.PatientId + "','" + patient.FirstName + "','" + patient.LastName + "','" + patient.Mail + "','" + patient.PhoneNumber + "','" + patient.Address + "','"  + patient.Hmo + "','" + patient.Password + "','" + patient.TherapistId + "')";
            //  MySqlCommand command = new MySqlCommand(addDetails, con);
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO Patient(PatientId, FirstName, LastName, Mail, PhoneNumber, Address, Hmo, Password, TherapistId) VALUES(@patientId, @firstName, @lastName, @mail, @phoneNumber, @Address, @hmo, @password, @therapistId)";
            comm.Parameters.AddWithValue("@patientId", patient.PatientId);
            comm.Parameters.AddWithValue("@firstName", patient.FirstName);
            comm.Parameters.AddWithValue("@lastName", patient.LastName);
            comm.Parameters.AddWithValue("@mail", patient.Mail);
            comm.Parameters.AddWithValue("@phoneNumber", patient.PhoneNumber);
            comm.Parameters.AddWithValue("@address", patient.Address);
            comm.Parameters.AddWithValue("@hmo", patient.Hmo);
            comm.Parameters.AddWithValue("@password", patient.Password);
            comm.Parameters.AddWithValue("@therapistId", patient.TherapistId);

            //comm.ExecuteNonQuery();
            //  con.Close();
            if (comm.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }

            con.Close();
            return false;

        }

        public bool isPatientExists(Patient patient)
        {
            con.Open();

            string getTherapist = "SELECT * FROM Patient WHERE PatientId = '" + patient.PatientId + "'";
            MySqlCommand command = new MySqlCommand(getTherapist, con);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();

            if (!reader.HasRows)
            {
                con.Close();
                reader.Close();
                return false;
            }
            con.Close();
            reader.Close();
            return true;
        }

        // get patient details using license id
        public Patient getPatientDetails(string patientId)
        {
            con.Open();

            string firstName, lastName, mail, phoneNumber, address, hmo, password, therapistId;
            Patient patient = null;

            string getTherapist = "SELECT * FROM Patient WHERE PatientId = '" + patientId + "'";
            MySqlCommand command = new MySqlCommand(getTherapist, con);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();

            if (!reader.HasRows)
            {
                con.Close();
                reader.Close();
                return null;
            }
            else
            {
                firstName = reader["FirstName"] + "";
                lastName = reader["LastName"] + "";
                mail = reader["Mail"] + "";
                phoneNumber = reader["PhoneNumber"] + "";
                address = reader["Address"] + "";
                hmo = reader["Hmo"] + "";
                password = reader["Password"] + "";
                therapistId = reader["TherapistId"] + "";
                patient = new Patient(patientId, firstName, lastName, mail, phoneNumber, address, hmo, password, therapistId);
            }
            con.Close();
            reader.Close();
            return patient;
        }

        // update patient details
        public bool updatePatientDetails(string patientId, Patient newPatient)
        {
            con.Open();
            String updateDetails = "UPDATE Patient SET FirstName = '" + newPatient.FirstName + "', LastName = '" + newPatient.LastName + "', Mail = '" + newPatient.Mail + "', PhoneNumber = '" + newPatient.PhoneNumber + "', Address = '" + newPatient.Address + "', Hmo = '" + newPatient.Hmo + "' WHERE PatientId = '" + patientId + "'";
            MySqlCommand command = new MySqlCommand(updateDetails, con);

            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        // get all patients of specific therapist
        public List<Patient> getAllPatientsByLicenseId(string licenseId)
        {
            con.Open();
            List<Patient> allPatients = new List<Patient>();
            String getPatients = "SELECT * FROM Patient WHERE TherapistId = '" + licenseId + "'";

            MySqlCommand command = new MySqlCommand(getPatients, con);
            MySqlDataReader reader = command.ExecuteReader();

            string patientId, firstName, lastName, mail, phoneNumber, address, hmo, password;


            while (reader.Read())
            {
                patientId = reader["PatientId"] + "";
                firstName = reader["FirstName"] + "";
                lastName = reader["LastName"] + "";
                mail = reader["Mail"] + "";
                phoneNumber = reader["PhoneNumber"] + "";
                address = reader["Address"] + "";
                hmo = reader["Hmo"] + "";
                password = reader["Password"] + "";
                Patient patient = new Patient(patientId, firstName, lastName, mail, phoneNumber, address, hmo, password, licenseId);

                allPatients.Add(patient);
            }

            con.Close();
            reader.Close();
            return allPatients;
        }

        public bool addAssignedExercise(string patientId, int folderId, string folderName, int exerciseId, string therapistId)
        {
            con.Open();
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO AssignedExercise(ExerciseId, FolderId, FolderName, PatientId, TherapistId) VALUES(@exerciseId, @folderId, @folderName, @patientId, @therapistId)";
            comm.Parameters.AddWithValue("@patientId", patientId);
            comm.Parameters.AddWithValue("@folderId", folderId);
            comm.Parameters.AddWithValue("@folderName", folderName);
            comm.Parameters.AddWithValue("@exerciseId", exerciseId);
            comm.Parameters.AddWithValue("@therapistId", therapistId);

            if (comm.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }

            con.Close();
            return false;
        }
        public List<AssignedExercise> getAllAssignedExercisesByPatientId(string patientId, string therapistId)
        {
            con.Open();
            List<AssignedExercise> allAssignedExercises = new List<AssignedExercise>();
            String getExercises = "SELECT * FROM AssignedExercise WHERE PatientId = '" + patientId + "' AND TherapistId = '" + therapistId + "'";

            MySqlCommand command = new MySqlCommand(getExercises, con);
            MySqlDataReader reader = command.ExecuteReader();

            int exerciseId, folderId;
            string folderName;

            while (reader.Read())
            {
                exerciseId = Convert.ToInt16(reader["ExerciseId"]);
                folderId = Convert.ToInt16(reader["FolderId"]);
                folderName = reader["FolderName"] + "";
                AssignedExercise assignedExercise = new AssignedExercise(exerciseId, folderId, folderName, patientId, therapistId);

                allAssignedExercises.Add(assignedExercise);
            }

            con.Close();
            reader.Close();
            return allAssignedExercises; 
        }
    }
}