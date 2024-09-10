package com.sedes.MosquitoLaboratorio.Patient.Infrastructure.Entities;

import jakarta.persistence.*;
import lombok.*;

import java.time.LocalDate;


@Data
@Entity
@Table(name = "patient")
public class Patient {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private long id;

    @Column(name = "names", nullable = false, length = 60)
    private String name;

    @Column(name = "lastname", nullable = false, length = 60)
    private String lastName;

    @Column(name = "secondlastname", length = 60)
    private String secondLastName;

    @Column(name = "gender", nullable = false)
    private char gender;

    @Column(name = "ci", nullable = false, length = 30)
    private String ci;

    @Column(name = "birthdate", nullable = false)
    private LocalDate birthDate;

    @Column(name = "phone", nullable = false, length = 10)
    private String phone;
}