using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sidz.BGameJam
{
    public class PuzzleGameManager : MonoBehaviour
    {
        [SerializeField] private GameObject m_refStoryBoard;
        [SerializeField] private GameObject m_refReport;
        [SerializeField] private TMPro.TextMeshProUGUI m_Timer;
        public float m_timer  = 180;


        [SerializeField] private GameObject GameSceneContent;
        [SerializeField] private Animator m_RefKEyBoard;

        [SerializeField] private PuzzleManager m_refPuzzleManager;


        private bool m_bFirstTime = true;

        private Coroutine timerCoroutine = null;
        private Color m_textColor;
        // Use this for initialization
        void Start()
        {
            GameSceneContent.SetActive(false);
            m_RefKEyBoard.enabled = false;
            m_textColor = m_Timer.color;

            PuzzleEventManager._Instance.EvntOnTimerComplete += TimerComplete;
        }
        void OnDisable()
        {
            if(PuzzleEventManager._Instance.EvntOnTimerComplete !=null)
            PuzzleEventManager._Instance.EvntOnTimerComplete -= TimerComplete;
        }

        private void TimerComplete()
        {
            LogOut();
            m_refReport.SetActive(true);
        }


        // Update is called once per frame
        void Update()
        {

        }

        public void Login()
        {
            if(m_bFirstTime == false)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
                return;
            }

            m_bFirstTime = false;
            GameSceneContent.SetActive(true);
            m_refStoryBoard.SetActive(false);
            m_refPuzzleManager.NextLevel();
            m_refPuzzleManager.LevelCrossed = 0;
            m_refPuzzleManager.Reset();
            m_RefKEyBoard.enabled = true;
            StartTimer();
            m_Timer.color = m_textColor;
            m_refReport.SetActive(false);
        }
        public void LogOut()
        {
            GameSceneContent.SetActive(false);
            m_RefKEyBoard.enabled = false;
            StopTimer();
            m_Timer.color = m_textColor;
           
        }

        public void ExitOffice()
        {
            LogOut();
            UnityEngine.SceneManagement.SceneManager.LoadScene("IntroScene");
        }
        private void StartTimer()
        {
            if(timerCoroutine !=null)
            {
                StopCoroutine(coTimer());
            }
            StartCoroutine(coTimer());
        }
        private void StopTimer()
        {
            if (timerCoroutine == null)
            {
                StopCoroutine(coTimer());
            }
        }
        IEnumerator coTimer()
        {
            float temp_f = 0;

            float temp_fStartTime = 7.0f*60*60;


            //Lerp from 8 to 6 
            //
            float temp_fRepeat = 0;
            float temp_Hour = 0;
            string strTime = "A.M";
            while(temp_f<m_timer)
            {
                temp_f += 1.0f*Time.deltaTime;
                temp_fStartTime += temp_f;
                //m_Timer.text = FormatTimerText(temp_fStartTime);
                temp_fRepeat = Mathf.Repeat(temp_f*10, 60);
                // string.Format("{0:00}:{1:00}", Mathf.FloorToInt(Mathf.Lerp(7, 18, temp_f / m_timer)), temp_fRepeat);
                // m_Timer.text = "" +  Mathf.FloorToInt(Mathf.Lerp(7, 18, temp_f / m_timer)) + ":"+ temp_fRepeat;

                temp_Hour = Mathf.FloorToInt(Mathf.Lerp(7, 18, temp_f / m_timer));
                if(temp_Hour>12)
                {
                    strTime = "P.M";
                }
                m_Timer.text= string.Format("{0:00}:{1:00} {2}", temp_Hour, temp_fRepeat, strTime);

                m_Timer.color = Color.Lerp(m_textColor,Color.red,(temp_f / m_timer) );
                //   m_Timer.text = ""+ Mathf.FloorToInt(temp_f);
                yield return new WaitForEndOfFrame();
            }
            m_Timer.color = Color.red;

            PuzzleEventManager._Instance.Fire_EvntOnTimerComplete();

        }
        private string temp_strDisplayTime = "";
        private float temp_fSeconds = 0;
        private float temp_fMinutes = 0;
        private float temp_fHours = 0;
        private string FormatTimerText(float a_fTimer)
        {
            temp_fSeconds = 0;
            temp_fMinutes = 0;
            if (a_fTimer > 60)
            {
                temp_fMinutes = Mathf.FloorToInt(a_fTimer / 60);
            }
            temp_fSeconds = Mathf.FloorToInt((a_fTimer % 60) * 1);
            temp_fHours = Mathf.FloorToInt(temp_fMinutes / 60);

           // temp_strDisplayTime = string.Format("{0}:{1:0}:{2:0}", temp_fHours, temp_fMinutes, (temp_fSeconds));
            temp_strDisplayTime = string.Format("{0:00}:{1:00}", temp_fHours, temp_fMinutes);
            return temp_strDisplayTime;
        }
    }
}