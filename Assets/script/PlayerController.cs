using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool citizen = false;
    private Collider data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (citizen == true && Input.GetKeyUp(KeyCode.E))
        {
            data.gameObject.transform.GetComponent<Target>().saved();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "citizen") {
            citizen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "citizen") {
            data = other;
            citizen = true;
        }
        else if (other.gameObject.name == "outlaw")
        {
            other.gameObject.transform.GetComponent<Target>().saved();
        }
        else if (other.gameObject.name == "zombie")
        {
            other.gameObject.transform.GetComponent<Target>().saved();
        }
    }
}
