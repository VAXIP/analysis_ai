using System;
using System.Collections.Generic;

namespace Assistant.Domain.Entities;

public partial class SalesRecord
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public string? ProductCategory { get; set; }

    public int? UnitsSold { get; set; }

    public decimal? UnitPrice { get; set; }

    public DateOnly? SaleDate { get; set; }

    public string? SaleLocation { get; set; }
}
