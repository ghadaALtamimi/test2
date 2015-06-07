using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nemiro.OAuth;
using Nemiro.OAuth.LoginForms;
using System.Diagnostics;
using System.Threading;

namespace AppVoice
{
    
    public partial class Exercise1 : System.Web.UI.Page
    {
        public Bl_Therapist bl_therapist;
        public Exercise exercise;
        public List<Task> allTasks;
        public string therapistId, exerciseTitle;
        public int exerciseId;
        private string CurrentPath = "/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
               

                therapistId = Session["therapist_licenseId"].ToString();        // get therapist id
                bl_therapist = new Bl_Therapist();

                    AddTaskPanel.Visible = false; // Panel of add task not visible

                if (Request.QueryString["exercise"] != null && Request.QueryString["id"] != null)       // if we came from exercises folder and not patient folder
                {
                    exerciseTitle = Request.QueryString["exercise"];        // get exercise title
                    exerciseId = Convert.ToInt16(Request.QueryString["id"]);    // get exercise id

                    exercise = bl_therapist.getExerciseDetails(exerciseId);     // get exercise details
                    allTasks = bl_therapist.getAllTasksByExerciseId(exerciseId);        // get all tasks of specific exercise

                    ExerciseNameLabel.Text = exercise.Title;        // set name label of exercise
                    FolderNameLabel.Text = bl_therapist.getFolderNameByFolderId(exercise.FolderId, therapistId);        // set folder name
                    ExerciseDescriptionLabel.Text = exercise.Description;       // set description 
                    TaskTitleLabelError.Visible = false;

                    if(exercise.Description.Equals(""))     // if no description for this exercise  - add button
                    {
                        AddDescriptionButton.Visible = true;
                        EditDescriptionButton.Visible = false;
                        SaveDescriptionButton.Visible = false;
                        DescriptionTextBox.Visible = false;
                    }
                    else            // if there is a description for this exercise  - edit button
                    {
                        AddDescriptionButton.Visible = false;
                        EditDescriptionButton.Visible = true;
                        SaveDescriptionButton.Visible = false;
                        DescriptionTextBox.Visible = false;
                    }
                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }

      

        private static OAuthToken GetAccessToken()          // get authorization to access dropbox files
        {
            var oauth = new OAuth();

            var requestToken = oauth.GetRequestToken(new Uri(DropboxRestApi.BaseUri), CONSTANT.APP_KEY, CONSTANT.APP_SECRET);

            var authorizeUri = oauth.GetAuthorizeUri(new Uri(DropboxRestApi.AuthorizeBaseUri), requestToken);
            Process.Start(authorizeUri.AbsoluteUri);
            Thread.Sleep(5000); // Leave some time for the authorization step to complete

            return oauth.GetAccessToken(new Uri(DropboxRestApi.BaseUri), CONSTANT.APP_KEY, CONSTANT.APP_SECRET, requestToken);
        }

        protected void OnAddExerciseDescription_Click(object sender, EventArgs e)
        {
            DescriptionTextBox.Visible = true;

            EditDescriptionButton.Visible = false;
            AddDescriptionButton.Visible = false;
            SaveDescriptionButton.Visible = true;

        }

        protected void OnEditExerciseDescription_Click(object sender, EventArgs e)
        {
            DescriptionTextBox.Visible = true;
            DescriptionTextBox.Text = exercise.Description;

            EditDescriptionButton.Visible = false;
            AddDescriptionButton.Visible = false;
            SaveDescriptionButton.Visible = true;
            DescriptionLabel.Visible = false;
        }

        protected void OnSaveExerciseDescription_Click(object sender, EventArgs e)
        {
            if (bl_therapist.updateDescriptionExercise(exercise, DescriptionTextBox.Text))
            {
                Page_Load(sender, e);
            }
        }

        protected void OnAddTask_Click(object sender, EventArgs e)
        {
            AddTaskPanel.Visible = true;
        }

        protected void OnSaveButton_Click(object sender, EventArgs e)
        {
            if(TaskTitleTextBox.Text.Equals(""))
            {
                TaskTitleLabelError.Visible = false;
            }
            else
            {
                string taskTitle, taskDescription, taskUrl, taskComment;
                int exerciseId;

                taskTitle = TaskTitleTextBox.Text;
                taskDescription = TaskDescriptionTextBox.Text;
                taskComment = CommentTextBox.Text;
            
                var accessToken = GetAccessToken();
                var api = new DropboxApi(CONSTANT.APP_KEY, CONSTANT.APP_SECRET, accessToken);

               // string aspNetFilePath = FileUploadUrl.PostedFile.FileName;

                string fileName = FileUploadUrl.FileName;           // getting name of uploaded file
                string filePath = Server.MapPath(FileUploadUrl.FileName);       // getting path of the upload file

                
                exerciseId = exercise.Id;
                Task task = new Task(taskTitle, taskDescription, fileName, taskComment, exerciseId);        // creating new task for specific exercise
                if(bl_therapist.addTask(task))      // if succeeded
                {
                    //Page_Load(sender, e);
                    UrlLabel.Text = "FilePath: " + filePath + " -- FileName: " + fileName;
                    FileUploadUrl.SaveAs(filePath);
                    var file = api.UploadFile("dropbox", fileName, @filePath);           //  UploadFile(string root, string path, string file)  -- uploading file to dropbox folder
                }
            }
        }

        protected void OnCancelButton_Click(object sender, EventArgs e)
        {
            AddTaskPanel.Visible = false;
        }



        
    }
}