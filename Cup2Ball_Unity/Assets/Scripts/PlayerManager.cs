using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<Color> colorList = new List<Color>();
    void Start()
    {
        ResetPlayer();
    }
    public void ResetPlayer()
    {
        transform.position = new Vector2(Random.Range(-8.0f, 8.0f), 3.5f);
        GetComponent<SpriteRenderer>().color = colorList[Random.Range(0,3)];
    }
}
