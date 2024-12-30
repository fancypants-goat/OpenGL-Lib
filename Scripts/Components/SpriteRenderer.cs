using OpenGL.Components;
using OpenGL.Interfaces;



namespace OpenGL;

public class SpriteRenderer : Component, IDrawable, IDisposable
{
    // ----- ALL THE VERTICES SHIT ----- //
    protected static float[] vertices =
    [// Position             Texture Coordinates
    // Front face
    -0.05f, -0.05f,  0.05f,  0.0f, 0.0f,  // Bottom-left
     0.05f, -0.05f,  0.05f,  1.0f, 0.0f,  // Bottom-right
    -0.05f,  0.05f,  0.05f,  0.0f, 1.0f,  // Top-left
     0.05f,  0.05f,  0.05f,  1.0f, 1.0f,  // Top-right

    // Back face
    -0.05f, -0.05f, -0.05f,  0.0f, 0.0f,  // Bottom-left
     0.05f, -0.05f, -0.05f,  1.0f, 0.0f,  // Bottom-right
    -0.05f,  0.05f, -0.05f,  0.0f, 1.0f,  // Top-left
     0.05f,  0.05f, -0.05f,  1.0f, 1.0f,  // Top-right

    // Top face
    -0.05f,  0.05f,  0.05f,  0.0f, 0.0f,  // Front-left
     0.05f,  0.05f,  0.05f,  1.0f, 0.0f,  // Front-right
    -0.05f,  0.05f, -0.05f,  0.0f, 1.0f,  // Back-left
     0.05f,  0.05f, -0.05f,  1.0f, 1.0f,  // Back-right

    // Bottom face
    -0.05f, -0.05f,  0.05f,  0.0f, 0.0f,  // Front-left
     0.05f, -0.05f,  0.05f,  1.0f, 0.0f,  // Front-right
    -0.05f, -0.05f, -0.05f,  0.0f, 1.0f,  // Back-left
     0.05f, -0.05f, -0.05f,  1.0f, 1.0f,  // Back-right

    // Left face
    -0.05f, -0.05f, -0.05f,  0.0f, 0.0f,  // Bottom-back
    -0.05f,  0.05f, -0.05f,  1.0f, 0.0f,  // Top-back
    -0.05f, -0.05f,  0.05f,  0.0f, 1.0f,  // Bottom-front
    -0.05f,  0.05f,  0.05f,  1.0f, 1.0f,  // Top-front

    // Right face
     0.05f, -0.05f, -0.05f,  0.0f, 0.0f,  // Bottom-back
     0.05f,  0.05f, -0.05f,  1.0f, 0.0f,  // Top-back
     0.05f, -0.05f,  0.05f,  0.0f, 1.0f,  // Bottom-front
     0.05f,  0.05f,  0.05f,  1.0f, 1.0f,  // Top-front
    ];
    protected static uint[] indices =
    [
    // Front face
    0, 1, 3, 0, 3, 2,

    // Back face
    4, 5, 7, 4, 7, 6,

    // Top face
    8, 9, 11, 8, 11, 10,

    // Bottom face
    12, 13, 15, 12, 15, 14,

    // Left face
    16, 17, 19, 16, 19, 18,

    // Right face
    20, 21, 23, 20, 23, 22
    ];
    
    
    
    
    
    
    // ----- OTHER STUFF THAT IS ACTUALLY IMPORTANT ----- //
    public Material material { get; set; }
    
    
    
    
    public SpriteRenderer(Material material, GameObject go) : base(go)
    {
        IDrawable.drawables.Add(this);
        
        this.material = material;
    }
    
    
    

    public void Draw()
    {
        throw new NotImplementedException();
    }
}
