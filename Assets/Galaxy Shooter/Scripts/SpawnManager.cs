using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Vector3[] enemySpawnPos = new Vector3[8];
    [SerializeField]
    private GameObject Player;
    private Player playerScript;
    [SerializeField]
    private float enemySpawnRate;
    [SerializeField]
    private GameObject[] powerUpList = new GameObject[3];
    [SerializeField]
    private float powerUpSpawnRate;


    private void Start() {
        playerScript = Player.GetComponent<Player>();
        StartCoroutine(StartPlayerSpawnRoutine());
        StartCoroutine(StartPowerUpSpawnRoutine());
    }

    private IEnumerator StartPlayerSpawnRoutine(){
        while(playerScript.health > 0){
            int randomPos = Random.Range(0,enemySpawnPos.Length);
            Instantiate(enemyPrefab,enemySpawnPos[randomPos],Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnRate);
        }
    }

    private IEnumerator StartPowerUpSpawnRoutine(){
        while(playerScript.health > 0){
            int randomPos = Random.Range(0,enemySpawnPos.Length);
            int randomPowerUp = Random.Range(0,powerUpList.Length);
            Instantiate(powerUpList[randomPowerUp],enemySpawnPos[randomPos],Quaternion.identity);
            yield return new WaitForSeconds(powerUpSpawnRate);
        }
    }



    


}
