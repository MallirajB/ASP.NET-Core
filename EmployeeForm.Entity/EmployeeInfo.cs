﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EmployeeForm.Entity
{
    public partial class EmployeeInfo
    {
        public int Employee_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Employee_Address { get; set; }
        public DateTime Date_of_Joining { get; set; }
        public int Employee_Age { get; set; }
        public string Employee_work_Location { get; set; }
        public int? Employee_Experience { get; set; }
        public long? Contact_Number { get; set; }
        public string Create_Password { get; set; }
        public string Confirm_Password { get; set; }
        public bool Is_Deleted { get; set; }
        public DateTime Created_Time_Stamp { get; set; }
        public DateTime Updated_Time_Stamp { get; set; }
    }
}