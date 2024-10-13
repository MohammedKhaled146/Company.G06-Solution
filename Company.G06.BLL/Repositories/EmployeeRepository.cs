﻿using Company.G06.BLL.Interfaces;
using Company.G06.DAL.Data.Contexts;
using Company.G06.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G06.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        

        public EmployeeRepository(AppDbContext context) : base(context) 
        {
            
        }

        public async Task<IEnumerable<Employee>> GetByNameAsync(string name)
        {
            return await _context.Employees.Where(E=>E.Name.ToLower().Contains(name.ToLower())).Include(E=>E.WorkFor).ToListAsync();
        }
    }
}