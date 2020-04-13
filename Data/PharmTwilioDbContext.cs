using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwilioSend.Models;

namespace TwilioSend.Data
{
    public class PharmTwilioDbContext:DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=PharmTwilio;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(connectionString);
        }
        public DbSet<SmsLog> SmsLogs { get; set; }
           
    }
}
