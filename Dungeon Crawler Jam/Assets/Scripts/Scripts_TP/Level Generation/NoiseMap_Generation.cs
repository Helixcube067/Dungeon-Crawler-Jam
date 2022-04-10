using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMap_Generation : MonoBehaviour
{
    public float[,] GenerateNoiseMap(int maxDepth, int maxWidth, float scale)
    {
        // Create empty noise map with maxDepth and maxWidth coords
        float[,] noiseMap = new float [maxDepth, maxWidth];

        for(int zIndex = 0; zIndex < maxDepth; zIndex++)
        {
            for (int xIndex = 0; xIndex < maxWidth; xIndex++)
            {
                // calculate sample indicies based on coordinates
                float sampleX = xIndex / scale;
                float sampleZ = zIndex / scale;

                // Generate noise value using Perlin Noise
                float noise = Mathf.PerlinNoise(sampleX, sampleZ);

                noiseMap[zIndex, xIndex] = noise;
            }
        }
            
        return noiseMap;
    }
}
