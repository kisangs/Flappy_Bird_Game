using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Game
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        int pipeSpeed = 10;
        int gravity = 8;
        int score = 0;
        private bool isGameOver = false;
        Random rnd = new Random();


        public Form1()
        {
            InitializeComponent();
            gameOverPanel.Visible = false;
            button1.Click += button1_Click;
            ground.Controls.Add(scoreText);
            scoreText.BackColor = Color.Transparent;
            scoreText.Parent = ground;
            scoreText.Left = 20;
            scoreText.Top = 25;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeBottom2.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -50)
            {
                pipeBottom.Left = rnd.Next(1200, 1400);
                score++;
            }

            if (pipeBottom2.Left < -50)
            {
                pipeBottom2.Left = rnd.Next(1400, 1800);
                score++;
            }

            if (pipeTop.Left < -80)
            {
                pipeTop.Left = rnd.Next(1200, 1600);
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeBottom2.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                    (flappyBird.Top < -25))
            {
                endGame();
            }
            if (score > 5)
            {
                pipeSpeed = 15;
            }
            if (score > 25)
            {
                pipeSpeed = 30;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pipeSpeed = 10;
            gravity = 8;
            score = 0;
            isGameOver = false;
            scoreText.Text = "Score: " + score;
            flappyBird.Top = 100;
            pipeBottom.Left = 800;
            pipeBottom2.Left = 800;
            pipeTop.Left = 1000;
            timer1.Start();
            gameOverPanel.Visible = false;
        }

        private void endGame()
        {
            timer1.Stop();
            isGameOver = true;
            gameOverPanel.Visible = true;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }
    }
}
