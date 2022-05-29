using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame
{
    public class MessageForm : UGuiForm
    {
        [SerializeField]
        Text Msg1Text;
        [SerializeField]
        Text Msg2Text;
        [SerializeField]
        Color Msg1Color;
        [SerializeField]
        Color Msg2Color;


        float timer = 0;
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            MessageData msgData = userData as MessageData;
            if (msgData != null) 
            {
                Msg1Text.text = msgData.Message1;
                Msg2Text.text = msgData.Message2;
                Msg1Text.color = Msg1Color;
                Msg2Text.color = Msg2Color;
            }
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            timer += elapseSeconds;
            if(timer > 1.5f) 
            {
                timer = 0f;
                this.Close();
            }
        }
    }
}
