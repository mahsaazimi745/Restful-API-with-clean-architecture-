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
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int Age { get; protected set; }
        public string FatherName { get; protected set; }
        public NationalCode NationalCode { get; protected set; }
        public PhoneNumber PhoneNumber { get; protected set; }
        public Email Email { get; protected set; }
        public Password PasswordHash { get; protected set; }

        public ApprovalStatus Status { get; protected set; } = ApprovalStatus.Pending;

        public DateTime? ApprovedDate { get; protected set; }
        public Guid? ApprovedById { get; protected set; }
        public User? ApprovedBy { get; protected set; }

        public bool IsApproved => Status == ApprovalStatus.Approved;

        public ICollection<UserRole> UserRoles { get; protected set; } = new List<UserRole>();

        protected User() { }

        protected User(string firstName, string lastName, string fatherName, int age,
                       NationalCode nationalCode, PhoneNumber phoneNumber,
                       Email email, Password password)
        {
            Id = Guid.NewGuid();
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            FatherName = fatherName ?? throw new ArgumentNullException(nameof(fatherName));
            Age = age > 0 ? age : throw new ArgumentException("Age must be positive.", nameof(age));
            NationalCode = nationalCode ?? throw new ArgumentNullException(nameof(nationalCode));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PasswordHash = password ?? throw new ArgumentNullException(nameof(password));
        }

        public string FullName => $"{FirstName} {LastName}";

        public void Approve(Guid approverId)
        {
            Status = ApprovalStatus.Approved;
            ApprovedById = approverId;
            ApprovedDate = DateTime.UtcNow;
        }

        public void Reject()
        {
            Status = ApprovalStatus.Rejected;
            ApprovedById = null;
            ApprovedDate = null;
        }
    }




}
    



