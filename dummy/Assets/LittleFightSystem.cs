using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LittleFightSystem : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] EnemyData enemyData;
    Coroutine coroutine;
    void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if (coroutine == null)
                coroutine = StartCoroutine(ISpawnBullet(other.transform));

            var targetPos = other.transform.position;
            targetPos.y = transform.parent.position.y;

            transform.parent.LookAt(targetPos);
            //transform.parent.Rotate(new Vector3(-transform.parent.rotation.x,0,0));
            //Debug.Log(transform.parent.name);
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
            Vector3 pos = transform.parent.position + Vector3.forward;
            pos = 3* pos.normalized + transform.parent.position;
            GameObject g = Instantiate(bullet, pos, bullet.transform.rotation);
            g.transform.LookAt(target.position);

            g.GetComponent<Bullet>().speed = enemyData.BulletSpeed;
            Vector3 dir = target.position - transform.position;
            dir.Normalize();
            g.GetComponent<Bullet>().Direction = dir;
        }
    }

}
