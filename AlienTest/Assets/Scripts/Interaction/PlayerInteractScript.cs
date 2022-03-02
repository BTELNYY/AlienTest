using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractScript : MonoBehaviour
{
    public float rayRange = 4;

    void Update()
    {
        CastRay();
    }

    void CastRay()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, rayRange);
        if (hit)
        {
            GameObject hitObject = hitInfo.transform.gameObject;
            if (Input.GetKey(KeyCode.E))
            {
                if (hitObject.GetComponent<IInteractable>() == null)
                {
                    Debug.Log("No IInteractable in object.");
                }
                else
                {
                    hitObject.GetComponent<IInteractable>().Interact();
                }
            }
        }
    }
}
