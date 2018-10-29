using UnityEngine;
using UnityEngine.UI;

public class DialogoController : MonoBehaviour
{
    public GameObject painelDialogo;
    public Text textIngles, textPortugues;
    private bool falaAtiva = false;
    FalaNPC falas;
    // Use this for initialization
    void Start()
    {
        painelDialogo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ProximaFala(FalaNPC fala)
    {
        this.falas = fala;
        falaAtiva = true;
        painelDialogo.SetActive(true);

        textIngles.text = falas.falaIngles;
        textPortugues.text = falas.falaPortugues;
    }

}
