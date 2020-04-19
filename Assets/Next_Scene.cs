using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Scene : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("P(guess) & P(known)");
    }
}
