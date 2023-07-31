using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    private SpriteRenderer spriteTD;
    [SerializeField] SpriteRenderer sprite;
    public float playerVelocity;
    [SerializeField] bool td;
    [SerializeField] GameObject botaoE;

    private enum MovementStateTD { idleTD, walkingUp, walkingDown, walkingSidesTD };
    private enum MovementState { idle, walkingSides };

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteTD = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float velocity_horizontal = 0;
        float velocity_vertical = 0;

        if (DialogueManager.isActive == true)
        {
            return;
        }

        if (InterrogatoryScript.isActive == true)
        {
            return;
        }

        if (GarrafasScript.isActive == true)
        {
            return;
        }

        if (LixeiraScript.isActive == true)
        {
            return;
        }

        if (CaixaDeForca.isActive == true)
        {
            return;
        }

        if (BanheiroScript.isActive == true)
        {
            return;
        }

        if (PaginaDiario.isActive == true)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {           
            velocity_horizontal -= playerVelocity;
        }
        if (Input.GetKey(KeyCode.D))
        {            
            velocity_horizontal += playerVelocity;
        }
        if (Input.GetKey(KeyCode.W)) 
        {           
            velocity_vertical += playerVelocity;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity_vertical -= playerVelocity;
        }

        rb.velocity = new Vector2(velocity_horizontal, velocity_vertical);

        if (td)
        {
            UpdateAnimationUpdateTD(velocity_horizontal, velocity_vertical);
        }
        else
        {
            UpdateAnimationUpdate(velocity_horizontal, velocity_vertical);
        }
    }

    private void UpdateAnimationUpdateTD(float x, float y)
    {
        MovementStateTD stateTD;

        if (x < 0)
        {
            stateTD = MovementStateTD.walkingSidesTD;
            spriteTD.flipX = true;
        }

        else if (x > 0)
        {
            stateTD = MovementStateTD.walkingSidesTD;
            spriteTD.flipX = false;
        }

        else
        {
            stateTD = MovementStateTD.idleTD;
        }

        if (rb.velocity.y > .1f)
        {
            stateTD = MovementStateTD.walkingUp;
        }

        else if (rb.velocity.y < -.1f)
        {
            stateTD = MovementStateTD.walkingDown;
        }

        anim.SetInteger("stateTD", (int)stateTD);
    }
    private void UpdateAnimationUpdate(float x, float y)
    {
        MovementState state;

        if (x < 0)
        {
            state = MovementState.walkingSides;
            sprite.flipX = true;

        }

        else if (x > 0)
        {
            state = MovementState.walkingSides;
            sprite.flipX = false;
        }

        else
        {
            state = MovementState.idle;
        }

        anim.SetInteger("state", (int)state);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");

        InterrogatoryScript.isActive = false;
    }

    public void GoToWinScene()
    {
        SceneManager.LoadScene("FinalScene");

        InterrogatoryScript.isActive = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        botaoE.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        botaoE.SetActive(false);
    }
}
