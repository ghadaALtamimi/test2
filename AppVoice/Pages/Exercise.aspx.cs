using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

                string aspNetFilePath = FileUploadUrl.PostedFile.FileName;

                string filePath = FileUploadUrl.FileName;

                string fileName = Path.Combine(Server.MapPath("."), filePath);
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