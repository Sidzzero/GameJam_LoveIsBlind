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


        private Collider m_refAttaachedCollider;

        public Image _SpriteRenderer
        {
            get
            {
                return m_refAttachedImage;
            }

           
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateValues(eItemType a_eItemType, Sprite m_refSprite, bool a_bIsTriggerEnabled)
        {
            m_eItemType = a_eItemType;
            m_refAttachedImage.sprite = m_refSprite;
            m_refAttaachedCollider.enabled = a_bIsTriggerEnabled;

        }
    }
}