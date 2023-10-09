using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float spinSpeed = 50f; // ȸ���ӵ�

    // Start is called before the first frame update
    void Start()
    {
        SetCoin();
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    void SetCoin()
    {
        //������ ������ ����
    }

    void Spin()
    {
        Quaternion _spin = Quaternion.Euler(0f, transform.eulerAngles.y + (1f * spinSpeed * Time.deltaTime), 0f);
        transform.rotation = _spin;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int temp = PlayerPrefs.GetInt("Coin");
            PlayerPrefs.SetInt("Coin", temp+1);
            gameObject.SetActive(false);
        }
    }

}
