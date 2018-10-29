using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCBehaviour : MonoBehaviour
{
    public PlayerBehaviour player;
    private bool isPlayer = false;
    public Animator animator;
    public bool isConcluid = false;
    private Dialogo fala;
    public DialogoController dialogoController;

    // Use this for initialization
    void Start()
    {
        fala = GetComponent<Dialogo>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isPlayer", isPlayer);
        if (player.animais.Count > 4)
        {
            isConcluid = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GetCollider(other))
        {
            dialogoController.painelDialogo.SetActive(true);
            isPlayer = true;
           /* if (!fala.dialogoConcluido)
            {

            }
            else
            {

            }
            fala.dialogoConcluido = true;*/
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GetCollider(other))
        {
            dialogoController.painelDialogo.SetActive(false);
            isPlayer = false;
            player.inQuest = true;

            if (isConcluid)
            {
                player.inQuest = false;
                player.animais.RemoveRange(0, 5);
                player.textCount.text = player.animais.Count.ToString();
                SetScene();
            }
        }
    }

    public bool GetCollider(Collider other)
    {
        return other.GetComponent<Collider>() != GetComponent<Collider>();
    }

    public void SetScene()
    {

        if(SceneManager.GetSceneByBuildIndex(1).name == "GameLevel1")
        {
            SceneManager.LoadScene("GameLevel2");
            return;
        }

        if(SceneManager.GetSceneByBuildIndex(2).name == "GameLevel2")
        {
            SceneManager.LoadScene("GameLevel3");
        }
    }    
}
