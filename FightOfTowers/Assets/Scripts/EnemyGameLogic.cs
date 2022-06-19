using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/* 
    Piotr Czuczeło
    Enemy Game Logic
*/
public class EnemyGameLogic : MonoBehaviour
{
    public float gold;
    public float exp;
    public int level;
    private float tmpGold;
    private bool startTimer;
    private float time;
              
    // Start is called before the first frame update
    void Start()
    {   
        startTimer = false;

        if (DifficultySetting.Difficulty == "Easy") {
            gold = 200;
            exp = 0;
            level = 1;
        } else if(DifficultySetting.Difficulty == "Medium") {
            gold = 300;
            exp = 400;
            level = 1;
        } else if(DifficultySetting.Difficulty == "Hard") {
            gold = 400;
            exp = 600;
            level = 1;
        }
        
    }

    void Update() {
        if (gold < 800 && level == 3) {
            tmpGold = 100;
            startTimer = true;
        } else if (gold < 80 && level == 2) {
            tmpGold = 10;
            startTimer = true;
        } else if (gold < 8 && level == 1) {
            tmpGold = 1;
            startTimer = true;
        }

        if (startTimer) {
            time += Time.deltaTime;
            if (time > 1) {
                startTimer = false;
                time = 0;
                AddGold(tmpGold);
                Debug.Log("Enemy debt: " + tmpGold.ToString());
            }
        }
    }

    // Update is called once per frame

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