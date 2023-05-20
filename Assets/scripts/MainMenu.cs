using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string scenename;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P)){
            SceneManager.LoadScene(scenename);
        }

        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
