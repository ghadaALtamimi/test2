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

                DropDownList ddl = DropDownPatients;
                ddl.CssClass = "form-control";

                List<string> patients = new List<string>();

                // patients.Add("בחר מטופל...");
                int ddlIndex = 0;

                foreach (Patient p in allPatient)
                {
                    ListItem lst = new ListItem(p.FirstName + " " + p.LastName, p.PatientId);       // create new list item with patient name as text, and patient id as value
                    if (!ddl.Items.Contains(lst))           // avoiding duplicate
                    {
                        ddl.Items.Insert(ddlIndex, lst);        // insert in dropdown the patient
                        ddlIndex++;
                    }
                }
                ddl.Items.Insert(ddlIndex, new ListItem("בחר מטופל...", "0"));      // insert placeholder
                ddl.Items.FindByValue("0").Selected = true;         // focus on placeholder

                if (Request.QueryString["patientId"] != null)           // if it is a reply
                {
                    ddl.Items.FindByValue("0").Selected = false;
                    ddl.Items.FindByValue(Request.QueryString["patientId"]).Selected = true; 
                    ddl.Enabled = false;
                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
         
        }

        protected void OnSendMessageButton_Click(object sender, EventArgs e)
        {
            DropDownList ddl = DropDownPatients;
            ddl.Items.FindByValue("0").Selected = false;
          
            ListItem lst = ddl.SelectedItem;
            System.Diagnostics.Debug.WriteLine(lst.Text + " " + lst.Value);
            Patient patient = null;
            Label3.ForeColor = Color.Green;
            
            
            if (lst.Value == "0") // if "בחר מטופל.." is chosen
            {
                TitleExerciseLabelError.Visible = true;
            }
            else
            {
                patient = bl_patient.getPatientDetails(lst.Value);          // get patient details of selected patient
            }

            if (!MessageTextBox.Text.Equals("") )       // is message text is not empty
            {
                if (patient != null)
                {
                    Message message = new Message(therapistId, patient.PatientId, MessageTextBox.Text, DateTime.Now, false);
                    if (bl_therapist.sendMessage(message))
                    {
                        MessageTextBox.Text = "";
                        Label3.Visible = true;
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
            } 
        }
    }
}