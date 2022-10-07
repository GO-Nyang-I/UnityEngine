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
    bool IsTriggerH = false;
    bool IsTriggerV = false;

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
        GameControl.GetComponent<Assets.Main.Scripts.GameController>().Buy(DrinkId);
        AudioManager.GetComponent<AudioController>().OnPlayCatSound();
        Bubble.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        Guest.velocity = new Vector2(nextMoveX, nextMoveY);

        if (IsTrigger == true)
        {
            if (IsTriggerH == true)
            {
                if (Bubble.gameObject.activeSelf == true)
                {
                    nextMoveX *= -1;
                    if (nextMoveX == 1)
                    {
                        spriteRenderer.flipX = false;

                    }
                    if (nextMoveX == -1)
                    {
                        spriteRenderer.flipX = true;
                    }
                }
                IsTriggerH = false;
            }
            if (IsTriggerV == true)
            {
                if (Bubble.gameObject.activeSelf == true)
                {
                    nextMoveY *= -1;
                }
                IsTriggerV = false;
            }
            CancelInvoke();
            Invoke("Think", 5);
            IsTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "SquareH")
        {
            IsTrigger = true;
            IsTriggerH = true;
        }
        if(collision.gameObject.name == "SquareV")
        {
            IsTrigger = true;
            IsTriggerV = true;
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
            if (nextMoveX == 1)
            {
                spriteRenderer.flipX = true;

            }
            if (nextMoveX == -1)
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (nextMoveX == 0 && nextMoveY == 0)
        {
            int status = Random.Range(0, 1);
            animator.SetInteger("Status", status);
        }

        Invoke("Think", 5);
    }
}
