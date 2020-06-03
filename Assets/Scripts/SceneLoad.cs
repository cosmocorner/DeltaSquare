using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public string LevelName;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(LevelName);
    }
}
