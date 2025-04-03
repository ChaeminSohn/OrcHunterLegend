using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public EnemyData data;
    private Rigidbody2D rigid;
    private Rigidbody2D target;
    private Animator anim;

    void OnEnable()
    {
        target = FindFirstObjectByType<PlayerMove>().GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("1_Move", true);
    }

    void FixedUpdate()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVac = dirVec.normalized * data.moveSpeed * Time.fixedDeltaTime;
        if (nextVac.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (nextVac.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        rigid.MovePosition(rigid.position + nextVac);
    }
}
