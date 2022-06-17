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

    // Start is called before the first frame update
    void Start()
    {
        gold = 200;
        exp = 0;
        level = 1;
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
                break;
            }
            case 3:
            {
                unit1Value.text = "800";
                unit2Value.text = "2000";
                unit3Value.text = "4000";
                upgradeValue.text = "max";
                break;
            }
            default:
            {
                unit1Value.text = "8";
                unit2Value.text = "20";
                unit3Value.text = "40";
                upgradeValue.text = "1000";
                break;
            }
        }
    }
}