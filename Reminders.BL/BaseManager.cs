using Reminders.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminders.BL
{
    public class BaseManager
    {
        
        protected string IncludeProperties { get; set; }

        public BaseManager(UnitOfWork unitOfWork)
        {
            this._UnitOfWork = unitOfWork;
        }


        protected UnitOfWork _UnitOfWork;
        public UnitOfWork UnitOfWork
        {
            get
            {
                return _UnitOfWork;
            }
            set { _UnitOfWork = value; }
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UnitOfWork.Dispose();
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
