using UnityEngine;

public class VolumeControl : MonoBehaviour {
    public AudioSource[] audioSources;///Add audio listeners for each scene
    
    
	// Use this for initialization
	void Start ()
    {
        UpdateVolumeSettings();
    }

    public void UpdateVolumeSettings()
    {
        float currentVolume = PlayerPrefs.GetFloat("Volume", 1);
        int status = PlayerPrefs.GetInt("VolumeMute", 1);
        bool volumeMuteStatus = true;
        if(status == 0)
            volumeMuteStatus = false;

        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].volume = currentVolume;
            audioSources[i].mute = volumeMuteStatus;
        }
    }
}
