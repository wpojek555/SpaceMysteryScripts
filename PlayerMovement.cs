using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using Random = System.Random;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float runSpeed = 2f;
    public float runCondition = 100f;
    public Scrollbar scrollbar;
    public GameObject scrollbarGreen;
    public CinemachineVirtualCamera camera;
    public bool isSnicking;
    public AudioSource audioSource;
    public AudioSource snickingSource;
    public AudioSource sprintingSource;
    public pauseMenuScript pauseMenu;
    [Header("jakieœ animacje")]
    public bool isCameraAnim;
    public Animator movementAnimator;
    public bool isAnim1;
    public bool isAnim2;
    public bool isAnim3;
    public bool isAnim4;
    public bool isAnim5;
    public bool isAnim6;

    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame

    private void Update()
    {
        pauseMenu = GetComponent<pauseMenuScript>();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (!isAnim2)
        {
            Debug.Log("1");
            if (!isAnim3)
            {
                Debug.Log("2");
                if (!isAnim4)
                {
                    Debug.Log("3");
                    if (!isAnim5)
                    {
                        Debug.Log("4");
                        if (!isAnim6)
                        {
                            Debug.Log("5");
                            if (!isAnim1)
                            {
                                Debug.Log("6");
                                    

                                if (!pauseMenu.isOpen)
                                {
                                    Vector3 move = transform.right * x + transform.forward * z;

                                    if (Input.GetButton("shift") && isGrounded)
                                    {
                                        bool zeroCondition = runCondition <= 1f;
                                        if (runCondition > 1f && !isSnicking)
                                        {
                                            runCondition -= 0.8f;
                                            scrollbar.size = runCondition / 100f;
                                            float speed2 = speed * runSpeed;
                                            controller.Move(move * speed2 * Time.deltaTime);
                                            audioSource.Pause();
                                            snickingSource.Pause();
                                            sprintingSource.UnPause();
                                            camera.m_Lens.FieldOfView = 95f;
                                            movementAnimator.SetBool("isWalking", false);
                                            movementAnimator.SetBool("isJumping", false);
                                            movementAnimator.SetBool("isRunning", true);
                                        }
                                        else if (zeroCondition)
                                        {
                                            movementAnimator.SetBool("isRunning", false);
                                            movementAnimator.SetBool("isJumping", false);
                                            movementAnimator.SetBool("isWalking", true);
                                            scrollbarGreen.SetActive(false);
                                            controller.Move(move * speed * Time.deltaTime);
                                            audioSource.UnPause();
                                            snickingSource.Pause();
                                            sprintingSource.Pause();
                                            camera.m_Lens.FieldOfView = 85f;
                                        }

                                        scrollbar.size = runCondition / 100f;

                                    }
                                    else
                                    {
                                        if (runCondition <= 100f)
                                        {
                                            scrollbarGreen.SetActive(true);
                                            runCondition += 0.3f;
                                            scrollbar.size = runCondition / 100f;
                                            camera.m_Lens.FieldOfView = 85f;
                                        }
                                        if (isSnicking)
                                        {

                                            controller.Move(move * speed / 2 * Time.deltaTime);
                                            audioSource.Pause();
                                            snickingSource.UnPause();
                                            sprintingSource.Pause();
                                        }
                                        else
                                        {
                                            movementAnimator.SetBool("isRunning", false);
                                            movementAnimator.SetBool("isJumping", false);
                                            movementAnimator.SetBool("isWalking", true);
                                            controller.Move(move * speed * Time.deltaTime);
                                            audioSource.UnPause();
                                            snickingSource.Pause();
                                            sprintingSource.Pause();
                                        }

                                    }


                                    if (Input.GetButtonDown("Jump") && isGrounded)
                                    {
                                        movementAnimator.SetBool("isRunning", false);
                                        movementAnimator.SetBool("isWalking", false);
                                        movementAnimator.SetBool("isJumping", true);
                                        velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
                                    }
                                    if (Input.GetButtonDown("Fire1") && isGrounded)
                                    {
                                        if (!isSnicking)
                                        {
                                            isSnicking = true;
                                            controller.height = controller.height / 2;
                                        }
                                    }
                                    if (Input.GetButtonUp("Fire1"))
                                    {
                                        if (isSnicking)
                                        {
                                            isSnicking = false;
                                            controller.height = controller.height * 2;
                                        }
                                    }


                                    velocity.y += gravity * Time.deltaTime;

                                    controller.Move(velocity * Time.deltaTime);
                                    if (move == Vector3.zero)
                                    {
                                        movementAnimator.SetBool("isRunning", false);
                                        movementAnimator.SetBool("isWalking", false);
                                        audioSource.Pause();
                                        snickingSource.Pause();
                                        sprintingSource.Pause();
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
            

    }

}
