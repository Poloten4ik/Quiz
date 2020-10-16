using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ExitScene : MonoBehaviour
    {
        public Text result;
        private GameManager right;
        void Start()
        {
            right = FindObjectOfType<GameManager>();
            float number = right._result;
            float number2 = right.QuizSoList.Count;
            float number3 = number / number2 * 100;
            result.text = number3.ToString() + "%";
            Destroy(right.gameObject);
        }
    }
}
