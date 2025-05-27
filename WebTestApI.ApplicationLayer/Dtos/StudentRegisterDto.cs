using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.ApplicationLayer.Dtos
{
   public class StudentRegisterDto
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FatherName { get; set; }
            public int Age { get; set; }
            public NationalCode NationalCode { get; set; }
            public PhoneNumber PhoneNumber { get; set; }
            public PhoneNumber ParentsPhoneNumber { get; set; }
            public Email Email { get; set; }
            public string Password { get; set; }
           
        }

    }

