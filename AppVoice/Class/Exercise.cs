using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class Exercise
    {
        string title, description, therapistId;
        int id, folderId;


        public Exercise(string title, string description, int folderId, string therapistId)
        {
            this.title = title;
            this.description = description;
            this.folderId = folderId;
            this.therapistId = therapistId;
        }

       // public Exercise(int id, Exercise exercise) : this(exercise.Title, exercise.Description, exercise.FolderId, exercise.TherapistId)
        public Exercise(int id, string title, string description, int folderId, string therapistId)
            : this(title, description, folderId, therapistId)
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

        public string Title
        {
            set
            {
                title = value;
            }
            get
            {
                return title;
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
        public int FolderId
        {
            set
            {
                folderId = value;
            }
            get
            {
                return folderId;
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