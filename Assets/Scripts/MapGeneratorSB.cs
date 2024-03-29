using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorSB : MonoBehaviour
{
    public enum DrawMode {NoiseMap, ColourMap};
    public DrawMode drawMode;   

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    //[Range(0,1)]
    //[SerializeField]
    public float persistance;

    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    public TerrainType[] regions;



    //private void Update()
    //{
    //    //float autoPersistance = Mathf.Sin(Time.time);
    //    //persistance = 
    //    float persistance = Mathf.Sin(Time.time);

    //}

    public void GenerateMap()
    {
        float[,] noiseMap = NoiseSB.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale,
            octaves, persistance, lacunarity, offset);

        Color[] colourMap = new Color[mapWidth * mapHeight];

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y * mapWidth + x] = regions[i].colour;
                    
                        break;
                    }
                }
            }
        }

        MapDisplaySB display = FindObjectOfType<MapDisplaySB>();
        //display.DrawNoiseMap(noiseMap);
        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        } else if (drawMode == DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapWidth,
                mapHeight));

        }
    }

    private void OnValidate()
    {
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }
        if (mapHeight < 1)
        {
            mapHeight = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
    }
}

[System.Serializable]
public struct TerrainType// orgianlly was struct
{
    public string name;
    public float height;
    public Color colour;
}

