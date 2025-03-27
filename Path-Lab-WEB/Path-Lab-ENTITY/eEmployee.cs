using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Path_Lab_ENTITY
{
    public class eEmployee
    {
        public Int32? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Degination { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public string Qualification { get; set; }
        public string ImagePath { get; set; }
        public string Type { get; set; }
        public string DateEntered { get; set; }
        public string DateUpdated { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAvailable { get; set; }
    }
}