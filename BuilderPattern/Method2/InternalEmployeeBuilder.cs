using BuilderPattern.Method1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Method2
{
    public class InternalEmployeeBuilder : EmployeeBuilderM2
    {
        public override void SetEmailAddress(string emailAddress)
        {
            //endswith @company.com

            var arr = emailAddress.Split('@');
            Employee.EmailAddress = arr[0] + "@company.com";
        }

        public override void SetFullName(string fullName)
        {
            var arr = fullName.Split(new[] { ' ', '.', '_' });

            Employee.FirstName = arr[0];
            Employee.LastName = arr[1];
        }

        public override void SetUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
