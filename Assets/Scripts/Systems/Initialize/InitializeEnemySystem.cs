﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InitializeEnemySystem : IInitializeSystem
{
    private readonly Contexts _contexts;


    public InitializeEnemySystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize() 
    {
        for (int i = GameConfig.Instance.enemySpawnMinY; i < GameConfig.Instance.enemySpawnMaxY; i++)
        {
            CreateEnemy(i);
        }
    }

    public void CreateEnemy(int i)
    {
        var e = _contexts.game.CreateEntity();
        e.AddPosition(0, i * 2f, 0);
        e.isEnemy = true;
        e.AddResource(GameConfig.Instance.enemyPrefab);
    }
}