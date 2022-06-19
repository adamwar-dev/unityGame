using UnityEngine;
using UnityEngine.UI;

/* 
    Piotr Czuczeło
    Adam Warzecha
    Mikolaj Malich
    Friendly Spawner Logic Script
*/
public class FriendlySpawner : MonoBehaviour
{
    public GameLogic gLogic;
    public GameObject unit1Object;
    public GameObject unit2Object;
    public GameObject unit3Object;
    public GameObject unit1ObjectLv2;
    public GameObject unit2ObjectLv2;
    public GameObject unit3ObjectLv2;
    public GameObject unit1ObjectLv3;
    public GameObject unit2ObjectLv3;
    public GameObject unit3ObjectLv3;
    [SerializeField] Image load;
    [SerializeField] Image fill;
    [SerializeField] Gradient gradient;
    [SerializeField] Button unit1;
    [SerializeField] Button unit2;
    [SerializeField] Button unit3;
    [SerializeField] private Button upgrade;
    private Slider slider;
    private float time;
    private bool startTimer;

    private Vector3 spawnPosition;

    private GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        slider = load.GetComponent<Slider>();
        startTimer = false;
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, time);
            fill.color = gradient.Evaluate(slider.normalizedValue);
            time += Time.deltaTime;

            if (time >= slider.maxValue)
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

        if (Input.GetKeyDown("f"))
        {
            SpawnObject();
        }
    }

    public void StartSpawnObject()
    {
        time = slider.minValue;
        unit1.interactable = false;
        unit2.interactable = false;
        unit3.interactable = false;
        load.enabled = true;
        slider.enabled = true;
        fill.enabled = true;
        startTimer = true;
    }

    private void SpawnObject()
    {
        load.enabled = false;
        slider.enabled = false;
        fill.enabled = false;
        Instantiate(objectToSpawn, spawnPosition, transform.rotation);
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
        if (gLogic.gold >= 40 * checkLevel())
        {
            unit1.interactable = unit2.interactable = unit3.interactable = true;
        }
        else if (gLogic.gold >= 20 * checkLevel())
        {
            unit1.interactable = unit2.interactable = true;
        }
        else if (gLogic.gold >= 8 * checkLevel())
        {
            unit1.interactable = true;
        }
    }

    public void enableExpButton()
    {
        if (gLogic.exp > 10000 && gLogic.level == 2)
        {
            upgrade.interactable = true;
        }
        else if (gLogic.exp > 1000 && gLogic.level == 1)
        {
            upgrade.interactable = true;
        }
    }

    public void buyingCost(float amount)
    {
        gLogic.SubtractGold(amount);
    }

    public void updateLevel()
    {
        upgrade.interactable = false;
        if (gLogic.level == 1)
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
        }

        gLogic.level++;
    }
}