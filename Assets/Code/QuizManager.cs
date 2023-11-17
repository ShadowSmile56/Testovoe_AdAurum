using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public Question[] allQuestions;

    public Text questionText;
    public Button[] answerButtons;
    public Image backgroundImage;
    public GameObject resultObject;
    public TMP_Text resultText;
    public Button nextQuestionButton;

    private int currentQuestionIndex = 0;

    public void ReceiveQuestions(Question[] receivedQuestions)
    {
        allQuestions = receivedQuestions;
        SetUIWithCurrentQuestion();
    }
    public void SetUIWithCurrentQuestion()
    {
        resultObject.SetActive(false);
        if (currentQuestionIndex < allQuestions.Length)
        {
            // ��������� ������ �������
            questionText.text = allQuestions[currentQuestionIndex].questionText;

            // ��������� ������ �� ������� �������
            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i < allQuestions[currentQuestionIndex].answers.Length)
                {
                    answerButtons[i].GetComponentInChildren<Text>().text = allQuestions[currentQuestionIndex].answers[i].text;
                }
            }

            // ��������� ����
            LoadBackground(allQuestions[currentQuestionIndex].background);
            
        }
        else
        {
            SceneManager.LoadScene("Result");
        }
    }
    void LoadBackground(string imagePath)
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
    }
    public void CheckAnswer(int selectedAnswerIndex)
    {
        
        bool isCorrect = IsAnswerCorrect(selectedAnswerIndex);
        resultText.text = isCorrect ? "�����!" : "�����������!";
        resultText.color = isCorrect ? Color.green : Color.red;
        resultObject.SetActive(true);
        if (isCorrect)
        {
            // ����������� ���������� ���������� ������� � ��������� � PlayerPrefs
            int correctAnswers = PlayerPrefs.GetInt("Count", 0);
            correctAnswers++;
            PlayerPrefs.SetInt("Count", correctAnswers);
            PlayerPrefs.Save();
        }
        currentQuestionIndex++;
    }
        
    private bool IsAnswerCorrect(int selectedAnswerIndex)
    {
        Answer[] answers = allQuestions[currentQuestionIndex].answers;
        return answers[selectedAnswerIndex].correct;
    }

}
