using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
   // public PlayerController player;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void MS()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // player.usePSController = !player.usePSController;
        PlayerController.useController = false;
        PlayerController.useXController = false;
        PlayerController.usePSController = false;
    }


    public void PS ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // player.usePSController = !player.usePSController;
        PlayerController.useController = true;
        PlayerController.useXController = false;
        PlayerController.usePSController = true;
    }

    public void XB()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // player.usePSController = !player.usePSController;
        PlayerController.useController = true;
        PlayerController.useXController = true;
        PlayerController.usePSController = false;
    }
}
