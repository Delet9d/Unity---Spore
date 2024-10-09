using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class PlatformScript : MonoBehaviour
{
    [SerializeField] private GameObject BoxPrefab;
    [SerializeField] private GameObject Hook;
    [SerializeField] private GameObject BoxParent;
    [SerializeField] private GameObject PathHook;
    
    
    private GameObject CurrentBox;

    private int TotalBoxes = 0;
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
        EventManager.OnBoxHit += SpawnPlatform;
    }

    private void Start()
    {
        SpawnPlatform();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody r = CurrentBox.GetComponent<Rigidbody>();
            r.isKinematic = false;
            r.AddForce(Vector3.down * 10, ForceMode.Impulse);
            CurrentBox.transform.parent = null;
        }
        
        _camera.transform.position = Vector3.Slerp( _camera.transform.position,
            new Vector3(_camera.transform.position.x, BoxParent.transform.childCount * 3 + 5,
            _camera.transform.position.z) , Time.deltaTime);
        PathHook.transform.position = new Vector3(PathHook.transform.position.x, 
            BoxParent.transform.childCount * 3 + 10, PathHook.transform.position.z);
    }
    
    public void SpawnPlatform()
    {
        CurrentBox = Instantiate(BoxPrefab, Hook.transform.position - new Vector3(0, 2.5f, 0), Quaternion.identity, Hook.transform);
    }


}
