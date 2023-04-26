// Importing the required namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Defining the MainMenu class
public class MainMenu : MonoBehaviour
{
    // Public function to start the game
    public void PlayGame()
    {
        // Load the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Public function to exit the game
    public void ExitGame()
    {
        // Log a message to the console
        Debug.Log("You have exited the game :)");

        // Quit the application, this will only work if the game is exported as exe 
        Application.Quit();
    }
}
