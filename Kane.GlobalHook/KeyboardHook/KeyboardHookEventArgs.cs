#region << 版 本 注 释 >>
/*-----------------------------------------------------------------
* 项目名称 ：Kane.GlobalHook
* 项目描述 ：全局钩子
* 类 名 称 ：KeyboardHookEventArgs
* 类 描 述 ：键盘钩子事件类
* 所在的域 ：KK-HOME
* 命名空间 ：Kane.GlobalHook
* 机器名称 ：KK-HOME 
* CLR 版本 ：4.0.30319.42000
* 作　　者 ：Kane Leung
* 创建时间 ：2020/3/31 22:43:03
* 更新时间 ：2020/3/31 22:43:03
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Kane Leung 2020. All rights reserved.
*******************************************************************
-----------------------------------------------------------------*/
#endregion
using System;
using System.Globalization;

namespace Kane.GlobalHook
{
    /// <summary>
    /// 键盘钩子事件类
    /// </summary>
    public class KeyboardHookEventArgs : EventArgs
    {
        private readonly KeyboardHookStruct HookStruct;
        /// <summary>
        /// 键盘钩子事件
        /// </summary>
        /// <param name="hookStruct">键盘钩子事件参数结构体</param>
        public KeyboardHookEventArgs(KeyboardHookStruct hookStruct)
        {
            HookStruct = hookStruct;
            Char = Convert.ToChar(HookApi.MapVirtualKey((uint)VirtualKeyCode, 2));
        }

        /// <summary>
        /// 虚拟键码
        /// </summary>
        public int VirtualKeyCode { get => HookStruct.VkCode; }

        /// <summary>
        /// 虚拟键码对应的键值
        /// </summary>
        public Keys Key => (Keys)VirtualKeyCode;

        /// <summary>
        /// 
        /// </summary>
        public char Char { get; internal set; }

        /// <summary>
        /// 键值对应的字符串
        /// </summary>
        public string KeyString
        {
            get
            {
                if (Char == '\0') return Key == Keys.Return ? "Enter" : $"{Key}";
                if (Char == '\r')
                {
                    Char = '\0';
                    return "Enter";
                }
                if (Char == '\b')
                {
                    Char = '\0';
                    return "Backspace";
                }
                return Char.ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// 键盘钩子消息类型
        /// </summary>
        public KeyboardMessages KeyboardMessage { get; internal set; }
    }
}