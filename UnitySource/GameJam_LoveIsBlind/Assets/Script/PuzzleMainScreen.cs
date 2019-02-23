using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sidz.BGameJam
{
    public class PuzzleMainScreen : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        #region UI

        public void PlayGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        }
        public void QuitGame()
        {
            Application.Quit();
        }
        #endregion
    }
}