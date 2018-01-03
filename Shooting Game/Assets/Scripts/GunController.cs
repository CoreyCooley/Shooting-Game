using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public GameObject crossHair;
    public AudioClip shotSound;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootAction();
        }
    }

    void ShootAction()
    {
        audioSource.PlayOneShot(shotSound);
    }
}
