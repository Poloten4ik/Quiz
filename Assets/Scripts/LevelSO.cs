using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSO : MonoBehaviour
{

    public QuestionList[] questions;
    public Text qText;
    public Text[] variantsText;
    public Button[] variantBttns = new Button[4];
    public int health = 0;

    List<object> qList;
    QuestionList crntQ;
    int randQ;

    public void Awake()
    {
        qList = new List<object>(questions);
        QuestionGenerate();
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void QuestionGenerate()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionList;
            qText.text = crntQ.question;
            List<string> variants = new List<string>(crntQ.variants);
            for (int i = 0; i < crntQ.variants.Length; i++)
            {
                int rand = Random.Range(0, variants.Count);
                variantsText[i].text = variants[rand];
                variants.RemoveAt(rand);
            }
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
    public void VariantsBttns(int index)
    {
        if (variantsText[index].text.ToString() == crntQ.variants[0])
        {
            health++;
        }
        else
        {

        }
        qList.RemoveAt(randQ);
        QuestionGenerate();
    }
}

[System.Serializable]
public class QuestionList
{
    [TextArea(10, 30)]
    public string question;
    public string[] variants = new string[4];
}
