using System.Drawing;



namespace Engine;

public class Material
{
    public ShaderProgram shader;
    public Texture texture;
    public Color color;
    public bool useTexture;
    
    
    
    public void Use()
    {
        shader.Use();
        
        if (useTexture)
            texture.Use();
    }
}
