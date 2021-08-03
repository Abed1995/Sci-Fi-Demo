using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;

    float horizontalInput;
    float verticalInput;
    float gravity = 9.81f;
    [SerializeField]
    private float speed = 5;

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

    public bool hasCoin;

    [SerializeField]
    GameObject weapon;

    [SerializeField]
    GameObject crossHair;

    bool weaponIsEnabled = false;
    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        ammoShoot = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
        uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && currentAmmo > 0 && weaponIsEnabled)
        {
            Shoot();

        }
        else
        {
            particleEffects.SetActive(false);
            ammoShoot.Stop();
        }

        StartCoroutine(ReloadAmmo());
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        Movement();
    }


    void Shoot()
    {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("hit " + hitInfo.transform.name);
        }
        particleEffects.SetActive(true);

        GameObject hitMarker = Instantiate(hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)) as GameObject;
        Destructable craft = hitInfo.transform.GetComponent<Destructable>();
        if (craft !=null)
        {
            craft.DestroyCraft();
        }
        currentAmmo--;
        uiManager.UpdateAmmo(currentAmmo);

        Destroy(hitMarker, 10f);
        if (ammoShoot.isPlaying == false)
        {
            ammoShoot.Play();
        }
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontalInput, 0, verticalInput) * speed;
        velocity.y -= gravity;

        // translate the local direction to global directiom 
        velocity = transform.transform.TransformDirection(velocity);

        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator ReloadAmmo()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < 50 && isReLoading == false)
        {
            isReLoading = true;
            yield return new WaitForSeconds(1.5f);
            currentAmmo = 50;
            uiManager.UpdateAmmo(currentAmmo);
            isReLoading = false;
        }
    }

    public void EnableWeapon()
    {
        weapon.SetActive(true);
        crossHair.SetActive(true);
        weaponIsEnabled = true;
    }
}
