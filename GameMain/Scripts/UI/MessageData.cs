using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class MessageData
    {
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public Color Message1Color { get; set; }
        public Color Message2Color { get; set; }

        public MessageData(string Msg1,string Msg2) 
        {
            Message1 = Msg1;
            Message2 = Msg2;
        }

        public MessageData(string Msg1, string Msg2, Color color1, Color color2) 
        {
            Message1 = Msg1;
            Message2 = Msg2;
            Message1Color = color1;
            Message2Color = color2;
        }
    }
}
