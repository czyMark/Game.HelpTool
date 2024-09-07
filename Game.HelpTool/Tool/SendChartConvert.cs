using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.HelpTool
{
    //发送的文字转换类
    public static class SendChartConvert
    {
        public static Dictionary<string, string> ChartStr = new Dictionary<string, string>() {
            {"Back","{BACKSPACE}"},
            {"Space"," "},
            {"BREAK","{BREAK}"},
            {"CapsLock","{CAPSLOCK}"},
            {"DEL","{DEL}"},
            {"Delete","{DELETE}"},
            {"Down","{DOWN}"},
            {"Up","{UP}"},
            {"End","{END}"},
            {"Enter","{ENTER}"},
            {"Return","{ENTER}"},
            {"Escape","{ESC}"},
            {"Help","{HELP}"},
            {"Home","{HOME}"}, 
            {"Insert","{INSERT}"},
            {"Left","{LEFT}"},
            {"NumLock","{NUMLOCK}"},
            {"PageDown","{PGDN}"},
            {"PageUp","{PGUP}"},
            {"PrintScreen","{PRTSC}"},
            {"Right","{RIGHT}"},
            {"Scroll","{SCROLLLOCK}"}, 
            {"ShiftKey","+"},
            {"RShiftKey",""},
            {"ControlKey","^"},
            {"Alt","%"},
            {"Tab","{TAB}"},
            {"F1","{F1}"},
            {"F2","{F2}"},
            {"F3","{F3}"},
            {"F4","{F4}"},
            {"F5","{F5}"},
            {"F6","{F6}"},
            {"F7","{F7}"},
            {"F8","{F8}"},
            {"F9","{F9}"},
            {"F10","{F10}"},
            {"F11","{F11}"},
            {"F12","{F12}"},
            {"F13","{F13}"},
            {"F14","{F14}"},
            {"F15","{F15}"},
            {"F16","{F16}"},
            {"OemQuestion","7"},
            {"D0","0"},
            {"D1","1"},
            {"D2","2"},
            {"D3","3"},
            {"D4","4"},
            {"D5","5"},
            {"D6","6"},
            {"D7","7"},
            {"D8","8"},
            {"D9","9"},
            {"NumPad0","0"},
            {"NumPad1","1"},
            {"NumPad2","2"},
            {"NumPad3","3"},
            {"NumPad4","4"},
            {"NumPad5","5"},
            {"NumPad6","6"},
            {"NumPad7","7"},
            {"NumPad8","8"},
            {"NumPad9","9"}
        };
        public static string ChartConver(string C)
        {
            foreach (var item in ChartStr)
            {
                if (item.Key == C)
                {
                    return item.Value;
                }
            }
            return C;
        }
    }
}
