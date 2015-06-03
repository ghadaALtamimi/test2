using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppVoice;

namespace AppVoice
{
    public class Bl_Patient
    {
        Dal_Patient dal_patient;
        public Bl_Patient()
        {
            dal_patient = new Dal_Patient();
        }

        public bool addPatient(Patient patient)
        {
            return dal_patient.addPatient(patient);
        }

        public bool isPatientExists(Patient patient)
        {
            return dal_patient.isPatientExists(patient);
        }

        public Patient getPatientDetails(string patientId)
        {
            return dal_patient.getPatientDetails(patientId);
        }

        public bool updatePatientDetails(string patientId, Patient newPatient)
        {
            return dal_patient.updatePatientDetails(patientId, newPatient);
        }

        // get all patients of specific therapist
        public List<Patient> getAllPatientsByLicenseId(string licenseId)
        {
            return dal_patient.getAllPatientsByLicenseId(licenseId);
        }
        public bool addAssignedExercise(string patientId, int folderId, string folderName, int exerciseId, string therapistId)
        {
            return dal_patient.addAssignedExercise(patientId, folderId, folderName, exerciseId, therapistId);
        }

        public List<AssignedExercise> getAllAssignedExercisesByPatientId(string patientId, string therapistId)
        {
            return dal_patient.getAllAssignedExercisesByPatientId(patientId, therapistId);
        }
    }
}