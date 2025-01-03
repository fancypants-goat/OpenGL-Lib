using System.Drawing;
using Engine.Components;
using Engine.Interfaces;
using Engine.OpenGL;
using OpenTK.Graphics.OpenGL4;



namespace Engine;

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
    
    // will be replaced with a default class containing default shaders and materials
    private readonly static ShaderProgram _defaultShader = new(
        new Shader(Assets.GetFilePath("Shaders/default/sprite/shader.vert"), ShaderType.VertexShader),
        new Shader(Assets.GetFilePath("Shaders/default/sprite/shader.frag"), ShaderType.FragmentShader));
    
    
    
    int vao;
    int vbo;
    int ebo;
    
    
    // ----- OTHER STUFF THAT IS ACTUALLY IMPORTANT ----- //
    public Material material { get; set; }
    
    
    
    
    public SpriteRenderer(Material material, GameObject go) : base(go)
    {
        IDrawable.drawables.Add(this);
        
        this.material = material;
        
        Create();
    }
    public SpriteRenderer(Texture texture, Color color, GameObject go) : base(go)
    {
        IDrawable.drawables.Add(this);
        
        this.material = new Material
        {
            shader = _defaultShader,
            texture = texture,
            color = color,
            useTexture = true
        };
        
        Create();
    }
    public SpriteRenderer(Color color, GameObject go) : base(go)
    {
        IDrawable.drawables.Add(this);
        
        this.material = new Material
        {
            shader = _defaultShader,
            color = color,
            useTexture = false
        };
        
        Create();
    }
    
    protected void Create()
    {
        vao = GL.GenVertexArray();
        vbo = GL.GenBuffer();
        ebo = GL.GenBuffer();
        
        GL.BindVertexArray(vao);
        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
        
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
        GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
        
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
        GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
        
        GL.EnableVertexAttribArray(0);
        GL.EnableVertexAttribArray(1);
        
        GL.BindVertexArray(0);
    }
    
    
    

    public void Draw()
    {
        GL.BindVertexArray(vao);
        
        material.Use();
        
        material.shader.SetUniformMatrix4("model", transform.positionMatrix * transform.rotationMatrix * transform.sizeMatrix);
        material.shader.SetUniformMatrix4("projection", Camera.main.Projection);
        material.shader.SetUniformMatrix4("view", Camera.main.View);
        material.shader.SetUniform4("color", material.color);
        material.shader.SetUniform1("useTexture", material.useTexture ? 1 : 0);
        
        GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}
