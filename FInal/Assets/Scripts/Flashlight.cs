using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    [SerializeField]
    GameObject flashLight;



    private Vector3 v3Offset;
    private GameObject goFollow;
    private float speed = 99f;
    private bool flashlightOn = true;


    private AudioSource audioSource;

    void Start()
    {
        goFollow = Camera.main.gameObject;
        v3Offset = transform.position - goFollow.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        flashLight.transform.position = goFollow.transform.position + v3Offset;
        flashLight.transform.rotation = Quaternion.Slerp(transform.rotation, goFollow.transform.rotation, speed);
        turnFlashlightOnAndOff();
    }

    private void turnFlashlightOnAndOff()
    {
        if (flashlightOn == false)
        {
            if (Input.GetButtonDown("Flashlight"))
            {
                flashLight.SetActive(true);
                flashlightOn = true;
                audioSource.Play();
                Debug.Log("flashlight on");

            }
        }
        else
        {
            if (Input.GetButtonDown("Flashlight"))
            {
                flashLight.SetActive(false);
                flashlightOn = false;
                audioSource.Play();
                Debug.Log("flashlight off");

            }
        }
    }
}
