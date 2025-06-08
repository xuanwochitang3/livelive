using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public string musicFolder = "Music"; // Resources/Music
    private AudioClip[] songs;
    private AudioSource audioSource;
    private int currentIndex = 0;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        LoadAllSongs();
        PlaySong(currentIndex);
    }

    void Update()
    {
        if (!audioSource.isPlaying && songs.Length > 0)
        {
            NextSong();
        }
    }

    void LoadAllSongs()
    {
        songs = Resources.LoadAll<AudioClip>(musicFolder);
        if (songs.Length == 0)
        {
            Debug.LogError("No songs found in Resources/Music!");
        }
    }

    void PlaySong(int index)
    {
        if (songs.Length == 0) return;

        index = Mathf.Clamp(index, 0, songs.Length - 1);
        audioSource.clip = songs[index];
        audioSource.Play();
        Debug.Log("Now playing: " + songs[index].name);
    }

    public void NextSong()
    {
        currentIndex = (currentIndex + 1) % songs.Length;
        PlaySong(currentIndex);
    }

    public void PreviousSong()
    {
        currentIndex = (currentIndex - 1 + songs.Length) % songs.Length;
        PlaySong(currentIndex);
    }
}