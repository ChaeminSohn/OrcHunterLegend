using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    private int currentIdx = 0;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    void Start()
    {
        StartCoroutine(AutoSpawnEnemy());
    }
    IEnumerator AutoSpawnEnemy()
    {
        while (!GameManager.IsGameOver)
        {
            Spawn(Random.Range(0, pools.Length - 1));
            yield return new WaitForSeconds(1.0f);
        }
    }

    void Spawn(int index)
    {
        Debug.Log("Spawn");
        GameObject select = null;
        foreach (GameObject obj in pools[index])
        {   //이미 생성된 오브젝트가 존재하고,
            if (!obj.activeSelf)    //비활성화 상태인 경우
            {
                select = obj;
                select.SetActive(true); //오브젝트 재활용
                break;
            }
        }

        if (select == null) //재활용 가능한 오브젝트를 못 찾은 경우
        {
            //새로 만들어서 리스트에 할당
            select = Instantiate(prefabs[index]);
            pools[index].Add(select);
        }
    }
}
