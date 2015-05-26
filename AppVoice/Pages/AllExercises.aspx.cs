using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice
{
    public partial class Exercises : System.Web.UI.Page
    {
        public string folderName, folderId, therapistId;
        //public int folderId;
        public List<Exercise> allExercises;
        public Folder folder;
        public Bl_Therapist bl_therapist = new Bl_Therapist();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
                therapistId = Session["therapist_licenseId"].ToString();
                //bl_therapist = new Bl_Therapist();

                if (Request.QueryString["folder"] != null && Request.QueryString["id"] != null)
                {
                    folderName = Request.QueryString["folder"];
                    folderId = Request.QueryString["id"];
                    folder = bl_therapist.getFolderDetails(Convert.ToInt16(folderId));
                    TitlePanel.Visible = true;
                    SaveDescriptionButton.Visible = false;
                    FolderNameLabel.Text = folder.Name;
                    if(folder.Description.Equals(""))
                    {
                        AddDescriptionButton.Visible = true;
                        EditDescriptionButton.Visible = false;

                        DescriptionTextBox.Visible = false;
                        DescriptionLabel.Visible = false;
                    }
                    else
                    {
                        AddDescriptionButton.Visible = false;
                        EditDescriptionButton.Visible = true;

                        DescriptionTextBox.Visible = false;
                        DescriptionLabel.Visible = true;

                        DescriptionLabel.Text = folder.Description;
                    }

                    allExercises = bl_therapist.getAllExercisesByFolderId(therapistId, Convert.ToInt32(folderId));
                }
                else
                {
                    TitlePanel.Visible = false;
                    allExercises = bl_therapist.getAllExercises(therapistId);
                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            
        }

        protected void OnAddExercise_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["folder"] != null && Request.QueryString["id"] != null)
            {
                Response.Redirect("/Pages/NewExercise.aspx?folder=" + folderName + "&id=" + folderId);
            }
            else
            {
                Response.Redirect("/Pages/NewExercise.aspx");
            }
        }
        protected void OnAddFolderDescription_Click(object sender, EventArgs e)
        {
            DescriptionTextBox.Visible = true;

            EditDescriptionButton.Visible = false;
            AddDescriptionButton.Visible = false;
            SaveDescriptionButton.Visible = true;
        }
        protected void OnEditFolderDescription_Click(object sender, EventArgs e)
        {
            DescriptionTextBox.Visible = true;
            DescriptionTextBox.Text = folder.Description;

            EditDescriptionButton.Visible = false;
            AddDescriptionButton.Visible = false;
            SaveDescriptionButton.Visible = true;
            DescriptionLabel.Visible = false;

        }
        protected void OnSaveFolderDescription_Click(object sender, EventArgs e)
        {
            if(bl_therapist.updateDescriptionFolder(folder, DescriptionTextBox.Text))
            {
                Page_Load(sender, e);
            }
        }
    }
}