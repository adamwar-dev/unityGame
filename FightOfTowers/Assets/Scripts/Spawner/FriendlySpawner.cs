using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlySpawner : MonoBehaviour
{

    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        Instantiate(objectToSpawn,transform.position,transform.rotation);
    }
}