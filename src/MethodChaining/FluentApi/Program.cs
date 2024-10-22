using FluentApi;

Console.WriteLine("Hello, Method Chaining!");

//Phone phone = new Phone();
//phone.Call("555-000-111", "555-111-222");

// Fluent Api
FluentPhone
    .Hangup()
    .From("555-000-111")    
    .To("555-111-222")
    .To("555-111-333")
    .To("555-111-444")
    .Call();

/*

FluentPhone
    .Hangup()
    .From("555-000-111")
    .To("555-111-222")
    .To("555-111-333")
    .To("555-111-444")
    .Call();

*/

