using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice
{
    public partial class NewExercise : System.Web.UI.Page
    {
        public Bl_Therapist bl_therapist;
        public Bl_Patient bl_patient;
        public string folderName, folderId, therapistId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
                bl_therapist = new Bl_Therapist();
                bl_patient = new Bl_Patient();

                therapistId = Session["therapist_licenseId"].ToString();
                TitleExerciseLabelError.Visible = false;
                if (Request.QueryString["folder"] != null && Request.QueryString["id"] != null)         // create new exercise from specific folder
                {
                    folderName = Request.QueryString["folder"];
                    folderId = Request.QueryString["id"];

                    DropDownListFolder.Visible = false;
                    TextBoxFolder.Visible = true;
                    TextBoxFolder.Text = folderName;

                }
                else        // create new exercise and choose specific folder
                {
                    DropDownListFolder.Visible = true;
                    TextBoxFolder.Visible = false;
                    fillDropDownListFolders();
                }

            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

        }

        private void fillDropDownListFolders()      // fill the dropdown list with folder's names
        {
            List<Folder> allFolders = bl_therapist.getAllFolders(Session["therapist_licenseId"].ToString());
            ArrayList arrayList = new ArrayList();

            foreach (Folder f in allFolders)
            {
                arrayList.Add(f.Name);
            }
            DropDownListFolder.DataSource = arrayList;
            DropDownListFolder.DataBind();
        }

        protected void OnSaveButton_Click(object sender, EventArgs e)       // on save exercise button
        {
            string exerciseTitle, exerciseDescription, link, imageName, fileName, imagePath, filePath;
            bool isVideo;

           


            if (TitleExerciseTextBox.Text.Equals(""))           // if title textbox is empty, do not add the exercise and return error messageText
            {
                TitleExerciseLabelError.Visible = true;
            }
            else
            {

                exerciseTitle = TitleExerciseTextBox.Text;      // save data from textboxes in order to add exercise
                exerciseDescription = DescriptionTextBox.Text;
                link = LinkTextBox.Text;
                imageName = PictureUpload.FileName;
                fileName = FileUpload.FileName;


                imagePath = Server.MapPath(imageName);
                filePath = Server.MapPath(fileName);

                // Connect to DROPBOX
                OAuthToken accessToken = new OAuthToken(CONSTANT.TOKEN, CONSTANT.SECRET);
                var api = new DropboxApi(CONSTANT.APP_KEY, CONSTANT.APP_SECRET, accessToken);
/*
                string imageName = 
                string fileName = FileUploadUrl.FileName;           // getting name of uploaded file
                string filePath = Server.MapPath(FileUploadUrl.FileName);       // getting path of the upload file

                UrlLabel.Text = "FilePath: " + filePath + " -- FileName: " + fileName;
*/

                if (VideoCheckBox.Checked)
                {
                    isVideo = true;
                }
                else
                {
                    isVideo = false;
                }

                if (folderId != null)       // if we add the exercise from a specific folder
                {
                    Exercise exercise = new Exercise(exerciseTitle, exerciseDescription, Convert.ToInt16(folderId), therapistId, link, imageName, fileName, isVideo);
                    if (bl_therapist.addExercise(exercise))
                    {
                        if (!fileName.Equals(""))//FileUpload.FileName != null)
                        {
                            FileUpload.SaveAs(filePath);
                            var file = api.UploadFile("dropbox", fileName, @filePath);           //  UploadFile(string root, string path, string file)  -- uploading file to dropbox folder
                        }
                       if (!imageName.Equals(""))
                        {
                            PictureUpload.SaveAs(imagePath);
                            var file = api.UploadFile("dropbox", imageName, @imagePath);           //  UploadFile(string root, string path, string file)  -- uploading file to dropbox folder
                        } 
                        Response.Redirect("/Pages/AllExercises.aspx?folder=" + folderName + "&id=" + folderId);
                    }
                    
                }
                else
                {       // if we add an exercise and we also choose the folder from this exercise
                    string folderName = DropDownListFolder.Text;
                    int folderIdByName = bl_therapist.getFolderIdByFolderName(folderName, therapistId);
                    Exercise exercise = new Exercise(exerciseTitle, exerciseDescription, Convert.ToInt16(folderIdByName), therapistId, link, imageName, fileName, isVideo);
                    if (bl_therapist.addExercise(exercise))
                    {
                        if (FileUpload.FileName.Equals(""))
                        {
                            FileUpload.SaveAs(filePath);
                            var file = api.UploadFile("dropbox", fileName, @filePath);           //  UploadFile(string root, string path, string file)  -- uploading file to dropbox folder
                        }
                         if (!imageName.Equals(""))
                         {
                             PictureUpload.SaveAs(imagePath);
                             var file = api.UploadFile("dropbox", imageName, @imagePath);           //  UploadFile(string root, string path, string file)  -- uploading file to dropbox folder
                         } 
                        Response.Redirect("/Pages/AllExercises.aspx?folder=" + folderName + "&id=" + folderIdByName);
                    }
                }
            }

        }
    }
}