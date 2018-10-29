using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    Resposta respostaData;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ProximaFala()
    {
        FindObjectOfType<DialogoController>().ProximaFala(respostaData.proximaFala);
    }
}
