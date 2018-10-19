using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;
       
        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
            textBox2.KeyDown += new KeyEventHandler(KeyDown);
        }

        public void Notify(Model m)
        {
            UpdateBoard(((TwoZeroFourEightModel) m).GetBoard());
            ScoreLb.Text = "SCORE : " + Convert.ToString(((TwoZeroFourEightModel)m).score);
            if (((TwoZeroFourEightModel)m).isFull())
            {
                if (((TwoZeroFourEightModel)m).gameOver())
                {
                    var result = MessageBox.Show("Game Over\n score : " + (((TwoZeroFourEightModel)m).score) 
                                                   + "\n Restart ?","Game Over", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                    {
                        ((TwoZeroFourEightModel)m).Clear();
                        UpdateBoard(((TwoZeroFourEightModel)m).GetBoard());
                        ScoreLb.Text = "SCORE : " + Convert.ToString(((TwoZeroFourEightModel)m).score);
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            } else {
                l.Text = "";
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.Gray;
                    break;
                case 2:
                    l.BackColor = Color.DarkGray;
                    break;
                case 4:
                    l.BackColor = Color.PeachPuff;
                    break;
                case 8:
                    l.BackColor = Color.BurlyWood;
                    break;
                case 16:
                    l.BackColor = Color.SandyBrown;
                    break;
                case 32:
                    l.BackColor = Color.IndianRed;
                    break;
                case 64:
                    l.BackColor = Color.Tomato;
                    break;
                case 128:
                    l.BackColor = Color.SpringGreen;
                    break;
                case 256:
                    l.BackColor = Color.GreenYellow;
                    break;
                case 512:
                    l.BackColor = Color.Green;
                    break;
                case 1024:
                    l.BackColor = Color.Goldenrod;
                    break;
                case 2048:
                    l.BackColor = Color.Yellow;
                    break;
                default:
                    l.BackColor = Color.Orange;
                    break;
            }
        }

        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00,board[0, 0]);
            UpdateTile(lbl01,board[0, 1]);
            UpdateTile(lbl02,board[0, 2]);
            UpdateTile(lbl03,board[0, 3]);
            UpdateTile(lbl10,board[1, 0]);
            UpdateTile(lbl11,board[1, 1]);
            UpdateTile(lbl12,board[1, 2]);
            UpdateTile(lbl13,board[1, 3]);
            UpdateTile(lbl20,board[2, 0]);
            UpdateTile(lbl21,board[2, 1]);
            UpdateTile(lbl22,board[2, 2]);
            UpdateTile(lbl23,board[2, 3]);
            UpdateTile(lbl30,board[3, 0]);
            UpdateTile(lbl31,board[3, 1]);
            UpdateTile(lbl32,board[3, 2]);
            UpdateTile(lbl33,board[3, 3]);
        }

        private new void KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Hide();
            ScoreLb.Show();
            if (e.KeyCode == Keys.Left)
            {
                controller.ActionPerformed(TwoZeroFourEightController.LEFT);
            }
            if (e.KeyCode == Keys.Right)
            {
                controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
            }
            if (e.KeyCode == Keys.Up)
            {
                controller.ActionPerformed(TwoZeroFourEightController.UP);
            }
            if (e.KeyCode == Keys.Down)
            {
                controller.ActionPerformed(TwoZeroFourEightController.DOWN);
            }
        }
    }
}
