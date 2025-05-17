using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using KarenKrill.StateSystem.Abstractions;
using KarenKrill.UI.Presenters.Abstractions;
using KarenKrill.StateSystem;
using KarenKrill.Logging;
using KarenKrill.UI.Views;
using KarenKrill.Diagnostics;
using KarenKrill.Utilities;

namespace ForbiddenRituals
{
    //using Abstractions;
    //using Input.Abstractions;
    //using Input;
    //using Movement;

    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<IInputActionService>().To<InputActionService>().FromNew().AsSingle().NonLazy();
#if DEBUG
            Container.Bind<ILogger>().To<Logger>().FromNew().AsSingle().WithArguments(new DebugLogHandler());
#else
            Container.Bind<ILogger>().To<StubLogger>().FromNew().AsSingle();
#endif
            InstallGameStateMachine();
            Container.BindInterfacesAndSelfTo<ViewFactory>().AsSingle().WithArguments(_uiPrefabs);
            Container.BindInterfacesAndSelfTo<DiagnosticsProvider>().FromMethod(context =>
            {
                return GameObject.FindFirstObjectByType<DiagnosticsProvider>(FindObjectsInactive.Exclude);
            }).AsSingle();
            InstallPresenterBindings();
        }

        [SerializeField]
        List<GameObject> _uiPrefabs;

        private void InstallGameStateMachine()
        {
            Container.Bind<IStateMachine<GameState>>()
                .To<StateMachine<GameState>>()
                .AsSingle()
                .WithArguments(new GameStateGraph())
                .OnInstantiated((context, instance) =>
                {
                    if (instance is IStateMachine<GameState> stateMachine)
                    {
                        context.Container.Bind<IStateSwitcher<GameState>>().FromInstance(stateMachine.StateSwitcher);
                    }
                })
                .NonLazy();
            var stateTypes = ReflectionUtilities.GetInheritorTypes(typeof(IStateHandler<GameState>), Type.EmptyTypes);
            foreach (var stateType in stateTypes)
            {
                Container.BindInterfacesTo(stateType).AsSingle();
            }
            Container.BindInterfacesTo<ManagedStateMachine<GameState>>().AsSingle();
        }
        private void InstallPresenterBindings()
        {
            var presenterTypes = ReflectionUtilities.GetInheritorTypes(typeof(IPresenter), new Type[] { typeof(IPresenter), typeof(IPresenter<>) });
            foreach (var presenterType in presenterTypes)
            {
                Container.BindInterfacesTo(presenterType).FromNew().AsSingle();
            }
        }
    }
}