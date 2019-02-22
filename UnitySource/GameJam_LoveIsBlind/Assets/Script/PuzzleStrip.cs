﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sidz.BGameJam
{
    public class PuzzleStrip : MonoBehaviour
    {
        public const float const_fFrameJump = 0.15f;
        public const float const_fMinSpeed = 0.45f;
        [Header("Settings:UI")]
        [SerializeField] private Slider m_SpeedSlider ;

        [Header("Settings:Strip")]
        [SerializeField] private Animator m_LeftAnimator;
        [SerializeField] private Animator m_RightAnimator;

        private float m_fCurrentLeftStartFrame = 0;
        private float m_fCurrentRightStartFrame = 0;

        
        // Use this for initialization
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void Init()
        {
            m_fCurrentLeftStartFrame = 0;
            m_fCurrentRightStartFrame = 0;
            m_LeftAnimator.Play("LeftToRight", 0, m_fCurrentLeftStartFrame);
            m_RightAnimator.Play("RightToLeft", 0, m_fCurrentRightStartFrame);
            m_SpeedSlider.onValueChanged.AddListener(OnSpeedSliderChange);
        }

        private void OnSpeedSliderChange(float arg0)
        {
           
            m_LeftAnimator.speed = Mathf.Max( arg0 * const_fMinSpeed,0.45f);
            m_RightAnimator.speed = Mathf.Max(arg0 * const_fMinSpeed, 0.45f);
            //   m_LeftAnimator.Play("LeftToRight", 0, m_fCurrentLeftStartFrame);
            // m_RightAnimator.Play("RightToLeft", 0, m_fCurrentRightStartFrame);
        }

        #region UI_BUTTON
        public void IncreaseLeftJump()
        {
            m_fCurrentLeftStartFrame += const_fFrameJump;
            m_LeftAnimator.Play("LeftToRight", 0, m_fCurrentLeftStartFrame);
        }
        public void DecreaseLeftJump()
        {
            m_fCurrentLeftStartFrame -= const_fFrameJump;

            m_fCurrentLeftStartFrame = Mathf.Max(0, m_fCurrentLeftStartFrame);
            m_LeftAnimator.Play("LeftToRight", 0, m_fCurrentLeftStartFrame);
        }


        public void IncreaseRightJump()
        {
            m_fCurrentRightStartFrame += const_fFrameJump;
            m_RightAnimator.Play("RightToLeft", 0, m_fCurrentRightStartFrame);
        }
        public void DecreaseRightJump()
        {
            m_fCurrentRightStartFrame -= const_fFrameJump;

            m_fCurrentRightStartFrame = Mathf.Max(0, m_fCurrentRightStartFrame);
            m_RightAnimator.Play("RightToLeft", 0, m_fCurrentRightStartFrame);
        }
        #endregion UI_BUTTON
    }
}