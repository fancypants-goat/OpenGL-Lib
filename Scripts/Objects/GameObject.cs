using System.Drawing;
using Engine.Components;
using OpenTK.Mathematics;



namespace Engine;

public class GameObject : IDisposable
{
    // contains all the objects that have no parent
    // these are refered to as root objects
    public static List<GameObject> rootObjects = [];
    
    
    
    
    
    
    // this is seen as the identification for this object, but can still have multiple of the same
    public string name;
    
    // if this object itself is active
    public bool isActive;
    // if this object is active on global scale
    // if any parents (or itself) are inactive, this will be false
    public bool isGloballyActive;
    
    
    public GameObject? parent { get; private set; }
    private List<GameObject> children;
    
    
    private List<Component> components;
    
    
    public Transform transform;
    
    
    private bool disposed = false;
    
    
    
    public GameObject(string name, bool isActive = true)
    {
        rootObjects.Add(this);
        
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        this.parent = null;
        
        this.components = [];
        
        this.transform = AddComponent<Transform>(Vector3.Zero, Vector3.Zero, Vector3.Zero);
    }
    
    public GameObject(string name, GameObject parent, bool isActive = true)
    {
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        SetParent(parent);
        
        this.components = [];
        
        this.transform = AddComponent<Transform>(Vector3.Zero, Vector3.Zero, Vector3.Zero);
    }
    
    public GameObject(string name, Transform transform, bool isActive = true)
    {
        rootObjects.Add(this);
        
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        this.parent = null;
        
        this.components = [];
        
        this.transform = transform;
        this.transform.gameObject = this;
        components.Add(this.transform);
    }
    
    public GameObject(string name, GameObject parent, Transform transform, bool isActive = true)
    {
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        SetParent(parent);
        
        this.components = [];
        
        this.transform = transform;
        this.transform.gameObject = this;
        components.Add(this.transform);
    }
    
    public GameObject(string name, Vector3 position, Vector3 size, Vector3 rotation, bool isActive = true)
    {
        rootObjects.Add(this);
        
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        this.parent = null;
        
        this.components = [];
        
        this.transform = AddComponent<Transform>(position, size, rotation);
    }
    
    public GameObject(string name, GameObject parent, Vector3 position, Vector3 size, Vector3 rotation, bool isActive = true)
    {
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        SetParent(parent);
        
        this.components = [];
        
        this.transform = AddComponent<Transform>(position, size, rotation);
    }
    
    public GameObject(string name, Transform transform, Material material, bool isActive = true)
    {
        rootObjects.Add(this);
        
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        this.parent = null;
        
        this.components = [];
        
        this.transform = transform;
        this.transform.gameObject = this;
        components.Add(this.transform);
        
        AddComponent<SpriteRenderer>(material);   
    }
    
    public GameObject(string name, GameObject parent, Transform transform, Material material, bool isActive = true)
    {
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        SetParent(parent);
        
        this.components = [];
        
        this.transform = transform;
        this.transform.gameObject = this;
        components.Add(this.transform);
        
        AddComponent<SpriteRenderer>(material);  
    }
    
    public GameObject(string name, Vector3 position, Vector3 size, Vector3 rotation, Material material, bool isActive = true)
    {
        rootObjects.Add(this);
        
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        this.parent = null;
        
        this.components = [];
        
        this.transform = AddComponent<Transform>(position, size, rotation);
        
        AddComponent<SpriteRenderer>(material);  
    }
    
    public GameObject(string name, GameObject parent, Vector3 position, Vector3 size, Vector3 rotation, Material material, bool isActive = true)
    {
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        SetParent(parent);
        
        this.components = [];
        
        this.transform = AddComponent<Transform>(position, size, rotation);
        
        AddComponent<SpriteRenderer>(material);  
    }
    
    public GameObject(string name, Transform transform, Color color, bool isActive = true)
    {
        rootObjects.Add(this);
        
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        this.parent = null;
        
        this.components = [];
        
        this.transform = transform;
        this.transform.gameObject = this;
        components.Add(this.transform);
        
        AddComponent<SpriteRenderer>(color);
    }
    
    public GameObject(string name, GameObject parent, Transform transform, Color color, bool isActive = true)
    {
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        SetParent(parent);
        
        this.components = [];
        
        this.transform = transform;
        this.transform.gameObject = this;
        components.Add(this.transform);
        
        AddComponent<SpriteRenderer>(color);
    }
    
    public GameObject(string name, Vector3 position, Vector3 size, Vector3 rotation, Color color, bool isActive = true)
    {
        rootObjects.Add(this);
        
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        this.parent = null;
        
        this.components = [];
        
        this.transform = AddComponent<Transform>(position, size, rotation);
        
        AddComponent<SpriteRenderer>(color);
    }
    
