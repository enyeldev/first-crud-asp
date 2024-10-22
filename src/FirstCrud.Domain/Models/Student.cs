using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCrud.Domain.Models
{
    public class Student
    {

        public int? Id { get; set; }


        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Adress { get; set; }

        public string? Phone { get; set; }

        public bool Deleted { get; set; }
    }
}