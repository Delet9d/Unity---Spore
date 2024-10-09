using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private ScriptableObject EntityParameters;
    private void Awake()
    {
        Instantiate(HealthBar, transform.position + new Vector3(0, GetEntityHalfHeight() + 1, 0),
            Quaternion.identity, transform);
    }

    private float GetEntityHalfHeight()
    {
        return gameObject.GetComponent<BoxCollider>().size.y ;
    }
}
