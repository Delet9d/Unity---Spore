using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private bool bTriggered;
    public void SetTrigger(bool b) { bTriggered = b; }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<BlockScript>() && other.transform.parent != null)
        {
            if (other.transform.parent.childCount == other.transform.GetSiblingIndex() + 1)
            {
                ConnectionFunc(other.gameObject.GetComponent<BlockScript>());
            }
        }
    }

    private void ConnectionFunc(BlockScript other)
    {
        if (bTriggered == false)
        {
            bTriggered = true;
            EventManager.onBoxHit();


            float diff = Mathf.Abs(other.transform.localPosition.x - transform.localPosition.x);     
            if (diff > 1.5f)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
                Invoke(nameof(DestroyObject), 3.0f);
                return;
            }
            
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            transform.parent = other.transform.parent;
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
