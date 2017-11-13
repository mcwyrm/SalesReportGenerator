using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SalesReportGenerator
{
    public class ReportRow<T> : IReportRow where T : class
    {
        readonly T content;
        public ReportRow(T content)
        {
            this.content = content;
        }

        public IEnumerable<string> ColumnHeaders
        {
            get
            {
                return typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Where(prop => Attribute.IsDefined(prop, typeof(ColumnAttribute)))
                        .OrderBy(o => (o.GetCustomAttribute(typeof(ColumnAttribute)) as ColumnAttribute).Order)
                        .Select(p => (string.IsNullOrEmpty((p.GetCustomAttribute(typeof(ColumnAttribute)) as ColumnAttribute).ColumnHeader)
                                                ? p.Name : (p.GetCustomAttribute(typeof(ColumnAttribute)) as ColumnAttribute).ColumnHeader));
            }
        }

        public IEnumerable<string> ToReportRow()
        {
            return typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                       .Where(prop => Attribute.IsDefined(prop, typeof(ColumnAttribute)))
                       .OrderBy(o => (o.GetCustomAttribute(typeof(ColumnAttribute)) as ColumnAttribute).Order)
                       .Select(p => content == null ? string.Empty : p.GetValue(content, null) == null ? string.Empty : p.GetValue(content, null).ToString());
        }
    }
}
