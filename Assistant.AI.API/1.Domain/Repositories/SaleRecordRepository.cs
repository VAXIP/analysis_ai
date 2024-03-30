namespace Assistant.Domain.Repositories;

/// <summary>
/// Retrieves sales records within a specified date range.
/// </summary>
/// <param name="startDate">The start date of the range.</param>
/// <param name="endDate">The end date of the range.</param>
/// <returns>An IEnumerable of SalesRecord objects within the specified date range.</returns>

public class SalesRecordRepository(Context context) : ISalesRecordRepository
{
    private readonly Context _context = context;

    /// <summary>
    /// Retrieves sales records within a specified date range.
    /// </summary>
    /// <param name="startDate">The start date of the range.</param>
    /// <param name="endDate">The end date of the range.</param>
    /// <returns>An enumerable collection of sales records within the specified date range.</returns>
    public IEnumerable<SalesRecord> GetSalesByDateRange(DateOnly startDate, DateOnly endDate)
    {
        return [.. _context.SalesRecords.Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate).OrderBy(s => s.SaleDate)];
    }
}
