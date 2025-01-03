using Engine.Components;
using OpenTK.Mathematics;


namespace Engine;

public class Transform : Component
{
    private Vector3 _position;
    
    private Vector3 _size;
    
    private Vector3 _rotation;
    
    
    
    public Vector3 position
    {
        get => _position;
        set
        {
            _position = value;
            positionMatrix = Matrix4.CreateTranslation(_position);
            if (gameObject.parent != null)
                positionMatrix *= gameObject.parent.transform.positionMatrix;
        }
    }
    
    public Vector3 size
    {
        get => _size;
        set
        {
            _size = value;
            sizeMatrix = Matrix4.CreateScale(_size);
            if (gameObject.parent != null)
                sizeMatrix *= gameObject.parent.transform.sizeMatrix;
        }
    }
    
    public Vector3 rotation
    {
        get => _rotation;
        set
        {
            _rotation = value;
            rotationMatrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(_rotation.X))
                            *Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_rotation.Y))
                            *Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(_rotation.Z));
            if (gameObject.parent != null)
                rotationMatrix *= gameObject.parent.transform.rotationMatrix;
        }
    }
    
    public Matrix4 positionMatrix { get; private set; }
    public Matrix4 sizeMatrix { get; private set; }
    public Matrix4 rotationMatrix { get; private set; }
    
    
    
    
    public Vector3 Translate(Vector3 translation)
    {
        position += translation;
        return position;
    }
    public Vector3 Translate(float x, float y, float z)
    {
        position += new Vector3(x, y, z);
        return position;
    }
    
    
    
    public Transform(Vector3 position, Vector3 size, Vector3 rotation, GameObject go) : base(go)
    {
        this.position = position;
        this.size = size;
        this.rotation = rotation;
    }
}
