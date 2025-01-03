using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;



namespace Engine;


public static class Input
{
	public static bool GetKeyDown (Key key)
	{
		return Program.main.KeyboardState.IsKeyPressed((Keys)key);
	}

	public static bool GetKeyUp (Key key)
	{
		return Program.main.KeyboardState.IsKeyReleased((Keys)key);
	}

	public static bool GetKey (Key key)
	{
		return Program.main.KeyboardState.IsKeyDown((Keys)key);
	}

	public static bool GetMouseDown (Key button)
	{
		return Program.main.MouseState.IsButtonPressed((MouseButton)button);
	}
	
	public static bool GetMouseUp (Key button)
	{
		return Program.main.MouseState.IsButtonReleased((MouseButton)button);
	}

	public static bool GetMouse (Key button)
	{
		return Program.main.MouseState.IsButtonDown((MouseButton)button);
	}

	public static Vector2 MouseMovement
	{
		get
		{
			return Program.main.MouseState.Delta;
		}
	}


	public static Vector2 MousePosition
	{
		get => Program.main.MousePosition + Program.main.Location;
	}
	public static Vector2 RelativeMousePosition
	{
		get => Program.main.MousePosition;
	}
}
