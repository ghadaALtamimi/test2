using System;
using System.Collections.Generic;
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
            int patientIndex = DropDownPatients.SelectedIndex;
            Patient patient = allPatient.ElementAt(patientIndex);

            bl_therapist.n
        }
    }
}