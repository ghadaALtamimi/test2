using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppVoice.Pages
{
    public partial class AllFolders : System.Web.UI.Page
    {
        Bl_Therapist bl_therapist;
        public List<Folder> allFolders;
        public int numAllFolders;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["therapist_name"] != null && Session["therapist_licenseId"] != null)
            {
                bl_therapist = new Bl_Therapist();
                allFolders = bl_therapist.getAllFolders(Session["therapist_licenseId"].ToString());
                numAllFolders = allFolders.Count();

                NewFolderPanel.Visible = false;

                if (Request.QueryString["deletedId"] != null)         // create new exercise from specific folder
                {
                    if(deleteFolder(Request.QueryString["deletedId"]))
                    {
                        Response.Redirect("/Pages/AllFolders.aspx");
                    }
                    else
                    {
                        Response.Redirect("/Default.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

        }

        protected void OnAddFolder_Click(object sender, EventArgs e)
        {
            NewFolderPanel.Visible = true;
        }
        
        protected void OnNewFolder_Click(object sender, EventArgs e)
        {
           Folder folder = new Folder(NewFolderTextBox.Text, "", Session["therapist_licenseId"].ToString());
            if(bl_therapist.addFolder(folder))
            {
                Page_Load(sender, e);
            }
        }

        protected void OnCancel_Click(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }

        protected void YesPopupButton_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)         // create new exercise from specific folder
            {
                string folderId = Request.QueryString["id"];
                Console.WriteLine(folderId);
                Debug.WriteLine(folderId);
                Page_Load(sender, e);
            }
        }

        private bool deleteFolder(string folderId)
        {
            return bl_therapist.deleteFolder(folderId);
        }
    }
}