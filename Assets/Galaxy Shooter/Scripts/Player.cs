using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canHaveShield = false;
    public bool canTripleShoot = false;
    public bool canSpeedUp = false;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    public GameObject shieldGameObject;
    [SerializeField]
    private GameObject _trippleLaserPrefab;
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _fireRate = 0.4f;
    private float _nextFireTime = 0.0f;
    public int health = 3;
    [SerializeField]
    private GameObject _playerExpPrefab;
    [SerializeField]
    private UIManager _uIManagerScript;
    private GameManager _gameManagerScript;
    private SpawnManager _spawnManagerScript;
    private AudioSource _audioSource;
    [SerializeField]
    private GameObject[] _engines;
    private int hitCount = 0;
    private void Start() {
        _uIManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spawnManagerScript = GameObject.Find("SpawnManagerObject").GetComponent<SpawnManager>();
        _audioSource = this.GetComponent<AudioSource>();
        if(_uIManagerScript != null){
            _uIManagerScript.UpdateLives(health);
        }
        if(_spawnManagerScript != null){
            _spawnManagerScript.StartRoutines();
        }
        hitCount = 0;
    }

    private void Update() {
        Movement();
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }

    private void Shoot(){
        if(Time.time > _nextFireTime){
            _audioSource.Play();
            if(canTripleShoot){
                Instantiate(_trippleLaserPrefab,transform.position,Quaternion.identity);
            }
            else{
                Instantiate(_laserPrefab,transform.position + new Vector3(0f,1f,0f),Quaternion.identity);
            }
            _nextFireTime = Time.time + _fireRate;
        }
    }

    private void Movement(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(canSpeedUp == true){
            this.transform.Translate(new Vector3(horizontalInput,0f,0f)*_speed*2*Time.deltaTime);
            this.transform.Translate(new Vector3(0f,verticalInput,0f)*_speed*2*Time.deltaTime);
        }
        else if(canSpeedUp == false){
            this.transform.Translate(new Vector3(horizontalInput,0f,0f)*_speed*Time.deltaTime);
            this.transform.Translate(new Vector3(0f,verticalInput,0f)*_speed*Time.deltaTime);
        }

        if(this.transform.position.x >= 9.5f){
            this.transform.position = new Vector3(-9.5f,this.transform.position.y,0f);
        }
        else if(this.transform.position.x <= -9.5f){
            this.transform.position = new Vector3(9.5f,this.transform.position.y,0f);
        }
        if(this.transform.position.y >= 0f){
            this.transform.position = new Vector3(this.transform.position.x,0f,0f);
        }
        else if(this.transform.position.y <= -4.2f){
            this.transform.position = new Vector3(this.transform.position.x,-4.2f,0f);
        }
    }
    
    public void StartTripleShotPowerDown(){
        canTripleShoot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void StartSpeedPowerDown(){
        canSpeedUp = true;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    public void StartShieldPowerDown(){
        canHaveShield = true;
        shieldGameObject.SetActive(true);
        StartCoroutine(ShieldPowerDownRoutine());
    }
    private IEnumerator ShieldPowerDownRoutine(){
        yield return new WaitForSeconds(10.0f);
        canHaveShield = false;
        shieldGameObject.SetActive(false);
    }
    private IEnumerator TripleShotPowerDownRoutine(){
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }
    private IEnumerator SpeedPowerDownRoutine(){
        yield return new WaitForSeconds(5.0f);
        canSpeedUp = false;
    }

    public void Die(){
        if(canHaveShield == false){
            health--;
            if(hitCount == 0){
                _engines[0].SetActive(true);
                hitCount++;
            }
            else if(hitCount == 1){
                _engines[1].SetActive(true);
                hitCount++;
            }
            _uIManagerScript.UpdateLives(health);
            if(health == 0){
                Instantiate(_playerExpPrefab,this.transform.position,Quaternion.identity);
                _gameManagerScript._hasGameStarted = false;
                _uIManagerScript.ShowMenu();
                Destroy(this.transform.gameObject);
            }
        }
    }
}
