using Dapper;
using JasonMoney.Domain.Entries;
using System;
using System.Collections.Generic;
using System.Data;

namespace JasonMoney.Infrastructure.Core;

/// <summary>
/// Extensions that convert a collection into Dapper's table-valued parameter
/// so they can be passed to a stored procedure as a user-defined table type.
/// </summary>
public static class EnumerableToTvpExtensions
{
    /// <summary>
    /// Create a Dapper table-valued parameter of entry transactions 
    /// to use with EntryTransactionRequest user-defined table type.
    /// </summary>
    /// <param name="transactions"> Enumerable of transactions. </param>
    /// <returns> A hydrated table-valued parameter. </returns>
    public static SqlMapper.ICustomQueryParameter ToTableValuedParameter(this IEnumerable<EntryTransaction> transactions)
        => ToDataTable(transactions).AsTableValuedParameter("[entries].[EntryTransactionRequest]");

    internal static DataTable ToDataTable(IEnumerable<EntryTransaction> transactions)
    {
        var table = new DataTable();

        table.Columns.Add(new DataColumn("CategoryId", typeof(int)) { AllowDBNull = true, });
        table.Columns.Add(new DataColumn("Amount", typeof(decimal)) { AllowDBNull = false, });
        table.Columns.Add(new DataColumn("CurrencyCode", typeof(string)) { AllowDBNull = false, });
        table.Columns.Add(new DataColumn("Memo", typeof(string)) { AllowDBNull = true, });

        foreach (var txn in transactions)
            table.Rows.Add(txn.Category?.Id ?? Convert.DBNull, txn.Amount, txn.CurrencyCode, txn.Memo ?? Convert.DBNull);

        return table;
    }

    public static SqlMapper.ICustomQueryParameter ToTableValuedParameter(this IEnumerable<Guid> ids)
        => ToDataTable(ids).AsTableValuedParameter("[dbo].[GuidIdRequest]");

    public static SqlMapper.ICustomQueryParameter ToTableValuedParameter(this IEnumerable<int> ids)
        => ToDataTable(ids).AsTableValuedParameter("[dbo].[IntIdRequest]");

    internal static DataTable ToDataTable<T>(IEnumerable<T> ids) where T : struct
    {
        var table = new DataTable();

        table.Columns.Add(new DataColumn("Id", typeof(T)) { AllowDBNull = false, });

        foreach (var slug in ids)
            table.Rows.Add(slug);

        return table;
    }
}
