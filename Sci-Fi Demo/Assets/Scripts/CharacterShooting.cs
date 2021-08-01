using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    [SerializeField]
    GameObject particleEffects;
    [SerializeField]
    GameObject hitMarkerPrefab;
    
    AudioSource ammoShoot;

    [SerializeField]
    int currentAmmo;
    int maxAmmo = 50;

    bool isReLoading;

    UiManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        ammoShoot = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
        uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && currentAmmo >0)
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(.5f,.5f , 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin ,out hitInfo))
            {
                Debug.Log("hit " + hitInfo.transform.name );
            }
            particleEffects.SetActive(true);

            GameObject hitMarker = Instantiate(hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)) as GameObject;

            currentAmmo--;
            uiManager.UpdateAmmo(currentAmmo);

            Destroy(hitMarker, 10f);
            if (ammoShoot.isPlaying==false)
            {
                ammoShoot.Play();
            }
           
        }
        else
        {
            particleEffects.SetActive(false);
            ammoShoot.Stop();
        }

        StartCoroutine(ReloadAmmo());
    }

    IEnumerator ReloadAmmo()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < 50 && isReLoading ==false)
        {
            isReLoading = true;
            yield return new WaitForSeconds(1.5f);
            currentAmmo = 50;
            uiManager.UpdateAmmo(currentAmmo);
            isReLoading = false;
        }
    }



}
