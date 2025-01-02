using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score_text;
    [SerializeField] private Image _curr_score_disp;

    [SerializeField] private Sprite[] _lives;

    [SerializeField] private TextMeshProUGUI _gameover_text;

    [SerializeField] private TextMeshProUGUI _restart_text;

    private GameManager _gamemanager;
   

    // Start is called before the first frame update
    void Start()
    {
        _score_text.text = "Score: 0";
        _curr_score_disp.sprite = _lives[3];

        _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void updateScore(int score)
    {
        _score_text.text = "Score: " + score;
    }

    public void updateLives(int lives)
    {
        _curr_score_disp.sprite = _lives[lives];

        if(lives == 0)
        {
            _gameover_text.gameObject.SetActive(true);
            _restart_text.gameObject.SetActive(true);
            _gamemanager.gameover();
            StartCoroutine(flicker());
        }
    }

    IEnumerator flicker()
    {
        while(true)
        {
        _gameover_text.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        _gameover_text.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        }

    }
}
