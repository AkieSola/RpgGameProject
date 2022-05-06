using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame
{
    public class DamageTextForm : UGuiForm
    {
        [SerializeField]
        private Text m_Text = null;
        float timer = 0;
        [SerializeField]
        private Color physicsColor;
        [SerializeField]
        private Color spellColor;
        [SerializeField]
        private Color pureColor;
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            DamageData dd = userData as DamageData;
            if (dd != null)
            {
                m_Text.text = dd.Damage.ToString();
                switch (dd.DamageType)
                {
                    case E_DamageType.Physics:
                        m_Text.color = physicsColor;
                        break;
                    case E_DamageType.Spell:
                        m_Text.color = spellColor;
                        break;
                    case E_DamageType.Pure:
                        m_Text.color = pureColor;
                        break;
                }
            }

            Vector3 ScreenPoint = Camera.main.WorldToScreenPoint(dd.Position);
            //Vector3 pos;
            //RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform, new Vector2(ScreenPoint.x, ScreenPoint.y), Camera.main, out pos);
            this.transform.position = ScreenPoint;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            //timer += elapseSeconds;
            //if (timer > 0.5f)
            //{
            //    timer = 0;
            //    Close();
            //}
        }
    }
}