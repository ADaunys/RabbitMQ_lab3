namespace Clients.Services;

/// <summary>
/// Structure for testing pass-by-value calls.
/// </summary>
public class WaterContainer
{
    /// <summary>
    /// Capacity
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// Upper bound
    /// </summary>
    public int UpperBound { get; set; }

    /// <summary>
    /// Lower bound
    /// </summary>
    public int LowerBound { get; set; }
}

/// <summary>
/// Service contract.
/// </summary>
public interface IService
{
    /// <summary>
    /// Check if liquid can be added to the capacity
    /// </summary>
    /// <returns>boolean</returns>
	bool CanAdd();

    /// <summary>
    /// Add liquid to the capacity
    /// </summary>
    /// <param name="amount">Amount of liquid to add</param>
    /// <returns>Amount of liquid to be added</returns>
    int Add(int amount);
}