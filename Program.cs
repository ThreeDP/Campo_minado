using System;

namespace campo_minado
{
    class Program
    {
        static void exibe_matriz(int[,] matriz, int n)
        {
            Console.Clear();
            Console.Write("\t\t");
            for (int i = 0; i < n; i++)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(i + "\t-\t");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void inicia(int[,] matriz, int n){
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matriz[i,j] = 0;
                }
            }
        }
        static void gera_bombas(int[,] matriz, int n)
        {
            Console.Clear();
            var rand = new Random();
            int i = 0, p1, p2;
            Console.Write("Entre a porcentagem: ");
            double porcent = Convert.ToDouble(Console.ReadLine()) / 100;

            int num_bombas = (int)((n * n) * porcent);

            while (i < num_bombas)
            {
                p1 = rand.Next(0, n);
                p2 = rand.Next(0, n);
                if (matriz[p1,p2] == 0){
                    matriz[p1,p2] = -2;
                    i++;
                }
            }
            Console.Clear();
        }

        static int play_game(int[,] matriz, int n)
        {
            int score=0, p1, p2, error_num=0;
            int[,] tela;
            tela = new int[n, n];
            inicia(tela, n);

            while (error_num != 3){
                exibe_matriz(tela, n);
                Console.Write("Entre a primeira posicao: ");
                p1 = int.Parse(Console.ReadLine());

                Console.Write("Entre a segunda posicao: ");
                p2 = int.Parse(Console.ReadLine());

                if (matriz[p1,p2] == 0){
                    matriz[p1,p2] = 3;
                    tela[p1,p2] = 3;
                    score += 3;
                } else if (matriz[p1,p2] == -2){
                    score += -2;
                    tela[p1,p2] = -2;
                    error_num++;
                }
            }
            return score;
        }
        static void Main(string[] args)
        {
            int[,] matriz;
            Console.WriteLine("Entre com o tamanho de N: ");
            int n = int.Parse(Console.ReadLine());
            matriz = new int[n, n];
            inicia(matriz, n);
            gera_bombas(matriz, n);

            char play = 'S';
            while (play == 'S')
            {
                int score = play_game(matriz, n);
                exibe_matriz(matriz, n);
                Console.WriteLine("Score: {0}", score);
                Console.Write("Jogar Novamente? <S> se sim: ");
                play = char.Parse(Console.ReadLine());
            }
            
            //Problema do campo minado
            //Crie um programa para simular um jogo de campo minado. Seu programa deve:
            //Permitir a escolha do tamanho do campo NxN;
            //Permitir a inclusão da porcentagem de bombas na matriz [5, 40]. Por exemplo: 20%, 30%, 40%
            //Exibir uma interface amigável com o usuário.
            //Permitir que o usuário jogue quantas vezes quiser.
            //Mostrar pontuação ao final (acertos + 3, erros -2);
        }
    }
}

