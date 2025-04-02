using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Animator anim; //애니메이터
    public float moveSpeed; //이동 속도
    private Vector3 inputVec;  //인풋 벡터

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (inputVec == Vector3.zero) //움직임 관련 인풋이 없는 경우
        {
            anim.SetBool("1_Move", false);
            return;
        }
        anim.SetBool("1_Move", true); //움직이는 애니메이션 실행
        if (inputVec.x > 0) //오른쪽으로 움직이는 경우
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (inputVec.x < 0)    //왼쪽으로 움직이는 경우
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.Translate(inputVec * moveSpeed * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
