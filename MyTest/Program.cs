using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
namespace MyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicantEducationPoco t = new ApplicantEducationPoco();
            t.Id = Guid.Parse("11223344-5566-7788-99AA-BBCCDDEEFF00");
        }
    }
}
