using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        
        public Result(bool success, string message) : this(success)//thisi eklememizin sebei successi eklemek zorundayız//constructora cok iyi bi örnek
        {
            Message = message;
        }
        public Result(bool success) 
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
