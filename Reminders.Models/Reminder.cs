using System;

namespace Reminders.Models
{
    public class Reminder
    {
        public int ID { get; set; }
        public int ReminderNumber { get; set; }
        public string Details { get; set; }
        public DateTime ReminderDate { get; set; }
        public string ReminderTime { get; set; }
    }
}
