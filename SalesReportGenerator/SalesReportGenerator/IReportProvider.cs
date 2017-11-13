using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SalesReportGenerator
{
    public interface IReportProvider
    {
        Stream ReadReport();
    }
}
