using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteract
{
    public bool isEnabled = true;
    public virtual void interact()
    {

    }
    public virtual void interactfail()
    {

    }
}
