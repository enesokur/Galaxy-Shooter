using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    [SerializeField]
    private float _speed = -2f;
    [SerializeField]
    private Vector3[] _randomEnemyPositions = new Vector3[8];
    private int _randomArrayIndex;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyExplosionPrefab;
    private void Start() {
        _randomArrayIndex = Random.Range(0,_randomEnemyPositions.Length);
        this.transform.position = _randomEnemyPositions[_randomArrayIndex];
    }
    private void Update() {
        EnemyAI();
    }

    private void EnemyAI(){
        this.transform.Translate(new Vector3(0f,_speed,0f)*Time.deltaTime);
        if(this.transform.position.y <= -6.30f){
            _randomArrayIndex = Random.Range(0,_randomEnemyPositions.Length);
            this.transform.position = _randomEnemyPositions[_randomArrayIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Player player = other.gameObject.GetComponent<Player>();
            if(player != null){
                player.Die();
            }
            _randomArrayIndex = Random.Range(0,_randomEnemyPositions.Length);
            Instantiate(enemyPrefab,_randomEnemyPositions[_randomArrayIndex],Quaternion.identity);
            Instantiate(enemyExplosionPrefab,this.transform.position,Quaternion.identity);
            Destroy(this.transform.gameObject);
        }
        if(other.gameObject.tag == "laser"){
            Destroy(other.gameObject);
            _randomArrayIndex = Random.Range(0,_randomEnemyPositions.Length);
            Instantiate(enemyPrefab,_randomEnemyPositions[_randomArrayIndex],Quaternion.identity);
            Instantiate(enemyExplosionPrefab,this.transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}