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
        // Use this for initialization
        void Start()
        {
            Init();
        }
        void Init()
        {
            m_refPuzzleStrip = GetComponent<PuzzleStrip>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                CreateBasicPuzzle();
            }
        }

        [ContextMenu("Create Puzzle")]
        public void CreateBasicPuzzle()
        {
            ClearPuzzle();
            //stop the playing strip
            m_refPuzzleStrip.StopStripAnim();
            //Spawn everything
            //Chose a Random puzzle 
            int temp_iRandomHeartPuzzle = Random.Range(0, m_lstHeartType.Count);
            Sprite m_refLeftSprite = m_lstHeartType[temp_iRandomHeartPuzzle].m_refLeftSide;
            Sprite m_refRightSprite = m_lstHeartType[temp_iRandomHeartPuzzle].m_refRightSide;

            //Logic is if left is chose as X from 1-4 then on Right 4-x postion shouldnt be chosen!
            int temp_iPosInLeftStrip = Random.Range(0,4);
            int temp_iPosInRightStrip = 3 - temp_iPosInLeftStrip;//***3 that 
            do
            {
                temp_iPosInRightStrip = Random.Range(0,4);//Oh dear Lord
            } while (temp_iPosInRightStrip == (3 - temp_iPosInLeftStrip) );
            Debug.LogError("LeftIndex:"+ temp_iPosInLeftStrip+",RightIndex:"+ temp_iPosInRightStrip);
            //Chose the item at this index
            m_refLeftItem[temp_iPosInLeftStrip].UpdateValues(eItemType.HeartLeft, m_refLeftSprite,true);
            m_refRightItem[temp_iPosInRightStrip].UpdateValues(eItemType.HeartRight, m_refRightSprite, true);

            //Fill others with whatever

            //start
            m_refPuzzleStrip.StartStripAnim(0);
        }

        private void ClearPuzzle()
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
    }
}