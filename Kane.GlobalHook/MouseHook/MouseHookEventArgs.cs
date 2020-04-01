#region << 版 本 注 释 >>
/*-----------------------------------------------------------------
* 项目名称 ：Kane.GlobalHook
* 项目描述 ：全局钩子
* 类 名 称 ：MouseHookEventArgs
* 类 描 述 ：鼠标钩子事件类
* 所在的域 ：KK-HOME
* 命名空间 ：Kane.GlobalHook
* 机器名称 ：KK-HOME 
* CLR 版本 ：4.0.30319.42000
* 作　　者 ：Kane Leung
* 创建时间 ：2020/3/31 23:59:12
* 更新时间 ：2020/3/31 23:59:12
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Kane Leung 2020. All rights reserved.
*******************************************************************
-----------------------------------------------------------------*/
#endregion
using System;
using System.Drawing;

namespace Kane.GlobalHook
{
    /// <summary>
    /// 键盘钩子事件类
    /// </summary>
    public class MouseHookEventArgs : EventArgs
    {
        private readonly MouseHookStruct HookStruct;
        /// <summary>
        /// 鼠标钩子事件
        /// </summary>
        /// <param name="hookStruct">鼠标钩子事件参数结构体</param>
        public MouseHookEventArgs(MouseHookStruct hookStruct) => HookStruct = hookStruct;

        /// <summary>
        /// 鼠标坐标
        /// </summary>
        public Point Position => HookStruct.Point;

        /// <summary>
        /// 鼠标滚轮方法
        /// </summary>
        public MouseScrollDirection ScrollDirection
        {
            get
            {
                if (MouseMessage != MouseMessages.MouseWheel) return MouseScrollDirection.None;
                return (HookStruct.MouseData >> 16) > 0 ? MouseScrollDirection.Up : MouseScrollDirection.Down;
            }
        }

        /// <summary>
        /// 鼠标钩子消息类型
        /// </summary>
        public MouseMessages MouseMessage { get; internal set; }

        /// <summary>
        /// 鼠标钩子按键类型
        /// </summary>
        public MouseButtons MouseButton { get; internal set; } = MouseButtons.None;

        /// <summary>
        /// 是否为双击
        /// </summary>
        public bool DoubleClick { get; internal set; } = false;
    }
}