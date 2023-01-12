using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManagement : MonoBehaviour
{
    [SerializeField] AudioSource ambientMusic;
   // private Renderer _myRenderer;
   // private Vector3 _startingPosition;


    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(1); // Carga escena de acerca de
    }

    public void LoadAboutUs()
    {
        SceneManager.LoadScene(0); //carga menu
    }

    public void ExitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
