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

                if (Request.QueryString["seenId"] != null)
                {
                    string messageId = Request.QueryString["seenId"];
                    if(bl_therapist.updateIsReadMessage(messageId))
                    {
                        Response.Redirect("/Pages/Messages.aspx");
                    }
                }
                messages = bl_therapist.getAllMessages(therapistId);
                //if((Request.QueryString["deleteId"] != null)
                foreach (Message m in messages)
                {
                    Patient patient = bl_patient.getPatientDetails(m.MessageFrom);
                   // checkBoxList.Items.Add(new ListItem("", ex.Id + ""));


                    TableRow tRow = new TableRow();     // adding row
                    TableCell cell2 = new TableCell();      // exercise title cell
                    TableCell cell3 = new TableCell();      // folder name cell
                    TableCell cell4 = new TableCell();      // date cell
                    TableCell cell5 = new TableCell();      // buttons

                    //Button button = new Button();
                    List<LinkButton> buttonList = new List<LinkButton>();
                    LinkButton replyButton = new LinkButton();
                    LinkButton seenButton = new LinkButton();

                    replyButton.Text = "הגב";
                    replyButton.CssClass = "btn btn-success left-buffer";
                    replyButton.PostBackUrl = "/Pages/NewMessage.aspx?patientId=" + patient.PatientId;

                    seenButton.Text = "קראתי";
                    seenButton.CssClass = "btn btn-warning";
                    seenButton.PostBackUrl = "/Pages/Messages.aspx?seenId=" + m.MessageId;
                    
                    if (!buttonList.Contains(replyButton))
                    {
                        buttonList.Add(replyButton);
                    }
                   
                    cell2.Text = patient.FirstName + " " + patient.LastName;
                    cell3.Text = m.MessageText;
                    cell4.Text = m.MessageDate.Date + "";
                    cell5.Controls.Add(replyButton);

                    if (!m.IsRead)
                    {
                        cell2.CssClass = "bold";
                        cell3.CssClass = "bold";
                        cell4.CssClass = "bold";
                        cell5.Controls.Add(seenButton);
                    }

                    tRow.Cells.Add(cell2);
                    tRow.Cells.Add(cell3);
                    tRow.Cells.Add(cell4);
                    tRow.Cells.Add(cell5);

                    Table.Rows.Add(tRow);
                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }

        protected void OnNewMessageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/NewMessage.aspx");
        }
    
      
    }
}