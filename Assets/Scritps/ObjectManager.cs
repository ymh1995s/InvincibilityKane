using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [Header("프리펩")]
    public GameObject MTEPrefab;
    public GameObject Bullet1Prefab;
    public GameObject Bullet2Prefab;

    [Header("오브젝트 풀")]
    GameObject[] targetPool;
    public GameObject[] MTEPool;
    public GameObject[] Bullet1Pool;
    public GameObject[] Bullet2Pool;

    [Header("오브젝트 풀의 위치")]
    [SerializeField]
    Transform tfPoolParent;

    int POOLMAX = 10000;

    private void Awake()
    {
        MTEPool = new GameObject[POOLMAX];
        Bullet1Pool = new GameObject[POOLMAX];
        Bullet2Pool = new GameObject[POOLMAX];

        Generate();
    }

    public void Generate()
    {
        for (int index = 0; index < MTEPool.Length; index++)
        {
            MTEPool[index] = Instantiate(MTEPrefab);
            MTEPool[index].SetActive(false);
            MTEPool[index].transform.SetParent(tfPoolParent);
        }

        for (int index = 0; index < Bullet1Pool.Length; index++)
        {
            Bullet1Pool[index] = Instantiate(Bullet1Prefab);
            Bullet1Pool[index].SetActive(false);
            Bullet1Pool[index].transform.SetParent(tfPoolParent);
        }

        for (int index = 0; index < Bullet2Pool.Length; index++)
        {
            Bullet2Pool[index] = Instantiate(Bullet2Prefab);
            Bullet2Pool[index].SetActive(false);
            Bullet2Pool[index].transform.SetParent(tfPoolParent);
        }
    }


    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "MTE":
                targetPool = MTEPool;
                break;
            case "Bullet1":
                targetPool = Bullet1Pool;
                break;
            case "Bullet2":
                targetPool = Bullet2Pool;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }
}
