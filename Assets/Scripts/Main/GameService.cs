using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    public WaveService waveService { get; private set; }
    public MapService mapService { get; private set; }
    public EventService eventService { get; private set; }

    [SerializeField] private UIService uiService;

    public UIService UIService => uiService;

    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;
    [SerializeField] private MapScriptableObject mapScriptableObject;

    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;

    private void Start()
    {
        eventService = new EventService();
        UIService.SubscribeToEvents();
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        waveService = new WaveService(waveScriptableObject);
        mapService = new MapService(mapScriptableObject);
    }

    private void Update()
    {
        playerService.Update();
    }

}
