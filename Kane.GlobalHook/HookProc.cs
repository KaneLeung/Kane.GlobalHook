#region << 版 本 注 释 >>
/*-----------------------------------------------------------------
* 项目名称 ：Kane.GlobalHook
* 项目描述 ：全局钩子
* 类 名 称 ：HookProc
* 类 描 述 ：钩子定义的回调函数
* 所在的域 ：KK-HOME
* 命名空间 ：Kane.GlobalHook
* 机器名称 ：KK-HOME 
* CLR 版本 ：4.0.30319.42000
* 作　　者 ：Kane Leung
* 创建时间 ：2020/3/31 22:17:20
* 更新时间 ：2020/3/31 22:17:20
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Kane Leung 2020. All rights reserved.
*******************************************************************
-----------------------------------------------------------------*/
#endregion
using System;

namespace Kane.GlobalHook
{
    /// <summary>
    /// 钩子定义的回调函数(CALLBACK Function)
    /// </summary>
    /// <param name="nCode">【nCode】参数是Hook代码，Hook子程使用这个参数来确定任务。这个参数的值依赖于Hook类型，每一种Hook都有自己的Hook代码特征字符集。</param>
    /// <param name="wParam">【wParam】和【lParam】参数的值依赖于Hook代码，但是它们的典型值是包含了关于发送或者接收消息的信息。</param>
    /// <param name="lParam">【wParam】和【lParam】参数的值依赖于Hook代码，但是它们的典型值是包含了关于发送或者接收消息的信息。</param>
    /// <returns></returns>
    public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
}