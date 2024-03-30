
namespace Assistant.Domain.Repositories.Interfaces
{

    /// <summary>
    /// Represents a repository for accessing sales records.
    /// </summary>
    public interface ISalesRecordRepository
    {
        /// <summary>
        /// Retrieves sales records within a specified date range.
        /// </summary>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>An enumerable collection of sales records.</returns>
        IEnumerable<SalesRecord> GetSalesByDateRange(DateOnly startDate, DateOnly endDate);
    }
}
