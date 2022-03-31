using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public class MainCityForm : UGuiForm
    {
        [SerializeField]
        private Slider m_ExpSlider = null;
        [SerializeField]
        private Slider m_HPSlider = null;
        [SerializeField]
        private Slider m_SPSlider = null;
        [SerializeField]
        private SkillList m_SkillList = null;

        private ProcedureMain m_ProcedureMain = null;
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_ProcedureMain = (ProcedureMain)userData;
            if(m_ProcedureMain == null)
            {
                Log.Warning("ProcedureMain is invalid when open MainCityForm.");
                return;
            }
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            m_ProcedureMain = null;

            base.OnClose(isShutdown, userData);
        }
    }
}