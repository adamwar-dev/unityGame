using UnityEngine;
using UnityEngine.UI;

/* 
    Piotr Czuczeło
    Adam Warzecha

    Friendly Spawner Logic Script
*/
public class FriendlySpawner : MonoBehaviour
{

    public GameObject unit1Object;
    public GameObject unit2Object;
    public GameObject unit3Object;
    public GameObject unit1ObjectLv2;
    public GameObject unit2ObjectLv2;
    public GameObject unit3ObjectLv2;
    [SerializeField] Image load;
    [SerializeField] Image fill;
    [SerializeField] Gradient gradient;
    [SerializeField] Button unit1;
    [SerializeField] Button unit2;
    [SerializeField] Button unit3;

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
        if(startTimer) {
            slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, time);
            fill.color = gradient.Evaluate(slider.normalizedValue);
            time += Time.deltaTime;
        
            if(time >= slider.maxValue) {
                startTimer = false;
                SpawnObject();
            }
        }

        if (Input.GetKeyDown("f"))
        {
            SpawnObject();
        }
    }
    public void StartSpawnObject() {
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

        Instantiate(objectToSpawn,spawnPosition,transform.rotation);

        unit1.interactable = true;
        unit2.interactable = true;
        unit3.interactable = true;
    }

    public void SpawnUnit1() {
        objectToSpawn = unit1Object;
        spawnPosition = transform.position;
        StartSpawnObject();
    }

    public void SpawnUnit2() {
        StartSpawnObject();
        spawnPosition = transform.position;
        spawnPosition.y = transform.position.y + 0.15f;
        objectToSpawn = unit2Object;
    }

      public void SpawnUnit3() {
        StartSpawnObject();
        spawnPosition = transform.position;
        spawnPosition.y = transform.position.y - 0.27f;
        objectToSpawn = unit3Object;
    }

    public void SpawnUnit1Lv2() {
        StartSpawnObject();
        spawnPosition = transform.position;
        spawnPosition.x = transform.position.x + 1f;
        spawnPosition.y = transform.position.y + 0.2f;
        objectToSpawn = unit1ObjectLv2;
    }

    public void SpawnUnit2Lv2() {
        StartSpawnObject();
        spawnPosition = transform.position;
        spawnPosition.y = transform.position.y - 0.2f;
        objectToSpawn = unit2ObjectLv2;
    }

    public void SpawnUnit3Lv2() {
        StartSpawnObject();
        spawnPosition = transform.position;
        spawnPosition.y = transform.position.y - 0.2f;
        objectToSpawn = unit3ObjectLv2;
    }
}
