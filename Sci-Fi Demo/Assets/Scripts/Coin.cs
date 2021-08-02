using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField]
    AudioClip coin;
    

    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == ("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
              Player player = other.GetComponent<Player>();
                player.hasCoin = true;
                UiManager uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
                uiManager.ShowCoinInventory();
                AudioSource.PlayClipAtPoint(coin, Camera.main.transform.position, 1f);
                Destroy(this.gameObject);

            }
        }
    }

}
