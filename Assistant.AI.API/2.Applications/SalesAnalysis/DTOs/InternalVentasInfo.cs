namespace Assistant.Applications.DTO;

/// <summary>
/// Represents the internal sales information.
/// </summary>
public class InternalVentasInfo
{
    /// <summary>
    /// Gets or sets the dictionary of most sold products.
    /// </summary>
    public Dictionary<string, int> ProductosMasVendidos { get; set; } = []; 

    /// <summary>
    /// Gets or sets the dictionary of categories with highest demand.
    /// </summary>
    public Dictionary<string, int> CategoriasConMayorDemanda { get; set; }= []; 

    /// <summary>
    /// Gets or sets the dictionary of most profitable products.
    /// </summary>
    public Dictionary<string, decimal> ProductosMasRentables { get; set; }= []; 

    /// <summary>
    /// Gets or sets the dictionary of most profitable categories.
    /// </summary>
    public Dictionary<string, decimal> CategoriasMasRentables { get; set; }= []; 
}
