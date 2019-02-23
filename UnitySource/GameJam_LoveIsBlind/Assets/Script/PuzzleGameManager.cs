using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sidz.BGameJam
{
    public class PuzzleGameManager : MonoBehaviour
    {
        [SerializeField] private GameObject m_refStoryBoard;


        [SerializeField] private GameObject GameSceneContent;
        [SerializeField] private Animator m_RefKEyBoard;

        [SerializeField] private PuzzleManager m_refPuzzleManager;
        // Use this for initialization
        void Start()
        {
            GameSceneContent.SetActive(false);
            m_RefKEyBoard.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Login()
        {
            GameSceneContent.SetActive(true);
            m_refStoryBoard.SetActive(false);
            m_refPuzzleManager.NextLevel();
            m_RefKEyBoard.enabled = true;
            
        }
        public void LogOut()
        {
            GameSceneContent.SetActive(false);
            m_RefKEyBoard.enabled = false;
        }
    }
}