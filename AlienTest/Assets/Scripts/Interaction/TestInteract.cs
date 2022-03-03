using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteract : InteractableObject
{
    public override void interact()
    {
        base.interact();
        Debug.Log("Test Interact");
    }
}
