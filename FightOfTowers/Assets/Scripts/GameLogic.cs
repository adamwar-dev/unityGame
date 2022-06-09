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

    public TextMeshProUGUI goldValue;

    public TextMeshProUGUI expValue;

    // Start is called before the first frame update
    void Start()
    {
        gold = 200;
        exp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        goldValue.text = gold.ToString();
        expValue.text = exp.ToString();
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
}