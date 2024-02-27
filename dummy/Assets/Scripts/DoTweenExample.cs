using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTweenExample : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnEnemyAt;
    [SerializeField] Transform moveEnemyTo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;
        Debug.Log("Player entered");
        StartCoroutine(ISpawnEnemes(other.transform,5));

    }

    IEnumerator ISpawnEnemes(Transform target,int numberOfEmnemies) 
    {
        for (int i = 0; i < numberOfEmnemies; i++) 
        { 
            GameObject g =Instantiate(enemyPrefab, spawnEnemyAt.position, Quaternion.LookRotation(target.position,Vector3.up));
            //g.GetComponent<LittleFightSystem>()
            var seq = DOTween.Sequence();
            seq.Append(g.transform.DOMove(moveEnemyTo.position, 4));
            seq.Join(g.transform.DORotate(g.transform.up,4));
            yield return seq.WaitForCompletion();
            g.transform.GetChild(0).GetComponent<LittleFightSystem>().isShooting = true;
            yield return new WaitForSeconds(2);
            
        }
    }
}
