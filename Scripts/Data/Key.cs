using OpenTK.Windowing.GraphicsLibraryFramework;


namespace Engine;

public enum Key
{
    //* MOUSE BUTTONS
    /// <summary>
        ///     The first button.
        /// </summary>
        Button1 = MouseButton.Button1,

        /// <summary>
        ///     The second button.
        /// </summary>
        Button2 = MouseButton.Button2,

        /// <summary>
        ///     The third button.
        /// </summary>
        Button3 = MouseButton.Button1,

        /// <summary>
        ///     The fourth button.
        /// </summary>
        Button4 = MouseButton.Button4,

        /// <summary>
        ///     The fifth button.
        /// </summary>
        Button5 = MouseButton.Button5,

        /// <summary>
        ///     The sixth button.
        /// </summary>
        Button6 = MouseButton.Button6,

        /// <summary>
        ///     The seventh button.
        /// </summary>
        Button7 = MouseButton.Button7,

        /// <summary>
        ///     The eighth button.
        /// </summary>
        Button8 = MouseButton.Button8,

        /// <summary>
        ///     The left mouse button. This corresponds to <see cref="Button1"/>.
        /// </summary>
        LeftMouse = Button1,

        /// <summary>
        ///     The right mouse button. This corresponds to <see cref="Button2"/>.
        /// </summary>
        RightMouse = Button2,

        /// <summary>
        ///     The middle mouse button. This corresponds to <see cref="Button3"/>.
        /// </summary>
        MiddleMouse = Button3,

        /// <summary>
        ///     The highest mouse button available.
        /// </summary>
        LastMouse = Button8,
   
   
    //* KEYBOARD KEYS
    /// <summary>
    /// An unknown key.
    /// </summary>
    Unknown = Keys.Unknown,

    /// <summary>
    /// The spacebar key.
    /// </summary>
    Space = Keys.Space,

    /// <summary>
    /// The apostrophe key.
    /// </summary>
    Apostrophe = Keys.Apostrophe /* ' */,

    /// <summary>
    /// The comma key.
    /// </summary>
    Comma = Keys.Comma /* , */,

    /// <summary>
    /// The minus key.
    /// </summary>
    Minus = Keys.Minus /* - */,

    /// <summary>
    /// The period key.
    /// </summary>
    Period = Keys.Period /* . */,

    /// <summary>
    /// The slash key.
    /// </summary>
    Slash = Keys.Slash /* / */,

    /// <summary>
    /// The 0 key.
    /// </summary>
    D0 = Keys.D0,

    /// <summary>
    /// The 1 key.
    /// </summary>
    D1 = Keys.D1,

    /// <summary>
    /// The 2 key.
    /// </summary>
    D2 = Keys.D2,

    /// <summary>
    /// The 3 key.
    /// </summary>
    D3 = Keys.D3,

    /// <summary>
    /// The 4 key.
    /// </summary>
    D4 = Keys.D4,

    /// <summary>
    /// The 5 key.
    /// </summary>
    D5 = Keys.D5,

    /// <summary>
    /// The 6 key.
    /// </summary>
    D6 = Keys.D6,

    /// <summary>
    /// The 7 key.
    /// </summary>
    D7 = Keys.D7,

    /// <summary>
    /// The 8 key.
    /// </summary>
    D8 = Keys.D8,

    /// <summary>
    /// The 9 key.
    /// </summary>
    D9 = Keys.D9,

    /// <summary>
    /// The semicolon key.
    /// </summary>
    Semicolon = Keys.Semicolon /* ; */,

    /// <summary>
    /// The equal key.
    /// </summary>
    Equal = Keys.Equal /* = */,

    /// <summary>
    /// The A key.
    /// </summary>
    A = Keys.A,

    /// <summary>
    /// The B key.
    /// </summary>
    B = Keys.B,

    /// <summary>
    /// The C key.
    /// </summary>
    C = Keys.C,

    /// <summary>
    /// The D key.
    /// </summary>
    D = Keys.D,

    /// <summary>
    /// The E key.
    /// </summary>
    E = Keys.E,

    /// <summary>
    /// The F key.
    /// </summary>
    F = Keys.F,

    /// <summary>
    /// The G key.
    /// </summary>
    G = Keys.G,

    /// <summary>
    /// The H key.
    /// </summary>
    H = Keys.H,

    /// <summary>
    /// The I key.
    /// </summary>
    I = Keys.I,

    /// <summary>
    /// The J key.
    /// </summary>
    J = Keys.J,

    /// <summary>
    /// The K key.
    /// </summary>
    K = Keys.K,

    /// <summary>
    /// The L key.
    /// </summary>
    L = Keys.L,

