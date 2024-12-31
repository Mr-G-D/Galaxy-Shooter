using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score_text;

    // Start is called before the first frame update
    void Start()
    {
        _score_text.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int score)
    {
        _score_text.text = "Score: " + score;
    }
}
