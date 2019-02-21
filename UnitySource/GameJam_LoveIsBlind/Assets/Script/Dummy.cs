using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sidz.BGameJam
{
   
    public class Dummy : MonoBehaviour
    {
        public static float const_fMinSpeed = 0.15f;
        public static float const_fMaxSpeed = 0.15f;

        public static float const_fMinMultiplier = 0.15f;
        public static float const_fMaxMultiplier = 0.15f;

        public Text m_LeftSpeed;
        public Text m_RightSpeed;
        public Animator m_RightAnim;
        public Animator m_LeftAnim;


        public float m_fLeftStart =0;
        public float m_fRightStart =0;

        public bool m_bEnableOFF = false;
        // Use this for initialization
        void Start()
        {
            m_RightAnim.speed = 0.5f;
            m_LeftAnim.speed = 0.5f;

            m_LeftAnim.Play("MoveForward", 0,0);
            m_RightAnim.Play("MoveForward", 0,0);
        }

        // Update is called once per frame
        void Update()
        {

        }
        [ContextMenu("Test Me")]
        public void TestMe()
        {
            m_RightAnim.speed = 0.5f;
            m_LeftAnim.speed = 0.5f;
            m_LeftAnim.Play("MoveForward", 0, 0.15f*2);
            m_RightAnim.Play("MoveForward", 0, 0.15f);
        }
        public void UpdateSpeed()
        {
            return;
            m_RightSpeed.text = "Right:" + m_RightAnim.speed;
            m_LeftSpeed.text = "Left:" + m_LeftAnim.speed;
            // m_RightAnim.Play("MoveReverse", 0, 0);

           
            
            m_LeftAnim.Play("MoveForward", 0, m_LeftAnim.speed);
            m_RightAnim.Play("MoveForward", 0, m_RightAnim.speed);
        }

        public void IncreaseSpeed(Animator a_refAnimator)
        {
            float temp_fSpeed = a_refAnimator.speed;
            temp_fSpeed += const_fMinSpeed;
            a_refAnimator.speed = Mathf.Max(temp_fSpeed, const_fMaxSpeed);
            // this.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "(+)"+a_refAnimator.speed;


        }
        public void DecreaseSpeed(Animator a_refAnimator)
        {
            float temp_fSpeed = a_refAnimator.speed;
            temp_fSpeed -= const_fMinSpeed;
            a_refAnimator.speed = Mathf.Max( temp_fSpeed, const_fMinSpeed);
            //   this.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "(-)" + a_refAnimator.speed;
           
        }

        public void IncreaseSpeedRight()
        {

            m_fRightStart += const_fMinMultiplier;


            m_RightAnim.Play("MoveForward", 0, m_fRightStart);
            m_LeftAnim.Play("MoveForward", 0, m_fLeftStart);

        }
        public void DecreaseSpeedRight()
        {
            m_fRightStart -= const_fMinMultiplier;

            m_fRightStart = Mathf.Max(m_fRightStart, 0.0f);
            m_RightAnim.Play("MoveForward", 0, m_fRightStart);
            m_LeftAnim.Play("MoveForward", 0, m_fLeftStart);
        }
        public void IncreaseSpeedLeft()
        {
            m_fLeftStart += const_fMinMultiplier;
            m_LeftAnim.Play("MoveForward", 0,m_fLeftStart);
            m_RightAnim.Play("MoveForward", 0, m_fRightStart);
        }
        public void DecreaseSpeedLeft()
        {
            m_fLeftStart -= const_fMinMultiplier;
            m_fLeftStart = Mathf.Max(m_fLeftStart, 0.0f);
            m_LeftAnim.Play("MoveForward", 0, m_fLeftStart);
            m_RightAnim.Play("MoveForward", 0, m_fRightStart);
        }

    }
}