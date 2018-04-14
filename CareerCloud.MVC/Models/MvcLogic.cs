using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.MVC.Models
{
    public class MvcLogic<T> where T : class
    {
        protected IDataRepository<T> bridge = null;
        public MvcLogic()
        {
            bridge = new EFGenericRepository<T>();
        }

        public IDataRepository<T> Repo
        {
            get { return bridge; }
        }

    }
}