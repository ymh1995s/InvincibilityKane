using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] string towerName; //타워 여러개명 종류 구분용
    [SerializeField] float range = 0f; //사정거리
    [SerializeField] float damage; //딜
    [SerializeField] float spinSpeed; // 회전속도
    [SerializeField] float rateOfAcc; //정확도
    [SerializeField] float rateOfFire; // 연사속도
    [SerializeField] float viewAngle; // 시야각
    [SerializeField] Transform muzzle; // 포구위치
    [SerializeField] LayerMask layerMask = 0; //타게팅할 레이어
    [SerializeField] Transform tfGunBody; //포탑
    [SerializeField] ParticleSystem particleFlash; //포신 섬광
    [SerializeField] GameObject go_HitEffect_Prefab; //적중 이펙트
    [SerializeField] int bulletSpeed = 100;

    private RaycastHit hitInfo; // 광선 충돌 객체의 정보 저장
    private Quaternion bulletRot; //총알 방향
    //AudioSource theAudio;

    private bool isFindTarget = false;
    private bool isAttack = false; //총구방향과 적 방향이 일치 할 시 공격

    private Transform tf_Target;

    //[SerializeField] AudioClip soundFire;
    
    float currentRateOfFire; //연사속도 계산용

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
        SearchEnemy(); //탐색만
        LookTarget(); //탐색하고 발견했으면 모가지 돌림
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
