using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivatorExample;

public class Transfer
{
    public string Operation { get; set; }
    public decimal Amount {  get; set; }

    public Transfer(string operation, decimal amount)
    {
        Operation = operation;
        Amount = amount;
    }
}
