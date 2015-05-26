using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class SpeechTherapist
    {

        private string licenseId, firstName, lastName, mail;

        public SpeechTherapist(string licenseId, string firstName, string lastName, string mail)
        {
            this.licenseId = licenseId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.mail = mail;

        }

        public string LicenseId
        {
            set
            {
                licenseId = value;
            }
            get
            {
                return licenseId;
            }
        }
        public String FirstName
        {
            set
            {
                firstName = value;
            }
            get
            {
                return firstName;
            }
        }
        public String LastName
        {
            set
            {
                lastName = value;
            }
            get
            {
                return lastName;
            }
        }
        public String Mail
        {
            set
            {
                mail = value;
            }
            get
            {
                return mail;
            }
        }


        public String toString()
        {
            String str = "";
            str += LicenseId + " " + FirstName + " " + LastName + " " + Mail;
            return str;
        }
    }

}