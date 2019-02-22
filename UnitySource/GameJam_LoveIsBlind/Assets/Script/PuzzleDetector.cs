using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sidz.BGameJam
{
    public class PuzzleDetector : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
       
        private void OnTriggerEnter(Collider other)
        {
            var temp_Item = other.GetComponent<Item>();
            if (temp_Item != null)
            {
                Debug.Log("OnTriggerEnter" + temp_Item._ItemType.ToString());
            }
        }
        private void OnTriggerExit(Collider other)
        {
            var temp_Item = other.GetComponent<Item>();
            if (temp_Item != null)
            {
                Debug.Log("OnTriggerExit->"+ temp_Item._ItemType.ToString());
            }
        }
    }
}