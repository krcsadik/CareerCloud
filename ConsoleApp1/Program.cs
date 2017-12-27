using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.ADODataAccessLayer;
using CareerCloud.Pocos;

namespace MyTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<SystemCountryCodePoco> oList;
            SystemCountryCodeRepository oCountry = new SystemCountryCodeRepository();
            try
            {
                oList=oCountry.GetAll();
                foreach (SystemCountryCodePoco o in oList)
                {
                    Console.WriteLine("Code.{0}....Name..{1}", o.Code, o.Name);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
