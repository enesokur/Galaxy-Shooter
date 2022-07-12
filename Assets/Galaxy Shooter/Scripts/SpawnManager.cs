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
    private GameManager _gameManagerScript;


    private void Start() {
        _gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerScript = Player.GetComponent<Player>();
    }

    public void StartRoutines(){
        StartCoroutine(StartPlayerSpawnRoutine());
        StartCoroutine(StartPowerUpSpawnRoutine());
    }


    private IEnumerator StartPlayerSpawnRoutine(){
        while(_gameManagerScript._hasGameStarted == true){
            int randomPos = Random.Range(0,enemySpawnPos.Length);
            Instantiate(enemyPrefab,enemySpawnPos[randomPos],Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnRate);
        }
    }

    private IEnumerator StartPowerUpSpawnRoutine(){
        while(_gameManagerScript._hasGameStarted == true){
            int randomPos = Random.Range(0,enemySpawnPos.Length);
            int randomPowerUp = Random.Range(0,powerUpList.Length);
            Instantiate(powerUpList[randomPowerUp],enemySpawnPos[randomPos],Quaternion.identity);
            yield return new WaitForSeconds(powerUpSpawnRate);
        }
    }



    


}
