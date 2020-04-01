![dotnet-version](https://img.shields.io/badge/.net-%3E%3D4.0-blue.svg) [![nuget-version](https://img.shields.io/nuget/v/Kane.GlobalHook.svg)](https://www.nuget.org/packages/Kane.GlobalHook) [![Nuget](https://img.shields.io/nuget/dt/Kane.GlobalHook)](https://www.nuget.org/packages/Kane.GlobalHook)

## 如何使用

Step 1：添加引用或在Nuget直接搜索【Kane.GlobalHook】; 

```Install-Package Kane.GlobalHook```

Step 2：使用方法:

### Keyboard Hook 挂载键盘钩子
``` c#
    var keyboardHook = new KeyboardHook();
    keyboardHook.KeyEvent += (sender,e) =>
    {
        //e为 KeyboardHookEventArgs 
        //事件
    };
    keyboardHook.Hook();//挂载键盘钩子
```

### Keyboard Unhook 卸载键盘钩子
``` c#
    keyboardHook.Unhook();//卸载键盘钩子
```

### Mouse Hook 挂载鼠标钩子
``` c#
    var mouseHook = new MouseHook();
    mouseHook.MouseEvent += (sender,e) =>
    {
        //e为 MouseHookEventArgs 
        //事件
    };
    mouseHook.Hook();//挂载鼠标钩子
```

### Mouse Unhook 卸载钩子
``` c#
    mouseHook.Unhook();//卸载鼠标钩子
```