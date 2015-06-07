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
                var accessToken = GetAccessToken();
             /*   if(String.IsNullOrEmpty(Properties.Settings.Default.AccessToken))       // checking for an access token in the application settings
                {
                    this.GetAccessToken();  // Access Token is empty. Receiving...
                }
                else
                {
                    this.GetFiles();    // Is not empty. Receiving a list of files

                } */




                therapistId = Session["therapist_licenseId"].ToString();
                bl_therapist = new Bl_Therapist();
                AddTaskPanel.Visible = false;
                if (Request.QueryString["exercise"] != null && Request.QueryString["id"] != null)
                {
                    exerciseTitle = Request.QueryString["exercise"];
                    exerciseId = Convert.ToInt16(Request.QueryString["id"]);

                    exercise = bl_therapist.getExerciseDetails(exerciseId);
                    allTasks = bl_therapist.getAllTasksByExerciseId(exerciseId);

                    ExerciseNameLabel.Text = exercise.Title;
                    FolderNameLabel.Text = bl_therapist.getFolderNameByFolderId(exercise.FolderId, therapistId);
                    ExerciseDescriptionLabel.Text = exercise.Description;
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
                        
                    }
                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }

      /*  private void GetFiles()
        {
            OAuthUtility.GetAsync("https://api.dropbox.com/1/metadata/auto/", new HttpParameterCollection 
            {
                { "path", this.CurrentPath }, 
                { "accesss_token", Properties.Settings.Default.AccessToken}     // Access token should be transmitted in all requests
            }//, callback: GetFiles_Result    // the callback method because the request is asynchronous
            );
        }
/*
        private void GetFiles_Result(RequestResult result)
        {
            if(InvokeRequired)
            {

            }
        } */
     /*   private void GetAccessToken()
        {
            var login = new DropboxLogin(CONSTANT.APP_KEY, CONSTANT.APP_SECRET);        // using app key and app secret to login in dropbox
            if(login.IsSuccessfully)
            {
                Properties.Settings.Default["AccessToken"] = login.AccessToken.Value;
                
                Properties.Settings.Default.Save();
            }
           

        } */

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
                //taskUrl = FileUploadUrl.;
                //string htmlFilePath = fupHtmlUpload.PostedFile.FileName;

                var accessToken = GetAccessToken();
                var api = new DropboxApi(CONSTANT.APP_KEY, CONSTANT.APP_SECRET, accessToken);

                //var file = api.UploadFile("dropbox", "1.txt", @"C:\1\1.txt");



                string aspNetFilePath = FileUploadUrl.PostedFile.FileName;

                string filePath = FileUploadUrl.FileName;

                string fileName = Path.Combine(Server.MapPath("."), filePath);

                UrlLabel.Text = "FilePath: " + filePath + " -- FileName: " + fileName;
                FileUploadUrl.SaveAs(fileName);
                
                exerciseId = exercise.Id;
                Task task = new Task(taskTitle, taskDescription, fileName, taskComment, exerciseId);
                if(bl_therapist.addTask(task))
                {
                    Page_Load(sender, e);
                }
            }
        }

        protected void OnCancelButton_Click(object sender, EventArgs e)
        {
            AddTaskPanel.Visible = false;
        }



        
    }
}