package com.sedes.MosquitoLaboratorio.Patient.Application.Services;

import com.sedes.MosquitoLaboratorio.Patient.Application.UseCases.IPatientService;
import com.sedes.MosquitoLaboratorio.Patient.Domain.Models.PatientModel;
import com.sedes.MosquitoLaboratorio.Patient.Domain.PortsOut.IPatientRepository;

import java.text.SimpleDateFormat;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;

public class PatientService implements IPatientService {

    private final IPatientRepository patientRepository;

    public PatientService(IPatientRepository patientRepository){
        this.patientRepository = patientRepository;
    }

    @Override
    public ArrayList<PatientModel> getAll() {
        return patientRepository.getAll();
    }

    @Override
    public PatientModel create(PatientModel patient) {
        var formatDate = DateTimeFormatter.ofPattern("yyyy-MM-dd");
        patient.getBirthDate().format(formatDate);
        return patientRepository.create(patient);
    }

    @Override
    public PatientModel edit(PatientModel patient) {
        return patientRepository.edit(patient);
    }

    @Override
    public PatientModel getOneById(long id) {
        return patientRepository.getOneById(id);
    }

    @Override
    public boolean delete(long id) {
        return patientRepository.delete(id);
    }
}
