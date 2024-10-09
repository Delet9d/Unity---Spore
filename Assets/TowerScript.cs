using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            other.transform.parent = transform;
            other.gameObject.GetComponent<BlockScript>().SetTrigger(true);
            EventManager.onBoxHit();

            // ConfigurableJoint temp = other.gameObject.AddComponent<ConfigurableJoint>();
            // temp.xMotion = ConfigurableJointMotion.Locked;
            // temp.yMotion = ConfigurableJointMotion.Locked;
            // temp.zMotion = ConfigurableJointMotion.Locked;
            // temp.angularXMotion = ConfigurableJointMotion.Locked;
            // temp.angularYMotion = ConfigurableJointMotion.Locked;
            // temp.angularZMotion = ConfigurableJointMotion.Limited;
            // temp.angularZLimit = new SoftJointLimit(){ limit = 7f };
            
            other.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    
}