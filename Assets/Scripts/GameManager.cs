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
            // ���� �� UI �ʱ�ȭ
            uiManager.InitializeUI();
            uiManager.UpdateCoinText(Coin);
        }
    }

    // ���� ���� �޼��� �߰�
    public void IncrementCoin(int amount)
    {
        Coin += amount; // ���� ����
        Debug.Log("Current Coin: " + Coin);

        if (uiManager != null)
        {
            // UI ������Ʈ
            uiManager.UpdateCoinText(Coin);
        }
    }

    // ���� ���� �޼��� �߰�


    public void DecrementMonsterCount()
    {
        if (remainingMonsterCount > 0)
        {
            remainingMonsterCount--; // ���͸� óġ�� ������ ���� ���� ���� 1�� ���ҽ�ŵ�ϴ�.
            Debug.Log("Remaining Monster Count: " + remainingMonsterCount);

            if (remainingMonsterCount <= 0)
            {
                // ���� ���� �Ǵ� ���� ���� ���� ó��
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
