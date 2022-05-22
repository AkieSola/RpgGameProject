//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

namespace RPGGame
{
    /// <summary>
    /// 界面编号。
    /// </summary>
    public enum UIFormId : byte
    {
        Undefined = 0,

        /// <summary>
        /// 弹出框。
        /// </summary>
        DialogForm = 1,

        /// <summary>
        /// 主菜单。
        /// </summary>
        MenuForm = 100,

        /// <summary>
        /// 设置。
        /// </summary>
        SettingForm = 101,

        /// <summary>
        /// 关于。
        /// </summary>
        AboutForm = 102,

        /// <summary>
        /// 主场景 
        /// </summary>
        MainCityForm = 103,

        /// <summary>
        /// 角色属性面板
        /// </summary>
        PlayerPropFrom = 104,

        /// <summary>
        /// 背包面板 
        /// </summary>
        BagFrom = 105,

        /// <summary>
        /// 使用面板
        /// </summary>
        UseForm = 106,

        /// <summary>
        /// 登录面板
        /// </summary>
        LoginForm = 107,

        /// <summary>
        /// 注册面板
        /// </summary>
        RegisterForm = 108,

        /// <summary>
        /// 伤害显示面板
        /// </summary>
        DamageTextForm = 201,
    }
}
