using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuizSO : MonoBehaviour
{
    public Image _currentBG;
    public Text _textQuestion;
    public LevelSO _currentLevel;
    public LevelSO _startLevel;

    public Text textVariant1;
    public Text textVariant2;
    public Text textVariant3;
    public Text textVariant4;
    private void Start()
    {
        _currentLevel = _startLevel;
        _currentBG.sprite = _currentLevel.Bg;
        _textQuestion.text = _currentLevel.question;

        textVariant1.text = _currentLevel.variant[0];
        textVariant2.text = _currentLevel.variant[1];
        textVariant3.text = _currentLevel.variant[2];
        textVariant4.text = _currentLevel.variant[3];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentLevel = _currentLevel.nextLevel;
            _currentBG.sprite = _currentLevel.Bg;
            _textQuestion.text = _currentLevel.question;

            textVariant1.text = _currentLevel.variant[0];
            textVariant2.text = _currentLevel.variant[1];
            textVariant3.text = _currentLevel.variant[2];
            textVariant4.text = _currentLevel.variant[3];
        }
    }

    public void Check(int index)
    {
        if(index == _currentLevel.rightVariant)
        {
            _currentLevel = _currentLevel.nextLevel;
            _currentBG.sprite = _currentLevel.Bg;
            _textQuestion.text = _currentLevel.question;

            textVariant1.text = _currentLevel.variant[0];
            textVariant2.text = _currentLevel.variant[1];
            textVariant3.text = _currentLevel.variant[2];
            textVariant4.text = _currentLevel.variant[3];
        }
        else
        {
            print("False");
        }
    }
}


