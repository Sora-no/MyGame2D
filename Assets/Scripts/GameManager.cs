using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static GameObject player;
    public static int score = 0;
    [SerializeField]
    private TextMeshProUGUI textScore;
    private TextMeshProUGUI ammoText;
    private GameObject deadText;
    private string inputText;
    private string gameScene;
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        
    }
    void Update(){
       SrcTextMesh();
    }
    public void SrcTextMesh(){
        //показ очков потронов
        gameScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        inputText = "Score " + score.ToString();
        if(textScore != null){
            textScore.text = inputText;
            ammoText.text = Gun.Bullets.ToString() + "/" + Gun.BulletsInPack.ToString();
        }
        // поиск интерфес потронов и очков
        if(gameScene != "MineMenu"){
            textScore = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
            ammoText = GameObject.Find("Ammo").GetComponent<TextMeshProUGUI>();

        }
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
        data.scoreS = score;
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
            score = data.scoreS;
            Debug.Log("Load");
        }
    }
}
