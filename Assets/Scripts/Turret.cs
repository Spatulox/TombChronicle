using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public float range = 15f;

    public string playerTag = "player";

    public Transform partToRotate;

    private float turnSpeed = 5f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(playerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestplayer = null;

        foreach (GameObject player in ennemies)
        {
            float distanceToplayer = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToplayer < shortestDistance)
            {
                shortestDistance = distanceToplayer;
                nearestplayer = player;
            }
        }

        if(nearestplayer != null && shortestDistance <= range)
        {
            target = nearestplayer.transform;
        }
        else
        {
            target = null;
        }
    }
	
    // Update is called once per frame
    void Update () {
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

  
}