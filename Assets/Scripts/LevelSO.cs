using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSO : MonoBehaviour
{

    public List<QuizSO> QuizSoList;
    public Text qText;
    public Text[] variantsText;
    public Button[] variantBttns = new Button[4];
    public int _result = 0;
    public int health = 3;
    public Text healthText;

    List<object> qList;
    QuizSO _crntQ;
    int randQ;

    public void Awake()
    {
        qList = new List<object>(QuizSoList);
        QuestionGenerate();
        print(health);
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
            _crntQ = qList[randQ] as QuizSO;
            qText.text = _crntQ.question;
            healthText.text = "Жизней: " + health.ToString();
            List<string> variants = new List<string>(_crntQ.variants);
            for (int i = 0; i < _crntQ.variants.Length; i++)
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
        if (variantsText[index].text.ToString() == _crntQ.variants[0])
        {
            _result++;
        }
        else
        {
            health -= 1;
            print(health);
            if (health == 0)
            {
                SceneManager.LoadScene(2);
            }

        }
        qList.RemoveAt(randQ);
        QuestionGenerate();
    }
}

