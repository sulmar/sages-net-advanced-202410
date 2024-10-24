using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskExample
{
    public class VoteService
    {
        Random random = new Random();

        public bool Get()
        {
            "Voting".DumpThreadId();

            Thread.Sleep(1000);

            bool result = random.Next(1, 100) % 2 == 0;

            $"Voted. Result {result}".DumpThreadId();

            return result;
        }
    }
}
