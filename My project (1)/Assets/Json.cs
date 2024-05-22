using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Json : MonoBehaviour
{
    public Text msg;
    public Text msg1;
    public string jURL;
    public JsonClass jData ;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetData()
    {
        Debug.Log("[Json] Downloading data");
        var req = new UnityWebRequest(jURL);
        req.method = UnityWebRequest.kHttpVerbGET;
        var result = Path.Combine(Application.persistentDataPath, "Result.json");
        var handler = new DownloadHandlerFile(result);
        handler.removeFileOnAbort = true;
        req.downloadHandler = handler;
        yield return req.SendWebRequest();
        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("[Json] ERR: Couldn't get file from URL ");
            msg.text = "Error :(";
            msg1.text = msg.text;
        }
        else
        {
            Debug.Log("[Json] Downloading succesful");
            jData = JsonUtility.FromJson<JsonClass>(File.ReadAllText(Application.persistentDataPath + "/Result.json"));
            msg.text = jData.Message.ToString() + "; " + jData.Number.ToString(); ;
            msg1.text = jData.Date.ToString();
            yield return StartCoroutine(GetData());
        }
    }

    [System.Serializable]
    public class JsonClass
    {
        public string Message;
        public string Date;
        public int Number;
    }
}
