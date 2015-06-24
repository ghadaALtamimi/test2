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
using Spring.Social.Dropbox.Api;

namespace AppVoice
{

    public partial class Exercise1 : System.Web.UI.Page
    {
        public Bl_Therapist bl_therapist;
        public Exercise exercise;
        public List<Task> allTasks;
        public string therapistId, exerciseTitle;
        public int exerciseId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {


                therapistId = Session["therapist_licenseId"].ToString();        // get therapist id
                bl_therapist = new Bl_Therapist();

                 hideTextBoxes();
                 hideOthersButton("");
                 UpdateButton.Visible = true;
                 SaveUpdatesButton.Visible = false;
                 DeleteButton.Visible = false;


                if (Request.QueryString["exercise"] != null && Request.QueryString["id"] != null)       // if we came from exercises folder and not patient folder
                {
                    exerciseTitle = Request.QueryString["exercise"];        // get exercise title
                    exerciseId = Convert.ToInt16(Request.QueryString["id"]);    // get exercise id

                    exercise = bl_therapist.getExerciseDetails(exerciseId);     // get exercise details

                    ErrorInUpdateLabel.Visible = false;
                    ExerciseNameLabel.Text = exercise.Title;        // set name label of exercise
                    FolderNameLabel.Text = bl_therapist.getFolderNameByFolderId(exercise.FolderId, therapistId);        // set folder name
                }

                if (!exercise.Description.Equals(""))
                {
                    DescriptionLabel.Text = exercise.Description;
                }
                if (!exercise.Link.Equals(""))
                {
                    Uri uri = new Uri(exercise.Link);
                    LinkHyperLink.NavigateUrl = uri.AbsoluteUri;
                    LinkHyperLink.Text = exercise.Link;
                }
                else
                {
                    LinkHyperLink.Text = "אין לינק לתרגיל זה";
                }
                if (!exercise.ImagePath.Equals(""))
                {
                    ImageLabel.Text = exercise.ImagePath;
                }
                if (!exercise.FilePath.Equals(""))
                {
                    FileLabel.Text = exercise.FilePath;
                }
               
                VideoCheckBox.Checked = exercise.IsVideo;
                
                VideoCheckBox.Enabled = false;

            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }

        /*****************************               Title               *****************************/
        protected void OnUpdateTitleButton_Click(object sender, EventArgs e)
        {
            hideOthersButton("title");
            showOnUpdate("title");
            hideButtonsUpdate();

            ExerciseNameLabel.Visible = false;
            ExerciseNameTextBox.Visible = true;
            ExerciseNameTextBox.Text = exercise.Title;
        }

      


        protected void OnSaveTitleButton_Click(object sender, EventArgs e)
        {
            // SAVE IN DAL
            if (bl_therapist.updateTitleExercise(exercise, ExerciseNameTextBox.Text))
            {
                showOthersButton();
                showOnSave("title");
                ExerciseNameLabel.Text = ExerciseNameTextBox.Text;
                ExerciseNameLabel.Visible = true;
                ExerciseNameTextBox.Visible = false;
            }
            
        }

        protected void OnCancelTitleButton_Click(object sender, EventArgs e)
        {
            showOthersButton();
            showOnSave("title");
            ExerciseNameLabel.Visible = true;
            ExerciseNameTextBox.Visible = false;
        }

        /*****************************               Description               *****************************/
        protected void OnUpdateDescriptionButton_Click(object sender, EventArgs e)
        {
            hideOthersButton("description");
            showOnUpdate("description");
            DescriptionLabel.Visible = false;
            DescriptionTextBox.Visible = true;
            DescriptionTextBox.Text = exercise.Description;
        }

        protected void OnSaveDescriptionButton_Click(object sender, EventArgs e)
        {
          
            if (bl_therapist.updateDescriptionExercise(exercise, DescriptionTextBox.Text))
            {
                showOthersButton();
                showOnSave("description");
                DescriptionLabel.Visible = true;
                DescriptionTextBox.Visible = false;
                DescriptionLabel.Text = DescriptionTextBox.Text;
            }
        }

        protected void OnCancelDescriptionButton_Click(object sender, EventArgs e)
        {
            showOthersButton();
            showOnSave("description");
            ExerciseNameLabel.Visible = true;
            ExerciseNameTextBox.Visible = false;
        }

        /*****************************               Link               *****************************/
        protected void OnUpdateLinkButton_Click(object sender, EventArgs e)
        {
            hideOthersButton("link");
            showOnUpdate("link");
            LinkHyperLink.Visible = false;
            LinkTextBox.Visible = true;
            LinkTextBox.Text = exercise.Link;
        }

        protected void OnSaveLinkButton_Click(object sender, EventArgs e)
        {
            if (bl_therapist.updateLinkExercise(exercise, LinkTextBox.Text))
            {
                showOthersButton();
                CancelLinkButton.Visible = false;
                LinkHyperLink.Visible = true;
                showOnSave("link");
                LinkTextBox.Visible = false;
                LinkHyperLink.Text = LinkTextBox.Text;
                DeleteButton.Visible = true;
            }

        }

