using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public GameObject prefab;
    public float fullHP;
    public float attackDmg;
    public float moveSpeed;

}
