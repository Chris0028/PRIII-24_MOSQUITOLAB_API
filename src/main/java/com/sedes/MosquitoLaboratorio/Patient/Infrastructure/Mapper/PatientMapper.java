package com.sedes.MosquitoLaboratorio.Patient.Infrastructure.Mapper;

import com.sedes.MosquitoLaboratorio.Patient.Domain.Models.PatientModel;
import com.sedes.MosquitoLaboratorio.Patient.Infrastructure.Entities.Patient;
import org.mapstruct.Mapper;
import org.mapstruct.MappingTarget;

import java.util.ArrayList;
import java.util.List;

@Mapper(componentModel = "spring")
public interface PatientMapper {
    Patient toEntity(PatientModel target);
    PatientModel toModel(Patient target);
    ArrayList<PatientModel> toModels(List<Patient> entities);
    void saveChanges(@MappingTarget Patient target, PatientModel source);
}
