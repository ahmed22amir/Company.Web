using Company.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Dto
{
    public class DepartmentDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
    }
}
