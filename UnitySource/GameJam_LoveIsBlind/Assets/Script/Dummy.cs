using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sidz.BGameJam
{
   
    public class Dummy : MonoBehaviour
    {
        public static float const_fMinSpeed = 0.25f;
        public static float const_fMaxSpeed = 0.25f;


        public Text m_LeftSpeed;
        public Text m_RightSpeed;
        public Animator m_RightAnim;
        public Animator m_LeftAnim;

        // Use this for initialization
        void Start()
        {
            UpdateSpeed();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void UpdateSpeed()
        {
            m_RightSpeed.text = "Right:" + m_RightAnim.speed;
            m_LeftSpeed.text = "Left:" + m_LeftAnim.speed;
        }

        public void IncreaseSpeed(Animator a_refAnimator)
        {
            float temp_fSpeed = a_refAnimator.speed;
            temp_fSpeed += 0.25f;
            a_refAnimator.speed = Mathf.Max(temp_fSpeed, const_fMaxSpeed);
            // this.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "(+)"+a_refAnimator.speed;
            UpdateSpeed();
        }
        public void DecreaseSpeed(Animator a_refAnimator)
        {
            float temp_fSpeed = a_refAnimator.speed;
            temp_fSpeed -= 0.25f;
            a_refAnimator.speed = Mathf.Max( temp_fSpeed, const_fMinSpeed);
            //   this.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "(-)" + a_refAnimator.speed;
            UpdateSpeed();
        }

     

    }
}