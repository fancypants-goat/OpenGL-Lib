using OpenTK.Graphics.OpenGL4;
using StbImageSharp;


namespace OpenGL;

public class Texture : IDisposable
{
    public readonly int Handle;
    
    public int Width { get; private set; }
    public int Height { get; private set; }
    
    public int textureUnit;
    
    public bool disposed = false;
    
    
    private static int currentTextureUnit = 0;
    
    // maxTextureUnits is set in OnLoad() in Program.cs
    public static int maxTextureUnits = 0;
    
    // represents the id of the first texture unit (Texture0)
    // this is used to calculate the id of the used texture unit corresponding to textureUnit
    public static readonly int textureUnitStart = (int)TextureUnit.Texture0;
    
    
    
    public Texture(int width = 0, int height = 0)
    {
        Handle = GL.GenTexture();
        Width = width;
        Height = height;
        
        textureUnit = currentTextureUnit++;
        if (currentTextureUnit > maxTextureUnits)
            currentTextureUnit = 0;
    }
    
    
    
    
    
    public void Use()
    {
        // add the start id of TextureUnit (Texture0) to get the id of the TextureUnit corresponding to textureUnit
        GL.ActiveTexture((TextureUnit)textureUnitStart + textureUnit);
        GL.BindTexture(TextureTarget.Texture2D, Handle);
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
            GL.DeleteTexture(Handle);
        }
        
        disposed = true;
    }
    
    ~Texture()
    {
        if (!disposed)
        {
            Console.WriteLine("Memory leak detected in Texture. Did you forget to call Dispose()?");
            Dispose(true);
        }
    }
    
    
    
    
    
    
    
    
    
    public static Texture FromFile(string path, int mipmapLevel)
    {
        if (mipmapLevel < 0) mipmapLevel = 0;
        
        var texture = new Texture();
        
        texture.Use();
        
        StbImage.stbi_set_flip_vertically_on_load(1);
        
        ImageResult image = ImageResult.FromStream(File.OpenRead(path), ColorComponents.RedGreenBlueAlpha);
        
        if (image == null || image.Data == null) throw new Exception($"Failed to load texture form {path}");
        
        GL.TexImage2D(TextureTarget.Texture2D, mipmapLevel, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.Byte, image.Data);
        
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, mipmapLevel != 0 ? (int)TextureMinFilter.LinearMipmapLinear : (int)TextureMinFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
        
        texture.Width = image.Width;
        texture.Height = image.Height;
        
        if (mipmapLevel != 0)
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            
        return texture;
    }
}
