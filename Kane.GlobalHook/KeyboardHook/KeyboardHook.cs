#region << 版 本 注 释 >>
/*-----------------------------------------------------------------
* 项目名称 ：Kane.GlobalHook
* 项目描述 ：全局钩子
* 类 名 称 ：KeyboardHook
* 类 描 述 ：键盘钩子
* 所在的域 ：KK-HOME
* 命名空间 ：Kane.GlobalHook
* 机器名称 ：KK-HOME 
* CLR 版本 ：4.0.30319.42000
* 作　　者 ：Kane Leung
* 创建时间 ：2020/3/31 22:42:24
* 更新时间 ：2020/3/31 22:42:24
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Kane Leung 2020. All rights reserved.
*******************************************************************
-----------------------------------------------------------------*/
#endregion
using System;
using System.Runtime.InteropServices;

namespace Kane.GlobalHook
{
    /// <summary>
    /// 键盘钩子
    /// </summary>
    public class KeyboardHook : IDisposable
    {
        #region 共有事件
        /// <summary>
        /// 键盘按下事件
        /// </summary>
        public event EventHandler<KeyboardHookEventArgs> KeyDown;
        /// <summary>
        /// 键盘弹起事件
        /// </summary>
        public event EventHandler<KeyboardHookEventArgs> KeyUp;
        /// <summary>
        /// 键盘事件，包括【键盘按下事件】和【键盘弹起事件】
        /// </summary>
        public event EventHandler<KeyboardHookEventArgs> KeyEvent;
        #endregion

        #region 私有变量
        /// <summary>
        /// 私有变量
        /// </summary>
        private IntPtr hookID;
        private readonly HookProc callback;
        private bool hooked;
        #endregion

        #region 私有方法
        private void OnKeyDown(KeyboardHookEventArgs e)
        {
            KeyDown?.Invoke(this, e);
            OnKeyEvent(e);
        }
        private void OnKeyUp(KeyboardHookEventArgs e)
        {
            KeyUp?.Invoke(this, e);
            OnKeyEvent(e);
        }
        private void OnKeyEvent(KeyboardHookEventArgs e) => KeyEvent?.Invoke(this, e);
        #endregion

        #region 键盘钩子构造函数 + KeyboardHook()
        /// <summary>
        /// 键盘钩子构造函数
        /// </summary>
        public KeyboardHook() => callback = KeyboardHookCallback;
        #endregion

        #region 挂载钩子，成功后返回HookID + Hook()
        /// <summary>
        /// 挂载钩子，成功后返回HookID
        /// </summary>
        /// <returns></returns>
        public IntPtr Hook()
        {
            hookID = HookApi.GetHookID((int)HookMode.WH_KEYBOARD_LL, callback);
            hooked = true;
            return hookID;
        }
        #endregion

        #region 触发键盘钩子事件时调用的回调方法 + KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        /// <summary>
        /// 触发键盘钩子事件时调用的回调方法
        /// </summary>
        /// <param name="nCode">【nCode】参数是Hook代码，Hook子程使用这个参数来确定任务。这个参数的值依赖于Hook类型，每一种Hook都有自己的Hook代码特征字符集。</param>
        /// <param name="wParam">要传递的参数; 由钩子类型决定是什么参数</param>
        /// <param name="lParam">要传递的参数; 由钩子类型决定是什么参数</param>
        /// <returns></returns>
        private IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var lParamStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                var e = new KeyboardHookEventArgs(lParamStruct);
                switch ((KeyboardMessages)wParam)
                {
                    case KeyboardMessages.KeyDown:
                        e.KeyboardMessage = KeyboardMessages.KeyDown;
                        OnKeyDown(e);
                        break;
                    case KeyboardMessages.KeyUp:
                        e.KeyboardMessage = KeyboardMessages.KeyUp;
                        OnKeyUp(e);
                        break;
                    case KeyboardMessages.SysKeyDown:
                        e.KeyboardMessage = KeyboardMessages.SysKeyDown;
                        OnKeyDown(e);
                        break;
                    case KeyboardMessages.SysKeyUp:
                        e.KeyboardMessage = KeyboardMessages.SysKeyUp;
                        OnKeyUp(e);
                        break;
                }
            }
            return HookApi.CallNextHookEx(hookID, nCode, wParam, lParam);
        }
        #endregion

        #region 卸载钩子 + Unhook()
        /// <summary>
        /// 卸载钩子，返回是否成功
        /// </summary>
        /// <returns></returns>
        public bool Unhook()
        {
            if (!hooked) return true;
            HookApi.UnhookWindowsHookEx(hookID);
            hooked = false;
            return true;
        }
        #endregion

        #region 释放资源 + Dispose()
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Unhook();
            GC.SuppressFinalize(this);
        }
        #endregion

        #region 析构函数，用来释放资源
        /// <summary>
        /// 析构函数，用来释放资源
        /// </summary>
        ~KeyboardHook()
        {
            Unhook();
        }
        #endregion
    }
}