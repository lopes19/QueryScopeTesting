using QueryStack.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryStack.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base("CONNECTION STRING")
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
