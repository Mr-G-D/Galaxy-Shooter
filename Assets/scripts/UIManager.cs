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

    // Start is called before the first frame update
    void Start()
    {
        _score_text.text = "Score: 0";
        _curr_score_disp.sprite = _lives[3];
    }

    public void updateScore(int score)
    {
        _score_text.text = "Score: " + score;
    }

    public void updateLives(int lives)
    {
        _curr_score_disp.sprite = _lives[lives];
    }
}
