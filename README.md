# USOD Test Task

## Created 3 systems:

1. **UI System**

   It is represented as a UISystem that implements the IUISystem interface.
   
   It gives access to the LoadingScreen and the display of windows that it inherits from the abstract class WindowBase.

   **Loading Screen** executes all instances in the queue that implement ILoadingOperation and displays the description of the operation and the progress of this operation.

   **GameUI** - is a class that inherits from WindowBase and has a public method for changing the time.

3. **SaveLoad System**

    Represented as a SaveLoadSystem that implements the ISaveLoadSystem interface. The LoadGameData method returns a Task<GameData>

3. **GameStateMachine**

    **GameStateMachine** is a simple state machine that can switch between states through their Id(GameStateType enum) and depends on IGameStateFactory.
    **GameStateFactory** implements **IGameStateFactory**

    **GameStateBase** is base state class. It has an Init method for passing a state machine and 3 abstract methods (2 public, 1 protected). Dependencies are introduced when creating in GameStateFactory.
