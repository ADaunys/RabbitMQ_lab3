namespace Servers;

using NLog;


/// <summary>
/// Service logic.
/// </summary>
class ServiceLogic : IService 
{
	/// <summary>
	/// Logger for this class.
	/// </summary>
	private Logger log = LogManager.GetCurrentClassLogger();

	/// <summary>
	/// Add given numbers.
	/// </summary>
	/// <param name="left">Left number.</param>
	/// <param name="right">Right number.</param>
	/// <returns>left + right</returns>
	public int AddLiteral(int left, int right)
	{
		log.Info($"AddLiteral({left}, {right})");
		return left + right;
	}

	/// <summary>
	/// Add given numbers.
	/// </summary>
	/// <param name="leftAndRight">Numbers to add.</param>
	/// <returns>Left + Right in Sum</returns>
	public ByValStruct AddStruct(ByValStruct leftAndRight)
	{
		log.Info($"AddStruct(ByValStruct(Left={leftAndRight.Left}, Right={leftAndRight.Right}))");
		leftAndRight.Sum = leftAndRight.Left + leftAndRight.Right;
		return leftAndRight;
	}
}