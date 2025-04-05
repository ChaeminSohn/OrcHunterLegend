using UnityEngine;

public class EnemyCtrl : LivingEntity
{
    public EnemyData data;
    private Rigidbody2D rigid;
    private Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("1_Move", true);
    }


    void FixedUpdate()
    {
        if (isDead) return;

        Vector2 dirVec = (Vector2)GameManager.PlayerTransform.position - rigid.position;
        Vector2 nextVac = data.moveSpeed * Time.fixedDeltaTime * dirVec.normalized;
        //바라보는 방향 조절
        if ((nextVac.x > 0 && transform.localScale.x != -1) ||
        (nextVac.x < 0 && transform.localScale.x != 1))
        {
            transform.localScale = new Vector3(-Mathf.Sign(nextVac.x), 1, 1);
        }
        rigid.MovePosition(rigid.position + nextVac);
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
    }
}
