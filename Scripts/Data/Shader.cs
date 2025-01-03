using OpenTK.Graphics.OpenGL4;


namespace Engine;

public struct Shader : IDisposable
{
    public string location;
    public ShaderType type; // has the same id as the OpenTK version of ShaderType.*type*
    
    public string source { get; private set; }
    public int shaderHandle { get; private set; }
    
    
    bool disposed = false;
    
    
    
    
    public void Compile()
    {
        source = File.ReadAllText(location);
            
        // ShaderType.* have the same ID as the OpenTK version of ShaderType.*
        // thus we can convert it instantly
        shaderHandle = GL.CreateShader((OpenTK.Graphics.OpenGL4.ShaderType)type);
        GL.ShaderSource(shaderHandle, source);
        
        // compile the shaders and check for errors
        GL.CompileShader(shaderHandle);
        
        GL.GetShader(shaderHandle, ShaderParameter.CompileStatus, out int compileStatus);
        if (compileStatus == 0)
        {
            string infoLog = GL.GetShaderInfoLog(shaderHandle);
            Console.WriteLine(infoLog);
        }
    }
    
    public Shader(string location, ShaderType type)
    {
        this.location = location;
        this.type = type;
        
        Compile();
    }
    
    
    public Shader()
    {
        Compile();
    }
    
    
    
    
    
    public void Dispose()
    {
        if (disposed) return;
        
        GL.DeleteShader(shaderHandle);
        disposed = true;
    }
}
