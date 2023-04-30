using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    public LayerMask WhatCanBeClickedOn;

    private NavMeshAgent MyAgent;

    private void Start()
    {
        MyAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Ray MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo;

            if(Physics.Raycast (MyRay, out HitInfo, 100, WhatCanBeClickedOn))
            {
                MyAgent.SetDestination(HitInfo.point);
            }
        }
    }
}
