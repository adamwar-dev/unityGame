using UnityEngine;
using UnityEngine.UI;

/* 
    Piotr Czuczeło
    Adam Warzecha

    Friendly Spawner Logic Script
*/
public class FriendlySpawner : MonoBehaviour
{

    public GameObject objectToSpawn;
    [SerializeField] Image load;
    [SerializeField] Image fill;
    [SerializeField] Gradient gradient;
    [SerializeField] Button unit1;
    [SerializeField] Button unit2;
    [SerializeField] Button unit3;

    private Slider slider;
    private float time;
    private bool startTimer;

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

        Instantiate(objectToSpawn,transform.position,transform.rotation);

        unit1.interactable = true;
        unit2.interactable = true;
        unit3.interactable = true;
    }
}
