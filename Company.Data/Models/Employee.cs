using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Address { get; set; }
        public decimal Salary { get; set; }
        public string email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public IFormFile Image { get; set; }
        public string ImgUrl { get; set; }
        public Department Department { get; set; }
        public int? DepartmentID { get; set; }
    }
}
