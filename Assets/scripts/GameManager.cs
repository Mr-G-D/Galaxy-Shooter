using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     private bool _gameover = false;


    public void gameover()
    {
        _gameover = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _gameover == true)
        {
            SceneManager.LoadScene(1);
        }
    }

}
