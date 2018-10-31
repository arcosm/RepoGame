using UnityEngine;
using UnityEngine.UI;

public abstract class FalaController : MonoBehaviour
{
    public GameObject panelBox;
    public TextAsset arquivo;
    public string[] texto;
    public Text textoMensagem;

    private int fimDaLinha, linhaAtual;


    // Use this for initialization
    protected virtual void Start()
    {
        if (arquivo != null)
        {
            texto = (arquivo.text.Split('\n'));
        }
        if(fimDaLinha == 0)
        {
            fimDaLinha = texto.Length;
        }
        SetActeve(false);
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    public void SetFala()
    {
        if (linhaAtual < fimDaLinha)
        {
            textoMensagem.text = texto[linhaAtual];
        }
        if (panelBox.activeSelf)
        {
            linhaAtual++;
        }

        if (linhaAtual > fimDaLinha)
        {
            linhaAtual = 0;
        }
    }

    public void SetActeve(bool h)
    {
        panelBox.SetActive(h);
    }
}
