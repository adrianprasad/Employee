using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Data;
using Employee.Entity;

namespace Employee.Data.Repo
{
    public class SqlEmployeeTable : IEmployeeTable
    {
        private readonly EntityDbContext _dbContext;
        public SqlEmployeeTable(EntityDbContext entityDbContext)
        {
            _dbContext = entityDbContext;
        }
        public void Insert(Employeedata employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }
        public void Update(Employeedata employee)
        {
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
        }
        IEnumerable<Employeedata> IEmployeeTable.GetAll()
        {
            return _dbContext.Employees.ToList();
        }
    }
}
