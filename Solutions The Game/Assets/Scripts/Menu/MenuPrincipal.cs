using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject menuPrincipal, menuOptions;

    // Use this for initialization
    void Start()
    {
        menuOptions.SetActive(false);
        menuPrincipal.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        menuPrincipal.SetActive(true);
        menuOptions.SetActive(false);
    }
    public void Options()
    {
        menuOptions.SetActive(true);
        menuPrincipal.SetActive(false);
    }
}
