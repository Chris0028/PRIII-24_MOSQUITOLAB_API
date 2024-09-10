package com.sedes.MosquitoLaboratorio.Patient.Infrastructure.Config;

import com.sedes.MosquitoLaboratorio.Patient.Application.Services.PatientService;
import com.sedes.MosquitoLaboratorio.Patient.Application.UseCases.IPatientService;
import com.sedes.MosquitoLaboratorio.Patient.Domain.PortsOut.IPatientRepository;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class PatientConfig {
    @Bean
    IPatientService patientBeanService(IPatientRepository patientRepository){
        return new PatientService(patientRepository);
    }
}
