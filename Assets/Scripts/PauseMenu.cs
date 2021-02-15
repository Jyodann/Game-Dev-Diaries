using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool canBePaused = true;
    [SerializeField] private GameObject pauseHUD;
    // Start is called before the first frame update
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canBePaused)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseHUD.SetActive(!isPaused);
        isPaused = !isPaused;
    }
    
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
