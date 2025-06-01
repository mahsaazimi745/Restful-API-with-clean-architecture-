using System;
using System.Collections.Generic;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.CoreLayer.Entity
{
    public class Coach : User
    {
        public Guid? ApprovedByAdminId { get; private set; }
        public Admin? ApprovedByAdmin { get; private set; }
        public DateTime? ApprovedAtByAdmin { get; private set; }
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
            Specialty = specialty ?? throw new ArgumentNullException(nameof(specialty));
            ExperienceYears = experienceYears;
            CertificationNumber = certificationNumber;
        }

        public void ApproveStudent(Student student, Enums.StudentLevel level)
        {
            student.ApproveByCoach(this.Id, this, level);
            ApprovedStudents.Add(student);
        }
        /* public void ApproveByAdmin(Guid adminId, Admin admin)
         {
             ApprovedByAdminId = adminId;
             ApprovedByAdmin = admin;
             ApprovedAtByAdmin = DateTime.UtcNow;
             Approve(adminId); // متد پایه User که وضعیت را Approved می‌کند
         }*/
        /*   public void ApproveByAdmin(Guid adminId, Admin admin)
           {
               Status = Enums.ApprovalStatus.Approved;
               ApprovedByAdminId = adminId;
               ApprovedByAdmin = admin;
               ApprovedAtByAdmin = DateTime.UtcNow;
           }*/
        /*     public void ApproveByAdmin(Guid adminId)
             {
                 if (IsApproved)
                     throw new InvalidOperationException("قبلاً تأیید شده.");

                 IsApproved = true;
                 ApprovedByAdminId = adminId;
                 ApprovedDate = DateTime.UtcNow;
             }*/
        public void ApproveByAdmin(Guid adminId)
        {
            if (IsApproved)
                throw new InvalidOperationException("قبلاً تأیید شده.");

            ApprovedByAdminId = adminId;
            ApprovedDate = DateTime.UtcNow;
            Approve(adminId); // متد پایه
        }

    }
}
