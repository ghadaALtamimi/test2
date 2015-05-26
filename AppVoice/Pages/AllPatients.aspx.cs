using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice.Pages
{
    public partial class AllPatients : System.Web.UI.Page
    {
        Bl_Therapist bl_therapist;
        Bl_Patient bl_patient;
        public List<Patient> allPatients;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
                bl_therapist = new Bl_Therapist();
                bl_patient = new Bl_Patient();

                allPatients = bl_patient.getAllPatientsByLicenseId(Session["therapist_licenseId"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

        }
        protected void ButtonShow_Click(object sender, EventArgs e)
        {
            //Response.Redirect("/Pages/PatientAccount.aspx?patient=" + PatientIdTextBox.Text);
            
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonExercise_Click(object sender, EventArgs e)
        {

        }
    }
}