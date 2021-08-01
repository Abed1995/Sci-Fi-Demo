using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
     Text ammoText;
   public void UpdateAmmo(int count)
    {
        ammoText.text = "Ammo : " + count;
    }
}
