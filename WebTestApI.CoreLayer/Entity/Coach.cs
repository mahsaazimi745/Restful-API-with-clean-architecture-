using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Enums;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.CoreLayer.Entity
{
    public class Coach:User
    {
            public string Specialty { get; private set; }
            public int ExperienceYears { get; private set; }
            public string? CertificationNumber { get; private set; }

            public ICollection<Student> ApprovedStudents { get; private set; } = new List<Student>();

            private Coach() { }

            public Coach(string firstName, string lastName, string fatherName, int age,
                         NationalCode nationalCode, PhoneNumber phoneNumber, Email email,
                         Password password, string specialty, int experienceYears, string? certificationNumber)
                : base(firstName, lastName, fatherName, age, nationalCode, phoneNumber, email, password)
            {
                Specialty = specialty;
                ExperienceYears = experienceYears;
                CertificationNumber = certificationNumber;
            }

            public void ApproveStudent(Student student, StudentLevel level)
            {
                student.ApproveByCoach(this.Id, this, level);
                ApprovedStudents.Add(student);
            }
        }

    }

