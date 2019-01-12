using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Runner.Player
{
    public class PlayerInput
    {
        public PlayerInput()
        {

        }

        public void Update(PlayerController player)
        {
            player.Velocity = GetPlayerMovementValue();

        }

        public Vector2 GetPlayerMovementValue()
        {
            var playerMovementValue = new Vector2();
            if (Input.isKeyDown(Keys.Left))
                playerMovementValue.X = -1;
            if (Input.isKeyDown(Keys.Right))
                playerMovementValue.X = 1;
            if (Input.isKeyDown(Keys.Up))
                playerMovementValue.Y = -1;
            if (Input.isKeyDown(Keys.Down))
                playerMovementValue.Y = 1;
            return playerMovementValue;
        }
    }
}