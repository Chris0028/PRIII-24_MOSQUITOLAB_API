package com.sedes.MosquitoLaboratorio.Patient.Application.UseCases;

import com.sedes.MosquitoLaboratorio.Patient.Domain.Models.PatientModel;

import java.util.ArrayList;

public interface IPatientService {
    ArrayList<PatientModel> getAll();
    PatientModel create(PatientModel patient);
    PatientModel edit(PatientModel patient);
    PatientModel getOneById(long id);
    boolean delete(long id);
}
