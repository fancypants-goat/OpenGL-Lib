using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;

namespace Engine;

// TODO: create an isActive thingy

public class Camera
{

	private static Camera _main;
	public static Camera main
	{
		get
		{
			if (_main == null)
			{
				throw new NullReferenceException("no main camera set!");
			}
			else
			{
				return _main;
			}
		}
		set
		{
			_main = value;
		}
	}

	public CameraType camera;


	public float size;


	public float near;
	public float far;

	public Vector3 position;
	private Vector3 _cameraPosition;
	public Vector3 rotation;
	public Matrix4 rotationMatrix;

	public Matrix4 Projection;
	public Matrix4 View;



	public Camera (CameraType type, Vector3 position, Vector3 rotation, float size, float near, float far, bool isMain = false)
	{
		this.camera = type;
        
		this.position = position;
		this._cameraPosition = position / 10;
		this.rotation = rotation;

		this.near = near;
		this.far = far;

        this.size = size;

		UpdateCamera(Program.main.Size.X, Program.main.Size.Y);

		if (isMain) main = this;
	}


	public void UpdateCamera (float width, float height)
	{
		if (camera == CameraType.Orthographic) UpdateOrthograhpicProjection(width, height);
		if (camera == CameraType.Perspective) UpdatePerspectiveProjection(width, height);

		this._cameraPosition = this.position / 10;
		
		UpdateView();
	}
	public void UpdateOrthograhpicProjection (float width, float height)
	{
		// calculate the aspect ratio
		float aspectRatio = width / height;
		// create a new projection matrix for an offcenter orthographic camera
		Projection = Matrix4.CreateOrthographicOffCenter
			(size * aspectRatio, -size * aspectRatio,
			-size, size,
			near, far);
	}
	public void UpdatePerspectiveProjection (float width, float height)
	{
		size = Math.Clamp(size, 0.001f , 180);
		near = Math.Clamp(near, 0.001f, far);
		far =  Math.Clamp(far, near, float.PositiveInfinity);

		float aspectRatio = width / height;

		Projection = Matrix4.CreatePerspectiveFieldOfView(
			MathHelper.DegreesToRadians(size), aspectRatio,
			near, far);

		Projection *= Matrix4.CreateScale(-1, 1, 1);
	}

	public void UpdateView ()
	{
		rotationMatrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.X))
			* Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y))
			* Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotation.Z));


		Vector3 target = _cameraPosition + rotationMatrix.Row2.Xyz;
		Vector3 upDirection = rotationMatrix.Row1.Xyz;



		View = Matrix4.LookAt(_cameraPosition, target, upDirection);
	}


	/// <summary>
	/// converts a given screen space coordinate to a place in the virtual game world
	/// <para>not implemented yet though</para>
	/// </summary>
	/// <param name="screenSpace">the coordinate that has to be converted to world space</param>
	/// <returns>the converted screen space</returns>
	public Vector2 ScreenToWorldSpace (Vector2 screenSpace)
	{
		// TODO: create function
		throw new NotImplementedException("Method ScreenToWorldSpace has not been implemented yet.");
	}

	/// <summary>
	/// gets the forwards direction of this camera. <br>
	/// this is towards the positive Z axis on the local axes
	/// </summary>
	/// <returns>the forwards direction</returns>
	public Vector3 GetForwardsDirection()
	{
		return Vector3.Normalize((new Vector4(Vector3.UnitZ, 1f) * rotationMatrix).Xyz);
	}
	/// <summary>
	/// gets the right direction of this camera. <br>
	/// this is towards the positive X axis on the local axes
	/// </summary>
	/// <returns>the direction facing the right</returns>
	public Vector3 GetRightDirection()
	{
		return Vector3.Normalize((new Vector4(Vector3.UnitX, 1f) * rotationMatrix).Xyz);
	}
	/// <summary>
	/// gets the upwards direction of this camera. <br>
	/// this is towards the positive Y axis on the local axes
	/// </summary>
	/// <returns>the upwards direction</returns>
	public Vector3 GetUpDirection()
	{
		return Vector3.Normalize((new Vector4(Vector3.UnitY, 1f) * rotationMatrix).Xyz);
	}
	/// <summary>
	/// gets the forwards direction of this camera on the XZ plane. ignores the Y axis <br>
	/// this is towards the Z axis on the local axes
	/// </summary>
	/// <returns>the forwards direction on the XZ plane</returns>
	public Vector3 GetHorizontalForwardsDirection()
	{
		return Vector3.Normalize((new Vector4(Vector3.UnitZ, 1f) * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y))).Xyz);
	}
	/// <summary>
	/// gets the right direction of this camera on the XZ plane. ignores the Y axis <br>
	/// this is towards the X axis on the local axes
	/// </summary>
	/// <returns>the right direction on the XZ plane</returns>
	public Vector3 GetHorizontalRightDirection()
	{
		return Vector3.Normalize((new Vector4(Vector3.UnitX, 1f) * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y))).Xyz);
	}
}





public enum CameraType
{
	Orthographic,
	Perspective,
}
