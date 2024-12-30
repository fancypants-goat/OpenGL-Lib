using System.Drawing;



namespace OpenGL;

public class Material
{
    public ShaderProgram shader;
    public Texture texture;
    public Color color;
    public bool useTexture;
}
