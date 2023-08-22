using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaceCreator : MonoBehaviour
{
    public CurrencyDataParser parser;
    private CurrencyData data;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;


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
        var vectors = new Vector2[data.rates.Count];
        var stepX = 0.5f;
        var x = 0f;
		var minYValue = float.MaxValue;
		var maxYValue = 0f;

		lineRenderer.positionCount = vectors.Length;

		for (int i = 0; i < vectors.Length; i++)
        {
			x += stepX;
			var y = data.rates.Values.ElementAt(i).BYN * 30;
            vectors[i] = new Vector2(x, y);

			if (y < minYValue)
				minYValue = y;

			if (y > maxYValue)
                maxYValue = y;

			lineRenderer.SetPosition(i, new Vector3(x, y, 0));
		};

		edgeCollider.SetPoints(vectors.ToList());
       
        lineRenderer.transform.position = new Vector3(-10/*-(x / 2)*/, -minYValue - 4);
		//lineRenderer.BakeMesh(new Mesh());

	}
}
