using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
/// <summary>
/// 노래 선택자
/// </summary>
public class SongSelector : MonoBehaviour
{
    public static SongSelector Instance;
    public string SelectedSongName;
    public VideoClip Clip;
    public SongData Data;
    public void Select(string songName)
    {
        SelectedSongName = songName;
    }

    public bool TryLoadSelectedSongData()
    {
        bool IsLoatded = false;
        if (string.IsNullOrEmpty(SelectedSongName))
            return false;

        try
        {
            Clip = Resources.Load<VideoClip>($"VideoClips/{SelectedSongName}");
            TextAsset dataText = Resources.Load<TextAsset>($"SongData/{SelectedSongName}");
            Data = JsonUtility.FromJson<SongData>(dataText.ToString());
            IsLoatded = true;
        }
        catch (System.Exception e)
        {
            IsLoatded=false;
            Debug.LogError($"SongSelector : Failed to Load song...{e.Message}");
        }
        
        return IsLoatded;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
