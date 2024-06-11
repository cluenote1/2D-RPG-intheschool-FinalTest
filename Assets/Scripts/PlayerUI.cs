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

        // Ÿ�̸� �ؽ�Ʈ Ȯ��
        if (timerText == null)
        {
            Debug.LogError("Timer Text is not assigned!");
        }

        elapsedTime = 0f;

        // ���� UI ������Ʈ
        UpdateCoinUI();

    }



    void Update()
    {
        elapsedTime += Time.deltaTime;

        // ��� �ð��� �а� �ʷ� ��ȯ
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // �ð� ���� ����
        if (timerText != null)
        {
            if (minutes > 0)
            {
                timerText.text = string.Format("{0:D1}�� {1:D2}��", minutes, seconds);
            }
            else
            {
                timerText.text = string.Format("{0:D1}��", seconds);
            }
            Debug.Log("Time Updated: " + timerText.text);
        }

        // ���� ī��Ʈ ������Ʈ
        int count = GameManager.Instance.monsterCount;
        monsterCountText.text = " : " + count.ToString();
        Debug.Log("Monster Count Updated: " + count);

        // �ٸ� UI ��� ������Ʈ
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
