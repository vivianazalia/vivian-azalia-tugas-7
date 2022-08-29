using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float upForce = 1f;
    public float sideForce = .1f;

    private float timer = 3;

    private Vector3 force;
    private Vector3 startPos;

    private void OnEnable()
    {
        Force();
        GetComponent<Rigidbody>().velocity = force;
    }

    private void Start()
    {
        startPos = transform.position;
    }

    public void Force()
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        force = new Vector3(xForce, yForce, zForce);
    }

    public void Spawn()
    {
        if(timer <= 0)
        {
            gameObject.SetActive(false);
            transform.position = startPos;
            timer = 3;
        }

        timer -= Time.deltaTime;
    }

    private void Update()
    {
        Spawn();
    }
}
