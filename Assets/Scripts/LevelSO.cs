using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSO : MonoBehaviour
{
    public Text qText;
    public Text[] variantsText;
    public Text question;
   

    public Button[] variantBttns = new Button[4];
    public Button helpbttn;

    public int _result = 0;
    public int _health = 3;
    public int _questionNumber = 0;
    int randQ;

    public Text healthText;
    public List<QuizSO> QuizSoList;
    List<object> qList;
    QuizSO _crntQ;
    
    public void Awake()
    {
        qList = new List<object>(QuizSoList);
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
            _crntQ = qList[randQ] as QuizSO;
            qText.text = _crntQ.question;
            healthText.text = "Жизней: " + _health.ToString();
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

        for (int i = 0; i < variantBttns.Length; i++)
        {
            variantBttns[i].gameObject.SetActive(true);
        }
        for (int i = qList.Count - 1; i < qList.Count; i++)
        {
            _questionNumber += 1;
            question.text = _questionNumber.ToString() + " / " + QuizSoList.Count;
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
            _health -= 1;
            
            if (_health == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
        qList.RemoveAt(randQ);
        QuestionGenerate();
    }

    public void HelpBttn()
    {
       
        for (int i = 0; i < variantBttns.Length; i++)
        {
            if (variantsText[i].text.ToString() == _crntQ.variants[0])
            {
                variantBttns[i].gameObject.SetActive(true);
            }
            else if(variantsText[i].text.ToString() == _crntQ.variants[1] || variantsText[i].text.ToString() == _crntQ.variants[2])
            {
                variantBttns[i].gameObject.SetActive(false);
            }
        }
        helpbttn.gameObject.SetActive(false);   
    }
}

