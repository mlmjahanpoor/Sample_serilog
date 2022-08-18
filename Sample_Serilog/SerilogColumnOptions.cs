using Serilog.Sinks.MSSqlServer;
using System.Data;

namespace Sample_Serilog
{
    public class SerilogColumnOptions
    {
        public static ColumnOptions GetColumnOptions()
        {
            var columnOptions = new ColumnOptions();
            columnOptions.Store.Remove(StandardColumn.Exception);
            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            // Remove all the StandardColumn
            //columnOptions.Store.Remove(StandardColumn.MessageTemplate);

            // Override the default Primary Column of Serilog by your custom column name
            columnOptions.Id.ColumnName = "LogId";

            // Add all the custom coumns
            columnOptions.AdditionalColumns = new List<SqlColumn>
    {
        new SqlColumn { DataType= SqlDbType.NVarChar, ColumnName = "C2" },
        new SqlColumn { DataType = SqlDbType.NVarChar, ColumnName = "C3" },
    };
            return columnOptions;
        }
    }
}