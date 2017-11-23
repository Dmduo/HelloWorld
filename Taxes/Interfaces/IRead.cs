using System.Collections.Generic;
using Taxes.Models;

namespace Taxes
{
    internal interface IReader
    {
        List<Tax> Open();
    }
}