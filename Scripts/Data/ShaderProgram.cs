using OpenTK;
using OpenTK.Graphics.OpenGL4;



namespace OpenGL;

public class ShaderProgram : IDisposable
{
    public readonly int Handle;
    
    public Shader[] shaders;
    
    
    
    bool disposed = false;
    
    
    public ShaderProgram(params Shader[] shaders)
    {
        this.shaders = shaders;
        
        Handle = GL.CreateProgram();
        
        // the shaders are automatically compiled upon creation, so we only need to attach them
        foreach (var shader in shaders)
        {
            GL.AttachShader(Handle, shader.shaderHandle);
        }
        
        
        GL.LinkProgram(Handle);
        
        GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out int linkStatus);
        if (linkStatus == 0)
        {
            string infoLog = GL.GetProgramInfoLog(Handle);
            Console.WriteLine(infoLog);
        }
        
        
        foreach (var shader in shaders)
        {
            GL.DetachShader(Handle, shader.shaderHandle);
        }
    }
    
    
    
    public void Use()
    {
        GL.UseProgram(Handle);
    }
    
    
    
    
    
    public void Dispose()
    {
        Dispose(false);
        GC.SuppressFinalize(this);
    }
    
    private void Dispose(bool finalized)
    {
        if (disposed) return;
        
        
        if (!finalized)
        {
            foreach (var shader in shaders)
            {
                shader.Dispose();
            }
        }
        
        GL.DeleteProgram(Handle);
        disposed = true;
    } 
    
    ~ShaderProgram()
    {
        if (!disposed)
        {
            Console.WriteLine("Memory leak detected in ShaderProgram! Did you forget to call Dispose()?");
            Dispose(true);
        }
    }
}
