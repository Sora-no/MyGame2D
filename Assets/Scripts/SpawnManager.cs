using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Enemys;
    private int randomPos;
    
    // Start is called before the first frame update
    void Start(){

        StartCoroutine(SpawnEnemys());
    }
    public IEnumerator SpawnEnemys(){
        while(MuvePlayer.isAlive){
            yield return new WaitForSeconds(Random.Range(1, 3));
            randomPos = Random.Range(0, 2);
            if(randomPos == 1)
                Instantiate(Enemys[0], new Vector3(Random.Range(94, 50), -2.95f, 0), Quaternion.identity);
            else if(randomPos == 0)
                Instantiate(Enemys[0], new Vector3(Random.Range(-94, -50), -2.95f, 0), Quaternion.identity);
        }
    }
    
}
