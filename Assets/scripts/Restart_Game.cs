using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Allows a user to 'restart' a minigame, e.g. 'restart' the P(known) scene
public class Restart_Game : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
