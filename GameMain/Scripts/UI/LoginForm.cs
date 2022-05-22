using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame
{
    public class LoginForm : UGuiForm
    {
        [SerializeField]
        Text LoginTitle;
        [SerializeField]
        InputField AccountInput;
        [SerializeField]
        Text AccountTitle;
        [SerializeField]
        InputField PasswordInput;
        [SerializeField]
        Text PasswordTitle;
        [SerializeField]
        Button LoginButton;
        [SerializeField]
        Button RegisterButton;

        ProcedureLogin m_ProcedureLogin;
        
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_ProcedureLogin = (ProcedureLogin)userData;

            LoginTitle.text = "µ«  ¬º";
            AccountTitle.text = "’À∫≈";
            PasswordTitle.text = "√‹¬Î";
            AccountInput.text = "«Î ‰»Î’À∫≈...";
            PasswordInput.text = "«Î ‰»Î√‹¬Î...";
            LoginButton.GetComponentInChildren<Text>().text = "µ«¬º";
            RegisterButton.GetComponentInChildren<Text>().text = "◊¢≤·";
            LoginButton.onClick.AddListener(OnLoginBtnClicked);
            RegisterButton.onClick.AddListener(OnRegisterBtnClicked);    
        }

        private void OnLoginBtnClicked() 
        {
            if(AccountInput.text == "«Î ‰»Î’À∫≈...") 
            {
                GameEntry.UI.OpenDialog(new DialogParams() 
                {
                    Mode = 1,
                    Message = "ƒ˙Œ¥ ‰»Î’À∫≈"
                });
            }
            else if (m_ProcedureLogin.accountDic.ContainsKey(AccountInput.text)) 
            {
                if(m_ProcedureLogin.accountDic[AccountInput.text] == PasswordInput.text) 
                {
                    m_ProcedureLogin.StartGame();
                }
                else 
                {
                    GameEntry.UI.OpenDialog(new DialogParams()
                    {
                        Mode = 1,
                        Message = "√‹¬Î¥ÌŒÛ"
                    });
                }
            }
        }

        private void OnRegisterBtnClicked() 
        {
            GameEntry.UI.OpenUIForm(UIFormId.RegisterForm, m_ProcedureLogin);
            this.Close();
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            LoginButton.onClick.RemoveAllListeners();
            RegisterButton.onClick.RemoveAllListeners();
            base.OnClose(isShutdown, userData);
        }
    }
}
