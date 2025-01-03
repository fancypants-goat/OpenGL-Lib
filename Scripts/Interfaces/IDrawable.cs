


namespace Engine.Interfaces;

public interface IDrawable
{
    // stores all registered drawables
    public static List<IDrawable> drawables { get; } = [];
    
    
    public Material material { get; set; }
    
    
    
    abstract public void Draw();
}
