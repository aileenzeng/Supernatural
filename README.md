# Supernatural
2D platform game based off of the hit-television series, Supernatural!

GIT COMMANDS:
*** VERY IMPORTANT: ***
*** MAKE SURE TO PULL BEFORE YOU EDIT ***
*** AND TO PUSH WHEN YOU'RE DONE EDITING ***
*** (and preferably, make everything compile) ***

Check status:
git status

To push:
git add .
git commit -m "insert message here, what you changed/are working on"
git push

To pull:
git pull

If there is a merge conflict with scripts
:wq

If there is a merge conflict w/ the scene (two people edited the same scene and are trying to push their changes)
--If you see an asterisk next to your editor in Unity, you have changed the scene.
--If multiple people are editing the scene at the same time, let them know to try to avoid merge conflicts.
--Git should give you the file name that has the merge conflict. 

git checkout --ours -- filename <-- To keep your changes
git checkout --theirs -- filename <-- To keep not-your changes

