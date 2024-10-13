﻿using Company.G06.BLL.Interfaces;
using Company.G06.BLL.Repositories;
using Company.G06.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Company.G06.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;

        public UnitOfWork(AppDbContext context)
        {
            _employeeRepository = new EmployeeRepository(context);
            _departmentRepository = new DepartmentRepository(context);
            _context = context;
        }
        public IDepartmentRepository DepartmentRepository => _departmentRepository;

        public IEmployeeRepository EmployeeRepository => _employeeRepository;

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
