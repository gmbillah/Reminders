using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reminders.BL;
using Reminders.DAL;
using Reminders.Models;


namespace Reminders.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        
        ReminderManager reminderManager;
        public RemindersController(ReminderContext reminderContext)
        {
            reminderManager = new ReminderManager(new UnitOfWork(reminderContext));

        }

        // GET api/reminders
        [HttpGet]
        public ActionResult<IEnumerable<Reminder>> Get()
        {
            return Ok(reminderManager.Get());
        }



        //// GET api/reminders/GetByReminderNumber?reminderNumber=5
        [HttpGet]
        [Route("GetByReminderNumber")]
        public ActionResult<Reminder> GetByReminderNumber(int reminderNumber)
        {
            var result = reminderManager.GetByNumber(reminderNumber);

            return result;
        }


        // POST api/reminders
        [HttpPost]
        public void Post(Reminder obj)
        {
            reminderManager.New(obj);
        }

        //// PUT api/reminders/5
        [HttpPut]
        public void Put(Reminder obj)
        {
           reminderManager.Update(obj);
           
        }

        //// DELETE api/reminders/5
        [HttpDelete("{id}")]
        public void Delete(int id)        {
            
            reminderManager.Remove(id);
        }
    }
}
