using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice
{
    public partial class Messages : System.Web.UI.Page
    {
        public Bl_Patient bl_patient;
        public Bl_Therapist bl_therapist;
        public string therapistId;
        public List<Message> messages;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_licenseId"] != null)
            {
                therapistId = Session["therapist_licenseId"].ToString();        // get therapist id
                bl_therapist = new Bl_Therapist();
                bl_patient = new Bl_Patient();

                messages = bl_therapist.getAllMessages(therapistId);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }

        protected void OnNewMessageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/NewMessage.aspx");
        }
    }
}