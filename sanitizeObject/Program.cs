using sanitizeObject;


Payment payment = new Payment
{
    Amount = new AmountInfo { Amount = 100, Currency = "USD!" },
    Message = "Payment@ from Tip@alti",
    RefCode = "Abc123$"
};

payment.Amount.owner = payment;

Console.WriteLine("Original Payment Object:");
Console.WriteLine($"Amount.Currency = \"{payment.Amount.Currency}\"");
Console.WriteLine($"Message = \"{payment.Message}\"");
Console.WriteLine($"RefCode = \"{payment.RefCode}\"\n");
Console.WriteLine("_____________________________________________");


var san = new ObjectSanitizer();
san.Sanitize(payment);

Console.WriteLine("\nSanitized Payment Object (Sanitize):");
Console.WriteLine($"Amount.Currency = \"{payment.Amount.Currency}\"");
Console.WriteLine($"Message = \"{payment.Message}\"");
Console.WriteLine($"RefCode = \"{payment.RefCode}\"\n");

//Console.WriteLine("_____________________________________________");

//ObjectSanitizer.SanitizeAndReplaceEveryThirdCharacter(payment);

//Console.WriteLine("\nSanitized Payment Object (Sanitize and Replace Every Third Character):");
//Console.WriteLine($"Amount.Currency = \"{payment.Amount.Currency}\"");
//Console.WriteLine($"Message = \"{payment.Message}\"");
//Console.WriteLine($"RefCode = \"{payment.RefCode}\"\n");


