package com.sedes.MosquitoLaboratorio.Patient.Domain.PortsOut;


import com.sedes.MosquitoLaboratorio.Patient.Domain.Models.PatientModel;

import java.util.ArrayList;

public interface IPatientRepository {

    ArrayList<PatientModel> getAll();
    PatientModel create(PatientModel patient);
    PatientModel edit(PatientModel patient);
    PatientModel getOneById(long id);
    boolean delete(long id);

}