    /// <summary>
    /// The M key.
    /// </summary>
    M = Keys.M,

    /// <summary>
    /// The N key.
    /// </summary>
    N = Keys.N,

    /// <summary>
    /// The O key.
    /// </summary>
    O = Keys.O,

    /// <summary>
    /// The P key.
    /// </summary>
    P = Keys.P,

    /// <summary>
    /// The Q key.
    /// </summary>
    Q = Keys.Q,

    /// <summary>
    /// The R key.
    /// </summary>
    R = Keys.R,

    /// <summary>
    /// The S key.
    /// </summary>
    S = Keys.S,

    /// <summary>
    /// The T key.
    /// </summary>
    T = Keys.T,

    /// <summary>
    /// The U key.
    /// </summary>
    U = Keys.U,

    /// <summary>
    /// The V key.
    /// </summary>
    V = Keys.V,

    /// <summary>
    /// The W key.
    /// </summary>
    W = Keys.W,

    /// <summary>
    /// The X key.
    /// </summary>
    X = Keys.X,

    /// <summary>
    /// The Y key.
    /// </summary>
    Y = Keys.Y,

    /// <summary>
    /// The Z key.
    /// </summary>
    Z = Keys.Z,

    /// <summary>
    /// The left bracket(opening bracket) key.
    /// </summary>
    LeftBracket = Keys.LeftBracket /* [ */,

    /// <summary>
    /// The backslash.
    /// </summary>
    Backslash = Keys.Backslash /* \ */,

    /// <summary>
    /// The right bracket(closing bracket) key.
    /// </summary>
    RightBracket = Keys.RightBracket /* ] */,

    /// <summary>
    /// The grave accent key.
    /// </summary>
    GraveAccent = Keys.GraveAccent /* ` */,

    /// <summary>
    /// The escape key.
    /// </summary>
    Escape = Keys.Escape,

    /// <summary>
    /// The enter key.
    /// </summary>
    Enter = Keys.Enter,

    /// <summary>
    /// The tab key.
    /// </summary>
    Tab = Keys.Tab,

    /// <summary>
    /// The backspace key.
    /// </summary>
    Backspace = Keys.Backspace,

    /// <summary>
    /// The insert key.
    /// </summary>
    Insert = Keys.Insert,

    /// <summary>
    /// The delete key.
    /// </summary>
    Delete = Keys.Delete,

    /// <summary>
    /// The right arrow key.
    /// </summary>
    Right = Keys.Right,

    /// <summary>
    /// The left arrow key.
    /// </summary>
    Left = Keys.Left,

    /// <summary>
    /// The down arrow key.
    /// </summary>
    Down = Keys.Down,

    /// <summary>
    /// The up arrow key.
    /// </summary>
    Up = Keys.Up,

    /// <summary>
    /// The page up key.
    /// </summary>
    PageUp = Keys.PageUp,

    /// <summary>
    /// The page down key.
    /// </summary>
    PageDown = Keys.PageDown,

    /// <summary>
    /// The home key.
    /// </summary>
    Home = Keys.Home,

    /// <summary>
    /// The end key.
    /// </summary>
    End = Keys.End,

    /// <summary>
    /// The caps lock key.
    /// </summary>
    CapsLock = Keys.CapsLock,

    /// <summary>
    /// The scroll lock key.
    /// </summary>
    ScrollLock = Keys.ScrollLock,

    /// <summary>
    /// The num lock key.
    /// </summary>
    NumLock = Keys.NumLock,

    /// <summary>
    /// The print screen key.
    /// </summary>
    PrintScreen = Keys.PrintScreen,

    /// <summary>
    /// The pause key.
    /// </summary>
    Pause = Keys.Pause,

    /// <summary>
    /// The F1 key.
    /// </summary>
    F1 = Keys.F1,

    /// <summary>
    /// The F2 key.
    /// </summary>
    F2 = Keys.F2,

    /// <summary>
    /// The F3 key.
    /// </summary>
    F3 = Keys.F3,

    /// <summary>
    /// The F4 key.
    /// </summary>
    F4 = Keys.F4,

    /// <summary>
    /// The F5 key.
    /// </summary>
    F5 = Keys.F5,

    /// <summary>
    /// The F6 key.
    /// </summary>
    F6 = Keys.F6,

    /// <summary>
    /// The F7 key.
    /// </summary>
    F7 = Keys.F7,

    /// <summary>
    /// The F8 key.
    /// </summary>
    F8 = Keys.F8,

    /// <summary>
    /// The F9 key.
    /// </summary>
    F9 = Keys.F9,

    /// <summary>
    /// The F10 key.
    /// </summary>
    F10 = Keys.F10,

