////////// ENEMY 1 SCENE //////////
This scene is made to demonstrate the standard enemy when it is working.

Scene is made up of 2 parts:
    1. Platforms
    2. Enemy

Platform instructions:
The colliders on the edges of this platform are meant for floating platforms. If the enemy is on the ground, ignore those steps.
1. Insert a 2d square and name it platform.
2. Add a 2d box collider to the platform and check "Is Trigger"
3. Duplicate the platform and add it as a child to the original platform. Uncheck "Is Trigger"
4. Add two 2d boxes as children to the platform to the left and right ends of the platform.
5. For these two boxes, add a collider and check "Is Trigger." Give them the "Edge" tag. Uncheck "Sprite Renderer."

Enemy instructions:
1. Create an 2d sprite of any shape.
2. Create an empty gameobject child to the enemy and name it Spawner. Put it at 0,0,0 of the original object.
3. For the original sprite, give it a 2d circle collider with "Is Trigger" unchecked. Give it a rigidbody 2d with everything default, and give it the EnemyStd script.
4. On the script, set speed to a value of your liking, "Is Left" does not matter, set the spawning object to the empty child object that you created earlier, and set the projectile to the projectile prefab.

////////// ENEMY 2 SCENE //////////
This scene is made to demonstrate the player functionality and cloud enemy.

Scene is made up of 3 parts:
    1. Cloud
    2. Player
    3. Projectile
First, create a platform for the player to stand on.

Player instructions:
1. Create a 2d sprite and name it Player.
2. Give it a rigidbody2d component with the default settings, a 2d box collider with "Is Trigger" unchecked, and the X Y scripts.
3. Set the P_Thrust in the X script to something like 4.
4. Set the P_Thrust in the Y script to something like 20. (Ignore "CanJumpY").
5. Give the player object the "Player" tag.
6. If you want to change the feel of the movement:
    a. Windows -> Panels -> 6 Project Settings
    b. Project Settings -> Input Manager -> Horizontal -> Gravity
    c. Change the gravity setting to a value of your liking.

Cloud instructions:
1. Create a 2d sprite and name it Cloud.
2. Give it the Cloud script. 
3. Add the Player object as the Player Obj variable, add HeartProj as the projectile variable, and change the speed to something like 1.5.

Heart Projectile instructions:
1. Create a 2d sprite called HeartProj
2. Give it a rigidbody 2d component with default settings, a 2d collider with "Is Trigger" checked, and the HeartProjectile script. 