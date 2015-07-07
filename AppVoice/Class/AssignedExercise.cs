using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class AssignedExercise
    {
        int id, exerciseId, folderId;
        string patientId, therapistId, folderName;


        public AssignedExercise(int exerciseId, int folderId, string folderName, string patientId, string therapistId)
        {
            this.exerciseId = exerciseId;
            this.folderId = folderId;
            this.folderName = folderName;
            this.patientId = patientId;
            this.therapistId = therapistId;
        }

        public AssignedExercise(int id, int exerciseId, int folderId, string folderName, string patientId, string therapistId) : this(exerciseId, folderId, folderName, patientId, therapistId)
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