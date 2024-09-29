using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Address { get; set; }
        public decimal Salary { get; set; }
        public string email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string? ImgUrl { get; set; }
        public DepartmentDto Department { get; set; }
        public int? DepartmentID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
