using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class SubmittedExercise
    {
        int id, exerciseId, isOpenedFile, isDone;
        string exerciseName, patientId, therapistId;
        public SubmittedExercise(int id, int exerciseId, string exerciseName, string patientId, string therapistId, int isOpenedFile, int isDone)
        {
            this.id = id;
            this.exerciseId = exerciseId;
            this.exerciseName = exerciseName;
            this.patientId = patientId;
            this.therapistId = therapistId;
            this.isOpenedFile = isOpenedFile;
            this.isDone = isDone;
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

        public string ExerciseName
        {
            set
            {
                exerciseName = value;
            }
            get
            {
                return exerciseName;
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
        public int IsOpenedFile
        {
            set
            {
                isOpenedFile = value;
            }
            get
            {
                return isOpenedFile;
            }
        }
        public int IsDone
        {
            set
            {
                isDone = value;
            }
            get
            {
                return isDone;
            }
        }
    }
}