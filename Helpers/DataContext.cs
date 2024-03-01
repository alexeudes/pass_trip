using System;
using Microsoft.EntityFrameworkCore;
using pass_trip.Domain.Models;

namespace pass_trip.Helpers
{
	public class DataContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(_configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Passport> Passports { get; set; }
    }
}

