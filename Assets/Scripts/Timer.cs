using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; // Ÿ�̸Ӹ� ǥ���� Text ������Ʈ
    private float elapsedTime; // ��� �ð�

    void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("Timer Text is not assigned!");
            return;
        }

        elapsedTime = 0f;
    }

    void Update()
    {
        if (timerText == null)
        {
            Debug.LogError("Timer Text is not assigned!");
            return;
        }

        elapsedTime += Time.deltaTime; // ��� �ð� ������Ʈ

        // ��� �ð��� �а� �ʷ� ��ȯ
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // �ð� ���� ����
        if (minutes > 0)
        {
            timerText.text = string.Format("{0:D1}�� {1:D2}��", minutes, seconds);
        }
        else
        {
            timerText.text = string.Format("{0:D1}��", seconds);
        }

        Debug.Log("Time Updated: " + timerText.text); // ����� �޽��� �߰�
    }
}
