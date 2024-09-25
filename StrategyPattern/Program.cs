

var paymentOptions = new PaymentOptions()
{
    CardNumber = "1234123412341234",
    CardHolderName = "Seyfullah Dikmen",
    ExpirationDate = "12/29",
    Cvv = "123",
    Amount = 2600
};

var paymentService = new PaymentService();

do
{
    Console.Write("Choose which bank you want to pay with (1: Garanti, 2: Yapı Kredi, 3: İş Bankası): ");
    var bank = Console.ReadLine();

    IPaymentService bankPaymentService = null;

    switch (bank)
    {
        case "1":
            bankPaymentService = new GarantiBankPaymentService();
            break;
        case "2":
            bankPaymentService= new YapiKrediPaymentService();
            break;
        case "3":
            bankPaymentService = new IsBankasiPaymentService();
            break;
        default:
            Console.WriteLine("Unvalid bank");
            break;
    }

    paymentService.SetPaymentService(bankPaymentService);
    paymentService.PayViaStrategy(paymentOptions);
}
while (Console.ReadKey().Key != ConsoleKey.Escape);

class PaymentService
{
    private IPaymentService paymentService;

    public PaymentService()
    {
        
    }

    public PaymentService(IPaymentService paymentService)
    {
        this.paymentService = paymentService;
    }

    public void SetPaymentService(IPaymentService paymentService)
    {
        this.paymentService = paymentService;
    }

    public bool PayViaStrategy(PaymentOptions options)
    {
        return paymentService.Pay(options);
    }
}

public class GarantiBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        Console.WriteLine("Pay with garanti");
        return true;
    }
}

public class YapiKrediPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        Console.WriteLine("Pay with yapi kredi");
        return true;
    }
}

public class IsBankasiPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        Console.WriteLine("Pay with is bankasi");
        return true;
    }
}

interface IPaymentService
{
    bool Pay(PaymentOptions paymentOptions);
}

public class PaymentOptions
{
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpirationDate { get; set; }
    public string Cvv { get; set; }
    public decimal Amount { get; set; }
}