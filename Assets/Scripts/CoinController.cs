using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.IncrementCoin(10); // �÷��̾ ������ �Ծ��� �� ���� ����
            Destroy(gameObject); // ���� ������Ʈ ����
        }
    }
}
