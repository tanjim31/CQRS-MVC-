﻿using Employee.Model;
using Employee.Service.Model;
using Employee.Shared.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.Interface;

public interface IEmployeeRepository : IRepository<Employees,VMEmployee,int>
{
}
