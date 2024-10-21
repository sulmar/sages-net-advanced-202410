using SetOperations;

Console.WriteLine("Hello, Set Operations!");

// Lista faktur
List<Invoice> invoices = new List<Invoice>
{
    new Invoice { Id = 1, Paid = true, Posted = true },
    new Invoice { Id = 2, Paid = false, Posted = true },
    new Invoice { Id = 3, Paid = true, Posted = false },
    new Invoice { Id = 4, Paid = false, Posted = false },
    new Invoice { Id = 5, Paid = true, Posted = true },
    new Invoice { Id = 6, Paid = false, Posted = false }
};

// TODO: pobierz faktury zapłacone
var paidInvoices = invoices;

// TODO: pobierz faktury zaksięgowane
var postedInvoices = invoices;

// TODO: pobierz wszystkie faktury, które są albo zapłacone, albo zaksięgowane (lub oba)

// TODO: pobierz faktury, które są zarówno zapłacone, jak i zaksięgowane

// TODO: pobierz faktury zapłacone, ale nie zaksięgowane
