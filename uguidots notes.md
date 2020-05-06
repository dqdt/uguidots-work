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

# 5/6/2020

https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/index.html

Notes on Unity UI docs:
* A UI toolkit for developing UI for games and applications.
* GameObject-based UI system that uses Components and the Game View to arrange, position, and style user interfaces.
* Creating a Canvas, positioning and animating elements, defining user interactions.

Canvas:
* The Canvas is a GameObject with a Canvas component.
  * All UI elements must be children of the Canvas. 
