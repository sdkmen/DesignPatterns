using BuilderPattern.Method1;
using BuilderPattern.Method2;

var eb = new EndpointBuilder("https://localhost");

eb
    .Append("api")
    .Append("v1")
    .Append("product")
    .AppendParam("id", "1")
    .AppendParam("name", "product1");

var url = eb.Build();

Console.WriteLine("Final url: " + url);

var empBuilder = new EmployeeBuilderM1();

var emp = empBuilder
    .SetFullName("Seyfullah Dikmen")
    .SetUserName("sdkmen")
    .SetEmailAddress("test@gmail.com")
    .BuildEmployee();

Console.WriteLine("Employee first name: " + emp.FirstName);

IEmployeeBuilderM2 employeeBuilder = new InternalEmployeeBuilder();
employeeBuilder.SetFullName("Seyfullah Dikmen");
employeeBuilder.SetEmailAddress("sdkmenn@gmail.com");

var employee = employeeBuilder.BuildEmployee();
Console.WriteLine("Employee email address: " + employee.EmailAddress);

var employeeGenerated = GenerateEmployee("Seyfullah Dikmen", "sdkmenn@gmail.com", 1);
Console.WriteLine("Generated employee email address: " + employeeGenerated.EmailAddress);

EmployeeM2 GenerateEmployee(string fullName, string emailAddress, int empType)
{
    IEmployeeBuilderM2 employeeBuilder;

    if(empType == 0)
        employeeBuilder = new InternalEmployeeBuilder();
    else
        employeeBuilder = new ExternalEmployeeBuilder();

    employeeBuilder.SetFullName(fullName);
    employeeBuilder.SetEmailAddress(emailAddress);

    return employeeBuilder.BuildEmployee();
}