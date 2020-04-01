#region << 版 本 注 释 >>
/*-----------------------------------------------------------------
* 项目名称 ：Kane.GlobalHook
* 项目描述 ：全局钩子
* 类 名 称 ：MouseHookStruct
* 类 描 述 ：鼠标钩子事件参数结构体
* 所在的域 ：KK-HOME
* 命名空间 ：Kane.GlobalHook
* 机器名称 ：KK-HOME 
* CLR 版本 ：4.0.30319.42000
* 作　　者 ：Kane Leung
* 创建时间 ：2020/3/31 23:59:25
* 更新时间 ：2020/3/31 23:59:25
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Kane Leung 2020. All rights reserved.
*******************************************************************
-----------------------------------------------------------------*/
#endregion
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Kane.GlobalHook
{
    /// <summary>
    /// 鼠标钩子事件参数结构体
    /// <para>LayoutKind.Sequential 用于强制将成 员按其出现的顺序进行顺序布局。</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class MouseHookStruct
    {
        /// <summary>
        /// 指针坐标
        /// </summary>
        public Point Point { get; set; }
        /// <summary>
        /// 键值
        /// </summary>
        public int MouseData { get; set; }
        /// <summary>
        /// 键标志
        /// </summary>
        public uint Flags { get; set; }
        /// <summary>
        /// 指定的时间戳记的这个讯息
        /// </summary>
        public uint Time { get; set; }
        /// <summary>
        /// 指定额外信息相关的信息
        /// </summary>
        public IntPtr DwExtraInfo { get; set; }
    }
}