using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class ScenesLoader : MonoBehaviour
    {
        public void LoadNextScene(int index)
        {
            SceneManager.LoadScene(index);
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}