    /// <summary>
    /// The F11 key.
    /// </summary>
    F11 = Keys.F11,

    /// <summary>
    /// The F12 key.
    /// </summary>
    F12 = Keys.F12,

    /// <summary>
    /// The F13 key.
    /// </summary>
    F13 = Keys.F13,

    /// <summary>
    /// The F14 key.
    /// </summary>
    F14 = Keys.F14,

    /// <summary>
    /// The F15 key.
    /// </summary>
    F15 = Keys.F15,

    /// <summary>
    /// The F16 key.
    /// </summary>
    F16 = Keys.F16,

    /// <summary>
    /// The F17 key.
    /// </summary>
    F17 = Keys.F17,

    /// <summary>
    /// The F18 key.
    /// </summary>
    F18 = Keys.F18,

    /// <summary>
    /// The F19 key.
    /// </summary>
    F19 = Keys.F19,

    /// <summary>
    /// The F20 key.
    /// </summary>
    F20 = Keys.F20,

    /// <summary>
    /// The F21 key.
    /// </summary>
    F21 = Keys.F21,

    /// <summary>
    /// The F22 key.
    /// </summary>
    F22 = Keys.F22,

    /// <summary>
    /// The F23 key.
    /// </summary>
    F23 = Keys.F23,

    /// <summary>
    /// The F24 key.
    /// </summary>
    F24 = Keys.F24,

    /// <summary>
    /// The F25 key.
    /// </summary>
    F25 = Keys.F25,

    /// <summary>
    /// The 0 key on the key pad.
    /// </summary>
    KeyPad0 = Keys.KeyPad0,

    /// <summary>
    /// The 1 key on the key pad.
    /// </summary>
    KeyPad1 = Keys.KeyPad1,

    /// <summary>
    /// The 2 key on the key pad.
    /// </summary>
    KeyPad2 = Keys.KeyPad2,

    /// <summary>
    /// The 3 key on the key pad.
    /// </summary>
    KeyPad3 = Keys.KeyPad3,

    /// <summary>
    /// The 4 key on the key pad.
    /// </summary>
    KeyPad4 = Keys.KeyPad4,

    /// <summary>
    /// The 5 key on the key pad.
    /// </summary>
    KeyPad5 = Keys.KeyPad5,

    /// <summary>
    /// The 6 key on the key pad.
    /// </summary>
    KeyPad6 = Keys.KeyPad6,

    /// <summary>
    /// The 7 key on the key pad.
    /// </summary>
    KeyPad7 = Keys.KeyPad7,

    /// <summary>
    /// The 8 key on the key pad.
    /// </summary>
    KeyPad8 = Keys.KeyPad8,

    /// <summary>
    /// The 9 key on the key pad.
    /// </summary>
    KeyPad9 = Keys.KeyPad9,

    /// <summary>
    /// The decimal key on the key pad.
    /// </summary>
    KeyPadDecimal = Keys.KeyPadDecimal,

    /// <summary>
    /// The divide key on the key pad.
    /// </summary>
    KeyPadDivide = Keys.KeyPadDivide,

    /// <summary>
    /// The multiply key on the key pad.
    /// </summary>
    KeyPadMultiply = Keys.KeyPadMultiply,

    /// <summary>
    /// The subtract key on the key pad.
    /// </summary>
    KeyPadSubtract = Keys.KeyPadSubtract,

    /// <summary>
    /// The add key on the key pad.
    /// </summary>
    KeyPadAdd = Keys.KeyPadAdd,

    /// <summary>
    /// The enter key on the key pad.
    /// </summary>
    KeyPadEnter = Keys.KeyPadEnter,

    /// <summary>
    /// The equal key on the key pad.
    /// </summary>
    KeyPadEqual = Keys.KeyPadEqual,

    /// <summary>
    /// The left shift key.
    /// </summary>
    LeftShift = Keys.LeftShift,

    /// <summary>
    /// The left control key.
    /// </summary>
    LeftControl = Keys.LeftControl,

    /// <summary>
    /// The left alt key.
    /// </summary>
    LeftAlt = Keys.LeftAlt,

    /// <summary>
    /// The left super key.
    /// </summary>
    LeftSuper = Keys.LeftSuper,

    /// <summary>
    /// The right shift key.
    /// </summary>
    RightShift = Keys.RightShift,

    /// <summary>
    /// The right control key.
    /// </summary>
    RightControl = Keys.RightControl,

    /// <summary>
    /// The right alt key.
    /// </summary>
    RightAlt = Keys.RightAlt,

    /// <summary>
    /// The right super key.
    /// </summary>
    RightSuper = Keys.RightSuper,

    /// <summary>
    /// The menu key.
    /// </summary>
    Menu = Keys.Menu
}
