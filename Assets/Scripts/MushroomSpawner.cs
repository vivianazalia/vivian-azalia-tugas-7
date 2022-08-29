using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    public GameObject objPrefab;
    [SerializeField] private int count;

    private List<GameObject> mushrooms = new List<GameObject>();

    private float timerToSpawn;

    private void Start()
    {
        SpawnInit();
    }

    public void SpawnInit()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj =  Instantiate(objPrefab, transform.position, Quaternion.identity);
            obj.transform.SetParent(this.transform);
            obj.SetActive(false);
            mushrooms.Add(obj);
        }
    }

    public void GetObject()
    {
        foreach(var m in mushrooms)
        {
            if (!m.activeInHierarchy)
            {
                m.SetActive(true);
                return;
            }
        }
    }

    public void Spawn()
    {
        if(timerToSpawn <= 0)
        {
            GetObject();
            timerToSpawn = .8f;
        }
        
        timerToSpawn -= Time.deltaTime;
    }
    
    void FixedUpdate(){
        //Instantiate(objPrefab, transform.position, Quaternion.identity);
        Spawn();
    }
}
