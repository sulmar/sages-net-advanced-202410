namespace QueueExample;

class SupportTicketService
{
    private Queue<Ticket> tickets = new Queue<Ticket>();

    public void SubmitTicket(Ticket ticket)
    {
        tickets.Enqueue(ticket);
        
        Console.WriteLine($"New ticket submitted: {ticket}");
    }

    public Ticket ProcessTicket()
    {
        Ticket ticket = tickets.Dequeue();

        return ticket;
    }

    public IEnumerable<Ticket> GetOpenedTickets()
    {
        return tickets;
    }

    public IEnumerable<Ticket> GetClosedTickets()
    {
        throw new NotImplementedException();
    }
}