namespace ForbiddenRituals.Abstractions
{
    public enum GameState
    {
        Initial,
        SceneLoad, // Load scene (with progress bar), show arts/tips, sync start with other players
        MainMenu, // New, load, settings, [exit]
        Lobby, // players join to room, match settings, player settings (hero, role, start bonus)
        CutScene, // Show some plot intro or cutscene
        Gameplay, // All gameplay stuff (Exploring, Stealth, Chase/Escape, Combat/Defence, Inventory, Puzzle/MiniGame)
        GameEnd,
        Pause,
        Exit
    }
    /*В игре есть следующие состояния: Initial, SceneLoad, MainMenu, Lobby, CutScene, Gameplay, GameEnd, Pause, Exit. С переходами между этими состояниями всё понятно. Но немного не понимаю, что */
}
