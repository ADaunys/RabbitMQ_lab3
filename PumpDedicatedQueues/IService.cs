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
    /// Check if liquid can be subtracted from the capacity
    /// </summary>
    /// <returns>boolean</returns>
    bool CanSubtract();

    /// <summary>
    /// Subtract liquid from the capacity
    /// </summary>
    /// <param name="amount">Amount of liquid to subtract</param>
    /// <returns>Amount of liquid to be subtracted</returns>
    int Subtract(int amount);
}