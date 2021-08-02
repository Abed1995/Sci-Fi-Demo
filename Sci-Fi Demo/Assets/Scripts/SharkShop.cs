using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    // Start is called before the first frame update
    
    AudioSource tradeDone;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == ("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (Input.GetKeyDown(KeyCode.E) && player.hasCoin == true )
            {
                player.hasCoin = false;
                tradeDone = GetComponent<AudioSource>();
                UiManager uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
                uiManager.HideCoinInvetory();
                tradeDone.Play();
                player.EnableWeapon();
            }

            else
            {
                Debug.Log("Get Out Of Here");
            }
        }
    }
}
