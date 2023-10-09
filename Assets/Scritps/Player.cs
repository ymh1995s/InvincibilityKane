using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�ʿ��� ������Ʈ
    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;

    private float applySpeed= 20f;

    //ī�޶� �ΰ���
    [SerializeField]
    private float lookSensitivity;

    //ī�޶� �Ѱ�
    [SerializeField]
    private float cameraRatationLimit; //ī�޶� ����(�� ġ�ѵ� �� ) ����Ʈ
    private float currentCameraRotationX = 0f; //���� �⺻��

    [SerializeField] private GameObject ShopPage;

    //�������̽� ���
    [SerializeField] private GameObject AD;
    [SerializeField] private GameObject CAM;
    [SerializeField] private GameObject Chat;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        OpenShop();
        OpenInterface();
        Move();
        CameraRotation();       //�¿� ĳ���� ȸ��
        CharacterRotation();        //���� ī�޶� ȸ�� 
    }

    private void OpenShop()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (ShopPage.activeSelf)
            {
                Time.timeScale = 1f;
                ShopPage.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                ShopPage.SetActive(true);
            }
        }
    }   

    private void OpenInterface()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (AD.activeSelf)
            {
                AD.SetActive(false);
                CAM.SetActive(false);
                Chat.SetActive(false);
            }
            else
            {
                AD.SetActive(true);
                CAM.SetActive(true);
                Chat.SetActive(true);
            }
        }
    }


    void MoveExample()
    {
        float moveZ = 0f;
        float moveX = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveZ += 1f;
        }
        transform.Translate(new Vector3(moveX, 0f, moveZ) * 0.1f);
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        //transform�� ���� ������ص� �ڱ� �ڽ��� ����Ű�� ��
        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxis("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));

    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxis("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        //ī�޶� min ~ max�� ���� (math.clamp��)
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRatationLimit, cameraRatationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            OnHit(1);
        }
    }

    public void OnHit(int dmg)
    {
        GameManager.instance.HP -= dmg;
        if (GameManager.instance.HP <= 0)
        {
            Time.timeScale = 0f;
            GameManager.instance.GameOver();
        }
    }

}
