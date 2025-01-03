using System.Drawing;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;



namespace Engine;

public class ShaderProgram : IDisposable
{
    public readonly int Handle;
    
    private Shader[] shaders;
    
    
    
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
    
    
    
    
    public void SetUniform1(string name, float value) => GL.Uniform1(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform1(string name, int value) => GL.Uniform1(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform1(string name, long value) => GL.Uniform1(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform1(string name, double value) => GL.Uniform1(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform1(string name, bool value) => GL.Uniform1(GL.GetUniformLocation(Handle, name), value ? 1 : 0);
    
    public void SetUniform2(string name, (float, float) value) => GL.Uniform2(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform2(string name, float a, float b) => GL.Uniform2(GL.GetUniformLocation(Handle, name), a, b);
    public void SetUniform2(string name, (int, int) value) => GL.Uniform2(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform2(string name, int a, int b) => GL.Uniform2(GL.GetUniformLocation(Handle, name), a, b);
    public void SetUniform2(string name, (long, long) value) => GL.Uniform2(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform2(string name, long a, long b) => GL.Uniform2(GL.GetUniformLocation(Handle, name), a, b);
    public void SetUniform2(string name, (double, double) value) => GL.Uniform2(GL.GetUniformLocation(Handle, name), value.Item1, value.Item2);
    
    public void SetUniform3(string name, (float, float, float) value) => GL.Uniform3(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform3(string name, float a, float b, float c) => GL.Uniform3(GL.GetUniformLocation(Handle, name), a, b, c);
    public void SetUniform3(string name, (int, int, int) value) => GL.Uniform3(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform3(string name, int a, int b, int c) => GL.Uniform3(GL.GetUniformLocation(Handle, name), a, b, c);
    public void SetUniform3(string name, (long, long, long) value) => GL.Uniform3(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform3(string name, long a, long b, long c) => GL.Uniform3(GL.GetUniformLocation(Handle, name), a, b, c);
    public void SetUniform3(string name, double a, double b, double c) => GL.Uniform3(GL.GetUniformLocation(Handle, name), a, b, c);
    
    public void SetUniform4(string name, (float, float, float, float) value) => GL.Uniform4(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform4(string name, float a, float b, float c, float d) => GL.Uniform4(GL.GetUniformLocation(Handle, name), a, b, c, d);
    public void SetUniform4(string name, (int, int, int, int) value) => GL.Uniform4(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform4(string name, int a, int b, int c, int d) => GL.Uniform4(GL.GetUniformLocation(Handle, name), a, b, c, d);
    public void SetUniform4(string name, (long, long, long, long) value) => GL.Uniform4(GL.GetUniformLocation(Handle, name), value);
    public void SetUniform4(string name, long a, long b, long c, long d) => GL.Uniform4(GL.GetUniformLocation(Handle, name), a, b, c, d);
    public void SetUniform4(string name, double a, double b, double c, double d) => GL.Uniform4(GL.GetUniformLocation(Handle, name), a, b, c, d);
    public void SetUniform4(string name, Color4 color) => GL.Uniform4(GL.GetUniformLocation(Handle, name), color);
    
    public void SetUniformMatrix2(string name, Matrix2 value, bool transpose = false) => GL.UniformMatrix2(GL.GetUniformLocation(Handle, name), transpose, ref value);
    public void SetUniformMatrix3(string name, Matrix3 value, bool transpose = false) => GL.UniformMatrix3(GL.GetUniformLocation(Handle, name), transpose, ref value);
    public void SetUniformMatrix4(string name, Matrix4 value, bool transpose = false) => GL.UniformMatrix4(GL.GetUniformLocation(Handle, name), transpose, ref value);
    
    
    
    
    
    
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
