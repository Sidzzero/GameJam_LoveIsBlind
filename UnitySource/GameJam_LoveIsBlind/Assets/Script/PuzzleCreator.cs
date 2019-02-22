using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sidz.BGameJam
{
    [System.Serializable]
    public class HeartType
    {
        public string m_strName="Simple Heart";
        public Sprite m_refLeftSide;
        public Sprite m_refRightSide;

    }
    public class PuzzleCreator : MonoBehaviour
    {


        [Header("Initial  Reference")]
        [SerializeField] private List<RectTransform> m_refLeftStrip;
        [SerializeField] private List<RectTransform> m_refRightStrip;
        [Space(5)]
        [SerializeField] private GameObject m_refItemType_1;
        [SerializeField] private GameObject m_refItemType_0;
        [Header("Avaiable Heart Item")]
        [SerializeField] private Sprite m_FullHeart;
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

        }

        [ContextMenu("Create Puzzle")]
        public void CreatePuzzle()
        {
            //stop the playing strip
            m_refPuzzleStrip.StopStripAnim();
            //Spawn everything

            //start
        }
    }
}