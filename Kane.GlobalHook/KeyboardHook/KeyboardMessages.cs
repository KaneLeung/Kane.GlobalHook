#region << 版 本 注 释 >>
/*-----------------------------------------------------------------
* 项目名称 ：Kane.GlobalHook
* 项目描述 ：全局钩子
* 类 名 称 ：KeyboardMessages
* 类 描 述 ：键盘钩子消息枚举类
* 所在的域 ：KK-HOME
* 命名空间 ：Kane.GlobalHook
* 机器名称 ：KK-HOME 
* CLR 版本 ：4.0.30319.42000
* 作　　者 ：Kane Leung
* 创建时间 ：2020/3/31 22:47:50
* 更新时间 ：2020/3/31 22:47:50
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Kane Leung 2020. All rights reserved.
*******************************************************************
-----------------------------------------------------------------*/
#endregion

namespace Kane.GlobalHook
{
    /// <summary>
    /// 键盘钩子消息枚举类
    /// </summary>
    public enum KeyboardMessages
    {
        /// <summary>
        /// 键盘按下
        /// </summary>
        KeyDown = 0x0100,
        /// <summary>
        /// 键盘弹起
        /// </summary>
        KeyUp = 0x0101,
        /// <summary>
        /// 系统键盘按下
        /// </summary>
        SysKeyDown = 0x0104,
        /// <summary>
        /// 系统键盘弹起
        /// </summary>
        SysKeyUp = 0x0105
    }
}