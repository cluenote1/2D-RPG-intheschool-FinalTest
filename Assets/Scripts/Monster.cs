using UnityEngine;

public class Monster : MonoBehaviour
{
    public float MonsterHP = 30f;
    public float MonsterDamage = 2f;
    public float MonsterExp = 3f;

    private float moveTime = 0f;
    private float TurnTime = 0;
    private bool isDie = false;

    public float MoveSpeed = 3f;
    public GameObject[] ItemObj;//마나, 채력 ,코인, 아이쇼 스피드

    private Animator MonsterAnimator;

    void Start()
    {
        GameManager.Instance.monsterCount++;
        MonsterAnimator = this.GetComponent<Animator>();
    }

    void Update()
    {
        MonsterMove();
    }

    private void MonsterMove()
    {
        if (isDie) return;

        moveTime += Time.deltaTime;

        if (moveTime <= TurnTime)
        {
            this.transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            TurnTime = Random.Range(1, 5);
            moveTime = 0;

            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie) return;

        if (collision.gameObject.tag == "Player")
        {
            MonsterAnimator.SetTrigger("Attack");
            GameManager.Instance.PlayerHP -= MonsterDamage;

            Debug.Log("PlayerHP : " + GameManager.Instance.PlayerHP);
        }

        if (collision.gameObject.tag == "Attack")
        {
            MonsterAnimator.SetTrigger("Damage");
            MonsterHP -= collision.gameObject.GetComponent<Attack>().BaseAttackDamage;

            if (MonsterHP <= 0)
            {
                MonsterDie();
                GameManager.Instance.DecrementMonsterCount();
            }
            Debug.Log("MonsterHP : " + MonsterHP);
        }
    }

    private void MonsterDie()
    {
        if (isDie) return;

        isDie = true;

        MonsterAnimator.SetTrigger("Die");
        GameManager.Instance.monsterCount--;
        GetComponent<Collider2D>().enabled = false;
        Invoke("CreateItem", 1.5f);
        Destroy(gameObject, 1.55f);
    }

    private void CreateItem()
    {
        int itemRandom = Random.Range(0, ItemObj.Length);
        if (itemRandom < ItemObj.Length)
        {
            Instantiate(ItemObj[itemRandom], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
