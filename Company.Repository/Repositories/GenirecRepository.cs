using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class GenirecRepository<T> : IGenirecRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;
        public GenirecRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        => _context.Set<T>().ToList();

        public T GetById(int id)
        => _context.Set<T>().Find(id);

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
