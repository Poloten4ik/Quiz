using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Text questionText;
        public Text[] variantsText;
        public Text questionNumber;


        public Button[] variantBttns = new Button[4];
        public Button helpbttn;
       
        public List<QuizSO> QuizSoList;
        List<object> questionList;
        QuizSO currentQuestion;

        public int _health = 3;
        public Image[] lives;

        public int _result = 0;
        public int _questionNumber = 0;

        private int randQuestion;

        public void Awake()
        {
            questionList = new List<object>(QuizSoList);
            StartCoroutine(QuestionGenerate());
        }
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
        public IEnumerator QuestionGenerate()
        {
            yield return new WaitForSeconds(0.5f);
            if (questionList.Count > 0)
            {
                randQuestion = Random.Range(0, questionList.Count);
                currentQuestion = questionList[randQuestion] as QuizSO;
                questionText.text = currentQuestion.question;
                List<string> variants = new List<string>(currentQuestion.variants);


                for (int i = 0; i < currentQuestion.variants.Length; i++)
                {
                    int rand = Random.Range(0, variants.Count);
                    variantsText[i].text = variants[rand];
                    variants.RemoveAt(rand);
                    variantBttns[i].GetComponent<Image>().color = Color.white;
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

            for (int i = questionList.Count - 1; i < questionList.Count; i++)
            {
                _questionNumber += 1;
                questionNumber.text = _questionNumber.ToString() + " / " + QuizSoList.Count;
            }
             
            HeartsUpdate();     
        }

        public void VariantsBttns(int index)
        {

            if (variantsText[index].text.ToString() != currentQuestion.variants[0])
            {
                variantBttns[index].image.color = Color.red;

                _health -= 1;

                if (_health == 0)
                {
                    SceneManager.LoadScene(2);
                }
            }
            else
            {
                _result++;
                variantBttns[index].GetComponent<Image>().color = Color.green;
            }
            questionList.RemoveAt(randQuestion);
            StartCoroutine(QuestionGenerate());

        }

        public void HelpBttn()
        {

            for (int i = 0; i < variantBttns.Length; i++)
            {
                if (variantsText[i].text.ToString() == currentQuestion.variants[0])
                {
                    variantBttns[i].gameObject.SetActive(true);
                }
                else if (variantsText[i].text.ToString() == currentQuestion.variants[1] || variantsText[i].text.ToString() == currentQuestion.variants[2])
                {
                    variantBttns[i].gameObject.SetActive(false);
                }
            }
            helpbttn.gameObject.SetActive(false);
        }
        public void HeartsUpdate()
        {
            for (int i = 0; i < lives.Length; i++)
            {
                if (i < _health)
                {
                    lives[i].enabled = true;
                }
                else
                {
                    lives[i].enabled = false;
                }
            }
        }
    }
}
