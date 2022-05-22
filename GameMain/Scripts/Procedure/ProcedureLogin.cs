using GameFramework.Event;
using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace RPGGame
{
    public class ProcedureLogin : ProcedureBase
    {
        private bool m_StartGame = false;
        private LoginForm m_LoginForm = null;
        private RegisterForm m_RegisterForm = null;

        public Dictionary<string, string> accountDic = new Dictionary<string, string>();
        public override bool UseNativeDialog 
        { 
            get
            { 
                return false; 
            }
        }

        public void StartGame()
        {
            m_StartGame = true;
        }

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
            accountDic.Add("123", "123");
        }

        protected override void OnEnter(IFsm<GameFramework.Procedure.IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            m_StartGame = false;
            GameEntry.UI.OpenUIForm(UIFormId.LoginForm, this);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (m_StartGame)
            {
                procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.MainCity"));
                procedureOwner.SetData<VarByte>("GameMode", (byte)GameMode.Story);
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            if(m_LoginForm != null)
            {
                m_LoginForm.Close();
                m_LoginForm = null;
            }
            if(m_RegisterForm != null)
            {
                m_RegisterForm.Close();
                m_RegisterForm = null;
            }
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            if (ne.UIForm.Logic is LoginForm)
            {
                m_LoginForm = (LoginForm)ne.UIForm.Logic;
            }
            if(ne.UIForm.Logic is RegisterForm)
            {
                m_RegisterForm = (RegisterForm)ne.UIForm.Logic;
            }
        }
    }
}
