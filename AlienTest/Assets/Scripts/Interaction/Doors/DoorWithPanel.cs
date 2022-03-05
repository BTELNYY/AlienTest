using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithPanel : InteractableObject
{
    [Header("Door Setup")]
    public Transform DoorModel;
    public float Speed;
    public float MoveX;
    public bool KeepCurrentX;
    public float MoveY;
    public bool KeepCurrentY;
    public float MoveZ;
    public bool KeepCurrentZ;
    public bool MoveBackAfterFirstUse = true;
    public bool DespawnAfterMove = false;
    Vector3 OriginalPosition;
    Vector3 MovePosition;
    bool startMove;
    bool moveBack;
    public override void interact()
    {
        startMove = true;
        moveBack = !moveBack;
    }
    void Start()
    {
        OriginalPosition = DoorModel.position;
        if (KeepCurrentX)
        {
            MoveX = OriginalPosition.x;
        }
        if (KeepCurrentY)
        {
            MoveY = OriginalPosition.y;
        }
        if (KeepCurrentZ)
        {
            MoveZ = OriginalPosition.z;
        }
        MovePosition = new Vector3(MoveX, MoveY, MoveZ);
        startMove = false;
        moveBack = false;
    }
    void Update()
    {
        if (DoorModel.position != MovePosition && startMove)
        {
            Vector3 newPos = Vector3.MoveTowards(DoorModel.position, MovePosition, Speed * Time.deltaTime);
            DoorModel.position = newPos;
        }
        else if (moveBack && !MoveBackAfterFirstUse && !DespawnAfterMove)
        {
            Vector3 newPos = Vector3.MoveTowards(DoorModel.position, OriginalPosition, Speed * Time.deltaTime);
            DoorModel.position = newPos;
            
        }
        else
        {
            startMove = false;
        }
    }
}
