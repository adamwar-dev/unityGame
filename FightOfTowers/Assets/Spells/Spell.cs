using UnityEngine;
using UnityEngine.UI;


public class Spell : MonoBehaviour
{
    [SerializeField] Button spell;
    [SerializeField] Image fill;
    [SerializeField] Slider slider;
    private bool isCooldown;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
       isCooldown = false;
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
    }

    public void useSpell() {
        if (isCooldown){
            return;
        } else {
            slider.value = slider.maxValue;
            isCooldown = true;
            time = 0f;
            //TODO: meteors
        }
    }
}
