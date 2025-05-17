using System.Collections.Generic;

using KarenKrill.StateSystem.Abstractions;

namespace ForbiddenRituals
{
    public class GameStateGraph : IStateGraph<GameState>
    {
        public GameState InitialState => GameState.Initial;

        public IDictionary<GameState, IList<GameState>> Transitions => _transitions;

        private readonly IDictionary<GameState, IList<GameState>> _transitions = new Dictionary<GameState, IList<GameState>>()
        {
            { GameState.Initial, new List<GameState> { GameState.SceneLoad } },
            { GameState.SceneLoad, new List<GameState> { GameState.MainMenu, GameState.CutScene, GameState.Gameplay } },
            { GameState.MainMenu, new List<GameState> { GameState.Lobby, GameState.SceneLoad, GameState.Exit } },
            { GameState.Lobby, new List<GameState> { GameState.MainMenu, GameState.SceneLoad } },
            { GameState.CutScene, new List<GameState> { GameState.SceneLoad, GameState.Gameplay, GameState.MainMenu } },
            { GameState.Gameplay, new List<GameState> { GameState.Pause, GameState.CutScene, GameState.GameEnd } },
            { GameState.GameEnd, new List<GameState> { GameState.SceneLoad, GameState.MainMenu, GameState.Lobby, GameState.Exit } },
            { GameState.Pause, new List<GameState> { GameState.Gameplay, GameState.MainMenu, GameState.Exit, GameState.SceneLoad, GameState.Lobby } },
            { GameState.Exit, new List<GameState>() }
        };
    }
}
