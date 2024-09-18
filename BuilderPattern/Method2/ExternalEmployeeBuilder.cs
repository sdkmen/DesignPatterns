using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Method2
{
    public class ExternalEmployeeBuilder : EmployeeBuilderM2
    {
        public override void SetEmailAddress(string emailAddress)
        {
            Employee.EmailAddress = emailAddress;
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
