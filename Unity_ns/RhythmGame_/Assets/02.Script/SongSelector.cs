using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
/// <summary>
/// �뷡 ������
/// </summary>
public class SongSelector : MonoBehaviour
{
    public static SongSelector Instance;
    public string SelectedSongName;
    public VideoClip Clip;
    public SongData Data;
    public bool IsDataLoaded => Data != null;

    public void Select(string songName)
    {
        SelectedSongName = songName;
    }

    /// <summary>
    /// Json �뷡 �����Ϳ� ����Ŭ���� �ε�
    /// </summary>
    /// <returns></returns>
    public bool TryLoadSelectedSongData()
    {
        bool IsLoaded = false;

        //���õ� �뷡�� �ִ��� üũ
        if (string.IsNullOrEmpty(SelectedSongName))
            return false;

        //�뷡 ������ & ����Ŭ�� �ε�� ���� ��� �õ�
        try
        {
            Clip = Resources.Load<VideoClip>($"VideoClips/{SelectedSongName}");
            TextAsset dataText = Resources.Load<TextAsset>($"SongData/{SelectedSongName}");
            Data = JsonUtility.FromJson<SongData>(dataText.ToString());
            IsLoaded = true;
        }
        catch (System.Exception e)
        {
            IsLoaded=false;
            Debug.LogError($"SongSelector : Failed to Load song...{e.Message}");
        }
        
        return IsLoaded;
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
