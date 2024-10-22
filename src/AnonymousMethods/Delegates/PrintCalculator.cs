using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates;

public class PrintCalculator
{
    public decimal CalculateStandardCost(int copies)
    {
        decimal cost = 0.99M;

        return copies * cost;
    }

    public decimal CalculateDiscountedCost(int copies, decimal percentage)
    {
        decimal cost = 0.99M;        

        decimal amount = CalculateStandardCost(copies);

        return amount - amount * percentage;
    }
}
