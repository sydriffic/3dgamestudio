using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{

    RaycastHit hit;
    public Camera cam;
    bool hasPinkKey = false, hasGoldKey = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 20, Color.red);

        if(Physics.Raycast(ray, out hit))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(hit.collider.gameObject.name == "Key")
                {
                    if(hit.collider.gameObject.tag == "Pink")
                    {
                        hasPinkKey = true;
                    }
                    if(hit.collider.gameObject.tag == "Gold")
                    {
                        hasGoldKey = true;
                    }
                    Destroy(hit.collider.gameObject);
                }

                if(hit.collider.gameObject.name == "DoorLocked")
                {
                    if(hit.collider.gameObject.tag == "Pink" && hasPinkKey)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    if(hit.collider.gameObject.tag == "Gold" && hasGoldKey)
                    {
                        Application.Quit();
                    }
                }
                Debug.Log(hit.collider.gameObject.tag);
            }

        
        }
    }
}
