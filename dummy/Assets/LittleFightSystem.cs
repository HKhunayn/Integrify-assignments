using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class LittleFightSystem : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] EnemyData enemyData;
    [SerializeField] bool LookAtTheTarget = true;
    [SerializeField] public bool isShooting = true;
    [SerializeField] bool enemyFollowsTheTarget = true;
    [SerializeField] bool bulletFolowsTheTarget = false;
    [SerializeField] float moveSpeed = 1;

    [SerializeField] Transform bulletSpawnPoint;
    Rigidbody rb;
    Coroutine coroutine;

    private void Start()
    {
        //transform.parent.DOJump(transform.up,1,2,1);
        rb = transform.parent.GetComponent<Rigidbody>();
    }
    void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if (coroutine == null && isShooting)
                coroutine = StartCoroutine(ISpawnBullet(other.transform));

            var targetPos = other.transform.position;
            targetPos.y = transform.parent.position.y;
            if (LookAtTheTarget)
                transform.parent.LookAt(targetPos);
            //transform.parent.Rotate(new Vector3(-transform.parent.rotation.x,0,0));
            //Debug.Log(transform.parent.name);

            if (enemyFollowsTheTarget && Vector3.Distance(transform.parent.position,other.transform.position) > 4f)
            {
                rb.position= Vector3.Lerp(transform.parent.position, other.transform.position, moveSpeed*Time.fixedDeltaTime);
            }
        }

    }


    void OnTriggerExit(Collider other) 
    {
        if (coroutine != null) 
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }

    }


    IEnumerator ISpawnBullet(Transform target) 
    {
        while (true) 
        {
            yield return new WaitForSeconds(enemyData.Delay);
            //transform.parent.LookAt(target);
            Vector3 pos = bulletSpawnPoint != null ? bulletSpawnPoint.position : transform.parent.position + (target.position - transform.parent.position).normalized;
            GameObject g = Instantiate(bullet, pos, bullet.transform.rotation);
            //g.transform.LookAt(target.position);
            if (bulletFolowsTheTarget)
                g.GetComponent<Bullet>().SetTarget(target, enemyData.BulletSpeed);
            else
                g.GetComponent<Bullet>().SetDirection((target.position - pos), enemyData.BulletSpeed);
        }
    }

}
