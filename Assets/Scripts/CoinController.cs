using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.IncrementCoin(10); // 플레이어가 동전을 먹었을 때 코인 증가
            Destroy(gameObject); // 동전 오브젝트 삭제
        }
    }
}
