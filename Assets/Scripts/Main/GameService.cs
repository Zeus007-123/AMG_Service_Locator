using ServiceLocator.Player;
using ServiceLocator.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{

    // Responsibilities :-
    // 1. Maintain and give access of services across the board.
    // 2. Create Respected services.

    public PlayerService playerService { get; private set; }

    [SerializeField] public PlayerScriptableObject playerScriptableObject;

    private void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
    }

    private void Update()
    {
        playerService.Update();
    }
}
