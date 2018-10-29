using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    public PlayerBehaviour player;
    // Use this for initialization
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Collider>() != GetComponent<Collider>())
        {
            if (player.inQuest && player.animais.Count < 5)
            {
                player.animais.Add(this);
                gameObject.SetActive(false);
                player.textCount.text = player.animais.Count.ToString();
            }
        }
    }
}