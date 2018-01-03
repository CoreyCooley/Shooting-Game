using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public GameObject crossHair;
    public AudioClip shotSound;
    public ParticleSystem muzzleFlash;

    private AudioSource audioSource;
    public static int roundsShot;
    public static int kills;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GamePlay.gameIsPaused)
        {
            transform.LookAt(crossHair.transform);

            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");

            Vector3 crosshairMove = new Vector3(h, v, 0);
            crossHair.transform.Translate(crosshairMove);

            float x = crossHair.transform.position.x;
            float y = crossHair.transform.position.y;

            if (x > 10)
                x = 10;
            if (x < -10)
                x = -10;
            if (y > 6)
                y = 6;
            if (y < -6)
                y = -6;

            crossHair.transform.position = new Vector3(x, y, 0);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ShootAction();
            }
        }
    }

    void ShootAction()
    {
        audioSource.volume = 0.05f;
        audioSource.PlayOneShot(shotSound);
        muzzleFlash.Emit(1);

        roundsShot++;

        Vector2 dir = new Vector2(crossHair.transform.position.x, crossHair.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, dir);

        // We shot one of the enemies
        if( hit.collider != null && hit.collider != crossHair)
        {
            kills++;
            Destroy(hit.collider.gameObject);
        }        
    }

    public static void Reset()
    {
        roundsShot = 0;
        kills = 0;
    }

    public int RoundsShot()
    {
        return roundsShot;
    }
}
