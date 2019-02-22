using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sidz.BGameJam
{
    [CreateAssetMenu(fileName = "SO_PuzzleLevel", menuName = "GameLevel/PuzzleLevel", order = 1)]
    public class SO_PuzzleLevel : ScriptableObject
    {

        [Range(0,3)]
        public int m_iOtherFill;//Other hearts...
        public bool m_bEnableBomb = false;

       
    }
}