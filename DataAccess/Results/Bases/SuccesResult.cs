using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Results.Bases
{
    public class SuccesResult : Result
    {
        public SuccesResult(string message) : base(true, message)
        {
        }

        public SuccesResult() : base(true, string.Empty) //stringEmpty = ""
        {
            
        }
    }
}
