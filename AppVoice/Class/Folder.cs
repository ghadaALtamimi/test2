using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class Folder
    {
        string name, description, therapistId;
        int id;

        public Folder(string name, string description, string therapistId)
        {
            this.name = name;
            this.description = description;
            this.therapistId = therapistId;
        }
        public Folder(int id, string name, string description, string therapistId) : this(name, description, therapistId)
        {
            this.id = id;
        }

        public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }

        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        public string Description
        {
            set
            {
                description = value;
            }
            get
            {
                return description;
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
    }
}