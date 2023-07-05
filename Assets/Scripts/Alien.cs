using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector3 horizontalMoveDistance = new Vector3(0, 0, 0);
    private Vector3 verticalMoveDistance = new Vector3(0, 0, 0);

    private const float MAX_LEFT = -2;
    private const float MAX_RİGHT = 2;
    private const float MAX_MOVE_SPEED = 0.02f;

    public static List<GameObject> allAliens = new List<GameObject>();

    private bool movingRight;
    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;

    
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
        {
            allAliens.Add(go);
        }
    }
    private void MoveEnemies()
    {
        int hitMax = 0;
        for (int i = 0; i < allAliens.Count; i++)
        {
            if (movingRight)
            {
                allAliens[i].transform.position += horizontalMoveDistance;
            }
            else
            {
                allAliens[i].transform.position -= horizontalMoveDistance;
            }
            if (allAliens[i].transform.position.x>MAX_RİGHT || allAliens[i].transform.position.x < MAX_LEFT)
            {
                hitMax++;
            }
            
        }
        if (hitMax > 0)
        {
            for (int i = 0; i < allAliens.Count; i++)
            {
                allAliens[i].transform.position -= verticalMoveDistance;
            }
            movingRight = !movingRight;
        }
        //timer
    }
    private float GetMoveSpeed()
    {
        float f = allAliens.Count * moveTime;
        if (f<MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return f;
        }
        return f;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer <= 0)
        {
            MoveEnemies();
        }
        moveTimer -= Time.deltaTime;
    }
}
