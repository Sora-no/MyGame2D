using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenuControler : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("Shalter");
    }
    [System.Serializable]
    class PlayerSaveData
    {
        public int pHPS;
        public int scoreS;
    }
    public void SaveData() {
        PlayerSaveData data = new PlayerSaveData();
        data.pHPS = MuvePlayer.HP;
        data.scoreS = GameManager.score;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Save");
    }
    public void LoadData() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(json);

            MuvePlayer.HP = data.pHPS;
            GameManager.score = data.scoreS;
            Debug.Log("Load");
        }
    }
}
