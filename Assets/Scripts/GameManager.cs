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
    private PlayerUI playerUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
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
            
        }

        playerUI = FindObjectOfType<PlayerUI>();
        if (playerUI != null)
        {
            playerUI.UpdateCoinUI();
        }

        
    }

    // ���� ���� �޼��� �߰�
    
    public void IncreamentCoin(int amount)
    {
        Coin += amount;
        Debug.Log("current Coin: " + Coin);

        if (uiManager != null)
        {
            // UI ������Ʈ
            uiManager.UpdateCoinText(Coin);
            Debug.Log("current Coin2: " + Coin);
            // UI ������Ʈ �޼��� ȣ��
            if (playerUI != null)
            {
                playerUI.UpdateCoinUI();
                Debug.Log("current Coin3: " + Coin);
            }
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
