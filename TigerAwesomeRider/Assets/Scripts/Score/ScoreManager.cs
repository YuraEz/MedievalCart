using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private int ScoreValue;
    [SerializeField] private int MaxScore = 150;

    public static ScoreManager Instance;


    private void OnEnable()
    {
        ServiceLocator.AddService(this);
    }

    private void OnDisable()
    {
        ServiceLocator.RemoveService(this);
    }

    private void Awake()
    {
        Instance = this;
        ScoreText.text = $"Score: {ScoreValue}";
    }

    public void IncreaseScore(int value)
    {
        if (ScoreValue > MaxScore) UIManager.Instance.ChangeScreen("Win");
        ScoreValue += value;
        ScoreText.text = $"Score: {ScoreValue}";
    }
}
