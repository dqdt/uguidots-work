# Taking notes here.

# 5/5/2020

Unity UI: also called UGUI. The name is com.unity.ugui.
* Why does the namespace(?) begin with "com"? 
* https://softwareengineering.stackexchange.com/questions/180353/why-do-so-many-namespaces-start-with-com
  * Reverse domain notation.

What is UGUIDots?
* A bridge between Unity's default UI and ECS (make it more data-oriented).
* The workflow of authoring UI elements should be the same (?).

Dependencies:
* Burst, Entities, Jobs, Collections, UGUI, Univeral RP, TextMeshPro.

Contributing:
* Fork the repo. 
  * Master branch for pending bugs. Develop branch for features.
* Push to your forked repo.
  * Pull request to the master branch.
    * Include a summary of changes in CHANGELOG.md.
  * Pull request to the develop branch if you have a feature.
Tips:
* Ensure your git commits are easy to follow and read.
* Follow the C# MSDN Conventions.

UGUIDots.Samples
* git clone [url] --recursive
  * https://explainshell.com/explain?cmd=git+clone+--recursive
  * After the clone is created, initialize all submodules within, using their default settings. This is equivalent to running `git submodule update --init --recursive` immediately after the clone is finished.
* UGUIDots.Samples includes UGUIDots as a submodule...
* Error: no private key
  * It works in Git Bash, but not Powershell/etc.
  * I don't have a ssh key for the other terminals?
  * https://help.github.com/en/github/authenticating-to-github/error-permission-denied-publickey#should-the-sudo-command-be-used-with-git
  * Just use Git Bash / Github Desktop for now...

OK, I figure I should have my own project, with a structure similar to UGUIDots.Samples.
* Private repo "uguidots-work" containing a unity project.
* Add my forked UGUIDots as a submodule in the Assets folder.
  * I should add a second remote: the main UGUIDots repo, named "origin2".
    * Now we can fetch changes from the main UGUIDots repo.
    * Pulling from the main repo? I rebased master onto origin2/master, and pulled the changes.
* Side note:
  * https://stackoverflow.com/questions/2883840/differences-between-git-pull-origin-master-git-pull-origin-master
    * `git pull origin master`: pulls from the `origin` remote, `master` branch
    * `git pull origin/master`: pulls from the locally stored branch `origin/master`
      * `origin/master` is a "cached copy" of what was last pulled from origin

I'm trying to open up the UGUIDots.Samples project in Unity, but it is stuck at "Resolving Packages".
* Just wait longer.

# 5/6/2020 - 5/8/2020

https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/index.html

Notes on Unity UI docs:
* A UI toolkit for developing UI for games and applications.
* GameObject-based UI system that uses Components and the Game View to arrange, position, and style user interfaces.
* The documentation describes creating a Canvas, positioning and animating elements, defining user interactions.

Canvas:
* The Canvas is an area that all UI elements should be inside.
* The Canvas is a GameObject with a Canvas component.
  * All UI elements must be children of a Canvas.
* Creating a new UI element (e.g. GameObject > UI > Image) when there is no existing Canvas in the scene will automatically create a Canvas and attach the new element as a child of the Canvas.
* A Canvas needs an EventSystem.
* The Canvas area is a rectangle in the Scene View.
  * Allows working outside the Game View.
* Draw order:
  * UI elements are drawn in the same order as they appear in the Hierarchy.
    * Drag elements to change the draw order.
    * To change the order in scripts, use these methods on the transform component: SetAs(First|Last)Sibling, SetSiblingIndex.
* Render Mode:
  * The canvas has a Render Mode setting to make it render in screen space or world space.
  * Screen Space - Overlay
    * Renders on top of the scene.
    * If the screen is resized or changes resolution, the Canvas will automatically resize.
  * Screen Space - Camera
    * The Canvas is placed a given distance in front of a specified Camera. The UI elements are rendered by this camera.
  * World Space
    * The Canvas will behave as any other object in the scene.
    * Position the Canvas through its Rect Transform.
    * UIs that are a part of the world. This is known as a "diegetic interface".
      * https://gamedev.stackexchange.com/questions/99246/what-are-diegetic-non-diegetic-spatial-and-meta-user-interfaces
        * "diegetic" means it's part of the scene; visible to the main character.
        * "non-diegetic" means it's not part of the scene.
      * https://en.wikipedia.org/wiki/Diegesis
        * The narrator tells the story: the details of the world and the experiences of the characters.
        * There is a presumed detachment from the story from the speaker and the audience.
        * diegesis: to narrate
        * non-diegetic elements: _how_ the narrator tells the story

Basic Layout:
* Every UI element is a rectangle for layout purposes.
  * Use the Rect Tool in the Scene View to manipulate the rectangle.
    * Move by dragging.
    * Resize by dragging the corners.
    * Rotate by hovering around the corner until the cursor changes, then drag.
      * Pivot point: Center of rectangle, or Pivot (manual).
      * Local/Global space: Tool handles are in the active object's rotation, or global rotation (??).
    * The Rect Tool is used for Unity2D features, UI, and even 3D objects.
* Rect Transform:
  * Used instead of the regular Transform component.
  * Position, Rotation, Scale, Width, Height
    * Rect Tool only changes the position, width, and height.
  * Pivot
    * Shown as a blue ring.
    * Rotations, size, and scale modifications occur around the pivot.
  * Anchor
    * Shown as four triangles.
    * Hold down Shift when dragging an anchor to also move the corresponding corner of the rectangle.
    * Anchor presets.
    * What's the math behind it? We'll see...

Visual Components:
* 