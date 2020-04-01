#region << 版 本 注 释 >>
/*-----------------------------------------------------------------
* 项目名称 ：Kane.GlobalHook
* 项目描述 ：全局钩子
* 类 名 称 ：HookApi
* 类 描 述 ：全局钩子用到的WinApi
* 所在的域 ：KK-HOME
* 命名空间 ：Kane.GlobalHook
* 机器名称 ：KK-HOME 
* CLR 版本 ：4.0.30319.42000
* 作　　者 ：Kane Leung
* 创建时间 ：2020/3/31 22:14:41
* 更新时间 ：2020/3/31 22:14:41
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Kane Leung 2020. All rights reserved.
*******************************************************************
-----------------------------------------------------------------*/
#endregion
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Kane.GlobalHook
{
    /// <summary>
    /// 全局钩子用到的WinApi
    /// </summary>
    public static class HookApi
    {
        #region 使用此功能，安装了一个钩子 + SetWindowsHookEx(int hooksMode, HookProc lpfn, IntPtr hMod, uint threadID)
        //键盘线程钩子
        //SetWindowsHookEx( 2,KeyboardHookProcedure, IntPtr.Zero, GetCurrentThreadId());//指定要监听的线程idGetCurrentThreadId(),
        //键盘全局钩子,需要引用空间(using System.Reflection;)
        //SetWindowsHookEx( 13,MouseHookProcedure,Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),0);
        /// <summary>
        /// 使用此功能，安装了一个钩子
        /// </summary>
        /// <param name="hooksMode">钩子类型，即确定钩子监听何种消息，上面的代码中设为2，即监听键盘消息并且是线程钩子，如果是全局钩子监听键盘消息应设为13,线程钩子监听鼠标消息设为7，全局钩子监听鼠标消息设为14</param>
        /// <param name="lpfn">钩子子程的地址指针。如果threadID参数为0 或是一个由别的进程创建的线程的标识，lpfn必须指向DLL中的钩子子程。 除此以外，lpfn可以指向当前进程的一段钩子子程代码。钩子函数的入口地址，当钩子钩到任何消息后便调用这个函数。</param>
        /// <param name="hMod">应用程序实例的句柄。标识包含lpfn所指的子程的DLL。如果threadID 标识当前进程创建的一个线程，而且子程代码位于当前进程，hMod必须为NULL。可以很简单的设定其为本应用程序的实例句柄</param>
        /// <param name="threadID">与安装的钩子子程相关联的线程的标识符如果为0，钩子子程与所有的线程关联，即为全局钩子</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(int hooksMode, HookProc lpfn, IntPtr hMod, uint threadID);
        #endregion

        #region 使用WINDOWS API函数代替获取当前实例的函数,防止钩子失效 + GetModuleHandle(string lpModuleName)
        /// <summary>
        /// 使用WINDOWS API函数代替获取当前实例的函数,防止钩子失效
        /// </summary>
        /// <param name="lpModuleName">一个指向含有模块名称字符串的指针</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion

        #region 调用此函数卸载钩子 + UnhookWindowsHookEx(IntPtr hookID); 
        /// <summary>
        /// 调用此函数卸载钩子
        /// </summary>
        /// <param name="hookID">要删除的钩子的句柄。这个参数是上一个函数SetWindowsHookEx的返回值.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hookID);
        #endregion

        #region 通过信息钩子继续下一个钩子 + CallNextHookEx(IntPtr hookID, int nCode, IntPtr wParam, IntPtr lParam)
        /// <summary>
        /// 通过信息钩子继续下一个钩子
        /// </summary>
        /// <param name="hookID">当前钩子的句柄</param>
        /// <param name="nCode">【nCode】参数是Hook代码，Hook子程使用这个参数来确定任务。这个参数的值依赖于Hook类型，每一种Hook都有自己的Hook代码特征字符集。</param>
        /// <param name="wParam">要传递的参数; 由钩子类型决定是什么参数</param>
        /// <param name="lParam">要传递的参数; 由钩子类型决定是什么参数</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr hookID, int nCode, IntPtr wParam, IntPtr lParam);
        #endregion

        #region 该函数将一虚拟键码翻译(映射)成一扫描码或一字符值，或者将一扫描码翻译成一虚拟键码 + MapVirtualKey(uint uCode, uint uMapType)
        /// <summary>
        /// 该函数将一虚拟键码翻译(映射)成一扫描码或一字符值，或者将一扫描码翻译成一虚拟键码
        /// </summary>
        /// <param name="uCode">定义一个键的扫描码或虚拟键码。该值如何解释依赖于uMapType参数的值。</param>
        /// <param name="uMapType">定义将要执行的翻译。该参数的值依赖于uCode参数的值</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern uint MapVirtualKey(uint uCode, uint uMapType);
        #endregion

        #region 获取全局钩子HookID + GetHookID(int hooksMode, HookProc callback)
        /// <summary>
        /// 获取全局钩子HookID
        /// </summary>
        /// <param name="hooksMode">钩子方法类型</param>
        /// <param name="callback">钩子定义的回调函数</param>
        /// <returns></returns>
        public static IntPtr GetHookID(int hooksMode, HookProc callback)
        {
            IntPtr hookID;
            using (var currentProcess = Process.GetCurrentProcess())
            using (var currentModule = currentProcess.MainModule)
            {
                var handle = GetModuleHandle(currentModule.ModuleName);
                hookID = SetWindowsHookEx(hooksMode, callback, handle, 0);
            }
            return hookID;
        }
        #endregion
    }
}