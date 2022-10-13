using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Guest1;
    public GameObject Guest2;
    public GameObject Guest3;

    private Animator animator;

    private float time;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SetMakingAnimaition()
    {
        animator.SetTrigger("Making");
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 3.0f)
        {
            Guest1.gameObject.SetActive(true);
        }
        if (time > 12.0f)
        {
            Guest2.gameObject.SetActive(true);
        }
        if (time > 20.0f)
        {
            Guest3.gameObject.SetActive(true);
        }
    }
}
