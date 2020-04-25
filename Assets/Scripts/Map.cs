using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Map : MonoBehaviour
{
    public void University()
    {
        SceneManager.LoadScene("Uni");
    }

    public void Campus()
    {
        SceneManager.LoadScene("Main");
    }
}
