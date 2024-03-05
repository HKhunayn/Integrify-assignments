using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class ClickTOMove : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] GameObject spawnedObj;
    Camera cam;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 dir = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 5)) - cam.transform.position;
            dir = dir.normalized;
            RaycastHit hit;
            Physics.Raycast(cam.transform.position, dir, out hit);

            
            Vector3 pos = hit.point;

            agent.destination = pos;
            //Debug.Log($"Going to {pos} and the Dis={hit.distance}");
            //Instantiate(spawnedObj, pos, Quaternion.identity);
        }
    }
}
