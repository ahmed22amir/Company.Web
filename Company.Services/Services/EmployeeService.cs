using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Compelet();
        }

        public void Delete(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Delete(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            var dept= _unitOfWork.EmployeeRepository.GetAll();
            return dept;
        }

        public Employee GetById(int? id)
        {
            if(id is null)
            {
                return null;
            }
            var dept = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if(dept is null)
            {
                return null;
            }
            return dept;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        => _unitOfWork.EmployeeRepository.GetEmployeeByName(name);

        public void Update(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Compelet();
        }
    }
}
