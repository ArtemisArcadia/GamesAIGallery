# GamesAIResit
Gallery Sim

Use: Open the Unity Project and press play. Add objects and tag them with goal if you want the agents to choose it as target to move to.

Behaviour: The behaviour basically works as follows:
An agent picks a target from the list of goal-tagged exhibits and moves to it, navigating it's way using the NavMesh and NavMoveTo. Once it does that, it waits/"looks" at the exhibit, in a spot around it (a more sophisticated way of doing this could have been using a raycast to "see" the exhibit and communicating that to the blackboard). When the agent is "done" looking at it's given exhibit, it removes it from the list of goals and chooses another one to see.

When an agent reaches an exhibit it turns off "NavMeshAgent" and turns on "NavMeshObstacle" allowing other agents to navigate around it without getting stuck. This is all emcompassed by a repeater that repeats the given behaviour over until it is done. After repeating the behaviour until it has no more exhibits it wants to view, the service "byeBye"'s conditions are met and the agent moves to the "exit", wherever it is placed.

Future Work/Improvements:

1.  Add an instantiate and destroy, allowing agents to "walk-in" and "leave" the gallery, This could be done using Unity's onCollisionEnter and a box collider on an "exit". 

2.  Add rayCasting to "see", which would allow for more sophisticated perception and navigation of the environment. 

3.  Add more rooms, upstairs and downstairs and a player-controlled character with some performable actions e.g. a whistle that calls all active agents to the players position.

Video Documentation (YouTube): https://www.youtube.com/edit?o=U&video_id=HnCFo5mtOPE
