using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sidz.BGameJam
{
    public class PuzzleEmployeReport : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI m_Report;
        [SerializeField] private PuzzleManager m_refPuzzleManager;
        // Use this for initialization
        void Start()
        {
            // m_refPuzzleManager.m_iCurrentLevel
           
            float m_efficeny= Mathf.LerpUnclamped(0,100, (1.0f*m_refPuzzleManager.LevelCrossed)/15.0f);
            
            m_Report.text = ""+ string.Format("{0:0}%",m_efficeny);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}