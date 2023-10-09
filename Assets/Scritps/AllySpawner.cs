using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    float spawnDelay = 5f;
    new Vector3 spawnPoint = new Vector3(24f, 3f, -35f);
    new Vector3[,] spawnPoint2 = new Vector3[10,10];


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                spawnPoint2[i,j] = spawnPoint + (Vector3.right * j*2f) + (Vector3.forward * i*2f);
            }
        }
        InvokeRepeating("AllySpawn", 0f, spawnDelay);
    }

    public void AllySpawn()
    {
        if(GameManager.instance.MTE > 0)
        {
            GameManager.instance.MTE -= 100;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    GameObject ally = GameManager.instance.objectManager.MakeObj("MTE");
                    ally.transform.position = spawnPoint2[i, j];
                    //Ally enemyLogic = ally.GetComponent<Ally>();
                }
            }
        }
    }
}
