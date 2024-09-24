using Company.Data.Contexts;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;

        public UnitOfWork(CompanyDbContext context)
        {
            DepartmentRepository =new DepartmentRepository(context);
            EmployeeRepository =new EmployeeRepository(context);
            _context = context;
        }

        public IDepartmentRepository DepartmentRepository { get ; set ; }
        public IEmployeeRepository EmployeeRepository { get ; set ; }

        public int Compelet()
        => _context.SaveChanges();
    }
}
