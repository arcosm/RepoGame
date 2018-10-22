using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    private AnimationController anim;

    //Movimentation
    public float rotateSpeed = 3.0F, speedRun, speedWalk, speedSideWalk, speedRotation;
    [System.NonSerialized]
    public float speed = 3.0F;
    private float horizontal, vertical;
    private CharacterController controller;
    public Transform focusCamera;
    public bool inQuest = false;
    public NPCBehaviour nPC;
    public List<AnimalBehaviour> animais;
    public Text textCount;
    public Scene scenes;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<AnimationController>();
        speed = speedWalk;
        controller = GetComponent<CharacterController>();
        textCount.text = animais.Count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        anim.animator.SetFloat("horizontal", horizontal);
        anim.animator.SetFloat("vertical", vertical);

        if (Input.GetKey(KeyCode.LeftShift) && horizontal == 0)
        {
            speed = speedRun;
            anim.PlayAnimation(AnimationStates.RUN);
        }
        else
        {
            speed = speedWalk;
            if (vertical != 0)
            {
                anim.PlayAnimation(AnimationStates.WALK);
            }
            else if (horizontal != 0)
            {
                anim.PlayAnimation(AnimationStates.SIDE_WALK);
            }
            else
                anim.PlayAnimation(AnimationStates.IDLE);
        }
        Vector3 cameraForward = Vector3.Scale(focusCamera.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = vertical * cameraForward + horizontal * focusCamera.right;

        moveDirection.y = Physics.gravity.y;

        controller.Move(moveDirection * speed * Time.deltaTime);
        Vector3 positionCamera = new Vector3(focusCamera.position.x, transform.position.y, focusCamera.position.z);
        Quaternion newRotation = Quaternion.LookRotation(positionCamera - transform.position);

        if (horizontal > 0 || vertical > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * speedRotation);
        }
    }
}