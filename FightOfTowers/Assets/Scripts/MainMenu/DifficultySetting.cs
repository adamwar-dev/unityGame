using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySetting : MonoBehaviour
{

    public static string Difficulty;

    public void SetDifficulty(string difficulty){
        Difficulty = difficulty;
        Debug.Log(Difficulty);
    }
}
