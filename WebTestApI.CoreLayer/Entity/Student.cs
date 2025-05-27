using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Enums;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.CoreLayer.Entity
{
        public class Student : User
        {
           // public string? ClassLevel { get; private set; }            // پایه تحصیلی
            public StudentLevel? Level { get; private set; }           // سطح تعیین‌شده توسط مربی
            public PhoneNumber? ParentsPhoneNumber { get; private set; }
            public Guid? ApprovedByCoachId { get; private set; }
            public Coach? ApprovedByCoach { get; private set; }
            public DateTime? ApprovedAt { get; private set; }

            private Student() { }

            public Student(string firstName, string lastName, string fatherName, int age,
                           NationalCode nationalCode, PhoneNumber phoneNumber, Email email,
                           Password password, PhoneNumber? parentsPhoneNumber)
                : base(firstName, lastName, fatherName, age, nationalCode, phoneNumber, email, password)
            {
                //ClassLevel = classLevel;
                ParentsPhoneNumber = parentsPhoneNumber?? throw new ArgumentNullException(nameof(phoneNumber));
        }

            public void ApproveByCoach(Guid coachId, Coach coach, StudentLevel level)
            {
                ApprovedByCoachId = coachId;
                ApprovedByCoach = coach;
                Level = level;
                ApprovedAt = DateTime.UtcNow;
            }
        }

    }

