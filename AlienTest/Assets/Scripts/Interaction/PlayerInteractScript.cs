using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractScript : MonoBehaviour
{
    [Header("Ray Settings")]
    public float rayDistance;
    //perhaps cahnge to a cone or line...?
    public float rayShpereRadius;
    public LayerMask interactableLayer;
    public Transform m_cam;
    private void Awake()
    {

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            CastRay();
        }
    }

    void CastRay()
    {
        //mghit need a chnge to player position?
        Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
        RaycastHit _hitInfo;

        bool _hitSomething = Physics.SphereCast(_ray, rayShpereRadius, out _hitInfo, rayDistance, interactableLayer);
        Debug.DrawRay(_ray.origin, _ray.direction * rayDistance, _hitSomething ? Color.green : Color.red);
        if (_hitSomething)
        {
            //did it hit the thing
            InteractableObject _interactable = _hitInfo.transform.GetComponent<InteractableObject>();


            if (_interactable != null)
            {
                _interactable.interact();


            }
            else
            {
                Debug.Log("No interactible in object");
            }
        }
    }
}
