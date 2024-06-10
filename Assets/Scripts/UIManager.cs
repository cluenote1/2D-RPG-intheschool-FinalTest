// UIManager.cs

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text killCountText;
    public Text coinCountText;

    private void Start()
    {
        InitializeUI();
    }

    public void InitializeUI()
    {
        if (killCountText != null)
        {
            killCountText.text = ": ";
        }
        if (coinCountText != null)
        {
            coinCountText.text = ": ";
        }
    }

    public void UpdateKillCountText(int remainingMonsterCount)
    {
        if (killCountText != null)
        {
            killCountText.text = ": " + remainingMonsterCount;
        }
    }

    public void UpdateCoinText(int coinAmount)
    {
        if (coinCountText != null)
        {
            coinCountText.text = ": " + coinAmount;
        }
    }
}
