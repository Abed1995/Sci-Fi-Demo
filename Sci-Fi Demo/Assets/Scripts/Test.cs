using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private MeshRenderer targetCube;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position,-transform.right,out hit,Mathf.Infinity))
        {
            targetCube = hit.transform.GetComponent<MeshRenderer>();
            targetCube.material.color = Color.blue;
        }
        else
        {
            if (targetCube!=null)
            {
                targetCube.material.color = Color.red;
            }
          
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, -transform.right * 50);
    }
}
