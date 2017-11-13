using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesReportGenerator
{
    public interface IReportRow
    {
        IEnumerable<string> ColumnHeaders { get; }
        IEnumerable<string> ToReportRow();
    }
}
