using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sidz.BGameJam
{
    public class PuzzleDetector : MonoBehaviour
    {
        [SerializeField] private List<Item> m_lstCollidedItem;
        [SerializeField] private bool bDetectionEnabled = true;


        private Animator m_refAttachedAnimator;
        public bool _DetectionEnabled
        {
            get
            {
                return bDetectionEnabled;
            }

            set
            {
                bDetectionEnabled = value;
            }
        }

        // Use this for initialization
        void Start()
        {
            Init();
        }

        private void Init()
        {
            m_lstCollidedItem = new List<Item>();
            m_refAttachedAnimator = GetComponent<Animator>();
            PuzzleEventManager._Instance.EvntOnPuzzleRoundStarted += CallBack_PuzzleRoundStarted;

        }
        void OnEnable()
        {
             
        }
        void OnDisable()
        {
            if(PuzzleEventManager._Instance)
            PuzzleEventManager._Instance.EvntOnPuzzleRoundStarted -= CallBack_PuzzleRoundStarted;
        }

        private void CallBack_PuzzleRoundStarted(int a_iCurrentLevel, int a_iCurrentRound)
        {
            Debug.Log("New Round Started,clearing :CurrentLEvel:"+ a_iCurrentLevel+",Round:"+ a_iCurrentRound);
            _DetectionEnabled = true;
            m_lstCollidedItem.Clear();
        }

        // Update is called once per frame
        void Update()
        {

        }

        #region EVENT_HOOKUP

        public void PlayIdle()
        {
            m_refAttachedAnimator.SetTrigger("Trigger_Idle");
        
        }
        private void UpdateMatchList(Item a_refItem)
        {
            if(_DetectionEnabled == false)
            {
                Debug.LogError("Dection Disabled...");
                return;
            }
            m_lstCollidedItem.Add(a_refItem);
            if(m_lstCollidedItem.Count>=2)
            {
                m_refAttachedAnimator.SetTrigger("Trigger_MatchFound");
                PuzzleEventManager._Instance.Fire_EvntOnMatchFound(this,m_lstCollidedItem);
                Debug.Log("Match Found");
                _DetectionEnabled = false;
            }
        }
        #endregion EVENT_HOOKUP

        private void OnTriggerEnter(Collider other)
        {
            var temp_Item = other.GetComponent<Item>();
            if (temp_Item != null)
            {
                Debug.Log("OnTriggerEnter" + temp_Item._ItemType.ToString());
                if(temp_Item._ItemType == eItemType.HeartLeft || temp_Item._ItemType == eItemType.HeartRight)
                {
                   if(m_lstCollidedItem.Contains(temp_Item) == false)
                    {
                        UpdateMatchList(temp_Item);
                    }
                   else
                    {
                        Debug.LogError("Item already present in list,Not Possible");
                    }
                }
              
            }
        }
        private void OnTriggerExit(Collider other)
        {
            var temp_Item = other.GetComponent<Item>();
            if (temp_Item != null)
            {
                Debug.Log("OnTriggerExit->"+ temp_Item._ItemType.ToString());
                if (temp_Item._ItemType == eItemType.HeartLeft || temp_Item._ItemType == eItemType.HeartRight)
                {
                    if (m_lstCollidedItem.Contains(temp_Item) == true)
                    {
                        m_lstCollidedItem.Remove(temp_Item);
                    }
                    else
                    {
                        Debug.LogError("Item not present in list,not Possible");
                    }
                }
            }
        }
    }
}