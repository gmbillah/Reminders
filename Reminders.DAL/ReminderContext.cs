using Microsoft.EntityFrameworkCore;
using Reminders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminders.DAL
{
    public class ReminderContext : DbContext
    {
        public ReminderContext(DbContextOptions<ReminderContext> options) : base(options)
        {

        }

        public DbSet<Reminder> Reminders { get; set; }
    }
}
