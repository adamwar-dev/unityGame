using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
    Piotr Czuczeło
    Enemy Spawner Logic Script
*/
public class EnemySpawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    public EnemyGameLogic gLogic;

    public GameObject unit1Object;
    public GameObject unit2Object;
    public GameObject unit3Object;
    public GameObject unit1ObjectLv2;
    public GameObject unit2ObjectLv2;
    public GameObject unit3ObjectLv2;
    public GameObject unit1ObjectLv3;
    public GameObject unit2ObjectLv3;
    public GameObject unit3ObjectLv3;

    public bool unit1;
    public bool unit2;
    public bool unit3;
    public bool upgrade;
    private Vector3 spawnPosition;

    private float time;
    private bool startTimer;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = false;
        unit1 = true;
        unit2 = true;
        unit3 = true;
        upgrade = false;
    }

    void Update()
    {
        if (startTimer)
        {
            time += Time.deltaTime;

            if (time >= 1)
            {
                startTimer = false;
                SpawnObject();
            }
        }
        else
        {
            enableGoldButton();
        }

        enableExpButton();

        if (Input.GetKeyDown("e"))
        {
            SpawnObject();
        }
    }

    public void StartSpawnObject()
    {
        time = 0;
        unit1 = false;
        unit2 = false;
        unit3 = false;
        startTimer = true;
    }

    public void SpawnObject()
    {
        Instantiate(objectToSpawn,transform.position,transform.rotation);
    }

    public void SpawnUnit1()
    {
        objectToSpawn = unit1Object;
        spawnPosition = transform.position;
        buyingCost(8);
        StartSpawnObject();
    }

    public void SpawnUnit2()
    {
        StartSpawnObject();
        spawnPosition = transform.position;
        spawnPosition.y = transform.position.y + 0.15f;
        objectToSpawn = unit2Object;
        buyingCost(20);
    }

    public void SpawnUnit3()
    {
        StartSpawnObject();
        spawnPosition = transform.position;
        spawnPosition.y = transform.position.y - 0.27f;
        objectToSpawn = unit3Object;
        buyingCost(40);
    }

    public void SpawnUnit1Lv2()
    {
        StartSpawnObject();
        spawnPosition = transform.position;
        buyingCost(80);
        spawnPosition.x = transform.position.x + 1f;
        spawnPosition.y = transform.position.y + 0.2f;
        objectToSpawn = unit1ObjectLv2;
    }

    public void SpawnUnit2Lv2()
    {
        StartSpawnObject();
        buyingCost(200);
        spawnPosition = transform.position;
        spawnPosition.y = transform.position.y - 0.2f;
        objectToSpawn = unit2ObjectLv2;
    }

    public void SpawnUnit3Lv2()
    {
        StartSpawnObject();
        buyingCost(400);
        spawnPosition = transform.position;
        spawnPosition.y = transform.position.y - 0.2f;
        objectToSpawn = unit3ObjectLv2;
    }

    public void SpawnUnit1Lv3()
    {
        StartSpawnObject();
        buyingCost(800);
        spawnPosition = transform.position;
        spawnPosition.y = transform.position.y - 0.2f;
        objectToSpawn = unit1ObjectLv3;
    }

    public void SpawnUnit2Lv3()
    {
        StartSpawnObject();
        buyingCost(2000);
        spawnPosition = transform.position;
        spawnPosition.y = transform.position.y - 0.1f;
        objectToSpawn = unit2ObjectLv3;
    }

    public void SpawnUnit3Lv3()
    {
        StartSpawnObject();
        buyingCost(4000);
        spawnPosition = transform.position;
        spawnPosition.y = transform.position.y + 0.3f;
        spawnPosition.x = transform.position.x + 1f;
        objectToSpawn = unit3ObjectLv3;
    }
public int checkLevel()
    {
        switch (gLogic.level)
        {
            case 2: return 10;
            case 3: return 100;
            default: return 1;
        }
    }

    public void enableGoldButton()
    {
        if (gLogic.gold > 40 * checkLevel())
        {
            unit1 = unit2 = unit3 = true;
        }
        else if (gLogic.gold > 20 * checkLevel())
        {
            unit1 = unit2 = true;
        }
        else if (gLogic.gold > 8 * checkLevel())
        {
            unit1 = true;
        }
    }

    public void enableExpButton()
    {
        if (gLogic.exp > 10000 && gLogic.level == 2)
        {
            upgrade = true;
        }
        else if (gLogic.exp > 1000 && gLogic.level == 1)
        {
            upgrade = true;
        }
    }

    public void buyingCost(float amount)
    {
        gLogic.SubtractGold(amount);
    }

   public void updateLevel()
    {
        upgrade = false;
        /* if (gLogic.level == 1)
        {
            unit1.onClick.RemoveListener(SpawnUnit1);
            unit1.onClick.AddListener(SpawnUnit1Lv2);
            unit2.onClick.RemoveListener(SpawnUnit2);
            unit2.onClick.AddListener(SpawnUnit2Lv2);
            unit3.onClick.RemoveListener(SpawnUnit3);
            unit3.onClick.AddListener(SpawnUnit3Lv2);
        }
        else if (gLogic.level == 2)
        {
            unit1.onClick.RemoveListener(SpawnUnit1Lv2);
            unit1.onClick.AddListener(SpawnUnit1Lv3);
            unit2.onClick.RemoveListener(SpawnUnit2Lv2);
            unit2.onClick.AddListener(SpawnUnit2Lv3);
            unit3.onClick.RemoveListener(SpawnUnit3Lv2);
            unit3.onClick.AddListener(SpawnUnit3Lv3);
        }*/

        gLogic.level++;
    }
}