        protected void OnCancelLinkButton_Click(object sender, EventArgs e)
        {
            showOthersButton();
            showOnSave("link");
            LinkHyperLink.Visible = true;
            LinkTextBox.Visible = false;
        }

        /*****************************               Image               *****************************/
        protected void OnUpdateImageButton_Click(object sender, EventArgs e)
        {
            hideOthersButton("image");
            showOnUpdate("image");
            ImageUpload.Visible = true;
        }


        protected void OnDeleteImageButton_Click(object sender, EventArgs e)
        {
            //exercise.ImagePath = "";
            if (bl_therapist.updateImagePathFromExercise(exercise, ""))
            {
                showOnSave("image");
                showOthersButton();
                ImageLabel.Text = "לא נבחרה תמנה";
            }
        }

        protected void OnSaveImageButton_Click(object sender, EventArgs e)
        {
            UpdateImageButton.Visible = true;
            SaveImageButton.Visible = false;
            CancelImageButton.Visible = false;


            UpdateButton.Visible = false;
            SaveUpdatesButton.Visible = true;
            DeleteButton.Visible = true;

            ImageLabel.Text = ImageUpload.FileName;
            string imagePath = Server.MapPath(ImageUpload.FileName);

            // Connect to DROPBOX
            OAuthToken accessToken = new OAuthToken(CONSTANT.TOKEN, CONSTANT.SECRET);
            var api = new DropboxApi(CONSTANT.APP_KEY, CONSTANT.APP_SECRET, accessToken);
            // save to computer
            ImageUpload.SaveAs(imagePath);
            // save to dropbox
            var file = api.UploadFile("dropbox", ImageUpload.FileName, @imagePath);           //  UploadFile(string root, string path, string file)  -- uploading file to dropbox folder
            bl_therapist.updateImagePathFromExercise(exercise, ImageUpload.FileName);
        }

        protected void OnCancelImageButton_Click(object sender, EventArgs e)
        {
            UpdateImageButton.Visible = true;
            SaveImageButton.Visible = false;
            CancelImageButton.Visible = false;

            UpdateButton.Visible = false;
            SaveUpdatesButton.Visible = true;
            DeleteButton.Visible = true;
            showOthersButton();
        }

        /*****************************               File               *****************************/
        protected void OnUpdateFileButton_Click(object sender, EventArgs e)
        {
            showOnUpdate("file");
            hideOthersButton("file");
            FileUpload.Visible = true;
        }

        protected void OnSaveFileButton_Click(object sender, EventArgs e)
        {
           
            showOnSave("file");
            showOthersButton();
            FileLabel.Text = FileUpload.FileName;
            string filePath = Server.MapPath(FileUpload.FileName);

            // Connect to DROPBOX
            OAuthToken accessToken = new OAuthToken(CONSTANT.TOKEN, CONSTANT.SECRET);
            var api = new DropboxApi(CONSTANT.APP_KEY, CONSTANT.APP_SECRET, accessToken);
            // save to computer
            ImageUpload.SaveAs(filePath);
            // save to dropbox
            var file = api.UploadFile("dropbox", FileUpload.FileName, @filePath);           //  UploadFile(string root, string path, string file)  -- uploading file to dropbox folder
        }


        protected void OnDeleteFileButton_Click(object sender, EventArgs e)
        {
            if (bl_therapist.updateFilePathFromExercise(exercise, ""))
            {
                showOnSave("file");
                showOthersButton();
                FileLabel.Text = "לא נבחר קובץ";
            }
            
        }
        protected void OnCancelFileButton_Click(object sender, EventArgs e)
        {
            showOnSave("file");
            UpdateButton.Visible = false;
            SaveUpdatesButton.Visible = true;
            DeleteButton.Visible = true;
            showOthersButton();
        }



        private void hideOthersButton(string str)
        {
            switch (str)
            {
                case "":
                    {
                        UpdateTitleButton.Visible = false;
                        UpdateDescriptionButton.Visible = false;
                        UpdateLinkButton.Visible = false;
                        UpdateImageButton.Visible = false;
                        UpdateFileButton.Visible = false;
                    }break;
                case "title":
                    {
                        UpdateDescriptionButton.Visible = false;
                        UpdateLinkButton.Visible = false;
                        UpdateImageButton.Visible = false;
                        UpdateFileButton.Visible = false;
                    } break;
                case "description":
                    {
                        UpdateTitleButton.Visible = false;
                        UpdateLinkButton.Visible = false;
                        UpdateImageButton.Visible = false;
                        UpdateFileButton.Visible = false;
                    } break;
                case "link":
                    {
                        UpdateDescriptionButton.Visible = false;
                        UpdateTitleButton.Visible = false;
                        UpdateImageButton.Visible = false;
                        UpdateFileButton.Visible = false;
                    } break;
                case "image":
                    {
                        UpdateDescriptionButton.Visible = false;
                        UpdateLinkButton.Visible = false;
                        UpdateTitleButton.Visible = false;
                        UpdateFileButton.Visible = false;
                    } break;
                case "file":
                    {
                        UpdateDescriptionButton.Visible = false;
                        UpdateLinkButton.Visible = false;
                        UpdateImageButton.Visible = false;
                        UpdateTitleButton.Visible = false;
                    } break;
            }
            DeleteImageButton.Visible = false;
            DeleteFileButton.Visible = false;
        }
        private void showOthersButton()
        {
            UpdateTitleButton.Visible = true;
            UpdateDescriptionButton.Visible = true;
            UpdateLinkButton.Visible = true;
            UpdateImageButton.Visible = true;
            DeleteImageButton.Visible = true;
            UpdateFileButton.Visible = true;
            DeleteFileButton.Visible = true;
            VideoCheckBox.Enabled = true;
        }

