using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour
{
    public GameObject virus;
    public float spawntimeMin,spawntimeMax;
    public Text beforeStart;
    private bool test;

    private void Awake()
    {
        Time.timeScale = 0;
        test = false;
    }
    void Start()
    {
        StartCoroutine(spawnVirus());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && test == false)
        {
            Time.timeScale = 1;
            beforeStart.enabled = false;
            test = true;
        }
    }

    IEnumerator spawnVirus()
    {
        Instantiate(virus, new Vector3(Random.Range(-4,6),transform.position.y, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(spawntimeMin, spawntimeMax));
        StartCoroutine(spawnVirus());
    }
}
