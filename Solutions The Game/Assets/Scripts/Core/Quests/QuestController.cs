using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public NPCBehaviour nPC;
    public List<AnimalBehaviour> animals = new List<AnimalBehaviour>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (animals.Count == 9)
        {
            nPC.isConcluid = true;
        }
    }

    public void AddAnimal(AnimalBehaviour animal)
    {
        animals.Add(animal);
    }
}