        protected void OnCheckedChange(object sender, EventArgs e)
        {
            if (VideoCheckBox.Checked)
            {
                bl_therapist.updateIsVideoExercise(exercise, 0);
            }
            else
            {
                bl_therapist.updateIsVideoExercise(exercise, 1);
            }
        }
        protected void OnUpdateButton_Click(object sender, EventArgs e)
        {
            showOthersButton();
            UpdateButton.Visible = false;
            DeleteButton.Visible = true;
            //CancelButton.Visible = true;
            SaveUpdatesButton.Visible = true;
        }

        protected void OnSaveUpdatesButton_Click(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }

        protected void OnDeleteButton_Click(object sender, EventArgs e)
        {
            if(bl_therapist.deleteExercise(exercise))
            {
                Response.Redirect("/Pages/AllExercises.aspx");
            }
            else
            {
                ErrorInUpdateLabel.Visible = true;
            }
        }

        private void hideTextBoxes()
        {
            ExerciseNameTextBox.Visible = false;
            DescriptionTextBox.Visible = false;
            LinkTextBox.Visible = false;
            ImageUpload.Visible = false;
            FileUpload.Visible = false;
            VideoCheckBox.Enabled = false;
        }
        private void showTextBoxes()
        {
            ExerciseNameTextBox.Visible = true;
            ExerciseNameTextBox.Text = exercise.Title;
            DescriptionTextBox.Visible = true;
            DescriptionTextBox.Text = exercise.Description;
            LinkTextBox.Visible = true;
            LinkTextBox.Text = exercise.Link;
            VideoCheckBox.Enabled = true;
        }
        private void hideButtonsUpdate()
        {
            UpdateButton.Visible = false;
            SaveUpdatesButton.Visible = false;
            DeleteButton.Visible = false;
        }

        private void showOnUpdate(string str)
        {
            switch (str)
            {
                case "title":
                    {
                        SaveTitleButton.Visible = true;
                        CancelTitleButton.Visible = true;
                        UpdateTitleButton.Visible = false;
                    } break;

                case "description":
                    {
                        SaveDescriptionButton.Visible = true;
                        CancelDescriptionButton.Visible = true;
                        UpdateDescriptionButton.Visible = false;
                    } break;

                case "link":
                    {
                        SaveLinkButton.Visible = true;
                        CancelLinkButton.Visible = true;
                        UpdateLinkButton.Visible = false;
                    } break;
                case "image":
                    {
                        SaveImageButton.Visible = true;
                        CancelImageButton.Visible = true;
                        UpdateImageButton.Visible = false;
                    } break;
                case "file":
                    {
                        SaveFileButton.Visible = true;
                        CancelFileButton.Visible = true;
                        DeleteFileButton.Visible = true;
                        UpdateFileButton.Visible = false;
                    } break;
            }
            hideButtonsUpdate();
        }

        private void showOnSave(string str)
        {
            switch (str)
            {
                case "title":
                    {
                        SaveTitleButton.Visible = false;
                        CancelTitleButton.Visible = false;
                        UpdateTitleButton.Visible = true;
                    } break;

                case "description":
                    {
                        SaveDescriptionButton.Visible = false;
                        CancelDescriptionButton.Visible = false;
                        UpdateDescriptionButton.Visible = true;
                    } break;

                case "link":
                    {
                        SaveLinkButton.Visible = false;
                        CancelLinkButton.Visible = false;
                        UpdateLinkButton.Visible = true;
                    } break;
                case "image":
                    {
                        SaveImageButton.Visible = false;
                        CancelImageButton.Visible = false;
                        DeleteImageButton.Visible = true;
                        UpdateImageButton.Visible = true;
                    } break;
                case "file":
                    {
                        SaveFileButton.Visible = false;
                        CancelFileButton.Visible = false;
                        DeleteFileButton.Visible = true;
                        UpdateFileButton.Visible = true;
                    } break;
            }
            SaveUpdatesButton.Visible = true;
            DeleteButton.Visible = true;
            UpdateButton.Visible = false;
        }


    }
}