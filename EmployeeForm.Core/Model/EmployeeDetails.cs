﻿using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmployeeForm.Core.Model
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmployeeAddress { get; set; }
        [JsonIgnore]
        public DateTime DateofJoining { get; set; }
        public int EmployeeAge { get; set; }
        public int LocationId { get; set; }
        public int EmployeeExperience { get; set; }
        public long? ContactNumber { get; set; }
        public string? CreatePassword { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? DateStr { get; set; }
        [JsonIgnore]
        public string? SearchName { get; set; }
        public string? WorkLocation { get; set; }
       


    }
}
