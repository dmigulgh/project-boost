using UnityEngine;

public class AudioClipper : MonoBehaviour
{
    public static AudioClip MakeSubclip(AudioClip clip, float start, float stop)
    {
     /* Create a new audio clip */
     int frequency = clip.frequency;
     int channels = clip.channels;
     float timeLength = stop - start;
     int samplesLength = (int)(frequency * timeLength * channels);
     AudioClip newClip = AudioClip.Create(clip.name + "-sub", samplesLength, channels, frequency, false);
     /* Create a temporary buffer for the samples */
     float[] data = new float[samplesLength];
     /* Get the data from the original clip */
     clip.GetData(data, (int)(frequency * start * channels));
     /* Transfer the data to the new clip */
     newClip.SetData(data, 0);
     /* Return the sub clip */
     return newClip;
    }
}