using System;
using WebTestApI.CoreLayer.Enums;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.CoreLayer.Entity
{
    public class Student : User
    {
        public StudentLevel? Level { get; private set; }
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
            ParentsPhoneNumber = parentsPhoneNumber ?? throw new ArgumentNullException(nameof(parentsPhoneNumber));
        }

        /*   public void ApproveByCoach(Guid coachId, Coach coach, StudentLevel level)
           {
               ApprovedByCoachId = coachId;
               ApprovedByCoach = coach;
               Level = level;
               ApprovedAt = DateTime.UtcNow;
               Approve(coachId);  // اینجا اصلاح شد ✅
           }*/
        /*  public void ApproveByCoach(Guid coachId)
          {
              if (IsApproved)
                  throw new InvalidOperationException("قبلاً تأیید شده.");

              IsApproved = true;
              ApprovedByCoachId = coachId;
              ApprovedDate = DateTime.UtcNow;
          }*/
        public void ApproveByCoach(Guid coachId, Coach coach, StudentLevel level)
        {
            if (IsApproved)
                throw new InvalidOperationException("قبلاً تأیید شده.");

            ApprovedByCoachId = coachId;
            ApprovedByCoach = coach;
            Level = level;
            ApprovedDate = DateTime.UtcNow;
            Status = ApprovalStatus.Approved;
        }

    }
}
