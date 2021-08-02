using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
     Text ammoText;

    [SerializeField]
    GameObject coinImage;
   public void UpdateAmmo(int count)
    {
        ammoText.text = "Ammo : " + count;
    }

   public void ShowCoinInventory()
    {
        coinImage.SetActive(true);
    }

    public void HideCoinInvetory()
    {
        coinImage.SetActive(false);
    }
}
