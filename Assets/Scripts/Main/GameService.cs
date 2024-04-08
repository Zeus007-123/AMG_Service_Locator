using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Wave;
using ServiceLocator.Sound;
using ServiceLocator.Player;
using ServiceLocator.UI;
using System;

namespace ServiceLocator.Main
{
    public class GameService : MonoBehaviour
    {
        // Services:
        private EventService eventService; 
        private MapService mapService; 
        private WaveService waveService; 
        private SoundService soundService; 
        private PlayerService playerService; 

        [SerializeField] private UIService uiService;

        // Scriptable Objects:
        [SerializeField] private MapScriptableObject mapScriptableObject;
        [SerializeField] private WaveScriptableObject waveScriptableObject;
        [SerializeField] private SoundScriptableObject soundScriptableObject;
        [SerializeField] private PlayerScriptableObject playerScriptableObject;

        // Scene Referneces:
        [SerializeField] private AudioSource SFXSource;
        [SerializeField] private AudioSource BGSource;

        private void Start()
        {
            createServices();
            InjectDependencies();
        }

        private void createServices()
        {
            eventService = new EventService();
            mapService = new MapService(mapScriptableObject);
            waveService = new WaveService(waveScriptableObject);
            soundService = new SoundService(soundScriptableObject, SFXSource, BGSource);
            playerService = new PlayerService(playerScriptableObject);
        }

        private void InjectDependencies()
        {
            playerService.Init(uiService, mapService, soundService);
            waveService.Init(eventService, uiService, mapService, soundService, playerService);
            uiService.Init(eventService, playerService, waveService);
            mapService.Init(eventService);
        }

        private void Update()
        {
            playerService.Update();
        }
    }
}