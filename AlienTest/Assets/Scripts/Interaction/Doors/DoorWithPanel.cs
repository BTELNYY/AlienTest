using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithPanel : InteractableObject
{
    [Header("Door Setup")]
    public Transform DoorModel;
    public float Speed;
    public Vector3 MovePosition;
    bool startMove;
    public override void interact()
    {
        startMove = true;
    }
    void Start()
    {
        startMove = false;
    }
    void Update()
    {
        if (DoorModel.position != MovePosition && startMove)
        {
            DoorModel.position = Vector3.MoveTowards(transform.position, MovePosition, Speed * Time.deltaTime);
        }
        else
        {
            startMove = false;
        }
    }
}
