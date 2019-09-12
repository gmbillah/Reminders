using Reminders.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminders.DAL
{
    public class UnitOfWork
    {
        public void Save()
        {
            ReminderContext.SaveChanges();
        }
        public ReminderContext ReminderContext;

        public UnitOfWork(ReminderContext ReminderContext)
        {
            this.ReminderContext = ReminderContext;
        }

        private GenericRepository<Reminder> reminderRepository;

        public GenericRepository<Reminder> ReminderRepository
        {
            get
            {
                if (reminderRepository == null)
                    reminderRepository = new GenericRepository<Reminder>(ReminderContext);
                return reminderRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ReminderContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
