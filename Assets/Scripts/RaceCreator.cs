using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCreator : MonoBehaviour
{
    public CurrencyDataParser parser;
    private CurrencyData data;

    public LineRenderer lineRenderer;

    void Start()
    {
        data = parser.ParceData();

        if (data == null)
        {
            Debug.LogWarning("Data is NULL");
            return;
        }

        CreateRaceByCurrencyData();
    }

    private void CreateRaceByCurrencyData()
    {

    }
}
