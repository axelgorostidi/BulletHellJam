using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] float dificulty = 0f;
    [SerializeField] float dificultyFactorIncrease = 0.2f;
    private float timer = 0f;
    private float timerDificultyIncrease = 0f;
    private float timerToSpawn = 0f;
    [SerializeField] float timeToSpawn = 1f;
    // Start is called before the first frame update
    [SerializeField] GameObject EnemyBasic;
    [SerializeField] GameObject EnemyShoot;
    [SerializeField] GameObject EnemyDiamond;

    void Start()
    {
        dificulty = 0f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerDificultyIncrease += Time.deltaTime;
        timerToSpawn += Time.deltaTime;
        
        if(timerDificultyIncrease>60f){ //en cada minuto aumenta la dificultad
            timerDificultyIncrease = 0;
            dificulty += dificultyFactorIncrease;
        }
        switch (SpawnControl())
        {
            case 1:
                Instantiate(EnemyBasic, transform.position, Quaternion.identity);
            break;
            case 2: 
                Instantiate(EnemyShoot, transform.position, Quaternion.identity);
            break;
            case 3:
                Instantiate(EnemyDiamond, transform.position, Quaternion.identity);
            break;
            default:
            break;
        }
    }

    
    int SpawnControl() //0 nada, 1 basico, 2 shoot, 3 diamond
    {
        if(timerToSpawn <= timeToSpawn){
            return 0;
        }
        timerToSpawn = 0f;
        float rand = UnityEngine.Random.Range(0f, 100f);

        if(rand > (dificulty+10)/3 && rand <=dificulty+10){
            return 1;
        }
        if(rand <= (dificulty+10)/3){
            rand = UnityEngine.Random.Range(0f, 100f);
            if(rand <= 30f){
                return 3;
            }else{
                return 2;
            }
           
        }

        return 0;
    }
}
