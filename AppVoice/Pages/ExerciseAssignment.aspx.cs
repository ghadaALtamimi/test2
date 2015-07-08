using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice
{
    public partial class ExerciseAssignment : System.Web.UI.Page
    {
        public List<Exercise> allExercises;
        public string therapistId;
        public string patientId;
        public Bl_Therapist bl_therapist;
        public Bl_Patient bl_patient;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
                therapistId = Session["therapist_licenseId"].ToString();
                bl_therapist = new Bl_Therapist();
                bl_patient = new Bl_Patient();

                LabelError.Visible = false;

                if (Request.QueryString["patientId"] != null)           // if its redirected from patient account
                {
                    PanelFromPatient.Visible = true;
                    PanelFromExercise.Visible = false;

                    patientId = Request.QueryString["patientId"];
                    allExercises = bl_therapist.getAllExercises(therapistId);
                    CheckBoxList checkBoxList = CheckBoxList2;

                    foreach (Exercise ex in allExercises)
                    {
                        string folderName = bl_therapist.getFolderNameByFolderId(ex.FolderId, therapistId);
                        string exerciseName = ex.Title;
                        checkBoxList.Items.Add(new ListItem("", ex.Id + ""));


                        TableRow tRow = new TableRow();     // adding row
                        TableCell cell1 = new TableCell();      // checkbox cell
                        TableCell cell2 = new TableCell();      // exercise title cell
                        TableCell cell3 = new TableCell();      // folder name cell
                        TableCell cell4 = new TableCell();      // buttons

                        Button button = new Button();
                        button.Text = "הצג";
                        button.CssClass = "btn btn-primary";
                        CheckBox checkbox = new CheckBox();

                        cell1.Controls.Add(checkbox);
                        cell2.Text = exerciseName;
                        cell3.Text = folderName;
                        cell4.Controls.Add(button);


                        tRow.Cells.Add(cell1);
                        tRow.Cells.Add(cell2);
                        tRow.Cells.Add(cell3);
                        tRow.Cells.Add(cell4);


                        table.Rows.Add(tRow);
                    }


                }

                else if (Request.QueryString["exerciseId"] != null)      // if its redirected from exercise account
                {
                    PanelFromPatient.Visible = false;
                    PanelFromExercise.Visible = true;
                    table.Visible = false;

                    Exercise exercise = bl_therapist.getExerciseDetails(Convert.ToInt16(Request.QueryString["exerciseId"]));        // get exercise details
                    if (exercise != null)
                    {
                        string folderName = bl_therapist.getFolderNameByFolderId(exercise.FolderId, exercise.TherapistId);
                        ExerciseNameLabel.Text = folderName + " >> " + exercise.Title;
                    }

                    CheckBoxList checkBoxList = CheckBoxList1;
                    List<Patient> allPatients = bl_patient.getAllPatientsByLicenseId(therapistId);
                    List<string> patients = new List<string>();
                    List<AssignedExercise> assignedExercises = bl_therapist.getAllAssignedExercisesByExerciseId(exercise.Id);

                    foreach (Patient p in allPatients)
                    {
                        bool isAssigned = false;
                        ListItem li1;
                        foreach (AssignedExercise ass in assignedExercises)      // run on assigned exercise to check if the exercise is already assigned to specific patient
                        {
                            if (ass.PatientId.Equals(p.PatientId))
                            {
                                isAssigned = true;
                            }

                        }
                        if (isAssigned)         // if exercise is already assigned
                        {
                            li1 = new ListItem(p.FirstName + " " + p.LastName, p.PatientId, false);          // make checkbox true and not clickable
                            li1.Selected = true;
                        }
                        else            // if exercise is not assigned
                        {
                            li1 = new ListItem("   " + p.FirstName + " " + p.LastName + "   ", p.PatientId, true);       // make checkbox false and  clickable
                            li1.Selected = false;
                        }
                        checkBoxList.Items.Add(li1);




                    }

                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }


        }

        protected void OnAddAllExercises_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["exerciseId"] != null)
            {
                Exercise exercise = bl_therapist.getExerciseDetails(Convert.ToInt16(Request.QueryString["exerciseId"]));
                CheckBoxList checkBoxList = CheckBoxList1;
                bool isError = false;
                foreach (ListItem item in checkBoxList.Items)
                {
                    if (item.Selected && item.Enabled)
                    {
                        string folderName = bl_therapist.getFolderNameByFolderId(exercise.FolderId, exercise.TherapistId);
                        AssignedExercise ass = new AssignedExercise(exercise.Id, exercise.FolderId, folderName, item.Value, exercise.TherapistId);
                        if (!bl_therapist.addAssignmentExercise(ass))
                        {
                            isError = true;
                        }

                    }
                }
                if (!isError)
                {
                    Response.Redirect("/Pages/AssignedExercises.aspx");
                }
            }
            else if (Request.QueryString["patientId"] != null)
            {
                string patientId = Request.QueryString["patientId"];
                List<Exercise> selectedExercises = new List<Exercise>();
                bool isError = false;
                int rowIndex = -2;      // start index -2 because  the first row is the header, and we do index++ right when we are in the loop
                foreach (TableRow row in table.Rows)
                {
                    rowIndex++;
                    var cell = row.Cells[0];
                    var cell1 = row.Cells[1];
                    foreach (Control control in cell.Controls)
                    {
                        var checkBox = control as CheckBox;
                        if (checkBox != null)
                        {
                            if (checkBox.Checked)
                            {
                                if (allExercises.Count > 0)
                                {
                                    //selectedExercises.Add(allExercises.ElementAt(rowIndex));
                                    Exercise ex = allExercises.ElementAt(rowIndex);     // get exercise details at checkbox checked
                                    if(ex != null)
                                    {
                                        AssignedExercise ass = new AssignedExercise(ex.Id, ex.FolderId, row.Cells[2].Text, patientId, therapistId);
                                        if(!bl_therapist.addAssignmentExercise(ass))
                                        {
                                            isError = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                }

                if(isError)
                {
                    LabelError.Visible = true;
                }
                else
                {
                    Response.Redirect("/Pages/AssignedExercises.aspx");
                }
            }
           
        }

        protected void OnCheckedChanged(object sender, EventArgs e)
        {
            List<Exercise> selectedExercises = new List<Exercise>();
            //    if (checkBox.Checked)
            {
                // string name = checkBox.InputAttributes.;
            }
        }
    }

}