using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace Impossible_Game
{
    public partial class Form1 : Form
    {
        //game variables
        int ballCount = 0;
        int playerSpeed = 5;
        int ballSpeed = 4;
        int ballSpeed2 = 10;
        int deaths = 0;

        // sector 1

        //Brushes to draw the game
        SolidBrush playerBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush pointBrush = new SolidBrush(Color.Purple);
        SolidBrush dangerBrush = new SolidBrush(Color.Red);
        SolidBrush safeBrush = new SolidBrush(Color.Green);
        SolidBrush borderBrush = new SolidBrush(Color.Black);

        // player
        Rectangle player = new Rectangle(25, 130, 20, 20);

        // borders
        Rectangle border0 = new Rectangle(0, 50, 10, 650);
        Rectangle border1 = new Rectangle(0, 50, 900, 25);
        Rectangle border2 = new Rectangle(0, 200, 750, 25);

        // Safezone
        Rectangle safezone1 = new Rectangle(0, 75, 60, 150);

        // Dangerballs
        Rectangle dangerBall1 = new Rectangle(75, 75, 17, 17);
        Rectangle dangerBall2 = new Rectangle(120, 183, 17, 17);
        Rectangle dangerBall3 = new Rectangle(165, 75, 17, 17);
        Rectangle dangerBall4 = new Rectangle(210, 183, 17, 17);
        Rectangle dangerBall5 = new Rectangle(255, 75, 17, 17);

        // points
        Rectangle pointBall1 = new Rectangle(165, 130, 15, 15);

        //Sector 2
        Rectangle border3 = new Rectangle(310, 100, 20, 100);


        // danger balls
        Rectangle dangerBalls1 = new Rectangle(844, 175, 25, 25);
        Rectangle dangerBalls2 = new Rectangle(844, 150, 25, 25);
        Rectangle dangerBalls3 = new Rectangle(330, 125, 25, 25);
        Rectangle dangerBalls4 = new Rectangle(330, 100, 25, 25);

        //Draws points
        Rectangle pointBall2 = new Rectangle(602, 135, 15, 15);

        //Sector 3
        //Borders
        Rectangle border4 = new Rectangle(875, 50, 25, 625);
        Rectangle border5 = new Rectangle(0, 525, 900, 25);

        //Creats danger balls
        Rectangle DangerBall1 = new Rectangle(85, 225, 15, 15);
        Rectangle DangerBall2 = new Rectangle(85, 240, 15, 15);
        Rectangle DangerBall3 = new Rectangle(85, 255, 15, 15);
        Rectangle DangerBall4 = new Rectangle(85, 270, 15, 15);
        Rectangle DangerBall5 = new Rectangle(85, 285, 15, 15);
        Rectangle DangerBalls1 = new Rectangle(350, 225, 25, 25);
        Rectangle DangerBalls2 = new Rectangle(375, 225, 25, 25);
        Rectangle DangerBalls3 = new Rectangle(400, 225, 25, 25);
        Rectangle DangerBalls4 = new Rectangle(425, 225, 25, 25);
        Rectangle DangerBalls5 = new Rectangle(450, 225, 25, 25);
        
        //Creates point
        Rectangle pointBall3 = new Rectangle(465, 375, 15, 15);

        //Creates dangerballs
        Rectangle DangerBalls6 = new Rectangle(475, 500, 25, 25);
        Rectangle DangerBalls7 = new Rectangle(500, 500, 25, 25);
        Rectangle DangerBalls8 = new Rectangle(525, 500, 25, 25);
        Rectangle DangerBalls9 = new Rectangle(550, 500, 25, 25);
        Rectangle DangerBalls0 = new Rectangle(575, 500, 25, 25);

        Rectangle DANGERBALLS1 = new Rectangle(750, 300, 20, 20);
        Rectangle DANGERBALLS2 = new Rectangle(855, 330, 20, 20);
        Rectangle DANGERBALLS3 = new Rectangle(750, 360, 20, 20);
        Rectangle DANGERBALLS4 = new Rectangle(855, 390, 20, 20);
        Rectangle DANGERBALLS5 = new Rectangle(750, 420, 20, 20);

        //Creates squares in sector 3
        Rectangle obstacle2 = new Rectangle(600, 300, 150, 150);
        Rectangle obstacle1 = new Rectangle(200, 300, 150, 150);

        //Creates safezone and border
        Rectangle safezone2 = new Rectangle(10, 225, 50, 300);
        Rectangle border6 = new Rectangle(60, 225, 25, 225);

        //Creates Danger Balls
        Rectangle DANGERBALL6 = new Rectangle(200, 450, 20, 20);
        Rectangle DANGERBALL7 = new Rectangle(230, 505, 20, 20);
        Rectangle DANGERBALL8 = new Rectangle(260, 450, 20, 20);
        Rectangle DANGERBALL9 = new Rectangle(290, 505, 20, 20);
        Rectangle DANGERBALL0 = new Rectangle(320, 450, 20, 20);

        Rectangle DANGERBALLs6 = new Rectangle(600, 450, 20, 20);
        Rectangle DANGERBALLs7 = new Rectangle(630, 505, 20, 20);
        Rectangle DANGERBALLs8 = new Rectangle(660, 450, 20, 20);
        Rectangle DANGERBALLs9 = new Rectangle(690, 505, 20, 20);
        Rectangle DANGERBALLs0 = new Rectangle(720, 450, 20, 20);

        Rectangle DANGERballs1 = new Rectangle(85, 300, 20, 20);
        Rectangle DANGERballs2 = new Rectangle(180, 330, 20, 20);
        Rectangle DANGERballs3 = new Rectangle(85, 360, 20, 20);
        Rectangle DANGERballs4 = new Rectangle(180, 390, 20, 20);
        Rectangle DANGERballs5 = new Rectangle(85, 420, 20, 20);

        //game control variables
        bool wpressed = false;
        bool apressed = false;
        bool spressed = false;
        bool dpressed = false;

        //Lists for dangerballs and walls
        List<Rectangle> walls = new List<Rectangle>();
        List<Rectangle> dangerList = new List<Rectangle>();

        // Danger ball speed list
        List<int> dangerXSpeed = new List<int>();
        List<int> dangerYSpeed = new List<int>();


        public Form1()
        {
            InitializeComponent();
        }
        public void InitializeGame()
        {
            //Resets all variables and labels so game can start
            gameTimer.Enabled = true;
            titleLabel.Text = "";
            startLabel.Text = "";
            titleLabel.BackColor = Color.Transparent;
            startLabel.BackColor = Color.Transparent;
            scoreLabel.Text = $"{ballCount}/3";
            deaths = 0;
            deathLabel.Text = $"Deaths: {deaths}";
            ballCount = 0;
            scoreLabel.Text = $"{ballCount}/3";
            player.X = 25;
            player.Y = 130;
            pointBall1.X = 165;
            pointBall1.Y = 130;
            pointBall2.X = 602;
            pointBall2.Y = 135;
            pointBall3.X = 465;
            pointBall3.Y = 375;

            #region lists
            walls.Clear();
            walls.Add(border0);
            walls.Add(border1);
            walls.Add(border2);
            walls.Add(border3);
            walls.Add(border4);
            walls.Add(border5);
            walls.Add(obstacle1);
            walls.Add(obstacle2);
            walls.Add(border6);

            dangerList.Clear();
            dangerXSpeed.Clear();
            dangerYSpeed.Clear();

            dangerList.Add(dangerBall1);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(4);

            dangerList.Add(dangerBall2);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(-4);

            dangerList.Add(dangerBall3);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(4);

            dangerList.Add(dangerBall4);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(-4);

            dangerList.Add(dangerBall5);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(4);

            dangerList.Add(dangerBalls1);
            dangerXSpeed.Add(-15);
            dangerYSpeed.Add(0);

            dangerList.Add(dangerBalls2);
            dangerXSpeed.Add(-15);
            dangerYSpeed.Add(0);

            dangerList.Add(dangerBalls3);
            dangerXSpeed.Add(15);
            dangerYSpeed.Add(0);

            dangerList.Add(dangerBalls4);
            dangerXSpeed.Add(15);
            dangerYSpeed.Add(0);

            dangerList.Add(DangerBall1);
            dangerXSpeed.Add(5);
            dangerYSpeed.Add(0);

            dangerList.Add(DangerBall2);
            dangerXSpeed.Add(5);
            dangerYSpeed.Add(0);

            dangerList.Add(DangerBall3);
            dangerXSpeed.Add(5);
            dangerYSpeed.Add(0);

            dangerList.Add(DangerBall4);
            dangerXSpeed.Add(5);
            dangerYSpeed.Add(0);

            dangerList.Add(DangerBall5);
            dangerXSpeed.Add(5);
            dangerYSpeed.Add(0);



            dangerList.Add(DangerBalls1);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(5);

            dangerList.Add(DangerBalls2);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(5);

            dangerList.Add(DangerBalls3);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(5);

            dangerList.Add(DangerBalls4);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(5);

            dangerList.Add(DangerBalls5);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(5);

            dangerList.Add(DangerBalls6);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(-5);

            dangerList.Add(DangerBalls7);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(-5);

            dangerList.Add(DangerBalls8);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(-5);

            dangerList.Add(DangerBalls9);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(-5);

            dangerList.Add(DangerBalls0);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(-5);

            dangerList.Add(DANGERBALLS1);
            dangerXSpeed.Add(4);
            dangerYSpeed.Add(0);

            dangerList.Add(DANGERBALLS2);
            dangerXSpeed.Add(-4);
            dangerYSpeed.Add(0);

            dangerList.Add(DANGERBALLS3);
            dangerXSpeed.Add(4);
            dangerYSpeed.Add(0);

            dangerList.Add(DANGERBALLS4);
            dangerXSpeed.Add(-4);
            dangerYSpeed.Add(0);

            dangerList.Add(DANGERBALLS5);
            dangerXSpeed.Add(4);
            dangerYSpeed.Add(0);

            dangerList.Add(DANGERBALL6);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(1); 
            
            dangerList.Add(DANGERBALL7);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(-1);

            dangerList.Add(DANGERBALL8);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(1);

            dangerList.Add(DANGERBALL9);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(-1);

            dangerList.Add(DANGERBALL0);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(1);

            dangerList.Add(DANGERBALLs6);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(1);

            dangerList.Add(DANGERBALLs7);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(-1);

            dangerList.Add(DANGERBALLs8);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(1);

            dangerList.Add(DANGERBALLs9);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(-1);

            dangerList.Add(DANGERBALLs0);
            dangerXSpeed.Add(0);
            dangerYSpeed.Add(1);

            dangerList.Add(DANGERballs1);
            dangerXSpeed.Add(4);
            dangerYSpeed.Add(0);

            dangerList.Add(DANGERballs2);
            dangerXSpeed.Add(-4);
            dangerYSpeed.Add(0);

            dangerList.Add(DANGERballs3);
            dangerXSpeed.Add(4);
            dangerYSpeed.Add(0);

            dangerList.Add(DANGERballs4);
            dangerXSpeed.Add(-4);
            dangerYSpeed.Add(0);

            dangerList.Add(DANGERballs5);
            dangerXSpeed.Add(4);
            dangerYSpeed.Add(0);
            #endregion
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //keys are not active
            switch (e.KeyCode)
            {
                case Keys.W:
                    {
                        wpressed = false;
                    }
                    break;
                case Keys.A:
                    {
                        apressed = false;
                    }
                    break;
                case Keys.S:
                    {
                        spressed = false;
                    }
                    break;
                case Keys.D:
                    {
                        dpressed = false;
                    }
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //keys are active
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (gameTimer.Enabled == false)
                    {
                        Application.Exit();
                    }
                    break;
                    //starts game
                case Keys.Space:
                    if (gameTimer.Enabled == false)
                    {
                        InitializeGame();
                    }
                    break;
                case Keys.W:
                    {
                        wpressed = true;
                    }
                    break;
                case Keys.A:
                    {
                        apressed = true;
                    }
                    break;
                case Keys.S:
                    {
                        spressed = true;
                    }
                    break;
                case Keys.D:
                    {
                        dpressed = true;
                    }
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Player speeds
            int x = player.X;
            int y = player.Y;

            #region move player
            //player controls
            if (wpressed == true)
            {
                player.Y = player.Y - playerSpeed;
            }
            if (spressed == true)
            {
                player.Y = player.Y + playerSpeed;
            }
            if (apressed == true)
            {
                player.X = player.X - playerSpeed;
            }
            if (dpressed == true)
            {
                player.X = player.X + playerSpeed;
            }
            #endregion

            #region move balls
            //moves the balls
            for (int i = 0; i < dangerList.Count; i++)
            {
                int newX = dangerList[i].X + dangerXSpeed[i];
                int newY = dangerList[i].Y + dangerYSpeed[i];

                dangerList[i] = new Rectangle(newX, newY, dangerList[i].Width, dangerList[i].Height);   
            }

            //code to make balls rebound after hittng a wall
            for (int i = 0; i < dangerList.Count; i++)
            {
                for (int j = 0; j < walls.Count; j++)
                {
                    if (dangerList[i].IntersectsWith(walls[j]))
                    {
                        dangerXSpeed[i] *= -1;
                        dangerYSpeed[i] *= -1;
                    }
                }
                
            }





            #endregion

            #region player danger collision

            //Sends player to spawn if they hit a ball and resets point balls and adds a death to the death tally
            for (int i = 0; i < dangerList.Count; i++)
            {
                if (dangerList[i].IntersectsWith(player))
                {
                    player.X = 25;
                    player.Y = 130;

                    deaths = deaths + 1;
                    deathLabel.Text = $"Deaths: {deaths}";

                    ballCount = 0;
                    scoreLabel.Text = $"{ballCount}/3";

                    pointBall1.X = 165;
                    pointBall1.Y = 130;

                    pointBall2.X = 602;
                    pointBall2.Y = 135;

                    pointBall3.X = 465;
                    pointBall3.Y = 375;

                    //plays sound
                    SoundPlayer player1 = new SoundPlayer(Properties.Resources.fail);
                    player1.Play();
                }
            }

            #endregion

            #region wall collisions

            //wont let player escape the confines of the game
            for (int i = 0; i < walls.Count; i++)
            {
                if (walls[i].IntersectsWith(player))
                {
                    player.X = x;
                    player.Y = y;
                }
            }

            #endregion
            //when a player hits a point ball it disappears and gives the player 1 of 3 points
            if(player.IntersectsWith(pointBall1))
            {
                pointBall1.X = -123;
                pointBall1.Y = -123;
                ballCount = ballCount + 1;
                scoreLabel.Text = $"{ballCount}/3";
                SoundPlayer player2 = new SoundPlayer(Properties.Resources.point);
                player2.Play();
            }
            if (player.IntersectsWith(pointBall2))
            {
                pointBall2.X = -123;
                pointBall2.Y = -123;
                ballCount = ballCount + 1;
                scoreLabel.Text = $"{ballCount}/3";
                SoundPlayer player3 = new SoundPlayer(Properties.Resources.point);
                player3.Play();
            }
            if (player.IntersectsWith(pointBall3))
            {
                pointBall3.X = -123;
                pointBall3.Y = -123;
                ballCount = ballCount + 1;
                scoreLabel.Text = $"{ballCount}/3";
                SoundPlayer player4 = new SoundPlayer(Properties.Resources.point);
                player4.Play();
            }

            //if the player hits the green safe zone and has all three point balls they win
            if (player.IntersectsWith(safezone2) && ballCount == 3)
            {
                gameTimer.Enabled = false;
                titleLabel.Text = $"YOU BEAT THE IMPOSSIBLE GAME \n You Died {deaths} Times ";
                startLabel.Text = "Press SPACE to play again press ESC to exit";
                SoundPlayer player5 = new SoundPlayer(Properties.Resources.win);
                player5.Play();
            }
            

            Refresh();
        }

        //draws the game
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameTimer.Enabled == true)
            {
                //Sector 1
                e.Graphics.FillRectangle(safeBrush, safezone1);

                
                //graw danger balls
                for(int i = 0; i < dangerList.Count; i++) 
                {
                    e.Graphics.FillEllipse(dangerBrush, dangerList[i]);
                }

                //draw walls
                for (int i = 0; i < walls.Count; i++)
                {
                    e.Graphics.FillRectangle(borderBrush, walls[i]);
                }

                //draws safezone, point balls and player
                e.Graphics.FillRectangle(safeBrush, safezone2);

                e.Graphics.FillEllipse(pointBrush, pointBall1);
                e.Graphics.FillEllipse(pointBrush, pointBall2);
                e.Graphics.FillEllipse(pointBrush, pointBall3);
                e.Graphics.FillRectangle(playerBrush, player);

                
            }
        }
    }
}