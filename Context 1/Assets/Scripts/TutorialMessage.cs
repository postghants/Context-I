using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
    [SerializeField] private float lifeSpan = 5f;
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
        if (currentDuration >= lifeSpan) Destroy(this.gameObject);

        float currentWiggle = WiggleSize * Mathf.Sin((currentDuration / WiggleDuration) * 2 * Mathf.PI);
        transform.localPosition = basePosition + new Vector3(0, currentWiggle);
    }
}
