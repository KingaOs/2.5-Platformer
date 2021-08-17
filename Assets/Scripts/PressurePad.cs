using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Moving Box"))
        {
            float dist = Vector3.Distance(transform.position, other.transform.position);

            if(dist < 0.5f)
            {
                other.GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<MeshRenderer>().material.color = Color.green;
                Destroy(this);
            }

        }
    }
}
