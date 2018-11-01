using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public PlayerBehaviour player;
    private bool isPlayer = false;
    public Animator animator;
    public bool isConcluid = false;
    private FalaEmIngles emIngles;
    private FalaEmPortugues emPortugues;
    private NumerosEmIngles numerosEmIngles;
    private NumerosEmPortugues numerosEmPortugues;

    public GameObject[] Animais = new GameObject[4];
    private int ind = -1;

    // Use this for initialization
    void Start()
    {
        emIngles = GetComponent<FalaEmIngles>();
        emPortugues = GetComponent<FalaEmPortugues>();
        numerosEmIngles = GetComponent<NumerosEmIngles>();
        numerosEmPortugues = GetComponent<NumerosEmPortugues>();
        SetVisibilideAnimals(ind);
        numerosEmIngles.SetActeve(true);
        numerosEmPortugues.SetActeve(true);
        SetCountAnimais();
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
        if (!player.inQuest)
        {
            emIngles.SetActeve(true);
            emPortugues.SetActeve(true);
            emIngles.SetFala();
            emPortugues.SetFala();
        }
        if (isConcluid)
        {
            emIngles.SetActeve(true);
            emPortugues.SetActeve(true);
            emIngles.SetFala();
            emPortugues.SetFala();
        }
        if (ind < 0 && !player.inQuest)
        {
            ind = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        emIngles.SetActeve(false);
        emPortugues.SetActeve(false);
        if (other.gameObject.CompareTag("Player") && GetCollider(other))
        {
            isPlayer = false;
            player.inQuest = true;
            SetVisibilideAnimals(ind);

            if (isConcluid)
            {
                player.inQuest = false;
                player.animais.RemoveRange(0, 5);
                player.textCount.text = player.animais.Count.ToString();
                SetCountAnimais();
                SetCountAnimais();
                ind++;
                isConcluid = false;
                if(ind > 3)
                {
                    ind = 0;
                }
            }
        }

    }

    public bool GetCollider(Collider other)
    {
        return other.GetComponent<Collider>() != GetComponent<Collider>();
    }

    public void SetVisibilideAnimals(int i)
    {
        switch (i)
        {
            case 0:
                {
                    Animais[0].SetActive(true);
                }
                break;
            case 1:
                {
                    Animais[1].SetActive(true);
                }
                break;
            case 2:
                {
                    Animais[2].SetActive(true);
                }
                break;
            case 3:
                {
                    Animais[3].SetActive(true);
                }
                break;
            default:
                {
                    Animais[0].SetActive(false);
                    Animais[1].SetActive(false);
                    Animais[2].SetActive(false);
                    Animais[3].SetActive(false);
                }
                break;
        }
    }

    public void SetCountAnimais()
    {
        switch (player.animais.Count)
        {
            case 0:
                {
                    numerosEmIngles.SetFala();
                    numerosEmPortugues.SetFala();
                }
                break;
            case 1:
                {
                    numerosEmIngles.SetFala();
                    numerosEmPortugues.SetFala();
                }
                break;
            case 2:
                {
                    numerosEmIngles.SetFala();
                    numerosEmPortugues.SetFala();
                }
                break;
            case 3:
                {
                    numerosEmIngles.SetFala();
                    numerosEmPortugues.SetFala();
                }
                break;
            case 4:
                {
                    numerosEmIngles.SetFala();
                    numerosEmPortugues.SetFala();
                }
                break;
            case 5:
                {
                    numerosEmIngles.SetFala();
                    numerosEmPortugues.SetFala();
                }
                break;
        }
    }
}
