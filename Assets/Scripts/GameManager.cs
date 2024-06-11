using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Define.Player SelectedPlayer;
    public string UserID;

    public float PlayerHP = 100f;
    public float PlayerExp = 1f;
    public int SpeedUp = 0;
    public int Coin = 0;
    public int didguswns = 0;
    public int monsterCount = 0;
    public int remainingMonsterCount;

    private UIManager uiManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UserID = PlayerPrefs.GetString("ID");

        uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            // 시작 시 UI 초기화
            uiManager.InitializeUI();
            uiManager.UpdateCoinText(Coin);
        }
    }

    // 코인 증가 메서드 추가
    public void IncrementCoin(int amount)
    {
        Coin += amount; // 코인 증가
        Debug.Log("Current Coin: " + Coin);

        if (uiManager != null)
        {
            // UI 업데이트
            uiManager.UpdateCoinText(Coin);
        }
    }

    // 코인 감소 메서드 추가


    public void DecrementMonsterCount()
    {
        if (remainingMonsterCount > 0)
        {
            remainingMonsterCount--; // 몬스터를 처치할 때마다 남은 몬스터 수를 1씩 감소시킵니다.
            Debug.Log("Remaining Monster Count: " + remainingMonsterCount);

            if (remainingMonsterCount <= 0)
            {
                // 게임 종료 또는 다음 레벨 등의 처리
            }
            else if (uiManager != null)
            {
                uiManager.UpdateKillCountText(remainingMonsterCount);
            }
        }
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + SelectedPlayer.ToString());
        GameObject player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return player;
    }
}
