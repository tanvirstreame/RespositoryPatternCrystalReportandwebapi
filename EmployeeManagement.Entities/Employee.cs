﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String password { get; set; }
    }
}
