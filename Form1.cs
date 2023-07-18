using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        int Xplayer = 0, Oplayer = 0, empatesPontos = 0, rodadas = 0;
        bool turno = true, jogo_final = false;
        string[] texto = new string[9];

        public Form1()
        {
            InitializeComponent();
        }

        public int ChecagemPlayer { get; private set; }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && jogo_final == false)
            {

                if (turno)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(2);

                } //final da estrutura

            }

        } //final método botão

        void Vencedor(int PlayerQuemGanhou)
        {
            jogo_final = true;

            if (PlayerQuemGanhou == 1)
            {
                Xplayer++;
                Xpontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("Jogador X ganhou!");
                turno = true;
                
            }
            else
            {
                Oplayer++;
                Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Jogador O ganhou!");
                turno = false;
            }
        }


        void Checagem(int ChecagemPlayer)
        {
            string suporte = "";

            if (ChecagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            } //final do suporte

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    // Chegagem Horizontal

                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {

                        Vencedor(ChecagemPlayer);
                        return;

                    } //final da chegagem horizontal
                }
            } //Final do loop horizontal

            //Chegagem vertical:

            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (suporte == texto[vertical])
                {
                    // Chegagem Vertical

                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        Vencedor(ChecagemPlayer);
                        return;

                    }
                }
            } //Final do loop Vertical

            //Verificações nas diagonais:

            if (texto[0] == suporte)
            {

                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    Vencedor(ChecagemPlayer);
                    return;

                } //Diagonal principal

            }

            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Vencedor(ChecagemPlayer);
                    return;

                } //Diagonal secundária
            }
            if (rodadas == 9 && jogo_final == false)
            {
                empatesPontos++;
                empates.Text = Convert.ToString(empatesPontos);
                MessageBox.Show("Empate!");
                jogo_final = true;
                return;
            }
        }
        private void btnclean_Click(object sender, EventArgs e)
        {
            btn.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";

            rodadas = 0;
            jogo_final = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }
    }
}
