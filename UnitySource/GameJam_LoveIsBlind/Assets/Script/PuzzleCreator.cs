using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sidz.BGameJam
{
    [System.Serializable]
    public class HeartType
    {
        public string m_strName = "Simple Heart";
        public Sprite m_refLeftSide;
        public Sprite m_refRightSide;

    }
    public class PuzzleCreator : MonoBehaviour
    {


        [Header("Initial  Reference")]
        [SerializeField] private PuzzleDetector m_refPuzzleDetector;
        [SerializeField] private List<RectTransform> m_refLeftStrip;
        [SerializeField] private List<RectTransform> m_refRightStrip;
        [Space(25)]
        [Header("Only Items REferences")]
        [SerializeField] private List<Item> m_refLeftItem;
        [SerializeField] private List<Item> m_refRightItem;

        [Header("Avaiable Heart Item")]
        [SerializeField] private Sprite m_FullHeart;
        [SerializeField] private Sprite m_Digitt1;
        [SerializeField] private Sprite m_Digitt0;

        [SerializeField] private List<HeartType> m_lstHeartType;

        private PuzzleStrip m_refPuzzleStrip;

        public PuzzleDetector _PuzzleDetector
        {
            get
            {
                return m_refPuzzleDetector;
            }

            set
            {
                m_refPuzzleDetector = value;
            }
        }

        // Use this for initialization
        void Start()
        {
            Init();
        }
        void Init()
        {
            m_refPuzzleStrip = GetComponent<PuzzleStrip>();
        }
        void OnDisable()
        {
            if (PuzzleEventManager._Instance)
                PuzzleEventManager._Instance.EvntOnMatchFound -= AMatchFound;
        }
        Coroutine m_coMatchAnim = null;
        private void AMatchFound(PuzzleDetector a_refDetector, List<Item> m_lstItem)
        {
            if(a_refDetector == m_refPuzzleDetector)
            {
                //foreach (Item temp_items in m_refLeftItem)
                //{
                //    temp_items.UpdateValues(eItemType.HeartFull, m_FullHeart, false);
                //}
                //foreach (Item temp_items in m_refRightItem)
                //{
                //    temp_items.UpdateValues(eItemType.HeartFull, m_FullHeart, false);
                //}

                if (m_coMatchAnim != null)
                {
                    StopCoroutine(m_coMatchAnim);
                }
                m_coMatchAnim = StartCoroutine(coMatchAnim(m_lstItem));


            }
        }
        IEnumerator coMatchAnim(List<Item> m_lstItem)
        {
            for (int i=0;i< m_lstItem.Count;i++)
            {
                //  m_refLeftItem[i].UpdateValues(eItemType.HeartFull, m_FullHeart, false);
                m_lstItem[i].UpdateValues(eItemType.HeartFull, m_FullHeart, false);
                m_lstItem[i].UpdateValues();
                yield return new WaitForSeconds(0.5f);
            }
           
        }

        void OnEnable()
        {
          
                PuzzleEventManager._Instance.EvntOnMatchFound += AMatchFound;
        }
        // Update is called once per frame
        void Update()
        {
            //if(Input.GetKeyDown(KeyCode.Space))
            //{
            //    CreateBasicPuzzle();
            //}
        }
        public void CreateBasicPuzzle(SO_PuzzleLevel a_mLevelSettings)
        {
            if (m_coMatchAnim != null)
            {
                StopCoroutine(m_coMatchAnim);
            }
            ClearPuzzle();
            //stop the playing strip

            if (m_refPuzzleStrip ==null)
            {
                m_refPuzzleStrip = GetComponent<PuzzleStrip>();
            }
            m_refPuzzleStrip.StopStripAnim();
            //Spawn everything
            //Chose a Random puzzle 
            int temp_iRandomHeartPuzzle = UnityEngine.Random.Range(0, m_lstHeartType.Count);
            Sprite m_refLeftSprite = m_lstHeartType[temp_iRandomHeartPuzzle].m_refLeftSide;
            Sprite m_refRightSprite = m_lstHeartType[temp_iRandomHeartPuzzle].m_refRightSide;

            //Logic is if left is chose as X from 1-4 then on Right 4-x postion shouldnt be chosen!
            int temp_iPosInLeftStrip = UnityEngine.Random.Range(0, 4);
            int temp_iPosInRightStrip = 3 - temp_iPosInLeftStrip;//***3 that 
            do
            {
                temp_iPosInRightStrip = UnityEngine.Random.Range(0, 4);//Oh dear Lord
            } while (temp_iPosInRightStrip == (3 - temp_iPosInLeftStrip));
            Debug.LogError("LeftIndex:" + temp_iPosInLeftStrip + ",RightIndex:" + temp_iPosInRightStrip);
            //Chose the item at this index
            m_refLeftItem[temp_iPosInLeftStrip].UpdateValues(eItemType.HeartLeft, m_refLeftSprite, true);
            m_refRightItem[temp_iPosInRightStrip].UpdateValues(eItemType.HeartRight, m_refRightSprite, true);




            //Fill others with whatever
            if(a_mLevelSettings.m_iOtherFill>0)
            {
                List<HeartType> temp_OtherHeart = new List<HeartType>(m_lstHeartType);
                List<Item> temp_OtherLeftItems = new List<Item>(m_refLeftItem);
                List<Item> temp_OtherRightItems = new List<Item>(m_refRightItem);
                temp_OtherLeftItems.RemoveAt(temp_iPosInLeftStrip);
                temp_OtherRightItems.RemoveAt(temp_iPosInRightStrip);

                temp_OtherHeart.Remove(m_lstHeartType[temp_iRandomHeartPuzzle]);

                bool temp_bUseLeftHearts = UnityEngine.Random.Range(1, 6) % 2 == 0 ? true : false;
                eItemType temp_eItem = temp_bUseLeftHearts ? eItemType.HeartLeft : eItemType.HeartRight;
                Sprite temp_Sprite = null;
                int temp_randomNumber = 0;
                int temp_iOtherAddCount = 0;
                
                for (int i=0;i< temp_OtherLeftItems.Count; i++ )
                {
                    temp_bUseLeftHearts = UnityEngine.Random.Range(1, 6) % 2 == 0 ? true : false;
                    temp_eItem = temp_bUseLeftHearts ? eItemType.HeartLeft : eItemType.HeartRight;


                    temp_randomNumber = UnityEngine.Random.Range(0, temp_OtherHeart.Count);
                    temp_Sprite = temp_bUseLeftHearts ? temp_OtherHeart[temp_randomNumber].m_refLeftSide:temp_OtherHeart[temp_randomNumber].m_refRightSide;
                    temp_OtherLeftItems[i].UpdateValues(temp_eItem, temp_Sprite, false);
                    temp_iOtherAddCount++;
                 

                    if (temp_iOtherAddCount>= a_mLevelSettings.m_iOtherFill)
                    {
                        break;
                    }

                }
                temp_iOtherAddCount = 0;
                for (int i= 0; i < temp_OtherRightItems.Count; i++)
                {
                    temp_bUseLeftHearts = UnityEngine.Random.Range(1, 6) % 2 == 0 ? true : false;
                    temp_eItem = temp_bUseLeftHearts ? eItemType.HeartLeft : eItemType.HeartRight;

                    temp_randomNumber = UnityEngine.Random.Range(0, temp_OtherHeart.Count);
                    temp_Sprite = temp_bUseLeftHearts ? temp_OtherHeart[temp_randomNumber].m_refLeftSide : temp_OtherHeart[temp_randomNumber].m_refRightSide;
                    temp_OtherRightItems[i].UpdateValues(temp_eItem, temp_Sprite, false);
                    temp_iOtherAddCount++;
                 
                    if (temp_iOtherAddCount >= a_mLevelSettings.m_iOtherFill)
                    {
                        break;
                    }
                }
            }


            //start
            m_refPuzzleStrip.StartStripAnim(0);
        }
        [ContextMenu("Create Puzzle")]
        public void CreateBasicPuzzle()
        {
            if (m_coMatchAnim != null)
            {
                StopCoroutine(m_coMatchAnim);
            }
            ClearPuzzle();
            //stop the playing strip
            m_refPuzzleStrip.StopStripAnim();
            //Spawn everything
            //Chose a Random puzzle 
            int temp_iRandomHeartPuzzle = UnityEngine.Random.Range(0, m_lstHeartType.Count);
            Sprite m_refLeftSprite = m_lstHeartType[temp_iRandomHeartPuzzle].m_refLeftSide;
            Sprite m_refRightSprite = m_lstHeartType[temp_iRandomHeartPuzzle].m_refRightSide;

            //Logic is if left is chose as X from 1-4 then on Right 4-x postion shouldnt be chosen!
            int temp_iPosInLeftStrip = UnityEngine.Random.Range(0,4);
            int temp_iPosInRightStrip = 3 - temp_iPosInLeftStrip;//***3 that 
            do
            {
                temp_iPosInRightStrip = UnityEngine.Random.Range(0,4);//Oh dear Lord
            } while (temp_iPosInRightStrip == (3 - temp_iPosInLeftStrip) );
            Debug.LogError("LeftIndex:"+ temp_iPosInLeftStrip+",RightIndex:"+ temp_iPosInRightStrip);
            //Chose the item at this index
            m_refLeftItem[temp_iPosInLeftStrip].UpdateValues(eItemType.HeartLeft, m_refLeftSprite,true);
            m_refRightItem[temp_iPosInRightStrip].UpdateValues(eItemType.HeartRight, m_refRightSprite, true);

            //Fill others with whatever

            //start
            m_refPuzzleStrip.StartStripAnim(0);
        }

        public void ClearPuzzle()
        {
            foreach(Item temp_items in m_refLeftItem)
            {
              //  temp_items.UpdateValues(eItemType.Digit0, m_Digitt0, false);
                temp_items.UpdateValues();
            }
            foreach (Item temp_items in m_refRightItem)
            {
               // temp_items.UpdateValues(eItemType.Digit0, m_Digitt1, false);
                temp_items.UpdateValues();
            }
        }


        public void StopAllStripPuzzleMovement(float a_stripSpeed)
        {
            m_refPuzzleStrip.StopStripAnim(0.01f);
        }

     
    }
}