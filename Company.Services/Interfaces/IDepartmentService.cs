using Company.Data.Models;
using Company.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentDto GetById(int? id);
        IEnumerable<Department> GetAll();
        void Add(DepartmentDto department);
        //void Update(DepartmentDto department);
        void Delete(DepartmentDto department);
    }
}
