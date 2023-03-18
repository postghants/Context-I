using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBehavior : MonoBehaviour
{
    [SerializeField] private string nextLevelName;

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(1f,1f), 0f);
        int playerCount = 0;

        foreach(Collider2D collider in colliders)
        {
            if (collider.GetComponent<characterJump>())
            {
                playerCount++;
            }
        }

        if(playerCount >= 2) // Players both reached finish
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
