using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ally : MonoBehaviour
{
    [Header("# Enemy Info")]
    public string enemyName;
    public float health;


    NavMeshAgent nav; //NAVMesh는 RigidBody Lock 걸음 오옹;;
    Rigidbody rigid;

    Vector3 destination = new Vector3(25f, 0f, 300f); //나중에 여기에 목적지 입력

    bool isAlive = false;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        //nav.SetDestination(transform.position);
        switch (enemyName)
        {
            case "MTE":
                isAlive = true;
                transform.rotation = Quaternion.Euler(new Vector3(0f ,-90f,0f));
                transform.tag = "Ally";
                this.gameObject.layer = 6; //Ally
                health = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(isAlive)
        {
            nav.enabled = true;
            nav.SetDestination(destination);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            OnHit(1);
        }
    }

    void OnHit(int dmg)
    {
        health -= dmg;
        if (health<=0)
        {
            StartCoroutine(Test());
        }
    }

    private IEnumerator Test()
    {
        isAlive = false;
        transform.tag = "Untagged";
        this.gameObject.layer = 2;
        nav.enabled = false;
        rigid.velocity = transform.up * 20 + transform.forward * (-1);
        yield return new WaitForSeconds(50f);
        gameObject.SetActive(false);
    }
}

