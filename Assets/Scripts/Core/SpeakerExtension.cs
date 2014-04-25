using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class SpeakerExtension : MonoBehaviour {
	public float pitchVariance = 0.0f;
	public float volumeVariance = 0.0f;
	
	#region ambient_looping_fields
	public bool ambientLooping = false;
	public float minLoopDelay = 2.0f;
	public float maxLoopDelay = 10.0f;
	public string loopPath = "";
	private static float MINIMUM_LOOP_TOLERANCE = 0.2f;
	private float nextLoop = 0.0f;
	#endregion
	
	private AudioSource source = null;
	private float originalPitch = 1.0f;
	private float originalVolume = 1.0f;
	
	public enum SpeakerType {
		SFX,
		Music,
		Ambient,
		UI
	}
	public SpeakerType speakerType = SpeakerType.SFX;
	
	void Awake() {
		source = this.gameObject.GetComponent<AudioSource> ();
		originalPitch = source.pitch;
		originalVolume = source.volume;
		
		if (ambientLooping) {
			SetNextLoop();
		}
	}
	
	void Update() {
		if (ambientLooping && Time.time > nextLoop) {
			PlayLoop();
		}
	}
	
	/// <summary>
	/// Sets the next loop time.
	/// </summary>
	/// <param name="additionalDelay">Additional delay in seconds.  Usually the length of the previous audio clip played</param>
	private void SetNextLoop(float additionalDelay = 0.0f) {
		//Check the min loop delay every interval tick in order to protect from editor value mishaps
		if (minLoopDelay < MINIMUM_LOOP_TOLERANCE) {
			minLoopDelay = MINIMUM_LOOP_TOLERANCE;
		}
		this.nextLoop = UnityEngine.Time.time + Random.Range(minLoopDelay, maxLoopDelay) + additionalDelay;
	}
	
	private void PlayLoop() {
		AudioClip clip = AudioManager.RandomAudioClip (loopPath);
		SetNextLoop(clip.length);
		PlaySound(clip);
	}
	
	public void PlaySound(AudioClip clip) {
		source.pitch = Random.Range (originalPitch - pitchVariance, originalPitch + pitchVariance);
		source.volume = Random.Range (originalVolume - volumeVariance, originalVolume + volumeVariance);
		source.PlayOneShot (clip);
	}
}
