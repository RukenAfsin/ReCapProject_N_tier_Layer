using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    //temel voidler için tutuyoruz bunu
    public interface IResult
    {
        bool Success {  get; }  // get sadece okunabilir demektir.işlem başarılı mı başarısız mı
        string Message { get; }
    }
}
