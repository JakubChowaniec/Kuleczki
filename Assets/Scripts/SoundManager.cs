using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource[] destroyNoise;
	public AudioSource[] backgroundMusic;

    public void PlayBackgroundMusic()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {
                int clipToPlay = Random.Range(0, backgroundMusic.Length);
                backgroundMusic[clipToPlay].Play();
            }
        }
        else
        {
            int clipToPlay = Random.Range(0, backgroundMusic.Length);
            backgroundMusic[clipToPlay].Play();
        }
    }
	public void PlayRandomDestroyNoise()
	{
		if (PlayerPrefs.HasKey("Sound"))
		{
			if(PlayerPrefs.GetInt("Sound") == 1)
			{
                //Choose a random number
                int clipToPlay = Random.Range(0, destroyNoise.Length);
                //plat that clip
                destroyNoise[clipToPlay].Play();
            }

		}
		else
		{
            //Choose a random number
            int clipToPlay = Random.Range(0, destroyNoise.Length);
            //plat that clip
            destroyNoise[clipToPlay].Play();
        }
	}


}
