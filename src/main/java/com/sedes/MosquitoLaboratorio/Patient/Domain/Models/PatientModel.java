package com.sedes.MosquitoLaboratorio.Patient.Domain.Models;

import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@NoArgsConstructor
@Data
public class PatientModel {
    private long id;
    private String name;
    private String lastName;
    private String secondLastName;
    private char gender;
    private String ci;
    private LocalDate birthDate;
    private String phone;
}
