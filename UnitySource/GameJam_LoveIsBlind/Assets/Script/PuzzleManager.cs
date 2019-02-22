using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sidz.BGameJam
{
    public class PuzzleManager : MonoBehaviour
    {
        [System.Serializable]
        public class Level
        {
            [Range(1, 5)]
            public int m_iNumberOfRounds = 1;

            public SO_PuzzleLevel m_refSettingsToUse;
        }


        [Header("ReadOnly")]
        public int m_iCurrentLevel = 0;
        public int m_iCurrentLevelRound = 0;
        public int m_iCompletedSpawner = 0;

      [Header("Puzzle Management")]
        [SerializeField] private List<PuzzleCreator> m_refPuzzleSpawnmers;
        [SerializeField] private List<Level> m_GameLevels;

        // Use this for initialization
        void Start()
        {
            Init();
        }

        private void Init()
        {
            m_iCurrentLevel = 0;
            m_iCurrentLevelRound = 0;
            m_iCompletedSpawner = 0;
            PuzzleEventManager._Instance.EvntOnMatchFound += AMatchFound;
        }
        private void Reset()
        {
            m_iCurrentLevel = 0;
            m_iCurrentLevelRound = 0;
            m_iCompletedSpawner = 0;

        }
        void OnDisable()
        {
            if (PuzzleEventManager._Instance)
                PuzzleEventManager._Instance.EvntOnMatchFound -= AMatchFound;
        }

        private void AMatchFound(PuzzleDetector a_refDetector, List<Item> m_lstItem)
        {
           
            foreach (PuzzleCreator temp_puzzleCreators in m_refPuzzleSpawnmers)
            {
                if (temp_puzzleCreators._PuzzleDetector == a_refDetector)
                {
                    m_iCompletedSpawner++;
                    temp_puzzleCreators.StopAllStripPuzzleMovement(0.0f);
                }
            }
            if(m_iCompletedSpawner >= m_refPuzzleSpawnmers.Count)
            {
                Debug.LogError("Go to Next Level...");
                StartCoroutine(coTimer());
               
            }
        }
        IEnumerator coTimer()
        {
            yield return new WaitForSeconds(3);
            NextLevel();
        }

        void OnEnable()
        {

        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextLevel();
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Reset();
            }
        }


        [ContextMenu("Test Puzzle Manager")]
        public void NextLevel()
        {
            if (m_iCurrentLevel >= m_GameLevels.Count)
            {
                Debug.LogError("All Levels Complete!");
                return;
            }

            if (m_iCurrentLevelRound >= m_GameLevels[m_iCurrentLevel].m_iNumberOfRounds)
            {
                Debug.LogError("Current Level Complete as rounds are over...!" + m_iCurrentLevel);
                m_iCompletedSpawner = 0;
                m_iCurrentLevel++;
            }
            else
            {
                m_iCurrentLevelRound++;
            }

            if (m_iCurrentLevel >= m_GameLevels.Count)
            {
                Debug.LogError("All Levels Complete!");
                return;
            }

            m_iCompletedSpawner = 0; 
            foreach (PuzzleCreator temp_puzzleCreators in m_refPuzzleSpawnmers)
            {
                temp_puzzleCreators._PuzzleDetector.PlayIdle();
                temp_puzzleCreators.CreateBasicPuzzle(m_GameLevels[m_iCurrentLevel].m_refSettingsToUse);
            }
            PuzzleEventManager._Instance.Fire_EvntOnPuzzleRoundStarted(m_iCurrentLevel, m_GameLevels[m_iCurrentLevel].m_iNumberOfRounds);


        }

    }
}