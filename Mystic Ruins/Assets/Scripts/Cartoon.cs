using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cartoon : MonoBehaviour
{
    public Image[] images; // �̹��� �迭, Inspector â���� �̹������� �Ҵ�
    public float fadeInDuration = 1f; // ������ ������� �ð�
    public GameObject SceneManager;
    private int currentIndex = 0;

    void Start()
    {
        if (images == null || images.Length == 0)
        {
            Debug.LogError("Images not set!");
            return;
        }

        // �ʱ� �̹��� ���� (ù ��° �̹����� ��� ����)
        SetImageAlpha(0);

        // ������ �̹����� ó������ �����ϰ� ����
        for (int i = 1; i < images.Length; i++)
        {
            SetImageAlpha(i, 0);
        }
        ShowNextImage();
    }

    void Update()
    {
        // ����: ���콺 Ŭ���� ������ ���� �̹����� ������ ������� ��
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextImage();
        }
    }

    void ShowNextImage()
    {
        // ���� �̹����� ������ �����ϰ�
        //tartCoroutine(FadeImage(currentIndex, 0));

        // ���� �̹����� ������ �������
        currentIndex = (currentIndex + 1) % images.Length;
        if (currentIndex == 0)
        {
            SceneManager.GetComponent<ResetGameData>().ResetData();
            SceneManager.GetComponent<ChangeScene>().ToMainScene();
        }
        StartCoroutine(FadeImage(currentIndex, 1));
    }

    IEnumerator FadeImage(int index, float targetAlpha)
    {
        Image targetImage = images[index];
        Color startColor = targetImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);

        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            targetImage.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetImage.color = targetColor;
    }

    void SetImageAlpha(int index, float alpha = 1)
    {
        Color color = images[index].color;
        color.a = alpha;
        images[index].color = color;
    }
}