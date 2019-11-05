using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;


namespace FreeBowser
{
    public class SoundManager
    {
        public static TimeSpan Time { get; set; }
        public static int PauseTime{get; set;}
        public static bool SoundLock1 { get; set; }
        

        public static void LoadSoundContent(Game1 game)
        {
            Game1.mainBGM = game.Content.Load<SoundEffect>("01-main-theme-overworld");
            Game1.collectCoinSound = game.Content.Load<SoundEffect>("smb_coin");
            Game1.jumpSmallSound = game.Content.Load<SoundEffect>("smb_jumpsmall");
            Game1.bumpSound = game.Content.Load<SoundEffect>("smb_bump");
            Game1.marioDieSound = game.Content.Load<SoundEffect>("smb_mariodie");
            Game1.marioPowerUpSound = game.Content.Load<SoundEffect>("smb_powerup");
            Game1.stompSound = game.Content.Load<SoundEffect>("smb_stomp");
            Game1.jumpSuperSound = game.Content.Load<SoundEffect>("smb_jump-super");
            Game1.breakBlockSound = game.Content.Load<SoundEffect>("smb_breakblock");

        }
        public static void PlaySound(SoundEffect sound){
            sound.Play();
            
        }
        
        public static void playJumpSound(IPlayer mario)
        {
           //case small mario, play small mario jumping sound
            if (mario.GetUpTimer() ==1 )
            {
                if (mario.GetState().Equals(MarioState.SMALL)) { 
                Game1.jumpSmallSound.Play();
                }
                else
                {
                    Game1.jumpSuperSound.Play();
                }
            }
     
            
        }

        public void Update(GameTime gameTime)
        {
            if (PauseTime != 0)
            {
                Console.Out.WriteLine("Time2" + (int)gameTime.ElapsedGameTime.TotalSeconds);
                Console.Out.WriteLine("Time1"+(int)Time.TotalSeconds);

                if (((int)gameTime.TotalGameTime.TotalSeconds - (int)Time.TotalSeconds) > PauseTime)
                {
                    Game1.mainBGMInstance.Play();
                    PauseTime = 0;
                }
            }
        }

      
        public void ReleaseBGM(int t)
        {
            PauseTime = t;
                       
        }

       
    }
}
