using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice.Pages
{
    public partial class NewPatient : System.Web.UI.Page
    {
        Bl_Patient bl_patient;
        Patient patient;
        string therapistId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
                bl_patient = new Bl_Patient();

                therapistId = Session["therapist_licenseId"].ToString();

                // Make error label not visible
                PatientIdLabelError.Visible = false;
                PatientIdLabelErrorExist.Visible = false;
                FirstNameLabelError.Visible = false;
                LastNameLabelError.Visible = false;
                MailLabelError.Visible = false;
                PhoneNumberLabelError.Visible = false;
                AddressLabelError.Visible = false;
                HmoLabelError.Visible = false;
                PasswordLabelError.Visible = false;
                RePasswordLabelError.Visible = false;
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }
        protected void OnSaveButton_Click(object sender, EventArgs e)
        {
            if(!isMissingField())       // if all fields are filled
            {
                string password1 = PasswordTextBox.Text;
                string password2 = RePasswordTextBox.Text;
                if(password1.Equals(password2))
                {
                    patient = new Patient(PatientIdTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text, MailTextBox.Text, PhoneNumberTextBox.Text, AddressTextBox.Text, HmoTextBox.Text, PasswordTextBox.Text, therapistId);
                    if (bl_patient.isPatientExists(patient))
                    {
                        PatientIdLabelErrorExist.Visible = true;
                    }
                    else if (bl_patient.addPatient(patient))
                    {
                        Response.Redirect("/Pages/PatientAccount.aspx?patient=" + PatientIdTextBox.Text);
                    }

                }
            }
        }

        private bool isMissingField()
        {
            bool isMissing = false;

            if(PatientIdTextBox.Text.Equals(""))         // patient id is missing
            {
                isMissing = true;
                PatientIdLabelError.Visible = true;
            }
            if (FirstNameTextBox.Text.Equals(""))        // firstName is missing
            {
                isMissing = true;
                FirstNameLabelError.Visible = true;
            }
            if (LastNameTextBox.Text.Equals(""))        // lastName is missing
            {
                isMissing = true;
                LastNameLabelError.Visible = true;
            }
            if (MailTextBox.Text.Equals(""))        // mail is missing
            {
                isMissing = true;
                MailLabelError.Visible = true;
            }
            if (PhoneNumberTextBox.Text.Equals(""))        // phone number is missing
            {
                isMissing = true;
                PhoneNumberLabelError.Visible = true;
            }
            if (AddressTextBox.Text.Equals(""))        // address is missing
            {
                isMissing = true;
                PatientIdLabelError.Visible = true;
            }
            if (HmoTextBox.Text.Equals(""))        // hmo is missing
            {
                isMissing = true;
                HmoLabelError.Visible = true;
            }
            if (PasswordTextBox.Text.Equals(""))        // password is missing
            {
                isMissing = true;
                PatientIdLabelError.Visible = true;
            }
            if (RePasswordTextBox.Text.Equals(""))        // re-password is missing
            {
                isMissing = true;
                RePasswordLabelError.Visible = true;
            }
            return isMissing;

        }
    }
}