using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Coin")
            {
                GameManager.Instance.IncrementCoin(1);
                Debug.Log("Player Coin : " + GameManager.Instance.Coin);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "didguswns")
            {
                GameManager.Instance.PlayerHP += 10;
                Debug.Log("Player Coin : " + GameManager.Instance.PlayerHP);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "IShowSpeed")
            {
                collision.gameObject.GetComponent<Character>().IncreaseSpeed();
                Destroy(gameObject);
            }
            else if (gameObject.tag == "StrongAttack")
            {
                collision.gameObject.GetComponent<Character>().EatStrongAttackItem();
                Destroy(gameObject);
            }
        }
    }
}
