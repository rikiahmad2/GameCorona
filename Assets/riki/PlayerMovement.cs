using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    Rigidbody rb;
    public Transform playerSpin;
    Animator anim;
    public Text gameOver;
    public AudioSource audioSource;
    public AudioClip a1;
    public AudioClip a2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Riki");
            
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Speed, 0, 0);
            playerSpin.localEulerAngles = new Vector3(0, 90, 0);
            anim.SetBool("isRun", true);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Speed, 0, 0);
            playerSpin.localEulerAngles = new Vector3(0, -90, 0);
            anim.SetBool("isRun", true);
        }

        else
        {
            anim.SetBool("isRun", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "virus")
        {
            audioSource.PlayOneShot(a2, 50f);
            gameOver.text = "Tekan 'R' Untuk Memulai Kembali";
            gameOver.enabled = true;
            Time.timeScale = 0;
        }
    }
}
