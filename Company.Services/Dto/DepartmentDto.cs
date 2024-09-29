using Company.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Dto
{
    public class DepartmentDto
    {
        [NotMapped]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
        [NotMapped]
        public bool IsDeleted { get; set; }
    }
}
