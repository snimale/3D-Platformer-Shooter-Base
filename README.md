## A Simple 3D Platformer Shooter that I developed in the year 2023.

# This project contains two scenes-

### Main Menu Scene
- The main menu displays simply an UI with quit, settings and play buttons with a background panel.
- No skybox has been used.
- There is a loading screen after clicking play button but is very fast thus, may not be visible.

### Level Scene
- The level scene has many components as described below ->
- It contains a player (which is supposed to be Mario but couldn't find 3D Free assets of Mario so had to compromise with a cube)
- But the player contains many animations like ->
  - Shooting recoil animation
  - Run animation
  - Walk animation
  - Change left/right direction
  - Jump animation
- Similarly there is enemy made up of cubes that generate when player approaches close to the enemy generators.
- Enemy also have animation and will follow the player.
- When player and enemy touch/collide damage is taken by both of them as given in serialized field in unity
- An IMPORTANT feature of game is the SHOOTING ABILITY of the player with particle systems used for muzzle flash and ray flash of bullet
- Bullets is used by ray casting and getting info from rayCastHit and this code is put in projective shooter object attached to the player
- There is no visual gun, as player shoots from its mouth, but it can be easily added.
- There is audio sounds and background music.
- There is a simple level with some obstacles that are NOT dynamically generated but WE CAN GENERATE OBSTACLES AND MAP DYNAMICALLY using PIXEL MAPPING 
as i have done in other project.
- There are various materials and some materials also have glow like muzzle flash.
- The length of ray of flash generated after shooting is dynamic i.e. depend on the distance from the object of collision
