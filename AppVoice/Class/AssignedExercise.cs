using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class AssignedExercise
    {
        int exerciseId, folderId;
        string patientId, therapistId, folderName;


        public AssignedExercise(int exerciseId, int folderId, string folderName, string patientId, string therapistId)
        {
            this.exerciseId = exerciseId;
            this.folderId = folderId;
            this.folderName = folderName;
            this.patientId = patientId;
            this.therapistId = therapistId;
        }

       
        public int ExerciseId
        {
            set
            {
                exerciseId = value;
            }
            get
            {
                return exerciseId;
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

        public string FolderName
        {
            set
            {
                folderName = value;
            }
            get
            {
                return folderName;
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