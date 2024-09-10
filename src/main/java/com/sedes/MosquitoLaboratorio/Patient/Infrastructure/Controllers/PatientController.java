package com.sedes.MosquitoLaboratorio.Patient.Infrastructure.Controllers;

import com.sedes.MosquitoLaboratorio.Patient.Application.UseCases.IPatientService;
import com.sedes.MosquitoLaboratorio.Patient.Domain.Models.PatientModel;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/patients")
public class PatientController {

    private IPatientService patientService;

    public PatientController(IPatientService patientService){
        this.patientService = patientService;
    }

    @GetMapping("{id}")
    public ResponseEntity<PatientModel> get(@PathVariable long id){
        return new ResponseEntity<>(patientService.getOneById(id), HttpStatus.OK);
    }

    @PostMapping
    public ResponseEntity<PatientModel> newPatient(@RequestBody PatientModel patient){
        return new ResponseEntity<>(patientService.create(patient), HttpStatus.CREATED);
    }

    @PatchMapping
    public ResponseEntity<PatientModel> edit(@RequestBody PatientModel patient){
        return new ResponseEntity<>(patientService.edit(patient), HttpStatus.OK);
    }

    @DeleteMapping
    public ResponseEntity<PatientModel> delete(@PathVariable long id){
        boolean deleted = patientService.delete(id);
        if(deleted){
            return new ResponseEntity<>(HttpStatus.NO_CONTENT);
        }else {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }
}
