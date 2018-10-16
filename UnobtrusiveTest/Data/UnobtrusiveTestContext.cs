using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnobtrusiveTest.Models.Employee;

namespace UnobtrusiveTest.Models
{
    public class UnobtrusiveTestContext : DbContext
    {
        public UnobtrusiveTestContext (DbContextOptions<UnobtrusiveTestContext> options)
            : base(options)
        {
        }

        public DbSet<UnobtrusiveTest.Models.Employee.Employee> Employee { get; set; }
    }
}
