using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestController : MonoBehaviour
{
    Rigidbody2D Guest;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public GameObject Bubble;
    public int nextMoveX;
    public int nextMoveY;

    public int DrinkId;
    bool IsTrigger = false;
    bool StartTrigger = false;
    bool GrabityTrigger = false;
    bool IsTriggerH_R = false;
    bool IsTriggerH_L = false;
    bool IsTriggerV_T = false;
    bool IsTriggerV_B = false;

    private GameObject AudioManager;
    private GameObject GameControl;

    private void Awake()
    {
        Invoke("Think", 5);

        Guest = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        AudioManager = GameObject.Find("AudioManager");
        GameControl = GameObject.Find("GameManager");
    }

    public void OnTouchedDrink()
    {
        bool IsBuy = GameControl.GetComponent<Assets.Main.Scripts.GameController>().Sell(DrinkId);
        if (IsBuy == true)
        {
            AudioManager.GetComponent<AudioController>().OnPlayCatSound();
            Bubble.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Guest.velocity = new Vector2(nextMoveX, nextMoveY);

        if (StartTrigger == true)
        {
            if (Bubble.gameObject.activeSelf == true)
            {
                nextMoveX = -1;
            }
            CancelInvoke();
            Invoke("Think", 5);
            StartTrigger = false;
        }

        if(GrabityTrigger == true)
        {
            if (Bubble.gameObject.activeSelf == true)
            {
                nextMoveY = 1;
            }
            CancelInvoke();
            Invoke("Think", 5);
            GrabityTrigger = false;
        }

        if (IsTrigger == true)
        {
            if ((IsTriggerH_R == true) || (IsTriggerH_L == true))
            {
                if (Bubble.gameObject.activeSelf == true)
                {
                    nextMoveX *= -1;
                }
                IsTriggerH_R = false;
                IsTriggerH_L = false;
            }
            if ((IsTriggerV_T == true) || (IsTriggerV_B == true))
            {
                if (Bubble.gameObject.activeSelf == true)
                {
                    nextMoveY *= -1;
                }
                IsTriggerV_T = false;
                IsTriggerV_B = false;
            }
            CancelInvoke();
            Invoke("Think", 5);
            IsTrigger = false;
        }

        if (nextMoveX == 1)
        {
            spriteRenderer.flipX = true;

        }
        if (nextMoveX == -1)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsTrigger = true;
        if (collision.gameObject.name == "SquareH_R")
        {
            IsTriggerH_R = true;
        }
        else if (collision.gameObject.name == "SquareH_L")
        {
            IsTriggerH_L = true;
        }
        if (collision.gameObject.name == "SquareV_T")
        {
            IsTriggerV_T = true;
        }
        else if (collision.gameObject.name == "SquareV_B")
        {
            IsTriggerV_B = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SquareH_R")
        {
            StartTrigger = true;
        }

        if (collision.gameObject.name == "SquareV_B")
        {
            GrabityTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Bubble.gameObject.activeSelf == false)
        {
            Guest.gameObject.SetActive(false);
        }
    }

    void Think()
    {
        nextMoveX = Random.Range(-1, 2);
        nextMoveY = Random.Range(-1, 2);

        if (nextMoveX != 0 || nextMoveY != 0)
        {
            animator.SetInteger("Status", 1);
        }
        else if (nextMoveX == 0 && nextMoveY == 0)
        {
            int status = Random.Range(-1, 2);
            animator.SetInteger("Status", status);
        }

        Invoke("Think", 5);
    }
}
