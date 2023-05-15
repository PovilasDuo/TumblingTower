using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance {get; private set;}

    public int Credits;
    public int TotalLivesLost;
    public int LifetimeScore;
    public int TotalCredits;
    public bool[] UnlockedSkins;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance=this;

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath+"/PlayerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath+"/PlayerData.dat",FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);
            Credits = data.Credits;
            TotalLivesLost=data.TotalLivesLost;
            LifetimeScore=data.LifetimeScore;
            TotalCredits=data.TotalCredits;
            UnlockedSkins=data.UnlockedSkins;
            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf =  new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath+"/PlayerData.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.Credits=Credits;
        data.TotalLivesLost=TotalLivesLost;
        data.LifetimeScore=LifetimeScore;
        data.TotalCredits=TotalCredits;
        data.UnlockedSkins=UnlockedSkins;

        bf.Serialize(file,data);
        file.Close();
    }


[Serializable]
    class PlayerData_Storage
    {
        public int Credits;
        public int TotalLivesLost;
        public int LifetimeScore;
        public int TotalCredits;
         public bool[] UnlockedSkins;
    }
}
