# GamesAIResit
Gallery Sim

Use: Open the Unity Project and press play. Add objects and tag them with goal if you want the agents to choose it as target to move to.

Behaviour: The behaviour basically works as follows: All the exhibits are tagged with the goal tag. An agent picks a target from the list of goal-tagged exhibits, sets it as it's new target, removes it from it's own list of exhibits to view and then moves to it, navigating it's way there using the NavMeshAgent script and NavMoveTo (NavMesh is baked into the environment). 

Once it does that, it waits/"looks" at the exhibit, in a spot around the exhibit (a more sophisticated way of doing this could have been using a raycast to "see" the exhibit and communicating that to the blackboard). When the agent is "done" looking at it's given exhibit, it repeats the same actions as above.

When an agent reaches an exhibit it turns off "NavMeshAgent" and turns on "NavMeshObstacle" allowing other agents to navigate around it without getting stuck; this is done because using a NavMesh provides the agents with no local avoidance, meaning they cannot navigate around each other, this causes problems when navigating through doorways and such. 

This is all emcompassed by a repeater that repeats the given behaviour over until it is done. After repeating the behaviour until it has no more exhibits it wants to view, the service "byeBye"'s conditions are met and the agent moves to the "exit", wherever it is placed.

Future Work/Improvements:

Add an instantiate and destroy, allowing agents to "walk-in" and "leave" the gallery, This could be done using Unity's onCollisionEnter and a box collider on an "exit".

Add rayCasting to "see", which would allow for more sophisticated perception and navigation of the environment. An agent, when it "sees" another agent in front of it, could walk around said agent until there is no longer an obstacle blocking it's forward path, for example.

Add more rooms, upstairs and downstairs and a player-controlled character with some perform-able actions e.g. a whistle that calls all active agents to the players position.

Video Documentation (YouTube): https://www.youtube.com/edit?o=U&video_id=HnCFo5mtOPE
