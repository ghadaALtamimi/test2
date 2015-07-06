using System;
using System.Collections.Generic;
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
                

                if (Request.QueryString["patientId"] != null)           // if its redirected from patient account
                {
                    PanelFromPatient.Visible = true;
                    PanelFromExercise.Visible = false;

                    patientId = Request.QueryString["patientId"];
                    allExercises = bl_therapist.getAllExercises(therapistId);

                    foreach (Exercise ex in allExercises)
                    {
                        string folderName = bl_therapist.getFolderNameByFolderId(ex.FolderId, therapistId);
                        string exerciseName = ex.Title;
                        CheckBoxList.Items.Add(new ListItem(exerciseName, "Ex"+ex.Id));
                    }

                }
                else if (Request.QueryString["exerciseId"] != null)      // if its redirected from exercise account
                {
                    PanelFromPatient.Visible = false;
                    PanelFromExercise.Visible = true;

                  //  ListView listViewPatient = ListViewPatient;
                    CheckBoxList checkBoxList = CheckBoxList1;
                    List<Patient> allPatients = bl_patient.getAllPatientsByLicenseId(therapistId);
                    List<string> patients = new List<string>();
                    //patients.Add("בחר מטופל...");
                    foreach (Patient p in allPatients)
                    {
                        ListItem li1 = new ListItem("\t" + p.FirstName + " " + p.LastName + "\t", "data", true);
                        li1.Selected = false;
                        checkBoxList.Items.Add(li1);
                        //patients.Add(p.FirstName + " " + p.LastName);
                    }

                   
                  //  listViewPatient.DataSource = patients;
                //    listViewPatient.DataBind();
                    
                }

            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }

    

        protected void OnAddAllExercises_Click(object sender, EventArgs e)
        {

        }
    }
}