


namespace Engine;

public static class Time
{
	private static float _deltaTime;
	public static float deltaTime
	{
		get
		{
			return _deltaTime;
		} 
		internal set
		{
			_deltaTime = Math.Clamp(value, 0, 0.2f);
		}
	}

	private static float _deltaTimeMilliseconds;
	public static float deltaTimeMilliseconds
	{
		get
		{
			return _deltaTimeMilliseconds;
		}
		set
		{
			_deltaTimeMilliseconds = Math.Clamp(value, 0, 200);
		}
	}

	private static float _timeScale = 1f;
	public static float timeScale
	{
		get
		{
			return _timeScale;
		}
		set
		{
			_timeScale = Math.Clamp(value, 0, float.MaxValue);
		}
	}
}
