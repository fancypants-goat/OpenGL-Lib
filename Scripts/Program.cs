using System.Drawing;
using Engine.Interfaces;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;



namespace Engine;

public class Program : GameWindow
{
    public static Program main;
    
    public Program() : base(WindowSettings.GameWindowSettings, WindowSettings.NativeWindowSettings)
    {
        main ??= this;
    }





    protected override void OnLoad()
    {
        // set the default render settings
        // GL.Enable(EnableCap.LineSmooth);
        GL.Enable(EnableCap.DepthTest);
        GL.Enable(EnableCap.Blend);
        
        GL.DepthFunc(DepthFunction.Lequal);
        GL.DepthMask(true);
        
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        
        GL.GetInteger(GetPName.MaxTextureImageUnits, out Texture.maxTextureUnits);
        
        GL.ClearColor(Color.Black);
        
        
        Create();
    }








    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
        
        Time.deltaTime = (float)args.Time * Time.timeScale;
        Time.deltaTimeMilliseconds = Time.deltaTime / 1000;
        
        Update();
    }









    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.Clear(ClearBufferMask.DepthBufferBit);
        
        Camera.main.UpdateCamera(ClientSize.X, ClientSize.Y);
        
        foreach (var drawable in IDrawable.drawables)
        {
            drawable.Draw();
        }
        
        SwapBuffers();  
    }









    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        
        Camera.main.UpdateCamera(e.Width, e.Height);
        GL.Viewport(0, 0, e.Width, e.Height);
    }









    public override void Close()
    {
        OnClose();
        
        base.Close();
    }






    //
    // overridable methods.
    // these do not contain any base code
    // and are mainly for the user to have an easily accesible way of creating the main logic of their game

    public virtual void Create() { }
    
    public virtual void Update() { }
    
    public virtual void OnClose() { }
}
