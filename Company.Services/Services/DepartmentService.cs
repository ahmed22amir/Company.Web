using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Repository.Repositories;
using Company.Services.Interfaces;
using Company.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(DepartmentDto department)
        {
            var MappedDepartment = new Department
            {
                Code = department.Code,
                Name = department.Name,
                CreateAt = DateTime.Now
            };
            _unitOfWork.DepartmentRepository.Add(MappedDepartment);
            _unitOfWork.Compelet();
        }

        public void Delete(DepartmentDto department)
        {
            _unitOfWork.DepartmentRepository.Delete(department);
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var dept = _unitOfWork.DepartmentRepository.GetAll()/*.Where(x=>x.IsDeleted != true)*/;
            return dept;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
            {
                return null;
            }
            var dept = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if(dept is null)
            {
                return null;
            }
            return dept;
        }

        public void Update(DepartmentDto department)
        {
            var dept = GetById(department.ID);
            if (dept.Name == department.Name)
            { 
                if(GetAll().Any(x=>x.Name == department.Name))
                {
                    throw new Exception("DulicatedDepartment");
                }
            }
            dept.Name = department.Name;
            dept.Code = department.Code;
            _unitOfWork.DepartmentRepository.Update(dept);
            _unitOfWork.Compelet();
        }
    }
}
