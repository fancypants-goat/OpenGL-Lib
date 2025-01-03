


namespace Engine.Components;

public class Component (GameObject gameObject) : IDisposable
{
    public GameObject gameObject = gameObject;
    public Transform transform = gameObject.transform;
    
    public bool enabled = true;
    
    private bool disposed = false;
    
    
    public virtual void Update() { }
    
    
    
    
    
    public void Dispose()
    {
        if (disposed) return;
        
        Dispose(false);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool finalized) { }
    
    
    ~Component()
    {
        if (!disposed)
        {
            Console.WriteLine("Memory leak detected in Component. Did you forget to call Dispose()?");
            Dispose(true);
        }
    }
}
