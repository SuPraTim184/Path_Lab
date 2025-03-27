using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_ENTITY
{
    public class eDoctor
    {
        public string DocNameSpec { get; set; } 
        public Int32? DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Availablechambers { get; set; }
        public string ImagePath { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? Fees { get; set; }
    }
}
