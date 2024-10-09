using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    
    [SerializeField] private float EntitySpeed;
    [SerializeField] private EntityMovementType MovementType;

    enum EntityMovementType
    {
        Velocity,
        ForceVelocity,
        Force,
        Impulse,
        Acceleration
    }
    // Start is called before the first frame update
    private Rigidbody EntityRB;
    private void Awake()
    {
        SetupEntityParams();
    }

    private void SetupEntityParams()
    {
        if(!gameObject.GetComponent<Rigidbody>()) 
            gameObject.AddComponent<Rigidbody>();
        EntityRB = GetComponent<Rigidbody>();

        EntityRB.useGravity = false;
    }


    private Vector3 MovementCalculation()
    {
        Vector3 Direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            Direction += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Direction += Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Direction += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Direction += Vector3.right;
        }
        
        Direction.Normalize();
        return Direction * Time.deltaTime;
    }

    private void EntityMovement()
    {
        if(MovementType == EntityMovementType.Velocity)
            EntityRB.velocity = MovementCalculation() * EntitySpeed;
        if(MovementType == EntityMovementType.ForceVelocity)
            EntityRB.AddForce(MovementCalculation()* EntitySpeed, ForceMode.VelocityChange);
        if(MovementType == EntityMovementType.Force)
            EntityRB.AddForce(MovementCalculation()* EntitySpeed, ForceMode.Force);
        if(MovementType == EntityMovementType.Impulse)
            EntityRB.AddForce(MovementCalculation()* EntitySpeed, ForceMode.Impulse);
        if(MovementType == EntityMovementType.Acceleration)
            EntityRB.AddForce(MovementCalculation()* EntitySpeed, ForceMode.Acceleration);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EntityMovement();
    }
}
