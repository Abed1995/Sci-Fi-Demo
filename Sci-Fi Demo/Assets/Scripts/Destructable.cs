using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    GameObject destroyedCraft;
    // Start is called before the first frame update
    public void DestroyCraft()
    {
        Instantiate(destroyedCraft, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
