using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour
{

    //预置表
    Dictionary<string, GameObject> prefabData;
    Dictionary<string, Sprite> spriteData;

    public static ResourceManager Instance;

    public Dictionary<string, GameObject> PrefabData
    {
        get
        {
            return prefabData;
        }
    }

    public Dictionary<string, Sprite> SpriteData
    {
        get
        {
            return spriteData;
        }
    }

    void Awake()
    {
        prefabData = new Dictionary<string, GameObject>();
        spriteData = new Dictionary<string, Sprite>();
        Instance = this;
        string path = "Prefabs/entity/";
        ReadPrefabs(path);
        path = "Prefabs/UI/Window/ConsoleWnd/";
        ReadPrefabs(path);
        path = "UI/Textures/";
        ReadSprite(path);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ReadPrefabs(string dirPath)
    {

        Object[] objList = Resources.LoadAll(dirPath);//AssetDatabase.LoadAssetAtPath<GameObject>(fileRePath) as GameObject;
        for (int i = 0; i < objList.Length; i++)
        {
            Object obj = objList[i];
            if (obj != null)
            {
                GameObject go = obj as GameObject;
                //添加到预置表选中
                string key = go.name;
                prefabData.Add(key, go);
                Debug.Log("读取" + key + "到预置表中");
            }

        }

    }

    void ReadSprite(string dir)
    {
        Object[] objList = Resources.LoadAll(dir);
        for (int i = 0; i < objList.Length; i++)
        {
            Object obj = objList[i];
            if (obj != null)
            {
                if (obj.GetType() != typeof(Sprite))
                {
                    Texture2D tex = obj as Texture2D;
                    Sprite sp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                    string key = obj.name;
                    spriteData.Add(key, sp);
                    Debug.Log("读取" + key + "到Sprite表中");
                }

            }

        }
    }
}
