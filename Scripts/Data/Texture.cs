using OpenTK.Graphics.OpenGL4;
using StbImageSharp;


namespace Engine;

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
        //// add the start id of TextureUnit (Texture0) to get the id of the TextureUnit corresponding to textureUnit
        GL.ActiveTexture(TextureUnit.Texture0);
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
    
    
    
    
    
    
    
    
    /// <summary>
    /// Creates a texture from an image file. 
    /// Only change the values after mipmap if you know what you are doing and it is required!
    /// </summary>
    public static Texture FromFile(string path, bool mipmap = false, ColorComponents colorComponents = ColorComponents.RedGreenBlueAlpha, PixelInternalFormat pixelInternalFormat = PixelInternalFormat.Rgba, PixelFormat pixelFormat = PixelFormat.Rgba, PixelType pixelType = PixelType.UnsignedByte)
    {
        var texture = new Texture();
        
        texture.Use();
        
        StbImage.stbi_set_flip_vertically_on_load(1);
        
        ImageResult image = ImageResult.FromStream(File.OpenRead(path), colorComponents);
        
        
        if (image == null || image.Data == null) throw new Exception($"Failed to load texture form {path}");
        
        GL.TexImage2D(TextureTarget.Texture2D, 0, pixelInternalFormat, image.Width, image.Height, 0, pixelFormat, pixelType, image.Data);
        
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, mipmap ? (int)TextureMinFilter.LinearMipmapLinear : (int)TextureMinFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
        
        texture.Width = image.Width;
        texture.Height = image.Height;
        
        if (mipmap)
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            
        return texture;
    }
}
