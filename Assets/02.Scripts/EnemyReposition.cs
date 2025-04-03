using UnityEngine;

public class EnemyReposition : MonoBehaviour
{
    private const float maxDistance = 20.0f;

    void OnEnable()
    {
        Reposition();
    }
    void Update()
    {
        Vector2 distance = (Vector2)GameManager.PlayerTransform.position - (Vector2)transform.position;
        if (distance.magnitude >= maxDistance) //플레이어와 너무 멀어졌을 경우
        {
            Reposition(); //재배치
        }
    }

    void Reposition()
    {
        float randomPosX = (Random.value > 0.5f) ? Random.Range(-5.0f, -3.0f) : Random.Range(3.0f, 5.0f);
        float randomPosY = (Random.value > 0.5f) ? Random.Range(-5.0f, -3.0f) : Random.Range(3.0f, 5.0f);
        //플레이어 근처 랜덤 위치에서 생성
        Vector2 newPos =
        (Vector2)GameManager.GetPlayerTransform().position + new Vector2(randomPosX, randomPosY);
        transform.position = newPos;
    }
}
