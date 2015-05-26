﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice
{
    public partial class AssignedExercises : System.Web.UI.Page
    {
        public List<AssignedExercise> allAssignedExercises;
        public string therapistId;
        public string patientId;
        public int exerciseId;
        public Bl_Therapist bl_therapist;
        public Bl_Patient bl_patient;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
                therapistId = Session["therapist_licenseId"].ToString();
                bl_therapist = new Bl_Therapist();
                bl_patient = new Bl_Patient();


                if (Request.QueryString["patientId"] != null && Request.QueryString["exerciseId"] != null)           // if its redirected from patient account
                {
                    patientId = Request.QueryString["patientId"];
                    exerciseId = Convert.ToInt16(Request.QueryString["exerciseId"]);

                    if(bl_patient.addAssignedExercise(patientId, exerciseId, therapistId))
                    {
                        allAssignedExercises = bl_patient.getAllAssignedExercisesByPatientId(patientId, therapistId);
                    }
                }
            }
        }
    }
}