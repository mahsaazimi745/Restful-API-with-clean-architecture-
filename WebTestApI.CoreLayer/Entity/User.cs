using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.ValueObjects;
using WebTestApI.CoreLayer.Enums;

namespace WebTestApI.CoreLayer.Entity
{
    public abstract class User
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; } // ✅ اصلاح شد
        public int Age { get; private set; }
        public string FatherName { get; private set; }
        public NationalCode NationalCode { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Email Email { get; private set; }
        public Password PasswordHash { get; private set; }
        public ApprovalStatus Status { get; private set; } = ApprovalStatus.Pending;

        #region Navigation
        public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
        #endregion

        protected User() { }

        protected User(string firstName, string lastName, string fatherName, int age,
                       NationalCode nationalCode, PhoneNumber phoneNumber,
                       Email email, Password password)
        {
            Id = Guid.NewGuid();

            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName)); // ✅ اصلاح شد
            FatherName = fatherName ?? throw new ArgumentNullException(nameof(fatherName));
            Age = age > 0 ? age : throw new ArgumentException("Age must be positive.", nameof(age));
            NationalCode = nationalCode ?? throw new ArgumentNullException(nameof(nationalCode));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PasswordHash = password ?? throw new ArgumentNullException(nameof(password));
        }

        public void Approve() => Status = ApprovalStatus.Approved;
        public void Reject() => Status = ApprovalStatus.Rejected;
        public string FullName => $"{FirstName} {LastName}"; // ✅ اصلاح شد
    }

}

