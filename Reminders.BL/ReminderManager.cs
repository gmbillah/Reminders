using Reminders.DAL;
using Reminders.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Reminders.BL
{
    public class ReminderManager:BaseManager
    {
        public ReminderManager(UnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }

        public Reminder New(Reminder reminder)
        {
            UnitOfWork.ReminderRepository.Insert(reminder);
            UnitOfWork.Save();
            return reminder;
        }

        public IEnumerable<Reminder> Get()
        {
            return UnitOfWork.ReminderRepository.Get();
        }

        public Reminder GetByNumber(int reminderNumber)
        {
            return
            UnitOfWork.ReminderContext.Reminders.Where(r => r.ReminderNumber == reminderNumber).FirstOrDefault();
        }

        public Reminder Update(Reminder reminder)
        {
            var existingReminder = UnitOfWork.ReminderRepository.GetByID(reminder.ID);
            if (existingReminder != null)
            {
                existingReminder.ReminderNumber = reminder.ReminderNumber;
                existingReminder.Details = reminder.Details;
                existingReminder.ReminderDate = reminder.ReminderDate;
                existingReminder.ReminderTime = reminder.ReminderTime;

                UnitOfWork.ReminderRepository.Update(existingReminder);
                UnitOfWork.Save();
            }
            
            return reminder;
        }

        public bool Remove(int id)
        {
            var existingReminder = UnitOfWork.ReminderRepository.GetByID(id);
            if (existingReminder != null)
            {
                UnitOfWork.ReminderRepository.Delete(existingReminder);
                UnitOfWork.Save();
                return true;
            }
             
            return false;
        }
    }
}
