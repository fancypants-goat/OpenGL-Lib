using System.Runtime.CompilerServices;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;



namespace Engine;

public static class WindowSettings
{
    public static NativeWindowSettings NativeWindowSettings = NativeWindowSettings.Default;
    public static GameWindowSettings GameWindowSettings = GameWindowSettings.Default;
    
    
    
    
    public static void Location((int, int) location)
    {
        NativeWindowSettings.Location = location;
    }
    
    
    
    
    
    public static void Size((int, int) size)
    {
        NativeWindowSettings.ClientSize = size;
    }
    
    
    
    
    
    public static void Title(string title)
    {
        NativeWindowSettings.Title = title;
    }
}
