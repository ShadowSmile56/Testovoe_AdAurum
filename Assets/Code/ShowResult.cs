using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewPoint : MonoBehaviour
{
    public TMP_Text resultText;

    void Start()
    {
        // ѕолучаем количество правильных ответов из PlayerPrefs и отображаем его
        int correctAnswers = PlayerPrefs.GetInt("Count", 0);
        resultText.text = " оличество правильных ответов: " + correctAnswers;
    }
}
