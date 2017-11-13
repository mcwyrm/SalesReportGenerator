using System;
using System.Linq;

namespace SalesReportGenerator
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute() { }

        public ColumnAttribute(string columnHeader)
        {
            _header = columnHeader;
        }

        public ColumnAttribute(int order)
        {
            this._order = order;
        }

        public ColumnAttribute(string columnHeader, int order) : this(columnHeader)
        {
            this._order = order;
        }

        private int _order = int.MaxValue;
        public int Order => _order;


        private string _header = string.Empty;
        public string ColumnHeader => _header;
    }
}
