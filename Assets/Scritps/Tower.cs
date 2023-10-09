using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] string towerName; //Ÿ�� �������� ���� ���п�
    [SerializeField] float range = 0f; //�����Ÿ�
    [SerializeField] float damage; //��
    [SerializeField] float spinSpeed; // ȸ���ӵ�
    [SerializeField] float rateOfAcc; //��Ȯ��
    [SerializeField] float rateOfFire; // ����ӵ�
    [SerializeField] float viewAngle; // �þ߰�
    [SerializeField] Transform muzzle; // ������ġ
    [SerializeField] LayerMask layerMask = 0; //Ÿ������ ���̾�
    [SerializeField] Transform tfGunBody; //��ž
    [SerializeField] ParticleSystem particleFlash; //���� ����
    [SerializeField] GameObject go_HitEffect_Prefab; //���� ����Ʈ
    [SerializeField] int bulletSpeed = 100;

    private RaycastHit hitInfo; // ���� �浹 ��ü�� ���� ����
    private Quaternion bulletRot; //�Ѿ� ����
    //AudioSource theAudio;

    private bool isFindTarget = false;
    private bool isAttack = false; //�ѱ������ �� ������ ��ġ �� �� ����

    private Transform tf_Target;

    //[SerializeField] AudioClip soundFire;
    
    float currentRateOfFire; //����ӵ� ����

    Vector3 temp =  new Vector3(0,0,0);
    Vector3 targetPos;


    // Start is called before the first frame update
    void Start()
    {
        //theAudio = GetComponent<AudioSource>();
        //theAudio.clip = soundFire;
    }

    private void FixedUpdate()
    {
        Spin();
        SearchEnemy(); //Ž����
        LookTarget(); //Ž���ϰ� �߰������� ���� ����
        Attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, temp);
    }

    // Update is called once per frame
    void Spin()
    {
        if (!isFindTarget && !isAttack)
        {
            Quaternion _spin = Quaternion.Euler(0f, tfGunBody.eulerAngles.y + (1f * spinSpeed * Time.deltaTime), 0f);
            tfGunBody.rotation = _spin;
        }
    }


    void SearchEnemy()
    {
        Collider[] _targets = Physics.OverlapSphere(transform.position, range, layerMask);

        for(int i=0; i<_targets.Length; i++)
        {
            Transform _targetTf = _targets[i].transform;

            //if(_targetTf.name=="Player") //Tag
            {
                Vector3 _direction = (_targetTf.position - tfGunBody.position).normalized;
                float _angle = Vector3.Angle(_direction, tfGunBody.forward);

                if(_angle < viewAngle *0.5f)
                {
                    tf_Target = _targetTf;
                    isFindTarget = true;

                    if(_angle < 5f) isAttack = true;
                    else isAttack = false;

                    return;
                }
            }
        }
        tf_Target = null;
        isAttack = false;
        isFindTarget = false;
    }

    private void LookTarget()
    {
        if(isFindTarget)
        {
            Vector3 _direction = (tf_Target.position - tfGunBody.position).normalized;
            temp = _direction;
            Quaternion t_lookRotation = Quaternion.LookRotation(_direction);
            Quaternion _rotation = Quaternion.Lerp(tfGunBody.rotation, t_lookRotation, 0.55f);
            tfGunBody.rotation = _rotation;
            bulletRot = _rotation;
        }
    }

    private void Attack()
    {
        if(isAttack)
        {
            currentRateOfFire += Time.deltaTime;
            if(currentRateOfFire >= rateOfFire)
            {
                currentRateOfFire = 0;
                //theAudio.Play();
                particleFlash.Play();


                GameObject bullet = GameManager.instance.objectManager.MakeObj("Bullet1");
                Rigidbody rigid = bullet.GetComponent<Rigidbody>();
                bullet.transform.position = muzzle.position;
                bullet.transform.rotation = bulletRot;
                rigid.velocity = (bullet.transform.forward* bulletSpeed) 
                    + new Vector3(Random.Range(-1, 1f) * rateOfAcc, Random.Range(-1, 0f) * rateOfAcc, 0f); 


                //if (Physics.Raycast(tfGunBody.position,
                //    tfGunBody.forward + new Vector3(Random.Range(-1, 1f) * rateOfAcc, Random.Range(-1, 1f) * rateOfAcc, 0f),
                //    out hitInfo, range, layerMask))
                //{

                //    GameObject _temp = Instantiate(go_HitEffect_Prefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                //    Destroy(_temp, 1f);

                //    if (hitInfo.transform.name == "Player")
                //    {
                //        //hitInfo.transform.GetComponent<Status>().DecreaseHP(Damage);
                //    }
                //}
            }
        }
    }
}
