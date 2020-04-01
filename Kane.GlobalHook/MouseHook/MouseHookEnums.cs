#region << 版 本 注 释 >>
/*-----------------------------------------------------------------
* 项目名称 ：Kane.GlobalHook
* 项目描述 ：全局钩子
* 类 名 称 ：MouseMessages
* 类 描 述 ：鼠标钩子枚举类
* 所在的域 ：KK-HOME
* 命名空间 ：Kane.GlobalHook
* 机器名称 ：KK-HOME 
* CLR 版本 ：4.0.30319.42000
* 作　　者 ：Kane Leung
* 创建时间 ：2020/3/31 23:58:59
* 更新时间 ：2020/3/31 23:58:59
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Kane Leung 2020. All rights reserved.
*******************************************************************
-----------------------------------------------------------------*/
#endregion

namespace Kane.GlobalHook
{
    /// <summary>
    /// 鼠标钩子消息类型枚举
    /// https://docs.microsoft.com/en-us/windows/win32/inputdev/mouse-input-notifications
    /// </summary>
    public enum MouseMessages
    {
        /// <summary>
        /// 鼠标移动
        /// </summary>
        MouseMove = 0x200,
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        LeftButtonDown = 0x201,
        /// <summary>
        /// 鼠标左键弹起
        /// </summary>
        LeftButtonUp = 0x202,
        /// <summary>
        /// 鼠标左键双击
        /// </summary>
        LeftButtonDBCLK = 0x203,
        /// <summary>
        /// 鼠标右键按下
        /// </summary>
        RightButtonDown = 0x204,
        /// <summary>
        /// 鼠标右键弹起
        /// </summary>
        RightButtonUp = 0x205,
        /// <summary>
        /// 鼠标右键双击
        /// </summary>
        RightButtonDBCLK = 0x206,
        /// <summary>
        /// 鼠标中键按下
        /// </summary>
        MiddleButtonDown = 0x207,
        /// <summary>
        /// 鼠标中键弹起
        /// </summary>
        MiddleButtonUp = 0x208,
        /// <summary>
        /// 鼠标中键双击
        /// </summary>
        MiddleButtonDBCLK = 0x209,
        /// <summary>
        /// 鼠标垂直滚轮
        /// </summary>
        MouseWheel = 0x20A,
        /// <summary>
        /// 鼠标水平【Horizontal】滚轮
        /// </summary>
        MouseHWheel = 0x20E,
    }

    /// <summary>
    /// 鼠标钩子鼠标按钮枚举
    /// </summary>
    public enum MouseButtons
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 鼠标左键
        /// </summary>
        Left,
        /// <summary>
        /// 鼠标右键
        /// </summary>
        Right,
        /// <summary>
        /// 鼠标中键
        /// </summary>
        Middle,
        /// <summary>
        /// 垂直滚轮
        /// </summary>
        Wheel,
        /// <summary>
        /// 水平滚轮
        /// </summary>
        HWheel,
    }

    /// <summary>
    /// 鼠标滚轮方向枚举
    /// </summary>
    public enum MouseScrollDirection
    {
        /// <summary>
        /// 无
        /// </summary>
        None = -1,
        /// <summary>
        /// 向上滚动
        /// </summary>
        Up = 0,
        /// <summary>
        /// 向下滚动
        /// </summary>
        Down = 1
    }
}