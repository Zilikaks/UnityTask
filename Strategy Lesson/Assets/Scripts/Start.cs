using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Start : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("Test");
    }
}
