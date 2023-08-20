using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CurrencyDataParser : MonoBehaviour
{
    public CurrencyData data;

    void Start()
    {
        var json = Resources.Load<TextAsset>("Decade/2022.01.01_2022.04.01").ToString();
        json = json.Replace("base", "base_currency");

        data = JsonUtility.FromJson<CurrencyData>(json);
        data.rates = new Dictionary<string, CurrencyValues>();
        JToken array = JToken.Parse(json).SelectToken("$.rates");

        foreach (JProperty prop in array.Children())
        {
            data.rates.Add(prop.Name, JsonUtility.FromJson<CurrencyValues>(prop.Value.ToString()));
            Debug.Log(prop.Name + "  -  " + prop.Value);
        }

        Debug.Log(data.rates.ElementAt(0).Value.BYN);
    }
}

[Serializable]
public class CurrencyData
{
    public bool success;
    public bool timeseries;
    public string start_date;
    public string end_date;
    public string base_currency;
    public Dictionary<string, CurrencyValues> rates;
}

[Serializable]
public class CurrencyValues
{
    public float RUB;
    public float BYN;
    public float UAH;
    public float CAD;
    public float EUR;
    public float JPY;
    public float CNY;
    public float ZWL;
}


