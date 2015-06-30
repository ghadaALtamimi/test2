using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice
{
    public partial class NewMessage : System.Web.UI.Page
    {
        public Bl_Therapist bl_therapist;
        public Bl_Patient bl_patient;
        private string therapistId;
        public List<Patient> allPatient;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
                therapistId = Session["therapist_licenseId"].ToString();        // get therapist id
                bl_therapist = new Bl_Therapist();
                bl_patient = new Bl_Patient();

                allPatient = bl_patient.getAllPatientsByLicenseId(therapistId);
                Label1.Visible = false;
                TitleExerciseLabelError.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;

               // DropDownList ddl = DropDownPatients;
                List<string> patients = new List<string>();
                patients.Add("בחר מטופל...");
                foreach(Patient p in allPatient)
                {
                    patients.Add(p.FirstName + " " + p.LastName);
                }
                DropDownPatients.DataSource = patients;
                DropDownPatients.DataBind();
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
         
        }

        protected void OnSendMessageButton_Click(object sender, EventArgs e)
        {
            DropDownList ddl = DropDownPatients;
            int patientIndex = ddl.SelectedIndex;
            System.Diagnostics.Debug.WriteLine(patientIndex);
            Patient patient = null;
            Label3.ForeColor = Color.Green;
            Label3.Visible = true;
           /* if (patientIndex == 0)
            {
                TitleExerciseLabelError.Visible = true;
            }
            else
            {
                patient = allPatient.ElementAt(patientIndex);
            }

            if (!MessageTextBox.Text.Equals("") )
            {
                if (patient != null)
                {
                    if (bl_therapist.sendMessage(therapistId, patient.PatientId, MessageTextBox.Text))
                    {
                        Response.Redirect("/Pages/Messages.aspx");
                    }
                }
                else
                {
                    Label2.Visible = true;
                }
            }   
            else
            {
                Label1.Visible = true;
            } */
        }
    }
}