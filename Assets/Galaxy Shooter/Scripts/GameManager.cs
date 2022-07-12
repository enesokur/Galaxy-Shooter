using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _hasGameStarted = false;
    [SerializeField]
    private GameObject _player;
    private UIManager uIScript;
    private void Start() {
        uIScript = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && _hasGameStarted == false){
            _hasGameStarted = true;
            Instantiate(_player,Vector3.zero,Quaternion.identity);
            uIScript.HideMenu();
        }
    }
}
