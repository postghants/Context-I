using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrompt : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
    [SerializeField] private float wiggleSize = 0.2f;
    [SerializeField] private float wiggleDuration = 1f;
    [SerializeField] private SpriteRenderer transitionSprite;
    [SerializeField] private Transform introChat;
    private float currentDuration = 0f;
    private Vector3 basePosition;

    private float transitionDuration = 1f;
    private float transitionDelay = 1f;
    private float messageSpeed = 8f;
    private float messageDelay = 4f;
    private float chatOffset1 = 6f;
    private float chatOffset2 = 8f;

    private bool introStarted = false;

    void Start()
    {
        basePosition = transform.localPosition;
    }
    void Update()
    {
        if (!introStarted)
        {
            currentDuration += Time.deltaTime;

            float currentWiggle = wiggleSize * Mathf.Sin((currentDuration / wiggleDuration) * 2 * Mathf.PI);
            transform.localPosition = basePosition + new Vector3(0, currentWiggle);
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(StartIntroTransition());
    }

    IEnumerator StartIntroTransition()
    {
        introStarted = true;
        transform.localPosition = new Vector3(-1000f, -1000f);

        float timer = 0f;

        while(timer < transitionDuration)
        {
            timer += Time.deltaTime;

            Color newColor = transitionSprite.color;
            newColor.a = timer / transitionDuration;
            transitionSprite.color = newColor;

            yield return null;
        }
        yield return new WaitForSeconds(transitionDelay);


        Vector3 chatBasePosition = new Vector3(0f, -9.5f);
        float currentOffset = 0f;

        while (currentOffset < chatOffset1)
        {
            currentOffset += Time.deltaTime * messageSpeed;

            if (currentOffset > chatOffset1) currentOffset = chatOffset1;

            introChat.position = chatBasePosition + new Vector3(0, currentOffset);

            yield return null;
        }
        yield return new WaitForSeconds(messageDelay);

        while (currentOffset < chatOffset2)
        {
            currentOffset += Time.deltaTime * messageSpeed;

            if (currentOffset > chatOffset2) currentOffset = chatOffset2;

            introChat.position = chatBasePosition + new Vector3(0, currentOffset);

            yield return null;
        }
        yield return new WaitForSeconds(2 * messageDelay);


        SceneManager.LoadScene(nextLevelName);
    }
}
