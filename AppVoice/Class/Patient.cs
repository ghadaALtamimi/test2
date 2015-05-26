using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class Patient
    {
        private string patientId, firstName, lastName, mail, phoneNumber, address, hmo, password, therapistId;

        public Patient(string patientId, string firstName, string lastName, string mail, string phoneNumber, string address, string hmo, string password, string therapistId)
        {
            this.patientId = patientId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.mail = mail;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.hmo = hmo;
            this.password = password;
            this.therapistId = therapistId;
        }

        public string PatientId
        {
            set
            {
                patientId = value;
            }
            get
            {
                return patientId;
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

        public string PhoneNumber
        {
            set
            {
                phoneNumber = value;
            }
            get
            {
                return phoneNumber;
            }
        }

        public string Address
        {
            set
            {
                address = value;
            }
            get
            {
                return address;
            }
        }

        public string Hmo
        {
            set
            {
                hmo = value;
            }
            get
            {
                return hmo;
            }
        }

        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }
        public string TherapistId
        {
            set
            {
                therapistId = value;
            }
            get
            {
                return therapistId;
            }
        }


        public String toString()
        {
            String str = "";
            str += PatientId + " " + FirstName + " " + LastName + " " + Mail + " " + PhoneNumber + " " + Address + " " + Hmo + " " + Password + " " + TherapistId;
            return str;
        }
    }

}