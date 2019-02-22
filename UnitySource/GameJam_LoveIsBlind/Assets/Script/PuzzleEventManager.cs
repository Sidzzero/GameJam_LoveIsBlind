using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sidz.BGameJam
{
    public class PuzzleEventManager : MonoBehaviour
    {

        private static PuzzleEventManager _instance;
        private PuzzleEventManager()
        {

        }

        public static PuzzleEventManager _Instance
        {
            get
            {

                if (_instance == null)
                {
                    _instance = FindObjectOfType<PuzzleEventManager>();
                }
                return _instance;
            }

        }
        void Awake()
        {
            //Check if instance already exists
            if (_instance == null)

                //if not, set instance to this
                _instance = this;

            //If instance already exists and it's not this:
            else if (_instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

        }


        public delegate void OnPuzzleRoundStarted(int a_iCurrentLevel,int a_iCurrentRound);
        public OnPuzzleRoundStarted EvntOnPuzzleRoundStarted;
        public void Fire_EvntOnPuzzleRoundStarted(int a_iCurrentLevel, int a_iCurrentRound)
        {
            if (EvntOnPuzzleRoundStarted != null)
            {
                EvntOnPuzzleRoundStarted(a_iCurrentLevel, a_iCurrentRound);
            }
        }

        public delegate void OnMatchFound(PuzzleDetector a_refDetector,List<Item> m_lstItem);
        public OnMatchFound EvntOnMatchFound;
        public void Fire_EvntOnMatchFound(PuzzleDetector a_refDetector,List<Item> m_lstItem)
        {
            if (EvntOnMatchFound != null)
            {
                EvntOnMatchFound(a_refDetector,m_lstItem);
            }
        }


    }
}