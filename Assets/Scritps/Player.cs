using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //필요한 컴포넌트
    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;

    private float applySpeed= 20f;

    //카메라 민감도
    [SerializeField]
    private float lookSensitivity;

    //카메라 한계
    [SerializeField]
    private float cameraRatationLimit; //카메라 위로(고개 치켜들 때 ) 리미트
    private float currentCameraRotationX = 0f; //정면 기본값

    [SerializeField] private GameObject ShopPage;

    //인터페이스 목록
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
        CameraRotation();       //좌우 캐릭터 회전
        CharacterRotation();        //상하 카메라 회전 
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

        //transform은 따로 선언안해도 자기 자신을 가르키는 듯
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
        //카메라를 min ~ max로 고정 (math.clamp로)
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
