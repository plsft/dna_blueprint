using System.Collections.Generic;
using Blue.Data.Models;

namespace Blue.Library.Api
{
    public interface IDataResult
    {
        IEnumerable<IModel> Results { get; set; }

        string Message { get; set; }

        bool Success { get; set; }

        //int Nonce { get; set; }

        //string Token { get; set; }

    }
}
