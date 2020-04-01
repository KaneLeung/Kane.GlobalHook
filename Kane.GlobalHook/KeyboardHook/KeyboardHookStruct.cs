#region << 版 本 注 释 >>
/*-----------------------------------------------------------------
* 项目名称 ：Kane.GlobalHook
* 项目描述 ：全局钩子
* 类 名 称 ：KeyboardHookStruct
* 类 描 述 ：键盘钩子事件参数结构体
* 所在的域 ：KK-HOME
* 命名空间 ：Kane.GlobalHook
* 机器名称 ：KK-HOME 
* CLR 版本 ：4.0.30319.42000
* 作　　者 ：Kane Leung
* 创建时间 ：2020/3/31 22:43:46
* 更新时间 ：2020/3/31 22:43:46
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Kane Leung 2020. All rights reserved.
*******************************************************************
-----------------------------------------------------------------*/
#endregion
using System.Runtime.InteropServices;

namespace Kane.GlobalHook
{
    /// <summary>
    /// 键盘钩子事件参数结构体
    /// <para>LayoutKind.Sequential 用于强制将成 员按其出现的顺序进行顺序布局。</para> 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class KeyboardHookStruct
    {
        /// <summary>
        /// 定一个虚拟键码。该代码必须有一个价值的范围1至254
        /// </summary>
        public int VkCode { get; set; }
        /// <summary>
        /// 指定的硬件扫描码的关键
        /// </summary>
        public int ScanCode { get; set; }
        /// <summary>
        /// 键标志
        /// </summary>
        public int Flags { get; set; }
        /// <summary>
        /// 指定的时间戳记的这个讯息
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// 指定额外信息相关的信息
        /// </summary>
        public int DwExtraInfo { get; set; }
    }
}