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

        float timer = 0;
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            MessageData msgData = userData as MessageData;
            if (msgData != null) 
            {
                Msg1Text.text = msgData.Message1;
                Msg2Text.text = msgData.Message2;
                Msg1Text.color = msgData.Message1Color;
                Msg2Text.color = msgData.Message2Color;
            }
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            timer += elapseSeconds;
            if(timer > 1f) 
            {
                this.Close();
            }
        }
    }
}
