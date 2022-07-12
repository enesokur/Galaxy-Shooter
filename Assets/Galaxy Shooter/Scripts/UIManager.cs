using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _health;
    [SerializeField]
    private Image _sourceImageLives;
    [SerializeField]
    private TMP_Text _scoreText;
    private int score = 0;

    [SerializeField]
    private GameObject _menuImage;
    [SerializeField]
    private GameObject _menuText;
    

    public void UpdateLives(int currentHealth){
        _sourceImageLives.sprite = _health[currentHealth];
    }

    public void UpdateScore(){
        score += 10;
        _scoreText.text = "Score: " + score;
    }

    public void HideMenu(){
        _menuImage.SetActive(false);
        _menuText.SetActive(false);
        _scoreText.text = "Score: ";
        score = 0;
    }
    public void ShowMenu(){
        _menuImage.SetActive(true);
        _menuText.SetActive(true);
    }
}
