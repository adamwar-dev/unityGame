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

    // Start is called before the first frame update
    void Start()
    {   
        if(DifficultySetting.Difficulty == "Easy"){
            gold = 200;
            exp = 0;
            level = 1;
        }else if(DifficultySetting.Difficulty == "Medium"){
            gold = 300;
            exp = 400;
            level = 1;
        }else if(DifficultySetting.Difficulty == "Hard"){
            gold = 400;
            exp = 600;
            level = 1;
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