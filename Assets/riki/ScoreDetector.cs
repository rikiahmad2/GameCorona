using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDetector : MonoBehaviour
{
    Rigidbody rb;
    Collider col;

    //UI
    public Text score;
    private float countScore;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        countScore += 100;
        if(collision.collider.CompareTag("virus"))
        {
            Destroy(collision.collider.gameObject);
            score.text = "SCORE : " + countScore.ToString();
        }
    }
}
