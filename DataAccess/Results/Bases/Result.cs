using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Results.Bases
{
    public abstract class Result
    {
        public bool IsSuccesful { get; }
        public string Message { get; }

        protected Result(bool isSuccesful, string message)
        {
            IsSuccesful = isSuccesful;
            Message = message;
        }
    }
}
