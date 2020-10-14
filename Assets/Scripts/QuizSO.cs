using UnityEngine;

[CreateAssetMenu(menuName = "Question", fileName = "New Question")]

public class QuizSO : ScriptableObject
{
    [TextArea(10, 30)]
    public string question;
    public string[] variants;
}

