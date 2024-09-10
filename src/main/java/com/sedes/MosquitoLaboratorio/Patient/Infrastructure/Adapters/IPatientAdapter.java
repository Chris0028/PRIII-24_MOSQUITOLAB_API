package com.sedes.MosquitoLaboratorio.Patient.Infrastructure.Adapters;

import com.sedes.MosquitoLaboratorio.Patient.Infrastructure.Entities.Patient;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IPatientAdapter extends JpaRepository<Patient, Long> {
}
