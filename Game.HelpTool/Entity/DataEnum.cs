using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.HelpTool
{
    //键盘状态
    public enum KeyStateData
    {
        KeyNone = 0,//0不启动键盘工具
        KeyGuid = 1, //1启动键盘工具输入Guid值
        KeyNumber = 2, //2启动键盘工具输入位数计数器
        KeyCache = 3, //3输出缓存内容
    }
    //鼠标状态
    public enum MouseStateData
    {
        MouseLeft = 0,//0是左键
        MouseRight = 1, //1是右键
        MouseRoller = 2, //2是滚动键
        MouseNone = 3,//没有鼠标操作
    }
    //条件执行判断
    public enum WhereExecStateData
    {
        WhereExecNone = 0, //不执行判断。对截图的内容做+并缓存
        WhereExecGreater = 1,//开始后判断是否大于N值(数字)
        WhereExecLess = 2,//开始后判断是否小于N值(数字)
        WhereExecEqual = 3,//开始后判断是否等于N值(数字)
        WhereExecContains = 4,//每当图中出现XX通过
        WhereExecNoContains = 5,//每当图中不包括XX通过
        WhereExecKeyDown = 6,//每当键盘按下XX时
        WhereExecFirstChar = 7,//识别内容匹配最开始一个字
        WhereExecLastChar = 8,//识别内容匹配最后一个字 
    }
    //脚本操作状态
    public enum OperationStateData
    {
        OperationMouse = 0, //0执行鼠标操作
        OperationKey = 1,//1执行键盘操作
        OperationRectWhere = 2, //2执行矩形识别条件操作 
        OperationPointWhere = 3, //2执行矩形识别条件操作 
    }
    //当前脚本状态
    public enum ScriptTypeData
    {
        ScriptExecNone = 0,//当前脚本无特殊操作
        ScriptExecRepeat = 1,//当前脚本重复执行
        ScriptWhereBefore = 2,//当前脚本为条件脚本，如果条件不通过执行上一个脚本
        ScriptWhereWait = 3, //当前脚本为条件脚本，如果条件不通过等待1秒后在重新判断
        ScriptWhereNoWait = 4, //当前脚本为条件脚本，如果条件不通过等待1秒后在重新判断
        ScriptStartExe = 5 //当前脚本为启动脚本，使用命令行执行某个程序
    }
    //条件脚本执行状态
    public enum WhereScriptExecStateData
    {
        ScriptWhereSuccess = 0,//当前脚本执行成功
        ScriptWhereBefore = 1,//当前脚本未达成条件，执行上一个脚本
        ScriptWhereWait = 2,//当前脚本未达成条件，等待后重新执行
    }

    public static class EnumDataConvert
    {
        //数据转换成对应字符串
        public static string ScriptStateToString(ScriptTypeData data)
        {
            switch (data)
            {
                case ScriptTypeData.ScriptExecNone:
                    return "脚本";
                case ScriptTypeData.ScriptExecRepeat:
                    return "可重复脚本";
                case ScriptTypeData.ScriptWhereBefore:
                    return "条件失败执行上一个";
                case ScriptTypeData.ScriptWhereWait:
                    return "条件失败等待重新执行";
                case ScriptTypeData.ScriptStartExe:
                    return "启动程序";
                default:
                    return "";
            }
        }
        public static string OperationStateToString(OperationStateData data)
        {
            switch (data)
            {
                case OperationStateData.OperationMouse:
                    return "执行鼠标操作";
                case OperationStateData.OperationKey:
                    return "执行键盘操作";
                case OperationStateData.OperationRectWhere:
                    return "执行条件操作";
                default:
                    return "";
            }
        }
        public static string WhereExecStateToString(WhereExecStateData data)
        {
            switch (data)
            {
                case WhereExecStateData.WhereExecNone:
                    return "不执行判断。对截图的内容做+并缓存";
                case WhereExecStateData.WhereExecGreater:
                    return "开始后判断是否大于N值(数字)";
                case WhereExecStateData.WhereExecLess:
                    return "开始后判断是否小于N值(数字)";
                case WhereExecStateData.WhereExecEqual:
                    return "开始后判断是否等于N值(数字)";
                case WhereExecStateData.WhereExecContains:
                    return "每当图中出现XX通过";
                case WhereExecStateData.WhereExecNoContains:
                    return "每当图中不出现XX通过";
                case WhereExecStateData.WhereExecFirstChar:
                    return "识别内容匹配最开始一个字";
                case WhereExecStateData.WhereExecLastChar:
                    return "识别内容匹配最后一个字 ";
                default:
                    return "";
            }
        }
        public static string MouseStateToString(MouseStateData data)
        {
            switch (data)
            {
                case MouseStateData.MouseLeft:
                    return "鼠标左键";
                case MouseStateData.MouseRight:
                    return "鼠标右键";
                case MouseStateData.MouseRoller:
                    return "鼠标滚轮";
                default:
                    return "";
            }
        }
        public static string KeyStateToString(KeyStateData data)
        {
            switch (data)
            {
                case KeyStateData.KeyNone:
                    return "不启动键盘工具,默认输入";
                case KeyStateData.KeyGuid:
                    return "启动键盘工具输出Guid值";
                case KeyStateData.KeyNumber:
                    return "启动键盘工具输出位数计数器";
                case KeyStateData.KeyCache:
                    return "启动键盘工具输出缓存内容";
                default:
                    return ""; 
            }
        }

        //字符串转换成对应数据
        public static ScriptTypeData StringToScriptState(string data)
        {
            switch (data)
            {
                case "脚本":
                    return ScriptTypeData.ScriptExecNone;
                case "可重复脚本":
                    return ScriptTypeData.ScriptExecRepeat;
                case "条件失败执行上一个":
                    return ScriptTypeData.ScriptWhereBefore;
                case "条件失败等待重新执行":
                    return ScriptTypeData.ScriptWhereWait;
                case "启动程序":
                    return ScriptTypeData.ScriptStartExe;
                default:
                    return ScriptTypeData.ScriptExecNone;
            }
        }
        public static OperationStateData StringToOperationState(string data)
        {
            switch (data)
            {
                case "执行鼠标操作":
                    return OperationStateData.OperationMouse;
                case "执行键盘操作":
                    return OperationStateData.OperationKey;
                case "执行条件操作":
                    return OperationStateData.OperationRectWhere;
                default:
                    return OperationStateData.OperationMouse;
            }
        }
        public static WhereExecStateData StringToWhereExecState(string data)
        {
            switch (data)
            {
                case "不执行判断。对截图的内容做+并缓存":
                    return WhereExecStateData.WhereExecNone;
                case "开始后判断是否大于N值(数字)":
                    return WhereExecStateData.WhereExecGreater;
                case "开始后判断是否小于N值(数字)":
                    return WhereExecStateData.WhereExecLess;
                case "开始后判断是否等于N值(数字)":
                    return WhereExecStateData.WhereExecEqual;
                case "每当图中出现XX通过":
                    return WhereExecStateData.WhereExecContains;
                case "识别内容匹配最开始一个字":
                    return WhereExecStateData.WhereExecFirstChar;
                case "识别内容匹配最后一个字":
                    return WhereExecStateData.WhereExecLastChar;
                default:
                    return WhereExecStateData.WhereExecNone;
            }
        }
        public static MouseStateData StringToMouseState(string data)
        {
            switch (data)
            {
                case "鼠标左键":
                    return MouseStateData.MouseLeft;
                case "鼠标右键":
                    return MouseStateData.MouseRight;
                case "鼠标滚轮":
                    return MouseStateData.MouseRoller;
                default:
                    return MouseStateData.MouseLeft;
            }
        }
        public static KeyStateData StringToKeyState(string data)
        {
            switch (data)
            {
                case "不启动键盘工具,默认输入":
                    return KeyStateData.KeyNone;
                case "启动键盘工具输出Guid值":
                    return KeyStateData.KeyGuid;
                case "启动键盘工具输出位数计数器":
                    return KeyStateData.KeyNumber;
                case "启动键盘工具输出缓存内容":
                    return KeyStateData.KeyCache;
                default:
                    return KeyStateData.KeyNone;
            }
        }
    }
}
