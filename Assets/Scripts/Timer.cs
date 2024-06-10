using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; // 타이머를 표시할 Text 컴포넌트
    private float elapsedTime; // 경과 시간

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

        elapsedTime += Time.deltaTime; // 경과 시간 업데이트

        // 경과 시간을 분과 초로 변환
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // 시간 포맷 설정
        if (minutes > 0)
        {
            timerText.text = string.Format("{0:D1}분 {1:D2}초", minutes, seconds);
        }
        else
        {
            timerText.text = string.Format("{0:D1}초", seconds);
        }

        Debug.Log("Time Updated: " + timerText.text); // 디버그 메시지 추가
    }
}
