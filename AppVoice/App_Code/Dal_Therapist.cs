using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class Dal_Therapist
    {
        private MySqlConnection con;

        public Dal_Therapist()
        {
            con = new MySqlConnection(CONSTANT.STR);
        }


        /*************************************************** THERAPIST FUNCTIONS ***************************************************/

        // show details of specific therapist
        public string showTherapistDetails()
        {
            string details = "";
            con.Open();
            string getFirstName = "SELECT FirstName FROM SpeechTherapist WHERE LicenseId = '123'";
            MySqlCommand command = new MySqlCommand(getFirstName, con);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();


            if (!reader.HasRows)
            {
                con.Close();
                reader.Close();
            }
            else
            {
                details = reader["FirstName"] + "";
                con.Close();
                reader.Close();
            }

            return details;

        }

        // get therapist details using license id
        public SpeechTherapist getTherapistDetails(string licenseId)
        {
            con.Open();

            string firstName, lastName, mail;
            SpeechTherapist speechTherapist = null;

            string getTherapist = "SELECT * FROM SpeechTherapist WHERE LicenseId = '" + licenseId + "'";
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
                mail = reader["Email"] + "";
                speechTherapist = new SpeechTherapist(licenseId, firstName, lastName, mail);
            }
            con.Close();
            reader.Close();
            return speechTherapist;
        }

        //check if therapist exists using licenseId
        public bool isTherapistExists(int licenseId)
        {
            con.Open();

            string getTherapist = "SELECT * FROM SpeechTherapist WHERE LicenseId = '" + licenseId + "'";
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

        // On therapist login - using license id and password to login 
        public SpeechTherapist therapistLogin(string licenseId, string password)
        {
            con.Open();

            string firstName, lastName, mail;
            SpeechTherapist speechTherapist;

            string getTherapist = "SELECT * FROM SpeechTherapist WHERE LicenseId = '" + licenseId + "' AND Password = '" + password + "'";
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
                mail = reader["Email"] + "";
                speechTherapist = new SpeechTherapist(licenseId, firstName, lastName, mail);
            }
            con.Close();
            reader.Close();
            return speechTherapist;
        }

        // Update therapist details - not include password
        public bool updateTherapistDetails(string licenseId, SpeechTherapist newTherapist)
        {
            con.Open();
            String updateDetails = "UPDATE SpeechTherapist SET FirstName = '" + newTherapist.FirstName + "', LastName = '" + newTherapist.LastName + "', Email = '" + newTherapist.Mail + "' WHERE LicenseId = '" + licenseId + "'";
            MySqlCommand command = new MySqlCommand(updateDetails, con);

            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        // Update therapist password
        public bool updateTherapistPassword(string licenceId, string newPassword)
        {
            con.Open();
            string updatePassword = "UPDATE SpeechTherapist SET Password = '" + newPassword + "' WHERE LicenseId = '" + licenceId + "'";
            MySqlCommand command = new MySqlCommand(updatePassword, con);
            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;

        }

        public bool isPasswordOkay(string licenseId, string password)           // check if password matches to the licenseId
        {
            con.Open();

            string getTherapist = "SELECT * FROM SpeechTherapist WHERE LicenseId = '" + licenseId + "' AND Password = '" + password + "'";
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


        /*  ****************************     Folder     ****************************  */

        public Folder getFolderDetails(int folderId)
        {
            con.Open();

            string folderName, folderDescription, therapistId;
            Folder folder = null;

            string getFolder = "SELECT * FROM Folder WHERE FolderId = '" + folderId + "'";
            MySqlCommand command = new MySqlCommand(getFolder, con);
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
                folderName = reader["Name"] + "";
                folderDescription = reader["Description"] + "";
                therapistId = reader["TherapistId"] + "";
                folder = new Folder(folderId, folderName, folderDescription, therapistId);
            }
            con.Close();
            reader.Close();
            return folder;
        }
        public List<Folder> getAllFolders(string therapistId)
        {

            con.Open();
            List<Folder> allFolders = new List<Folder>();
            String getFolders = "SELECT * FROM Folder WHERE TherapistId = '" + therapistId + "'";

            MySqlCommand command = new MySqlCommand(getFolders, con);
            MySqlDataReader reader = command.ExecuteReader();

            string folderName, folderDescription;
            int folderId;

            while (reader.Read())
            {
                folderName = reader["Name"] + "";
                folderDescription = reader["Description"] + "";
                folderId = Convert.ToInt32(reader["FolderId"]);
                Folder folder = new Folder(folderId, folderName, folderDescription, therapistId);

                allFolders.Add(folder);
            }

            con.Close();
            reader.Close();
            return allFolders;
        }


        public bool addFolder(Folder folder)
        {

            con.Open();
            // String addDetails = "INSERT INTO Folder VALUES('" + patient.PatientId + "','" + patient.FirstName + "','" + patient.LastName + "','" + patient.Mail + "','" + patient.PhoneNumber + "','" + patient.Address + "','"  + patient.Hmo + "','" + patient.Password + "','" + patient.TherapistId + "')";
            //  MySqlCommand command = new MySqlCommand(addDetails, con);
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO Folder(Name, TherapistId) VALUES(@name, @therapistId)";
            comm.Parameters.AddWithValue("@name", folder.Name);
            comm.Parameters.AddWithValue("@therapistId", folder.TherapistId);

            //  con.Close();
            if (comm.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }

            con.Close();
            return false;

        }

        public bool updateDescriptionFolder(Folder folder, string description)
        {
            con.Open();
            string updateDescription = "UPDATE Folder SET Description = '" + description + "' WHERE FolderId = '" + folder.Id + "'";
            MySqlCommand command = new MySqlCommand(updateDescription, con);
            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
        public int getFolderIdByFolderName(string folderName, string therapistId)
        {
            con.Open();

            int folderId;

            string getFolderId = "SELECT FolderId FROM Folder WHERE Name = '" + folderName + "' AND TherapistId = '" + therapistId + "'";
            MySqlCommand command = new MySqlCommand(getFolderId, con);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();

            if (!reader.HasRows)
            {
                con.Close();
                reader.Close();
                return 0;
            }
            else
            {
                folderId = Convert.ToInt16(reader["FolderId"]);

            }
            con.Close();
            reader.Close();
            return folderId;
        }


        public string getFolderNameByFolderId(int folderId, string therapistId)
        {
            con.Open();

            string folderName = "";

            string getFolderName = "SELECT Name FROM Folder WHERE FolderId = '" + folderId + "' AND TherapistId = '" + therapistId + "'";
            MySqlCommand command = new MySqlCommand(getFolderName, con);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();

            if (!reader.HasRows)
            {
                con.Close();
                reader.Close();
            }
            else
            {
                folderName = reader["Name"] + "";
            }
            con.Close();
            reader.Close();
            return folderName;
        }

        public int getFolderIdByExerciseId(int exerciseId, string therapistId)
        {
            con.Open();

            int folderId = 0;

            string getFolderId = "SELECT FolderId FROM Exercise WHERE ExerciseId = '" + exerciseId + "' AND TherapistId = '" + therapistId + "'";
            MySqlCommand command = new MySqlCommand(getFolderId, con);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();

            if (!reader.HasRows)
            {
                con.Close();
                reader.Close();
            }
            else
            {
                folderId = Convert.ToInt16(reader["FolderId"]);
            }
            con.Close();
            reader.Close();
            return folderId;
        }
        /*  ****************************     Exercise     ****************************  */

        public bool addExercise(Exercise exercise)
        {

            con.Open();
            // String addDetails = "INSERT INTO Folder VALUES('" + patient.PatientId + "','" + patient.FirstName + "','" + patient.LastName + "','" + patient.Mail + "','" + patient.PhoneNumber + "','" + patient.Address + "','"  + patient.Hmo + "','" + patient.Password + "','" + patient.TherapistId + "')";
            //  MySqlCommand command = new MySqlCommand(addDetails, con);
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO Exercise(Title, FolderId, TherapistId, Description) VALUES(@title, @folderId, @therapistId, @description)";
            comm.Parameters.AddWithValue("@title", exercise.Title);
            comm.Parameters.AddWithValue("@description", exercise.Description);
            comm.Parameters.AddWithValue("@folderId", exercise.FolderId);
            comm.Parameters.AddWithValue("@therapistId", exercise.TherapistId);

            //  con.Close();
            if (comm.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }

            con.Close();
            return false;

        }

        public Exercise getExerciseDetails(int exerciseId)
        {
            con.Open();

            string exerciseTitle, exerciseDescription, therapistId;
            int folderId;
            Exercise exercise = null;

            string getExercise = "SELECT * FROM Exercise WHERE ExerciseId = '" + exerciseId + "'";
            MySqlCommand command = new MySqlCommand(getExercise, con);
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
                exerciseTitle = reader["Title"] + "";
                exerciseDescription = reader["Description"] + "";
                therapistId = reader["TherapistId"] + "";
                folderId = Convert.ToInt16(reader["FolderId"]);
                exercise = new Exercise(exerciseId, exerciseTitle, exerciseDescription, folderId, therapistId);
            }
            con.Close();
            reader.Close();
            return exercise;
        }

        public List<Exercise> getAllExercisesByFolderId(string therapistId, int folderId)
        {

            con.Open();
            List<Exercise> allExercises = new List<Exercise>();
            String getExercises = "SELECT * FROM Exercise WHERE TherapistId = '" + therapistId + "' AND FolderId = '" + folderId + "'";

            MySqlCommand command = new MySqlCommand(getExercises, con);
            MySqlDataReader reader = command.ExecuteReader();

            int exerciseId;
            string exerciseTitle, exerciseDescription;

            while (reader.Read())
            {
                //  public Exercise(int id, string title, string folderId, string therapistId)
                exerciseId = Convert.ToInt32(reader["ExerciseId"]);
                exerciseTitle = reader["Title"] + "";
                exerciseDescription = reader["Description"] + "";
                Exercise exercise = new Exercise(exerciseId, exerciseTitle, exerciseDescription, folderId, therapistId);

                allExercises.Add(exercise);
            }

            con.Close();
            reader.Close();
            return allExercises;
        }

        public List<Exercise> getAllExercises(string therapistId)
        {

            con.Open();
            List<Exercise> allExercises = new List<Exercise>();
            String getExercises = "SELECT * FROM Exercise WHERE TherapistId = '" + therapistId + "' ORDER BY FolderId ASC";

            MySqlCommand command = new MySqlCommand(getExercises, con);
            MySqlDataReader reader = command.ExecuteReader();

            int exerciseId, folderId;
            string exerciseTitle, exerciseDescription;

            while (reader.Read())
            {
                //  public Exercise(int id, string title, string folderId, string therapistId)
                exerciseId = Convert.ToInt32(reader["ExerciseId"]);
                exerciseTitle = reader["Title"] + "";
                exerciseDescription = reader["Description"] + "";
                folderId = Convert.ToInt32(reader["FolderId"]);
                Exercise exercise = new Exercise(exerciseId, exerciseTitle, exerciseDescription, folderId, therapistId);

                allExercises.Add(exercise);
            }

            con.Close();
            reader.Close();
            return allExercises;
        }
        public bool updateDescriptionExercise(Exercise exercise, string description)
        {
            con.Open();
            string updateDescription = "UPDATE Exercise SET Description = '" + description + "' WHERE ExerciseId = '" + exercise.Id + "'";
            MySqlCommand command = new MySqlCommand(updateDescription, con);
            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
        /*  ****************************     Task     ****************************  */

        public bool addTask(Task task)
        {
            con.Open();
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO Task(TaskTitle, Description, ImagePath, Comment, ExerciseId) VALUES(@taskTitle, @description, @imagePath, @comment, @exerciseId)";
            comm.Parameters.AddWithValue("@taskTitle", task.Title);
            comm.Parameters.AddWithValue("@description", task.Description);
            comm.Parameters.AddWithValue("@imagePath", task.ImagePath);
            comm.Parameters.AddWithValue("@comment", task.Comment);
            comm.Parameters.AddWithValue("@exerciseId", task.ExerciseId);

            //  con.Close();
            if (comm.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }

            con.Close();
            return false;
        }

        public List<Task> getAllTasksByExerciseId(int exerciseId)
        {
            
            con.Open();
            List<Task> allTasks = new List<Task>();
            String getAllTasks = "SELECT * FROM Task WHERE ExerciseId = '" + exerciseId + "'";

            MySqlCommand command = new MySqlCommand(getAllTasks, con);
            MySqlDataReader reader = command.ExecuteReader();

            string taskTitle, taskDescription, imagePath, comment;

            while (reader.Read())
            {
                taskTitle = reader["TaskTitle"] + "";
                imagePath = reader["ImagePath"] + "";
                taskDescription = reader["Description"] + "";
                comment = reader["Comment"] + "";
                Task task = new Task(taskTitle, taskDescription, imagePath, comment, exerciseId);
                allTasks.Add(task);
            }

            con.Close();
            reader.Close();
            return allTasks;
        }


         /*  ****************************     Assignment Exercise     ****************************  */
        public bool addAssignmentExercise(AssignedExercise assignedExercise)
        {
            con.Open();
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO AssignedExercise(ExerciseId, FolderId, FolderName, PatientId, TherapistId) VALUES(@exerciseId, @folderId, @folderName, @patientId, @therapistId)";
            comm.Parameters.AddWithValue("@exerciseId", assignedExercise.ExerciseId);
            comm.Parameters.AddWithValue("@folderId", assignedExercise.FolderId);
            comm.Parameters.AddWithValue("@folderName", assignedExercise.FolderName);
            comm.Parameters.AddWithValue("@patientId", assignedExercise.PatientId);
            comm.Parameters.AddWithValue("@therapistId", assignedExercise.TherapistId);

            //  con.Close();
            if (comm.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }

            con.Close();
            return false;
        }

        public List<AssignedExercise> getAllAssignedExercisesByTherapistId(string therapistId)      // get list of assigned exercises by therapist id
        {
            con.Open();
            List<AssignedExercise> allAssignedExercises = new List<AssignedExercise>();
            
            String getAssignedExercises = "SELECT * FROM AssignedExercise WHERE TherapistId = '" + therapistId + "'";

            MySqlCommand command = new MySqlCommand(getAssignedExercises, con);
            MySqlDataReader reader = command.ExecuteReader();

            int exerciseId, folderId;
            string patientId, folderName;

            while (reader.Read())
            {
                folderName = reader["FolderName"] + "";
                patientId = reader["PatientId"] + "";
                exerciseId = Convert.ToInt32(reader["ExerciseId"]);
                folderId = Convert.ToInt32(reader["FolderId"]);
                AssignedExercise assignedExercise = new AssignedExercise(exerciseId, folderId, folderName, patientId, therapistId);
                allAssignedExercises.Add(assignedExercise);
            }
            con.Close();
            reader.Close();
            return allAssignedExercises;
        }

        public List<AssignedExercise> getAllAssignedExercisesByPatientId(string patientId)      // get list of assigned exercises by patient id
        {
            con.Open();
            List<AssignedExercise> allAssignedExercises = new List<AssignedExercise>();

            String getAssignedExercises = "SELECT * FROM AssignedExercise WHERE PatientId = '" + patientId + "'";

            MySqlCommand command = new MySqlCommand(getAssignedExercises, con);
            MySqlDataReader reader = command.ExecuteReader();

            int exerciseId, folderId;
            string therapistId, folderName;

            while (reader.Read())
            {
                folderName = reader["FolderName"] + "";
                therapistId = reader["TherapistId"] + "";
                exerciseId = Convert.ToInt32(reader["ExerciseId"]);
                folderId = Convert.ToInt32(reader["FolderId"]);
                AssignedExercise assignedExercise = new AssignedExercise(exerciseId, folderId, folderName, patientId, therapistId);
                allAssignedExercises.Add(assignedExercise);
            }
            con.Close();
            reader.Close();
            return allAssignedExercises;
        }

        public List<AssignedExercise> getAllAssignedExercisesByExerciseId(int exerciseId)       // get list of assigned exercises by exercise id
        {
            con.Open();
            List<AssignedExercise> allAssignedExercises = new List<AssignedExercise>();

            String getAssignedExercises = "SELECT * FROM AssignedExercise WHERE ExerciseId = '" + exerciseId + "'";

            MySqlCommand command = new MySqlCommand(getAssignedExercises, con);
            MySqlDataReader reader = command.ExecuteReader();

            string patientId, therapistId, folderName;
            int folderId;

            while (reader.Read())
            {
                folderName = reader["FolderName"] + "";
                therapistId = reader["TherapistId"] + "";
                patientId = reader["PatientId"] + "";
                folderId = Convert.ToInt32(reader["FolderId"]);
                AssignedExercise assignedExercise = new AssignedExercise(exerciseId, folderId, folderName, patientId, therapistId);
                allAssignedExercises.Add(assignedExercise);
            }
            con.Close();
            reader.Close();
            return allAssignedExercises;
        }

        public List<Exercise> getListExerciseByListAssignedExercise(List<AssignedExercise> assignedExercise)        // return list of exercises, given list of assigned exercises
        {
            
            List<Exercise> allExercises = new List<Exercise>();
            foreach(AssignedExercise ass in assignedExercise)
            {
                Exercise exercise = getExerciseDetails(ass.ExerciseId);
                allExercises.Add(exercise);
            }

            return allExercises;
        }
    }
}
