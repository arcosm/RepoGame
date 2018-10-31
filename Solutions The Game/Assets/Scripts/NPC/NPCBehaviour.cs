using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCBehaviour : MonoBehaviour
{
    public PlayerBehaviour player;
    private bool isPlayer = false;
    public Animator animator;
    public bool isConcluid = false;
    private FalaEmIngles emIngles;
    private FalaEmPortugues emPortugues;

    public float tempoTotal;
    private float currenttempo;

    // Use this for initialization
    void Start()
    {
        emIngles = GetComponent<FalaEmIngles>();
        emPortugues = GetComponent<FalaEmPortugues>();
        emIngles.SetActeve(false);
        emPortugues.SetActeve(false);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isPlayer", isPlayer);
        if (player.animais.Count > 4)
        {
            isConcluid = true;
        }

        if (isPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                emIngles.SetFala();
                emPortugues.SetFala();
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GetCollider(other))
        {
            isPlayer = true;
        }
        emIngles.SetActeve(true);
        emPortugues.SetActeve(true);
        emIngles.SetFala();
        emPortugues.SetFala();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GetCollider(other))
        {
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
        emIngles.SetActeve(false);
        emPortugues.SetActeve(false);
    }

    public bool GetCollider(Collider other)
    {
        return other.GetComponent<Collider>() != GetComponent<Collider>();
    }

    public void SetScene()
    {

        if (SceneManager.GetSceneByBuildIndex(1).name == "GameLevel1")
        {
            SceneManager.LoadScene("GameLevel2");
            return;
        }

        if (SceneManager.GetSceneByBuildIndex(2).name == "GameLevel2")
        {
            SceneManager.LoadScene("GameLevel3");
        }
    }
}
