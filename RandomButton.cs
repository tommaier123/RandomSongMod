using UnityEngine;
using Synth.mods.utils;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.IO;

public class RandomButton : MonoBehaviour
{

    public static RandomButton s_instance;

    private Action<GameObject> uiCallback;
    private Action<int> selectedCallback;
    private List<TrackData> loadedTracks;

    public GameObject wrap;
    public GameObject canvas;
    public Button button;
    private bool canvasSet = false;

    public static Action<GameObject> UICallback
    {
        get
        {
            return s_instance.uiCallback;
        }

        set
        {
            s_instance.uiCallback = value;
        }
    }

    public static Action<int> SelectedCallback
    {
        get
        {
            return s_instance.selectedCallback;
        }

        set
        {
            s_instance.selectedCallback = value;
        }
    }

    public static List<TrackData> LoadedTracks
    {
        get
        {
            return s_instance.loadedTracks;
        }

        set
        {
            s_instance.loadedTracks = value;
        }
    }

    // Use this for initialization
    void Awake()
    {
        if (s_instance != null)
        {
            Destroy(this);
        }

        s_instance = this;
        DontDestroyOnLoad(this);

        button.onClick.AddListener(PlayRandom);
        Hide();
    }

    void Start()
    {
        if (s_instance == null) { return; }

    }

    public static void Show()
    {
        if (s_instance == null) { return; }
        s_instance.wrap.SetActive(true);
    }

    public static void Hide()
    {
        if (s_instance == null) { return; }
        s_instance.wrap.SetActive(false);
    }

    public static void InitCanvasVRTK()
    {
        if (!s_instance.canvasSet && s_instance.uiCallback != null)
        {
            s_instance.canvasSet = true;
            s_instance.uiCallback(s_instance.canvas);
        }
    }

    public void PlayRandom()
    {

        if (SelectedCallback != null && LoadedTracks != null)
        {
            var temp = UnityEngine.Random.Range(0, LoadedTracks.Count);
            SelectedCallback(temp);
            log("random" + temp.ToString() + ", " + LoadedTracks.Count.ToString() + Environment.NewLine);
        }
    }

    public static void DestroyRandomButton()
    {
        if (s_instance == null) { return; }

        Destroy(s_instance);
    }

    public void log(string str)
    {
        //get file path
        var dataPath = Application.dataPath;
        var filePath = dataPath.Substring(0, dataPath.LastIndexOf('/')) + "/Novalog.txt";

        //write
        using (var streamWriter = new StreamWriter(filePath, true))
        {
            streamWriter.Write(str);
        }
    }
}
