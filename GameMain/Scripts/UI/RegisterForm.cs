using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame
{
    public class RegisterForm : UGuiForm
    {
        [SerializeField]
        Text RegisterTitle;
        [SerializeField]
        InputField AccountInput;
        [SerializeField]
        Text AccountTitle;
        [SerializeField]
        InputField PasswordInput;
        [SerializeField]
        Text PasswordTitle;
        [SerializeField]
        Button ReturnLoginButton;
        [SerializeField]
        Button RegisterButton;

        private ProcedureLogin m_ProcedureLogin;
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

             m_ProcedureLogin = (ProcedureLogin)userData;

            RegisterTitle.text = "◊¢  ≤·";
            AccountTitle.text = "’À∫≈";
            PasswordTitle.text = "√‹¬Î";
            AccountInput.text = "«Î ‰»ÎœÎ◊¢≤·µƒ’À∫≈...";
            PasswordInput.text = "«Î ‰»ÎœÎ◊¢≤·µƒ√‹¬Î...";
            ReturnLoginButton.GetComponentInChildren<Text>().text = "∑µªÿµ«¬º";
            RegisterButton.GetComponentInChildren<Text>().text = "»∑»œ◊¢≤·";
            ReturnLoginButton.onClick.AddListener(OnReturnLoginBtnClicked);
            RegisterButton.onClick.AddListener(OnRegisterBtnClicked);
        }

        private void OnReturnLoginBtnClicked() 
        {
            GameEntry.UI.OpenUIForm(UIFormId.LoginForm, m_ProcedureLogin);
            this.Close();
        }

        private void OnRegisterBtnClicked()
        {
            if(AccountInput.text == "«Î ‰»ÎœÎ◊¢≤·µƒ’À∫≈...") 
            {
                GameEntry.UI.OpenDialog(new DialogParams()
                {
                    Mode = 1,
                    Message = "«Î ‰»Î“™◊¢≤·µƒ’À∫≈"
                });
            }
            else if(PasswordInput.text == "«Î ‰»ÎœÎ◊¢≤·µƒ√‹¬Î...") 
            {
                GameEntry.UI.OpenDialog(new DialogParams()
                {
                    Mode = 1,
                    Message = "«Î ‰»Îƒ˙µƒ√‹¬Î"
                });
            }
            else if(m_ProcedureLogin.accountDic.ContainsKey(AccountInput.text))
            {
                GameEntry.UI.OpenDialog(new DialogParams()
                {
                    Mode = 1,
                    Message = "∏√’À∫≈“—±ª◊¢≤·"
                });
            }
            else 
            {
                m_ProcedureLogin.accountDic.Add(AccountInput.text, PasswordInput.text);
                GameEntry.UI.OpenDialog(new DialogParams()
                {
                    Mode = 1,
                    Message = "◊¢≤·≥…π¶!",
                    OnClickConfirm = (o) => 
                    {
                        GameEntry.UI.OpenUIForm(UIFormId.LoginForm, m_ProcedureLogin);
                        GameEntry.UI.CloseUIForm(this);
                    }
                });
            }
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            ReturnLoginButton.onClick.RemoveAllListeners();
            RegisterButton.onClick.RemoveAllListeners();
            base.OnClose(isShutdown, userData);
        }
    }
}
