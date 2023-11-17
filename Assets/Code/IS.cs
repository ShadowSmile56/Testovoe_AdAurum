using UnityEngine;
using UnityEngine.UI;

public class IS : MonoBehaviour
{
    public Image targetImage; // Ссылка на компонент Image, куда вы хотите поместить изображение
    public string imagePath = "backgrounds/Forest"; // Путь к изображению в папке Resources

    void Start()
    {
        SetImage(imagePath);
    }

    void SetImage(string path)
    {
        Sprite sprite = Resources.Load<Sprite>(path);

        if (sprite != null)
        {
            targetImage.sprite = sprite; // Установка спрайта для компонента Image
        }
        else
        {
            Debug.LogError("Image not found at path: " + path);
        }
    }
}
