using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sai_Raj_Laboratory.Models
{
    public class DatabaseContext:DbContext
    {
        /*public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }*/

        public DbSet<Report> Reports { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@" Data Source = E:\My projects\Sai-Raj-Laboratory\Demo.db");
    }
}
