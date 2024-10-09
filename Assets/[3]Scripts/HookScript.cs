using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    [SerializeField] private Transform PathPoints;
    [SerializeField] private float HookSpeed = 10f;
    private int CurrentForcePointIndex;
    private Rigidbody HookRB;
    private void Start()
    {
        CurrentForcePointIndex = 0;
        HookRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var temp = (PathPoints.GetChild(CurrentForcePointIndex).position - transform.position);
        temp.Normalize();
        HookRB.AddForce(temp * HookSpeed, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        ToNextPoint(other.transform.GetSiblingIndex());
    }
    
    private void ToNextPoint(int index)
    {
        if (index < PathPoints.childCount - 1)
            CurrentForcePointIndex = index + 1;
        else
            CurrentForcePointIndex = 0;
    }

}
