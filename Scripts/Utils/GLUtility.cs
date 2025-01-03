using OpenTK.Graphics.OpenGL4;


namespace Engine.OpenGL;

public static class GLUtility
{
    public static bool CheckError()
    {
        ErrorCode error = GL.GetError();
        if (error != ErrorCode.NoError)
        {
            Console.WriteLine(error);
            return true;
        }
        return false;
    }
    
    public static bool CheckError(params ErrorCode[] specificErrors)
    {
        ErrorCode error = GL.GetError();
        
        if ((specificErrors.Length == 0 && error != ErrorCode.NoError) || specificErrors.Any(e => e == error))
        {
            Console.WriteLine(error);
            return true;
        }
        
        return false;
    }
}
