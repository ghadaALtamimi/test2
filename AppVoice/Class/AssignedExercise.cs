using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class AssignedExercise
    {
        int exerciseId;
        string patientId, therapistId;


        public AssignedExercise(int exerciseId, string patientId, string therapistId)
        {
            this.exerciseId = exerciseId;
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
    }
}