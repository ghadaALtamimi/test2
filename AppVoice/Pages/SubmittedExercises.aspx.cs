using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice.Pages
{
    public partial class SubmittedExercises : System.Web.UI.Page
    {
        public Bl_Therapist bl_therapist;
        public Bl_Patient bl_patient;
        private string therapistId;
        public List<SubmittedExercise> submittedExercises;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
                therapistId = Session["therapist_licenseId"].ToString();        // get therapist id
                bl_therapist = new Bl_Therapist();
                bl_patient = new Bl_Patient();
                if(Request.QueryString["deletedId"] != null && Request.QueryString["patientId"] != null &&  Request.QueryString["exerciseId"] != null)
                {
                   if(bl_therapist.deleteSubmittedExercise(Request.QueryString["deletedId"], Request.QueryString["patientId"], Request.QueryString["exerciseId"]))
                   {
                       Response.Redirect("/Pages/SubmittedExercises.aspx");
                   }
                }
                submittedExercises = bl_therapist.getSubmittedExercises(therapistId);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }
    }
}