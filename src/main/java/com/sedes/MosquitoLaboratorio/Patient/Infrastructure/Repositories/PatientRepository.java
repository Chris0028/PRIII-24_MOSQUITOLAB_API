package com.sedes.MosquitoLaboratorio.Patient.Infrastructure.Repositories;

import com.sedes.MosquitoLaboratorio.Patient.Domain.Models.PatientModel;
import com.sedes.MosquitoLaboratorio.Patient.Domain.PortsOut.IPatientRepository;
import com.sedes.MosquitoLaboratorio.Patient.Infrastructure.Adapters.IPatientAdapter;
import com.sedes.MosquitoLaboratorio.Patient.Infrastructure.Mapper.PatientMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public class PatientRepository implements IPatientRepository {

    @Autowired
    PatientMapper mapper;
    private final IPatientAdapter patientAdapter;

    public PatientRepository(IPatientAdapter patientAdapter){
        this.patientAdapter = patientAdapter;
    }

    @Override
    public ArrayList<PatientModel> getAll() {
        var patients = patientAdapter.findAll();
        return mapper.toModels(patients);
    }

    @Override
    public PatientModel create(PatientModel patient) {
        var modelToEntity = mapper.toEntity(patient);
        var newPatient = patientAdapter.save(modelToEntity);
        return mapper.toModel(newPatient);
    }

    @Override
    public PatientModel edit(PatientModel patient) {
        var getModel = patientAdapter.findById(patient.getId());
        mapper.saveChanges(getModel.get(), patient);
        var modelToEntity = mapper.toEntity(patient);
        var target = patientAdapter.save(modelToEntity);
        return mapper.toModel(target);
    }

    @Override
    public PatientModel getOneById(long id) {
        var getPatient = patientAdapter.findById(id);
        return getPatient.map(patient -> mapper.toModel(patient)).orElse(null);
    }

    @Override
    public boolean delete(long id) {
        var patient = patientAdapter.findById(id);
        patientAdapter.deleteById(patient.get().getId());
        return false;
    }
}
