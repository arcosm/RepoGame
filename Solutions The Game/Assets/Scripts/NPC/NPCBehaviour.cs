using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCBehaviour : MonoBehaviour
{
    public PlayerBehaviour player;
    private bool isPlayer = false;
    public Animator animator;
    public bool isConcluid = false;
    public string textFalas;

    public float LPS, tempo;
    int i;
    public Text[] textsFalas;
    public Text falaAtual;

    // Use this for initialization
    void Start()
    {
        textFalas = File.ReadAllText("Assets/ArtWork/Txt/Falas.txt");
        textsFalas[0].text = "";
        textsFalas[1].text = "";
    }

    // Update is called once per frame
    void Update()
    {
        LerFalas();
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
            isPlayer = true;
        }

    }

    void LerFalas()
    {
        if (tempo > 2)
            tempo = 0;

        tempo += Time.deltaTime;
        if (tempo > (1f / LPS) && i < textFalas.Length)
        {
            if (textFalas[i] == '-')
            {
                i++;
                int novoFala = textFalas[i];
                novoFala -= 48;
                print(novoFala);
                falaAtual = textsFalas[novoFala];
            }
            else
            {
                falaAtual.text += textFalas[i];                
            }
            i++;            
        }
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
