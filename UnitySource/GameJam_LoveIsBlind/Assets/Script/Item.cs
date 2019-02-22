using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sidz.BGameJam
{
    public enum eItemType
    {
        HeartLeft,
        HeartRight,
        HeartFull,
        Digit1,
        Digit0,
        Bomb
    }
    public class Item : MonoBehaviour
    {
       

        [Header("Setting:References")]
        [SerializeField] private Image m_refAttachedImage;

        [Header("Read Only")]
        [SerializeField] private eItemType m_eItemType;
        [SerializeField] private Sprite m_Digitt1;
        [SerializeField] private Sprite m_Digitt0;


        private Collider m_refAttaachedCollider;

        public Image _SpriteRenderer
        {
            get
            {
                return m_refAttachedImage;
            }

           
        }

        public eItemType _ItemType
        {
            get
            {
                return m_eItemType;
            }

            set
            {
                m_eItemType = value;
            }
        }

        // Use this for initialization
        void Start()
        {
            Init();
        }

        private void Init()
        {
            m_refAttaachedCollider = GetComponent<Collider>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateValues(eItemType a_eItemType, Sprite m_refSprite, bool a_bIsTriggerEnabled)
        {
            _ItemType = a_eItemType;
            m_refAttachedImage.sprite = m_refSprite;
            m_refAttaachedCollider.enabled = a_bIsTriggerEnabled;

        }

        ///Randomise between 0 or 1 digit
        public void UpdateValues()
        {
           if (UnityEngine.Random.Range(0, 8) %2 ==0)
            {
             
                UpdateValues(eItemType.Digit1, m_Digitt1, false);
            }
           else
            {
                UpdateValues(eItemType.Digit0, m_Digitt0, false);
            }
        }
    }
}