    public GameObject(string name, GameObject parent, Vector3 position, Vector3 size, Vector3 rotation, Color color, bool isActive = true)
    {
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        SetParent(parent);
        
        this.components = [];
        
        this.transform = AddComponent<Transform>(position, size, rotation);
        
        AddComponent<SpriteRenderer>(color);
    }
    
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public GameObject(string name, Transform transform, Texture texture, Color color, bool isActive = true)
    {
        rootObjects.Add(this);
        
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        this.parent = null;
        
        this.components = [];
        
        this.transform = transform;
        this.transform.gameObject = this;
        components.Add(this.transform);
        
        AddComponent<SpriteRenderer>(texture, color);
    }
    
    public GameObject(string name, GameObject parent, Transform transform, Texture texture, Color color, bool isActive = true)
    {
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        SetParent(parent);
        
        this.components = [];
        
        this.transform = transform;
        this.transform.gameObject = this;
        components.Add(this.transform);
        
        AddComponent<SpriteRenderer>(texture, color);
    }
    
    public GameObject(string name, Vector3 position, Vector3 size, Vector3 rotation, Texture texture, Color color, bool isActive = true)
    {
        rootObjects.Add(this);
        
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        this.parent = null;
        
        this.components = [];
        
        this.transform = AddComponent<Transform>(position, size, rotation);
        
        AddComponent<SpriteRenderer>(texture, color);
    }
    
    public GameObject(string name, GameObject parent, Vector3 position, Vector3 size, Vector3 rotation, Texture texture, Color color, bool isActive = true)
    {
        this.name = name;
        
        this.isActive = isActive;
        this.isGloballyActive = isActive;
        
        this.children = [];
        SetParent(parent);
        
        this.components = [];
        
        this.transform = AddComponent<Transform>(position, size, rotation);
        
        AddComponent<SpriteRenderer>(texture, color);
    }
    
    
    
    
    //
    // OBJECT LOGIC
    public void UpdateObject()
    {
        isGloballyActive = (parent == null || parent.isGloballyActive) && isActive;
        
        foreach (var child in children)
        {
            child.UpdateObject();
        }
    }
    
    
    
    //
    // OBJECT HIERARCHY
    
    public void SetParent(GameObject? parent)
    {
        // this adds this object as a root object if the parent is set to null (so this object will be parentles)
        // or removes it from root objects (if it was even there in the first place) if an actual parent is being set
        if (parent == null)
            rootObjects.Add(this);
        else
            rootObjects.Remove(this);
        
        // first remove this object as child from previous parent
        this.parent?.children.Remove(this); // if this.parent is not null
        
        // then re-set the parent of this object to the new parent
        this.parent = parent;
        
        // and last add this object as a child to the new parent
        this.parent?.children.Add(this); // if this.parent is not null
    }
    
    
    public void AddChild(GameObject child)
    {
        // yes you could implement logic to add the child
        // but SetParent does the exact same thing
        // except the child takes in the parent instead of the other way around
        child.SetParent(this); 
    }
    
    public void AddChildren (params GameObject[] children)
    {
        // this does the exact same thing as AddChild except for multiple.
        // see AddChild(GameObject child) for more info
        foreach (var child in children)
        {
            child.SetParent(this);
        }
    }
    
    
    
    
    
    
    //
    // COMPONENT SYSTEM
    
    public T AddComponent<T>(params object[] args) where T : Component
    {
        object[] fullArgs = new object[args.Length + 1];
        Array.Copy(args, fullArgs, args.Length);
        fullArgs[^1] = this;
        
        T component = (T)Activator.CreateInstance(typeof(T), fullArgs);
        
        if (component == null) throw new Exception($"Failed to create component of type {typeof(T)} in AddComponent<T>");
        
        components.Add(component);
        
        return component;
    }
    
    
    public T GetComponent<T>(bool includeDisabled = true) where T : Component
    {
        foreach (var component in components)
        {
            if (component is T c)
            {
                if (!includeDisabled && !component.enabled) continue;
                
                Console.WriteLine(c.GetType().Name);
                return c;
            }
        }
        
        return null;
    }
    
    
    public void RemoveComponent<T>(bool includeDisabled = true) where T : Component
    {
        foreach (var component in components)
        {
            if (component is T)
            {
                if (!includeDisabled && !component.enabled) continue;
                
                components.Remove(component);
            }
        }
    }
    public void RemoveComponent(int index)
    {
        components.RemoveAt(index);
    }
    
    
    //
    // DIPOSE, GC AND DECONSTRUCTOR
    
    public void Dispose()
    {
        Dispose(false);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool finalized)
    {
        if (disposed) return;
        
        if (!finalized)
        {
            foreach (var child in children)
            {
                child.SetParent(parent);
            }
            SetParent(null);
            
            foreach (var component in components)
            {
                component.Dispose();
            }
        }
        
        
        rootObjects.Remove(this);
        disposed = true;
    }
    
    ~GameObject()
    {
        if (!disposed)
        {
            Console.WriteLine("Memory leak detected in GameObject! Did you forget to call Dispose()?");
            Dispose(true);
        }
    }
}
