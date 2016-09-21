using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour
{
	public void PlayMusic()
	{
		GetComponent<AudioSource>().Play();
	}

	public void PauseMusic()
	{
		GetComponent<AudioSource>().Pause();
	}
}
