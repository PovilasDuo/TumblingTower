using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string GroupName;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat(GroupName, volume);
    }

    List<int> Widths = new List<int>() {800,1280,1366,1920};
    List<int> Heights = new List<int>() {600,768,768,1080};

    public void SetScreenRes(int i)
    {
        bool fullscreen = Screen.fullScreen;
        int Width = Widths[i];
        int Height = Heights[i];
        Screen.SetResolution(Width,Height,fullscreen);
    }

    public void SetFullScreen(bool f)
    {
        Screen.fullScreen = f;
    }

}
