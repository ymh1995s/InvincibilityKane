using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rigid;
    BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ally" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Obstacle")
        {
            rigid.angularVelocity = new Vector3(0, 0, 0);
            gameObject.SetActive(false);
        }
    }
}
