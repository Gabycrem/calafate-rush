using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Startgame(string game)
    {
        SceneManager.LoadScene(game);
    }

    public void Exit()
    {
        Application.Quit();
        /* Debug.Log("Se cerro el juego");*/
    }

}
