using System.Drawing;
using OpenTK.Mathematics;
using Engine;



namespace Test;

public class Game : Program
{
    public static readonly float speed = 10;
    
    public override void Create()
    {
        new Camera(CameraType.Perspective, new Vector3(0, 0, -10), new Vector3(0), 100, 0, 1000, isMain: true);
        
        new GameObject("OpenGL-Logo", new Vector3(0), new Vector3(20, 20, 0), new Vector3(0), Texture.FromFile(Assets.GetFilePath("OpenGL-Logo.png"), mipmap: true), Color.White);
    }


    public override void Update()
    {
        float toMove = speed * Time.deltaTime;
        
        if (Input.GetKey(Key.W))
            Camera.main.position += new Vector3(0, 0, toMove);
        if (Input.GetKey(Key.S))
            Camera.main.position += new Vector3(0, 0, -toMove);
        if (Input.GetKey(Key.A))
            Camera.main.position += new Vector3(-toMove, 0, 0);
        if (Input.GetKey(Key.D))
            Camera.main.position += new Vector3(toMove, 0, 0);
        if (Input.GetKey(Key.LeftShift))
            Camera.main.position += new Vector3(0, -toMove, 0);
        if (Input.GetKey(Key.Space))
            Camera.main.position += new Vector3(0, toMove, 0);
    }
}
