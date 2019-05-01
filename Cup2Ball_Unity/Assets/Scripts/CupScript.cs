using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour
{
    public Animator animScore;
    private Color cupColor;

    void Start()
    {
        cupColor = transform.parent.GetComponent<SpriteRenderer>().color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {      
        if(other.CompareTag("Player") && other.gameObject.GetComponent<SpriteRenderer>().color == cupColor) 
        {
            animScore.SetTrigger("Scoring");
            GameManager.Instance.AddScore();
        }
    }
}
