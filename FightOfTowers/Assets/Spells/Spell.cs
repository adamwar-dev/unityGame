using UnityEngine;
using UnityEngine.UI;


public class Spell : MonoBehaviour
{
    [SerializeField] Button spell;
    [SerializeField] Image fill;
    [SerializeField] Slider slider;
    [SerializeField] GameObject meteor;
    private bool spawnMeteors;
    private bool isCooldown;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
       isCooldown = false;
       spawnMeteors = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown) {
            slider.value = Mathf.Lerp(slider.maxValue, slider.minValue, time / slider.maxValue);
            time += Time.deltaTime;
            if(slider.value <= slider.minValue) {
                isCooldown = false;
            }
        }

        if(spawnMeteors) {
            for(int i = 0; i < 15; i++) {
                Vector2 pos = new Vector2(Random.Range(-16,16), Random.Range(6,15));
                Object.Instantiate(meteor, pos, Quaternion.identity);
            }
            spawnMeteors = false;
        }
    }

    public void useSpell() {
        if (isCooldown){
            return;
        } else {
            spawnMeteors = true;
            slider.value = slider.maxValue;
            isCooldown = true;
            time = 0f;
        }
    }
}
