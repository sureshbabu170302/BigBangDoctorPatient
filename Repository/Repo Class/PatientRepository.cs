﻿using BigBangDoctorPatient.Context;
using BigBangDoctorPatient.Models;
using BigBangDoctorPatient.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigBangDoctorPatient.Repository.Repo_Class
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DoctorPatientContext _context;

        public PatientRepository(DoctorPatientContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _context.Patients.Include(x => x.Doctor).ToListAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task AddPatient(Patient patient)
        {

            var r = _context.Doctors.Find(patient.Doctor.Doctor_Id);
            patient.Doctor = r;
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatient(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> SearchPatients(string query)
        {
            return await _context.Set<Patient>()
                .Where(p => p.Patient_Name.Contains(query) || p.Disease.Contains(query))
                .ToListAsync();
        }

        public async Task<bool> PatientExists(int id)
        {
            return await _context.Patients.AnyAsync(e => e.Patient_Id == id);
        }

        public async Task<List<Patient>> SearchPatientsByName(string name)
        {
            var patients = await _context.Patients.ToListAsync();
            return patients
                .Where(p => p.Patient_Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

    }
}
