// UIManager.cs

using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text killCountText;
    public Text coinCountText;    

    public void InitializeUI()
    {
        UpdateKillCountText(0);
        UpdateCoinText(0);
    }

    public void UpdateKillCountText(int remainingMonsterCount)
    {
        if (killCountText != null)
        {
            killCountText.text = ": " + remainingMonsterCount;
        }
    }

    public void UpdateCoinText(int coin)
    {
        if (coinCountText != null)
        {
            coin += coin;
            Debug.Log("Updating coin text to " + coin);
            coinCountText.text = ": " + coin;
        }
        else
        {
            Debug.LogError("Coin Text is not assigned in UIManager.");
        }
    }
   
    


}
