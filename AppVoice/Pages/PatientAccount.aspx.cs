using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice
{
    public partial class AddedPatient : System.Web.UI.Page
    {
        Bl_Patient bl_patient;

        Patient patient;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
                bl_patient = new Bl_Patient();
                string patientId = Request.QueryString["patient"];
                patient = bl_patient.getPatientDetails(patientId);

                setLabelFields(patient);             // Fill all fields with patient details

                // Make Error Label not visible
                FirstNameLabelError.Visible = false;
                LastNameLabelError.Visible = false;
                MailLabelError.Visible = false;
                PhoneLabelError.Visible = false;
                AddressErrorlabel.Visible = false;
                HmoErrorLabel.Visible = false;

                // Make buttons not visible
                EditButton.Visible = true;
                SaveDetailsButton.Visible = false;
                DeleteButton.Visible = false;
                CancelButton.Visible = false;

                // Make textbox not visible
                FirstNameTextBox.Visible = false;
                LastNameTexBox.Visible = false;
                MailTextBox.Visible = false;
                PhoneNumberTextBox.Visible = false;
                AddressTextBox.Visible = false;
                HmoTextBox.Visible = false;

                // Panel update success not visible
                UpdatePanelSuccess.Visible = false;
                UpdatePanelFailure.Visible = false;

            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }

        protected void OnEdit_Click(object sender, EventArgs e)
        {
            // Make buttons visibles
            EditButton.Visible = false;
            SaveDetailsButton.Visible = true;
            DeleteButton.Visible = true;
            CancelButton.Visible = true;

            // Make label not visible
            FirstNameLabel.Visible = false;
            LastNameLabel.Visible = false;
            MailLabel.Visible = false;
            PhoneNumberLabel.Visible = false;
            AddressLabel.Visible = false;
            HmoLabel.Visible = false;


            // Make textbox visible
            FirstNameTextBox.Visible = true;
            LastNameTexBox.Visible = true;
            MailTextBox.Visible = true;
            PhoneNumberTextBox.Visible = true;
            AddressTextBox.Visible = true;
            HmoTextBox.Visible = true;

            // Fill textbox with therapist details
            FirstNameTextBox.Text = patient.FirstName;
            LastNameTexBox.Text = patient.LastName;
            MailTextBox.Text = patient.Mail;
            PhoneNumberTextBox.Text = patient.PhoneNumber;
            AddressTextBox.Text = patient.Address;
            HmoTextBox.Text = patient.Hmo;

            // Panel update success not visible
            UpdatePanelSuccess.Visible = false;
            UpdatePanelFailure.Visible = false;
        }

        protected void OnSaveDetails_Click(object sender, EventArgs e)
        {
            Patient newPatient = new Patient(patient.PatientId, FirstNameTextBox.Text, LastNameTexBox.Text, MailTextBox.Text, PhoneNumberTextBox.Text, AddressTextBox.Text, HmoTextBox.Text, patient.Password, patient.TherapistId);

            if (bl_patient.updatePatientDetails(patient.PatientId, newPatient)) // update details success
            {
                UpdatePanelSuccess.Visible = true;
                UpdatePanelFailure.Visible = false;

            }
            else        // update details failure
            {
                UpdatePanelFailure.Visible = true;
                UpdatePanelSuccess.Visible = false;
            }

            // set label fields
            setLabelFields(newPatient);

            // Make buttons visibles
            EditButton.Visible = true;
            SaveDetailsButton.Visible = false;
            DeleteButton.Visible = false;
            CancelButton.Visible = false;


            // Make label visible
            FirstNameLabel.Visible = true;
            LastNameLabel.Visible = true;
            MailLabel.Visible = true;
            PhoneNumberLabel.Visible = true;
            AddressLabel.Visible = true;
            HmoLabel.Visible = true;

            // Make textbox not visible
            FirstNameTextBox.Visible = false;
            LastNameTexBox.Visible = false;
            MailTextBox.Visible = false;
            PhoneNumberTextBox.Visible = false;
            AddressTextBox.Visible = false;
            HmoTextBox.Visible = false;

        }

        private void setLabelFields(Patient patient)
        {
            // Fill all fields with patient details
            FirstNameLabel.Text = patient.FirstName;
            LastNameLabel.Text = patient.LastName;
            PatientIdLabel.Text = patient.PatientId;
            MailLabel.Text = patient.Mail;
            PhoneNumberLabel.Text = patient.PhoneNumber;
            AddressLabel.Text = patient.Address;
            HmoLabel.Text = patient.Hmo;
        }

        protected void OnCancel_Click(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }

        protected void OnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}