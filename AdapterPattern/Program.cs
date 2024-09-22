//structural

var transaction = new TransferTranscation()
{
    Amount = 10,
    FromIBAN = "1",
    ToIBAN = "2",
};

//var adapter = new JsonBankApiAdapter();
var adapter = new XmlBankApiAdapter();
var result = adapter.ExecuteTranscation(transaction);

Console.WriteLine("Result: " + result);
Console.ReadLine();

interface IBankApi
{
    bool ExecuteTranscation(TransferTranscation transcation);
}

class JsonBankApiAdapter : IBankApi
{
    private readonly JsonBankApi jsonBankApi;

    public JsonBankApiAdapter()
    {
        jsonBankApi = new();
    }

    public bool ExecuteTranscation(TransferTranscation transcation)
    {
        // some controls
        return jsonBankApi.ExecuteTranscation(transcation);
    }
}

class XmlBankApiAdapter : IBankApi
{
    private readonly XmlBankApi xmlBankApi;

    public XmlBankApiAdapter()
    {
        xmlBankApi = new();
    }

    public bool ExecuteTranscation(TransferTranscation transcation)
    {
        // some controls
        return xmlBankApi.ExecuteTranscation(transcation);
    }
}

class JsonBankApi : IBankApi
{
    public bool ExecuteTranscation(TransferTranscation transcation)
    {
        var json = $$""""
                     {
                        ""FromIBAN"": ""{{transcation.FromIBAN}}"",
                        ""ToIBAN"": ""{{transcation.ToIBAN}}"",
                        ""Amount"": ""{{transcation.Amount:N2}}""
                     }
                     """";

        //Call bank api with Json
        Console.WriteLine($"{GetType().Name} worked with;");
        Console.WriteLine(json);
        return true;
    }
}

class XmlBankApi : IBankApi
{
    public bool ExecuteTranscation(TransferTranscation transcation)
    {
        var xml = $"""
                    <TransferTranscation>
                        <FromIBAN>{transcation.FromIBAN}</FromIBAN>
                        <ToIBAN>{transcation.ToIBAN}</ToIBAN>
                        <Amount>{transcation.Amount:N2}</Amount>
                    </TransferTranscation>
                  """;

        //Call bank api with xml
        Console.WriteLine($"{GetType().Name} worked with;");
        Console.WriteLine(xml);
        return true;
    }
}

class TransferTranscation
{
    public string FromIBAN { get; set; }
    public string ToIBAN { get; set; }
    public decimal Amount { get; set; }
}