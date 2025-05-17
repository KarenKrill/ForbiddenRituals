namespace ForbiddenRituals
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
}
