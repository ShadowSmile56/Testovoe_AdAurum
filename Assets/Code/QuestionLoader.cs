using UnityEngine;


[System.Serializable]
public class QuestionData
{
    public Question[] questions;
}

public class QuestionLoader : MonoBehaviour
{
    public Question[] questions;
    public QuizManager quizManager;
    /*public Text questionText;
    public Button[] answerButtons;
    public Image backgroundImage;*/
    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("StreamingAssets/questions");
        if (jsonFile != null)
        {
            string jsonData = jsonFile.text;

            // ƒесериализаци€ JSON в структуру QuestionData
            QuestionData data = JsonUtility.FromJson<QuestionData>(jsonData);

            // ѕомещаем вопросы из структуры в массив
            questions = data.questions;
            quizManager.ReceiveQuestions(questions);

            // ѕример заполнени€ текста вопроса и текста кнопок из JSON
            /* if (questions.Length > 0)
             {
                 questionText.text = questions[0].questionText; // «аполнение текста вопроса

                 for (int i = 0; i < answerButtons.Length; i++)
                 {
                     if (i < questions[0].answers.Length)
                     {
                         answerButtons[i].GetComponentInChildren<Text>().text = questions[0].answers[i].text; // «аполнение текста кнопок ответов
                     }
                 }
                 LoadBackground(questions[0].background);
             }*/

        }
        else
        {
            Debug.LogError("Cannot load questions.json!");
        }
    }
    /*void LoadBackground(string imagePath)
    {
        if (!string.IsNullOrEmpty(imagePath))
        {
            string path = imagePath;
            print(path);
            Sprite backgroundSprite = Resources.Load<Sprite>(path);

            if (backgroundSprite != null)
            {
                backgroundImage.sprite = backgroundSprite;
            }
            else
            {
                Debug.LogError("Background image not found: " + imagePath);
            }
        }
        else
        {
            Debug.LogError("Background image path is empty!");
        }
    }*/
}