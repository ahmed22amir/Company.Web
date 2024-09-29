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
using AutoMapper;

namespace Company.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService()
        {
        }

        public DepartmentService(IUnitOfWork unitOfWork , IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(DepartmentDto departmentDto)
        {
            //var MappedDepartment = new Department
            //{
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreateAt = DateTime.Now
            //};
            Department dept = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(dept);
            _unitOfWork.Compelet();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            //Department dept = new Department
            //{
            //    Name = department.Name,
            //    Code = department.Code,
            //    CreateAt = DateTime.Now,
            //};
            Department dept = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Delete(dept);
            _unitOfWork.Compelet();
        }

        public IEnumerable<Department> GetAll()
        {
            var dept = _unitOfWork.DepartmentRepository.GetAll()/*.Where(x=>x.IsDeleted != true)*/;
            //var MappedDepartment = dept.Select(x => new DepartmentDto
            //{
            //    Code=x.Code,
            //    Name = x.Name,
            //});
            //IEnumerable<DepartmentDto> MappedDepartment = _mapper.Map<IEnumerable<DepartmentDto>>(dept);
            return dept;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
            {
                return null;
            }
            var dept = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (dept is null)
                return null;

            DepartmentDto departmentDto = _mapper.Map<DepartmentDto>(dept);
            return departmentDto;
        }

        //public void Update(Department department)
        //{
        //    var dept = GetById(department.ID);
        //    if (dept.Name == department.Name)
        //    { 
        //        if(GetAll().Any(x=>x.Name == department.Name))
        //        {
        //            throw new Exception("DulicatedDepartment");
        //        }
        //    }
        //    dept.Name = department.Name;
        //    dept.Code = department.Code;
        //    _unitOfWork.DepartmentRepository.Update(dept);
        //    _unitOfWork.Compelet();
        //}
    }
}
