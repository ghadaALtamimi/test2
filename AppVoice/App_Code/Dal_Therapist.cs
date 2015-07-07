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

        public bool deleteFolder(string folderId)
        {
            con.Open();

            String deleteExercises = "DELETE FROM Exercise WHERE FolderId = '" + folderId + "'";
            MySqlCommand command = new MySqlCommand(deleteExercises, con);

            while (command.ExecuteNonQuery() < 0)
            {
                con.Close();
                return false;
            }

            String deleteFolder = "DELETE FROM Folder WHERE FolderId = '" + folderId + "'";
            MySqlCommand command1 = new MySqlCommand(deleteFolder, con);
            if (command1.ExecuteNonQuery() < 0)
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }
        /*  ****************************     Exercise     ****************************  */

        public bool addExercise(Exercise exercise)
        {

            con.Open();
            // String addDetails = "INSERT INTO Folder VALUES('" + patient.PatientId + "','" + patient.FirstName + "','" + patient.LastName + "','" + patient.Mail + "','" + patient.PhoneNumber + "','" + patient.Address + "','"  + patient.Hmo + "','" + patient.Password + "','" + patient.TherapistId + "')";
            //  MySqlCommand command = new MySqlCommand(addDetails, con);
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO Exercise(Title, FolderId, TherapistId, Description, Link, ImagePath, FilePath, IsVideo) VALUES(@title, @folderId, @therapistId, @description, @link, @imagePath, @filePath, @isVideo)";
            comm.Parameters.AddWithValue("@title", exercise.Title);
            comm.Parameters.AddWithValue("@description", exercise.Description);
            comm.Parameters.AddWithValue("@folderId", exercise.FolderId);
            comm.Parameters.AddWithValue("@therapistId", exercise.TherapistId);
            comm.Parameters.AddWithValue("@imagePath", exercise.ImagePath);
            comm.Parameters.AddWithValue("@filePath", exercise.FilePath);
            comm.Parameters.AddWithValue("@isVideo", Convert.ToInt16(exercise.IsVideo));
            comm.Parameters.AddWithValue("@link", exercise.Link);

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

            string exerciseTitle, exerciseDescription, therapistId, imagePath, filePath, link;
            int folderId;
            bool isVideo;

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
                link = reader["Link"] + "";
                imagePath = reader["ImagePath"] + "";
                filePath = reader["FilePath"] + "";
                isVideo = Convert.ToBoolean(reader["IsVideo"]);
                exercise = new Exercise(exerciseId, exerciseTitle, exerciseDescription, folderId, therapistId, link, imagePath, filePath, isVideo);
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
            string exerciseTitle, exerciseDescription, imagePath, filePath, link;
            bool isVideo;

            while (reader.Read())
            {
                //  public Exercise(int id, string title, string folderId, string therapistId)
                exerciseId = Convert.ToInt32(reader["ExerciseId"]);
                exerciseTitle = reader["Title"] + "";
                exerciseDescription = reader["Description"] + "";
                link = reader["Link"] + "";
                imagePath = reader["ImagePath"] + "";
                filePath = reader["FilePath"] + "";
                isVideo = Convert.ToBoolean(reader["IsVideo"]);
                Exercise exercise = new Exercise(exerciseId, exerciseTitle, exerciseDescription, folderId, therapistId, link, imagePath, filePath, isVideo);

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
            string exerciseTitle, exerciseDescription, imagePath, filePath, link;
            bool isVideo;

            while (reader.Read())
            {
                //  public Exercise(int id, string title, string folderId, string therapistId)
                exerciseId = Convert.ToInt32(reader["ExerciseId"]);
                exerciseTitle = reader["Title"] + "";
                exerciseDescription = reader["Description"] + "";
                folderId = Convert.ToInt32(reader["FolderId"]);
                link = reader["Link"] + "";
                imagePath = reader["ImagePath"] + "";
                filePath = reader["FilePath"] + "";
                isVideo = Convert.ToBoolean(reader["IsVideo"]);
                Exercise exercise = new Exercise(exerciseId, exerciseTitle, exerciseDescription, folderId, therapistId, link, imagePath, filePath, isVideo);

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

        public bool updateExercise(Exercise new_exercise)
        {
            con.Open();
            string updateDescription = "UPDATE Exercise SET Title = '" + new_exercise.Title + "', Description = '" + new_exercise.Description + "', ImagePath = '" + new_exercise.ImagePath + "', FilePath = '" + new_exercise.FilePath + "', IsVideo = '" + Convert.ToInt16(new_exercise.IsVideo) + "', Link = '" + new_exercise.Link + "' WHERE ExerciseId = '" + new_exercise.Id + "'";
            MySqlCommand command = new MySqlCommand(updateDescription, con);
            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        public bool updateImagePathFromExercise(Exercise exercise, string imagePath)
        {
            con.Open();
            string updateImage = "UPDATE Exercise SET ImagePath = '" + imagePath + "' WHERE ExerciseId = '" + exercise.Id + "'";
            MySqlCommand command = new MySqlCommand(updateImage, con);
            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        public bool updateFilePathFromExercise(Exercise exercise, string filePath)
        {
            con.Open();
            string updateFile = "UPDATE Exercise SET FilePath = '" + filePath + "' WHERE ExerciseId = '" + exercise.Id + "'";
            MySqlCommand command = new MySqlCommand(updateFile, con);
            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        public bool updateTitleExercise(Exercise exercise, string title)
        {
            con.Open();
            string updateTitle = "UPDATE Exercise SET Title = '" + title + "' WHERE ExerciseId = '" + exercise.Id + "'";
            MySqlCommand command = new MySqlCommand(updateTitle, con);
            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
        public bool updateLinkExercise(Exercise exercise, string link)
        {
            con.Open();
            string updateLink = "UPDATE Exercise SET Link = '" + link + "' WHERE ExerciseId = '" + exercise.Id + "'";
            MySqlCommand command = new MySqlCommand(updateLink, con);
            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        public bool updateIsVideoExercise(Exercise exercise, int isVideo)
        {
            con.Open();
            string updateVideo = "UPDATE Exercise SET IsVideo = '" + isVideo + "' WHERE ExerciseId = '" + exercise.Id + "'";
            MySqlCommand command = new MySqlCommand(updateVideo, con);
            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        public bool deleteExercise(Exercise exercise)
        {
            con.Open();
            string deleteEx = "DELETE FROM Exercise WHERE ExerciseId = '" + exercise.Id + "'";
            MySqlCommand command = new MySqlCommand(deleteEx, con);
            if (command.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
        public bool deleteExercise(string exerciseId)
        {
            con.Open();
            string deleteEx = "DELETE FROM Exercise WHERE ExerciseId = '" + exerciseId + "'";
            string deleteAssEx = "DELETE FROM AssignedExercise WHERE ExerciseId = '" + exerciseId + "'";
            string deleteSubEx = "DELETE FROM SubmittedExercise WHERE ExerciseId = '" + exerciseId + "'";


            MySqlCommand command1 = new MySqlCommand(deleteEx, con);
            MySqlCommand command2 = new MySqlCommand(deleteAssEx, con);
            MySqlCommand command3 = new MySqlCommand(deleteSubEx, con);


            if (command1.ExecuteNonQuery() < 0 )        // remove from Exercise table
            {
                con.Close();
                return false;
            }
            while(command2.ExecuteNonQuery() < 0)       // remove from AssignedExercise table
            {
                con.Close();
                return false;
            }
            while(command3.ExecuteNonQuery() < 0)       // remove from SubmittedExercise table
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
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
            foreach (AssignedExercise ass in assignedExercise)
            {
                Exercise exercise = getExerciseDetails(ass.ExerciseId);
                allExercises.Add(exercise);
            }

            return allExercises;
        }
        /*  ****************************     Messages     ****************************  */
        public int getNumOfUnreadMessages(string licenseId)
        {
            List<Message> allMessages = getAllMessages(licenseId);
            int numOfUnreadMessages = 0;
            foreach (Message m in allMessages)
            {
                if (!m.IsRead)
                {
                    numOfUnreadMessages++;
                }
            }
            return numOfUnreadMessages;
        }

        public List<Message> getAllMessages(string licenseId)
        {
            con.Open();
            List<Message> allMessages = new List<Message>();

            String getAllMessages = "SELECT * FROM Messages WHERE MessageTo = '" + licenseId + "' ORDER BY MessageId DESC";

            MySqlCommand command = new MySqlCommand(getAllMessages, con);
            MySqlDataReader reader = command.ExecuteReader();

            int messageId;
            string messageFrom, messageTo, messageText;
            bool isRead;

            while (reader.Read())
            {
                messageId = Convert.ToInt32(reader["MessageId"]);
                messageFrom = reader["MessageTo"] + "";
                messageTo = licenseId;
                messageText = reader["Message"] + "";
                isRead = Convert.ToBoolean(reader["IsRead"]);
                Message message = new Message(messageId, messageFrom, messageTo, messageText, isRead);
                allMessages.Add(message);
            }
            con.Close();
            reader.Close();
            return allMessages;
        }

        public List<Message> getUnreadMessages(string licenseId)
        {
            List<Message> allMessages = getAllMessages(licenseId);
            List<Message> unreadMessages = new List<Message>();
            foreach (Message m in allMessages)
            {
                if (!m.IsRead)
                {
                    unreadMessages.Add(m);
                }
            }
            return unreadMessages;
        }

        public bool sendMessage(string messageFrom, string messageTo, string messageText)
        {
            con.Open();
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO Messages(MessageFrom, MessageTo, MessageText) VALUES(@messageFrom, @messageTo, @MessageText)";
            comm.Parameters.AddWithValue("@messageFrom", messageFrom);
            comm.Parameters.AddWithValue("@messageTo", messageTo);
            comm.Parameters.AddWithValue("@messageText", messageText);

            //  con.Close();
            if (comm.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }

            con.Close();
            return false;
        }

        /*  ****************************     Submitted Exercise     ****************************  */
        public List<SubmittedExercise> getSubmittedExercises(string licenseId)
        {
            con.Open();
            List<SubmittedExercise> allExercises = new List<SubmittedExercise>();

            String getAllExercises = "SELECT * FROM SubmittedExercise WHERE TherapistId = '" + licenseId + "'";

            MySqlCommand command = new MySqlCommand(getAllExercises, con);
            MySqlDataReader reader = command.ExecuteReader();

            int id, exerciseId, isOpenedFile, isDone;
            string patientId, exerciseName, videoPath;

            while (reader.Read())
            {
                id = Convert.ToInt32(reader["Id"]);
                exerciseId = Convert.ToInt32(reader["ExerciseId"]);
                exerciseName = reader["ExerciseName"] + "";
                patientId = reader["PatientId"] + "";
                isOpenedFile = Convert.ToInt16(reader["OpenedFile"]);
                isDone = Convert.ToInt16(reader["IsDone"]);
                videoPath = reader["VideoLink"] + "";
                SubmittedExercise submittedExercise = new SubmittedExercise(id, exerciseId, exerciseName, patientId, licenseId, isOpenedFile, isDone, videoPath);

                allExercises.Add(submittedExercise);
            }
            con.Close();
            reader.Close();
            return allExercises;
        }
    }
}
