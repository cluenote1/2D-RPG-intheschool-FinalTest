using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image CharacterImg;
    public Text IdText;

    public Slider HpSlider;

    public Text monsterCountText;
    public Text timerText;
    public Text coinText;

    private GameObject player;
    public GameObject spawnPos;

    private float elapsedTime;

    void Start()
    {
        
        IdText.text = GameManager.Instance.UserID;
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);

        // 타이머 텍스트 확인
        if (timerText == null)
        {
            Debug.LogError("Timer Text is not assigned!");
        }

        elapsedTime = 0f;

        // 코인 UI 업데이트
        UpdateCoinUI();

    }



    void Update()
    {
        elapsedTime += Time.deltaTime;

        // 경과 시간을 분과 초로 변환
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // 시간 포맷 설정
        if (timerText != null)
        {
            if (minutes > 0)
            {
                timerText.text = string.Format("{0:D1}분 {1:D2}초", minutes, seconds);
            }
            else
            {
                timerText.text = string.Format("{0:D1}초", seconds);
            }
            Debug.Log("Time Updated: " + timerText.text);
        }

        // 몬스터 카운트 업데이트
        int count = GameManager.Instance.monsterCount;
        monsterCountText.text = " : " + count.ToString();
        Debug.Log("Monster Count Updated: " + count);

        // 다른 UI 요소 업데이트
        display();
    }

    private void display()
    {
        if (CharacterImg != null && player != null)
        {
            CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        }

        if (HpSlider != null)
        {
            HpSlider.value = GameManager.Instance.PlayerHP;
        }
    }

    public void UpdateCoinUI()
    {
        coinText.text = " : " + GameManager.Instance.Coin.ToString();
    }
}
