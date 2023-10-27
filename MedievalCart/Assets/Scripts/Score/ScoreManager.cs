using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private int ScoreValue;

    private void OnEnable()
    {
        //ServiceLocator.AddService(this);
    }

    private void OnDisable()
    {
        //ServiceLocator.RemoveService(this);
    }

    private void Awake()
    {
        ScoreText.text = $"Score: {ScoreValue}";
    }

    public void IncreaseScore(int value)
    {
        ScoreValue += value;
        ScoreText.text = $"Score: {ScoreValue}";
    }
}
