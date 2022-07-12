using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    [SerializeField]
    private float _speed = -2f;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyExplosionPrefab;
    private UIManager _uIManagerScript;
    private void Start() {
        _uIManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void Update() {
        EnemyAI();
    }

    private void EnemyAI(){
        this.transform.Translate(new Vector3(0f,_speed,0f)*Time.deltaTime);
        if(this.transform.position.y < -7){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Player player = other.gameObject.GetComponent<Player>();
            if(player != null){
                player.Die();
                player.canHaveShield = false;
                player.shieldGameObject.SetActive(false);
            }
            Instantiate(enemyExplosionPrefab,this.transform.position,Quaternion.identity);
            Destroy(this.transform.gameObject);
        }
        if(other.gameObject.tag == "laser"){
            Destroy(other.gameObject);
            Instantiate(enemyExplosionPrefab,this.transform.position,Quaternion.identity);
            _uIManagerScript.UpdateScore();
            Destroy(this.gameObject);
        }
    }
}
