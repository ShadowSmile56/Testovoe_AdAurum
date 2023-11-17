using UnityEngine;
using UnityEngine.UI;

public class IS : MonoBehaviour
{
    public Image targetImage; // ������ �� ��������� Image, ���� �� ������ ��������� �����������
    public string imagePath = "backgrounds/Forest"; // ���� � ����������� � ����� Resources

    void Start()
    {
        SetImage(imagePath);
    }

    void SetImage(string path)
    {
        Sprite sprite = Resources.Load<Sprite>(path);

        if (sprite != null)
        {
            targetImage.sprite = sprite; // ��������� ������� ��� ���������� Image
        }
        else
        {
            Debug.LogError("Image not found at path: " + path);
        }
    }
}
