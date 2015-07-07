using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class Exercise
    {
        string title, description, therapistId, imagePath, filePath, link;
        int id, folderId;
        bool isVideo;

        public Exercise(string title, string description, int folderId, string therapistId, string link, string imagePath, string filePath, bool isVideo)
        {
            this.title = title;
            this.description = description;
            this.folderId = folderId;
            this.therapistId = therapistId;
            this.link = link;
            this.imagePath = imagePath;
            this.filePath = filePath;
            this.isVideo = isVideo;
        }

       // public Exercise(int id, Exercise exercise) : this(exercise.Title, exercise.Description, exercise.FolderId, exercise.TherapistId)
        public Exercise(int id, string title, string description, int folderId, string therapistId, string link, string imagePath, string filePath, bool isVideo)
            : this(title, description, folderId, therapistId, link, imagePath, filePath, isVideo)
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

        public string Link
        {
            set
            {
                link = value;
            }
            get
            {
                return link;
            }
        }
        public string ImagePath
        {
            set
            {
                imagePath = value;
            }
            get
            {
                return imagePath;
            }
        }

        public string FilePath
        {
            set
            {
                filePath = value;
            }
            get
            {
                return filePath;
            }
        }

        public bool IsVideo
        {
            set
            {
                isVideo = value;
            }
            get
            {
                return isVideo;
            }
        }

        public String ToString()
        {
            String str = "";
            str += "Id: " + Id + " \n Title:" + Title + " \n Description: " + Description + " \n FolderId: " + FolderId + " \n Link" + Link + " \n ImagePath: " + ImagePath + " \n FilePath: " + FilePath + " \n isVideo: " + IsVideo + " \n TherapistId: " + TherapistId;
            return str;
        }
    }
    
}