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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {
            //manual Mapping
            //Employee employee = new Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    Name = employeeDto.Name,
            //    Salary = employeeDto.Salary,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    email = employeeDto.email,
            //    HiringDate = employeeDto.HiringDate,
            //    DepartmentID = employeeDto.DepartmentID,
            //    ImgUrl = employeeDto.ImgUrl,
            //};
            
            Employee employee = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Compelet();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    Name = employeeDto.Name,
            //    Salary = employeeDto.Salary,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    email = employeeDto.email,
            //    HiringDate = employeeDto.HiringDate,
            //    DepartmentID = employeeDto.DepartmentID,
            //    ImgUrl = employeeDto.ImgUrl,
            //};

            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Compelet();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var emp = _unitOfWork.EmployeeRepository.GetAll();
            //var MappedEmployee = emp.Select(x => new EmployeeDto
            //{
            //    Address = x.Address,
            //    Age = x.Age,
            //    Name = x.Name,
            //    Salary = x.Salary,
            //    PhoneNumber = x.PhoneNumber,
            //    email = x.email,
            //    HiringDate = x.HiringDate,
            //    DepartmentID = x.DepartmentID,
            //    ImgUrl = x.ImgUrl,
            //    CreatedAt = x.CreateAt,
            //});

            IEnumerable<EmployeeDto> MappedEmployee = _mapper.Map < IEnumerable<EmployeeDto>>(emp);
            return MappedEmployee;
        }

        public EmployeeDto GetById(int? id)
        {
            if(id is null)
            {
                return null;
            }
            var emp = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if(emp is null)
               return null;
            
            //EmployeeDto employeeDto = new EmployeeDto
            //{
            //    Address = emp.Address,
            //    Age = emp.Age,
            //    Name = emp.Name,
            //    Salary = emp.Salary,
            //    PhoneNumber = emp.PhoneNumber,
            //    email = emp.email,
            //    HiringDate = emp.HiringDate,
            //    DepartmentID = emp.DepartmentID,
            //    ImgUrl = emp.ImgUrl,
            //};
            EmployeeDto employeeDto =_mapper.Map<EmployeeDto>(emp);
            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var emp = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            //var employeeDto = emp.Select(x => new EmployeeDto
            //{
            //    Address = x.Address,
            //    Age = x.Age,
            //    Name = x.Name,
            //    Salary = x.Salary,
            //    PhoneNumber = x.PhoneNumber,
            //    email = x.email,
            //    HiringDate = x.HiringDate,
            //    DepartmentID = x.DepartmentID,
            //    ImgUrl = x.ImgUrl,
            //    CreatedAt = x.CreateAt,
            //});

            IEnumerable<EmployeeDto> employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(emp);
            return employeeDto;
        }

        //public void Update(EmployeeDto employee)
        //{
        //    _unitOfWork.EmployeeRepository.Update(employee);
        //    _unitOfWork.Compelet();
        //}
    }
}
