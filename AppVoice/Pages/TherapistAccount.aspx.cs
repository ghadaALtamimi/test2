using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice.Pages
{
    public partial class TherapistAccount : System.Web.UI.Page
    {
        Bl_Therapist bl_therapist;
        SpeechTherapist therapist;
        string licenseId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
                bl_therapist = new Bl_Therapist();
                licenseId = Session["therapist_licenseId"].ToString();
                therapist = bl_therapist.getTherapistDetails(licenseId);
                AccountName.Text =  therapist.FirstName + " " + therapist.LastName;

                // Set label fields
                setLabelField(therapist);

                // Make buttons not visibles
                EditButton.Visible = true;
                SaveDetailsButton.Visible = false;
                SavePasswordButton.Visible = false;
                DeleteButton.Visible = false;
                PasswordButton.Visible = true;
                CancelButton.Visible = false;

                // Make label visible
                FirstNameLabel.Visible = true;
                LastNameLabel.Visible = true;
                MailLabel.Visible = true;

                // Make textbox not visible
                FirstNameTextBox.Visible = false;
                LastNameTexBox.Visible = false;
                MailTextBox.Visible = false;
                PasswordTextBox0.Visible = false;
                PasswordTextBox1.Visible = false;
                PasswordTextBox2.Visible = false;

                // Make Panel Error not visible
                FirstNamePanelError.Visible = false;
                LastNamePanelError.Visible = false;
                PasswordPanelError.Visible = false;
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
            SavePasswordButton.Visible = false;
            PasswordButton.Visible = false;
            DeleteButton.Visible = true;
            CancelButton.Visible = true;

            // Make label not visible
            FirstNameLabel.Visible = false;
            LastNameLabel.Visible = false;
            MailLabel.Visible = false;

            // Make textbox visible
            FirstNameTextBox.Visible = true;
            LastNameTexBox.Visible = true;
            MailTextBox.Visible = true;
            PasswordTextBox0.Visible = false;
            PasswordTextBox1.Visible = false;
            PasswordTextBox2.Visible = false;

            // Fill textbox with therapist details
            FirstNameTextBox.Text = therapist.FirstName;
            LastNameTexBox.Text = therapist.LastName;
            MailTextBox.Text = therapist.Mail;

            
        }

        protected void OnSaveDetails_Click(object sender, EventArgs e)
        {
            SpeechTherapist speechTherapist = new SpeechTherapist(therapist.LicenseId, FirstNameTextBox.Text, LastNameTexBox.Text, MailTextBox.Text);
            
            if (bl_therapist.updateTherapistDetails(licenseId, speechTherapist)) // update details success
            {
                UpdatePanelSuccess.Visible = true;
                UpdatePanelFailure.Visible = false;
                DetailsUpdateSuccess.Visible = true;
                DetailsUpdateFailure.Visible = false;
                
            }
            else        // update details failure
            {
                UpdatePanelFailure.Visible = true;
                UpdatePanelSuccess.Visible = false;
                DetailsUpdateFailure.Visible = true;
                DetailsUpdateSuccess.Visible = false;
            }

            // set label fields
            setLabelField(bl_therapist.getTherapistDetails(speechTherapist.LicenseId));

            // Make buttons visibles
            EditButton.Visible = true;
            SaveDetailsButton.Visible = false;
            SavePasswordButton.Visible = false;
            PasswordButton.Visible = true;
            DeleteButton.Visible = false;
            CancelButton.Visible = false;


            // Make label visible
            FirstNameLabel.Visible = true;
            LastNameLabel.Visible = true;
            MailLabel.Visible = true;

            // Make textbox visible
            FirstNameTextBox.Visible = false;
            LastNameTexBox.Visible = false;
            MailTextBox.Visible = false;
            PasswordTextBox0.Visible = false;
            PasswordTextBox1.Visible = false;
            PasswordTextBox2.Visible = false;

            //Make Password error Panel not visible
            PasswordUpdateSuccess.Visible = false;
            PasswordUpdateFailure.Visible = false;
            
        }

        protected void OnSavePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = PasswordTextBox0.Text;
            string newPassword1 = PasswordTextBox1.Text;
            string newPassword2 = PasswordTextBox2.Text;
            if(oldPassword.Equals("") || newPassword1.Equals("") || newPassword2.Equals(""))          // if textbox is empty
            {
                PasswordPanelError.Visible = true;
                PasswordLabelError.Text = "יש למלא את כל השדות!";
            }
            else if (bl_therapist.isPasswordOkay(licenseId, oldPassword))       // if password matches with actual password
            {

                if (newPassword1.Equals(newPassword2))          // if passwords match
                {
                    if (bl_therapist.updateTherapistPassword(licenseId, newPassword1)) // update password success
                    {
                        UpdatePanelSuccess.Visible = true;
                        UpdatePanelFailure.Visible = false;
                        PasswordUpdateSuccess.Visible = true;
                        PasswordUpdateFailure.Visible = false;
                    }
                    else        // update password failure
                    {
                        UpdatePanelFailure.Visible = true;
                        UpdatePanelSuccess.Visible = false;
                        PasswordUpdateFailure.Visible = true;
                        PasswordUpdateSuccess.Visible = false;
                    }

                    // Make buttons visibles
                    EditButton.Visible = true;
                    SaveDetailsButton.Visible = false;
                    SavePasswordButton.Visible = false;
                    PasswordButton.Visible = true;
                    DeleteButton.Visible = false;
                    CancelButton.Visible = false;

                    // Make label visible
                    FirstNameLabel.Visible = true;
                    LastNameLabel.Visible = true;
                    MailLabel.Visible = true;

                    // Make textbox visible
                    FirstNameTextBox.Visible = false;
                    LastNameTexBox.Visible = false;
                    MailTextBox.Visible = false;
                    PasswordTextBox0.Visible = false;
                    PasswordTextBox1.Visible = false;
                    PasswordTextBox2.Visible = false;

                    //Make Details error Panel not visible
                    DetailsUpdateSuccess.Visible = false;
                    DetailsUpdateFailure.Visible = false;
                }
                else             // if passwords don't match
                {
                    PasswordPanelError.Visible = true;
                    PasswordLabelError.Text = "הסיסמאות צריכות להיות זהות!";
                }
            }
            else
            {
                PasswordPanelError.Visible = true;
                PasswordLabelError.Text = "הסיסמה לא מתאימה לסיסמה הנוכחית!";
            }
           
        }
        
        
        protected void OnPassword_Click(object sender, EventArgs e)
        {

            // Make buttons visibles
            SaveDetailsButton.Visible = false;
            SavePasswordButton.Visible = true;
            PasswordButton.Visible = false;
            EditButton.Visible = false;
            DeleteButton.Visible = false;
            CancelButton.Visible = true;

            // Make textbox visible
            PasswordTextBox0.Visible = true;
            PasswordTextBox1.Visible = true;
            PasswordTextBox2.Visible = true;

        }

        protected void OnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void OnDelete_Click(object sender, EventArgs e)
        {

        }

        private void setLabelField(SpeechTherapist therapist)
        {
            LicenseIdLabel.Text = therapist.LicenseId.ToString();
            FirstNameLabel.Text = therapist.FirstName;
            LastNameLabel.Text = therapist.LastName;
            MailLabel.Text = therapist.Mail;
        }
    

    }
}