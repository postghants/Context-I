using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrompt : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
    [SerializeField] private float WiggleSize = 0.2f;
    [SerializeField] private float WiggleDuration = 1f;
    private float currentDuration = 0f;
    private Vector3 basePosition;

    void Start()
    {
        basePosition = transform.localPosition;
    }
    void Update()
    {
        currentDuration += Time.deltaTime;

        float currentWiggle = WiggleSize * Mathf.Sin((currentDuration / WiggleDuration) * 2 * Mathf.PI);
        transform.localPosition = basePosition + new Vector3(0, currentWiggle);

        if(currentDuration >= 10) //TODO: MAKE THIS HAPPEN WHEN X IS PRESSED INSTEAD OF ON A TIMER
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
