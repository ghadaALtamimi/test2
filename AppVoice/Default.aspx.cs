using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice
{
    public partial class Default : System.Web.UI.Page
    {
        Bl_Therapist bl_therapist;

        protected void Page_Load(object sender, EventArgs e)
        {
            bl_therapist = new Bl_Therapist();
            Dal_Therapist dal_therapist = new Dal_Therapist();
            //Label1.Text = dal_therapist.showTherapistDetails();
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {

            
            if (IdTextBox.Text.Equals(""))
            {
                IdLabelError.Text = "נא הזן מספר רשיון";
                IdPanelError.Visible = true;
            }
            else
            {
                IdPanelError.Visible = false;
            }
            if (PwdTextBox.Text.Equals(""))
            {
                PwdLabelError.Text = "נא הזן סיסמה";
                PwdPanelError.Visible = true;
            }
            else
            {
                PwdPanelError.Visible = false;
            }
            if (!IdTextBox.Text.Equals("") && !PwdTextBox.Text.Equals(""))
            {
                IdPanelError.Visible = false;
                PwdPanelError.Visible = false;
                string licenseId = IdTextBox.Text;
                string password = PwdTextBox.Text;
                SpeechTherapist therapist = bl_therapist.therapistLogin(licenseId, password);
                if (therapist != null)
                {
                    Session.Add("therapist_licenseId", therapist.LicenseId);
                    Session.Add("therapist_name", therapist.FirstName);
                    Response.Redirect("Pages/AllFolders.aspx");
                }
                else
                {
                    PwdLabelError.Text = "מספר רשיון או סיסמה שגוי/ה";
                    PwdPanelError.Visible = true;
                    IdPanelError.Visible = false;
                }
            }

        }

        protected void NewUser_Click(object sender, EventArgs e)
        {

        }


    }
}