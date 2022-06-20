// author: Mikolaj Malich

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public float gold;

    public float exp;

    public int level;
    public TextMeshProUGUI goldValue;

    public TextMeshProUGUI expValue;

    public TextMeshProUGUI unit1Value;
    public TextMeshProUGUI unit2Value;
    public TextMeshProUGUI unit3Value;
    public TextMeshProUGUI upgradeValue;
    public Image buttonImage1;
    public Image buttonImage2;
    public Image buttonImage3;
    public Sprite lv1_unit1;
    public Sprite lv1_unit2;
    public Sprite lv1_unit3;
    public Sprite lv2_unit1;
    public Sprite lv2_unit2;
    public Sprite lv2_unit3;
    public Sprite lv3_unit1;
    public Sprite lv3_unit2;
    public Sprite lv3_unit3;

    private RectTransform button2;

    // Start is called before the first frame update
    void Start()
    {
        gold = 200;
        exp = 0;
        level = 1;
        button2 = buttonImage2.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        goldValue.text = gold.ToString();
        expValue.text = exp.ToString();
        updateValues();
    }

    public void AddGold(float value)
    {
        gold += value;
    }

    public void SubtractGold(float value)
    {
        gold -= value;
    }

    public void AddExp(float val)
    {
        exp += val;
    }

    public void updateValues()
    {
        switch (level)
        {
            case 2:
            {
                unit1Value.text = "80";
                unit2Value.text = "200";
                unit3Value.text = "400";
                upgradeValue.text = "10000";
                buttonImage1.sprite = lv2_unit1;
                buttonImage2.sprite = lv2_unit2;
                //button2.transform.position = new Vector2(-0.0001f, 0f);
                //buttonImage2.transform.localScale = new Vector3(1.5f,1.5f, 1);
                buttonImage3.sprite = lv2_unit3; 
                buttonImage2.transform.localScale = new Vector3(1.5f,2.0f, 1);
                buttonImage3.transform.localScale = new Vector3(1.0f,1.0f, 1);
                break;
            }
            case 3:
            {
                unit1Value.text = "800";
                unit2Value.text = "2000";
                unit3Value.text = "4000";
                upgradeValue.text = "max";
                buttonImage1.sprite = lv3_unit1;
                buttonImage2.sprite = lv3_unit2;
                buttonImage3.sprite = lv3_unit3;   
                buttonImage2.transform.localScale = new Vector3(1.1f,1.1f, 1);
                buttonImage3.transform.localScale = new Vector3(1.0f,1.0f, 1);
                break;
            }
            default:
            {
                unit1Value.text = "8";
                unit2Value.text = "20";
                unit3Value.text = "40";
                upgradeValue.text = "1000";
                buttonImage1.sprite = lv1_unit1;
                buttonImage2.sprite = lv1_unit2;
                buttonImage3.sprite = lv1_unit3;
                buttonImage2.transform.localScale = new Vector3(2f,1.0f, 1);
                buttonImage3.transform.localScale = new Vector3(1.5f,1.5f, 1);
                break;
            }
        }
    }
}