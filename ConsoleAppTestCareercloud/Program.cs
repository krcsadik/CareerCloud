using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System.Data.Entity;


namespace ConsoleAppTestCareercloud
{
    class Program
    {
        static void Main(string[] args)
        {
            CareerCloudContext ctx = new CareerCloudContext();
            int n = 0;
            int j = 0;
            Console.WriteLine(" Listing...profile >>> location .....");
            foreach (CompanyProfilePoco c in ctx.CompanyProfiles)
            {
                Console.WriteLine($"{c.ContactName}...{c.ContactPhone}..");
                j = 0;
                foreach (CompanyLocationPoco t in c.CompanyLocations)
                {
                    Console.WriteLine($"            {t.PostalCode}...{t.Street}..{t.City}");
                    if (++j > 5) break;
                }
                if (++n > 5) break;
            }

            n = 0;
            Console.WriteLine(" Listing...location >>> location .....");
            foreach (CompanyLocationPoco c in ctx.CompanyLocations)
            {

                Console.WriteLine($"{c.PostalCode}...{c.Street}..{c.City}");
                j = 0;
                foreach (CompanyProfilePoco t in ctx.CompanyProfiles)
                {
                    
                    Console.WriteLine($"        {t.ContactName}...{t.ContactPhone}..");
                    
                    if (++j > 5) break;
                }
                if (++n > 5) break;
            }



            Console.ReadLine();
        }
    }
}
