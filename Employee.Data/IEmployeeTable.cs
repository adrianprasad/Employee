using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Entity;

namespace Employee.Data
{
    public interface IEmployeeTable
    {
        void Insert(Employeedata employee);
        void Update(Employeedata employee);
        IEnumerable<Employeedata> GetAll();
    }
}
