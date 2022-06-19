using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemySpawner spawner;
    bool startTimer;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        startTimer = true;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer){
            
            time += Time.deltaTime;

            if (time >= 3)
            {
                startTimer = false;
                CheckSpawner();
                time = 0;
            }
            startTimer = true;
        }
        
    }


    public void CheckSpawner(){
        int value = RandomInt();
        if(spawner.gLogic.level == 1){
            
            if(spawner.unit1 && value == 1){

                Debug.Log(spawner.gLogic.gold);
                spawner.SpawnUnit1();

            }

            if(spawner.unit2 && value == 2){

                Debug.Log(spawner.gLogic.gold);
                spawner.SpawnUnit2();

            }

            if(spawner.unit3 && value == 3){

                Debug.Log(spawner.gLogic.gold);
                spawner.SpawnUnit3();

            }

        }else if(spawner.gLogic.level == 2){

            if(spawner.unit1 && value == 1){

                Debug.Log(spawner.gLogic.gold);
                spawner.SpawnUnit1Lv2();

            }

            if(spawner.unit2 && value == 2){

                Debug.Log(spawner.gLogic.gold);
                spawner.SpawnUnit2Lv2();

            }

            if(spawner.unit3 && value == 3){

                Debug.Log(spawner.gLogic.gold);
                spawner.SpawnUnit3Lv2();
                
            }

        }else if(spawner.gLogic.level == 3){

            if(spawner.unit1 && value == 1){

                Debug.Log(spawner.gLogic.gold);
                spawner.SpawnUnit1Lv3();

            }

            if(spawner.unit2 && value == 2){

                Debug.Log(spawner.gLogic.gold);
                spawner.SpawnUnit2Lv3();

            }

            if(spawner.unit3 && value == 3){

                Debug.Log(spawner.gLogic.gold);
                spawner.SpawnUnit3Lv3();
                
            }

        }

        if(spawner.upgrade){

            spawner.updateLevel();          
        }

    }

    public int RandomInt(){
        return Random.Range(1,3);
    }
}
