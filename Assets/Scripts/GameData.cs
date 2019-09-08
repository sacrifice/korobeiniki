﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

[Serializable]
public class GameData
{
    int ImpratorLoyality;
    int Money;
    int PeasantsLoyality;
    int Peasants;
    GameStatment Satatment;
    GameProgress Progress;

    public static void SaveGameData(GameData data, string name)
    {
        name += ".korobeinikiData";
        if (File.Exists(name))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + name, FileMode.Open);
            bf.Serialize(file,data);
            file.Close();
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + name, FileMode.Create);
            bf.Serialize(file, data);
            file.Close();
        }
    }

    public static GameData LoadGameData(string name)
    {
        name += ".korobeinikiData";
        if (File.Exists(name))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + name, FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();
            return data;
        }else
        {
            Debug.LogError("File " + Application.persistentDataPath + name +" does not exists");
            return null;
        }
    }



}

public class GameStatment
{
    // buildings, enviroment
}

public class GameProgress
{
    //missions, progress in this missions
}