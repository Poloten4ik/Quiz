using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScene : MonoBehaviour
{
    public Text result;

    private LevelSO right;
    void Start()
    {
        right = FindObjectOfType<LevelSO>();
        float number = right._result;
        float number2 = right.QuizSoList.Count;
        float number3 = number / number2 * 100;
        result.text = number3.ToString() + "%";
        Destroy(right.gameObject);
    }
}
