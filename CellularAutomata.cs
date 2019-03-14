using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CellularAutomata : MonoBehaviour {

    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [Range(0,100)]
    [SerializeField] private int _fillPercent;
    [Range(0,10)]
    [SerializeField] private int _iterations;

    [SerializeField] private string _seed;

    private int _widthPrev;
    private int _heightPrev;
    private int _fillPercentPrev;
    private int _iterationsPrev;
    private string _prevSeed;


    private int[,] _map;

    private void Awake()
    {
        BuildCave();
        _prevSeed = _seed;
    }

    private void Update()
    {
        if(_widthPrev != _width || _heightPrev != _height || _fillPercentPrev != _fillPercent || _iterationsPrev != _iterations || _seed != _prevSeed)
        {
            BuildCave();
        }
        _widthPrev = _width;
        _heightPrev = _height;
        _fillPercentPrev = _fillPercent;
        _iterationsPrev = _iterations;
        _prevSeed = _seed;
    }

    private void BuildCave()
    {
        _map = GenerateMap(_width, _height, _seed, _fillPercent);
        FillEdgesOfMap(_map);
        for(int i=0; i<_iterations; i++)
        {
            SmoothIteration(_map);
        }
    }

    private static int[,] GenerateMap(int width, int height, string seed, int fillPercent)
    {
        int[,] map = new int[width, height];

        System.Random randomNumberGenerator = new System.Random(seed.GetHashCode());
        for(int x=0; x<width; x++)
        {
            for(int y=0; y<height; y++)
            {
                map[x,y] = (randomNumberGenerator.Next(0,100) < fillPercent) ? 1 : 0;
            }
        }
        return map;
    }

    private static void FillEdgesOfMap(int[,] map)
    {
        for(int x=0; x<map.GetLength(0); x++)
        {
            for (int y=0; y<map.GetLength(1); y++)
            {
                if(x == 0 || x == map.GetLength(0)-1 || y == 0 || y == map.GetLength(1)-1)
                {
                    map[x,y] = 1;
                }
            }
        }
    }

    private static void SmoothIteration(int[,] map)
    {
        for(int x=0; x<map.GetLength(0); x++)
        {
            for (int y=0; y<map.GetLength(1); y++)
            {
                int neighbourCount = GetNeighbourCount(map, x, y);
                
                if(neighbourCount > 4)
                    map[x,y] = 1;
                else if (neighbourCount < 4)
                    map[x,y] = 0;
            }
        }
    }

    private static int GetNeighbourCount(int[,] map, int x, int y)
    {
        int neighbourCount = 0;
        for(int nX = x-1; nX <= x+1; nX++)
        {
            for(int nY = y-1; nY <= y+1; nY++)
            {
                if(nX >= 0 && nX < map.GetLength(0) && nY >= 0 && nY < map.GetLength(1))
                {
                    if(nX != x || nX != y)
                    {
                        neighbourCount += map[nX, nY];
                    }
                }
                else
                {
                    neighbourCount++;
                }
            }
        }
        return neighbourCount;
    }
    
    private void OnDrawGizmos()
    {
        if(_map != null)
        {
            for(int x=0; x<_width; x++)
            {
                for(int y=0; y<_height; y++)
                {
                    Gizmos.color = (_map[x,y] == 1) ? Color.black : Color.clear;
                    Vector3 position = new Vector3(-_width/2 + x + 0.5f, 0, -_height/2 + y +0.5f);
                    Gizmos.DrawCube(position, Vector3.one);
                }
            }
        }
    }
}
