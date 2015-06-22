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
            string exerciseTitle, exerciseDescription;

            if (TitleExerciseTextBox.Text.Equals(""))           // if title textbox is empty, do not add the exercise and return error messageText
            {
                TitleExerciseLabelError.Visible = true;
            }
            else
            {
                exerciseTitle = TitleExerciseTextBox.Text;      // save data from textboxes in order to add exercise
                exerciseDescription = DescriptionTextBox.Text;

                if (folderId != null)       // if we add the exercise from a specific folder
                {
                    Exercise exercise = new Exercise(exerciseTitle, exerciseDescription, Convert.ToInt16(folderId), therapistId);
                    if (bl_therapist.addExercise(exercise))
                    {
                        Response.Redirect("/Pages/AllExercises.aspx?folder=" + folderName + "&id=" + folderId);
                    }
                    
                }
                else
                {       // if we add an exercise and we also choose the folder from this exercise
                    string folderName = DropDownListFolder.Text;
                    int folderIdByName = bl_therapist.getFolderIdByFolderName(folderName, therapistId);
                    Exercise exercise = new Exercise(exerciseTitle, exerciseDescription, Convert.ToInt16(folderIdByName), therapistId);
                    if (bl_therapist.addExercise(exercise))
                    {
                        Response.Redirect("/Pages/AllExercises.aspx?folder=" + folderName + "&id=" + folderIdByName);
                    }
                }
            }

        }
    }
}