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
        // Inicia a matriz com ZEROS.
        static void inicia(int[,] matriz, int n){
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matriz[i,j] = 0;
                }
            }
        }
        static int gera_bombas(int[,] matriz, int n)
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
                // Adiciona -2 nos locais que estaram as bombas.
                if (matriz[p1,p2] == 0){
                    matriz[p1,p2] = -2;
                    i++;
                }
            }
            Console.Clear();
            return num_bombas;
        }

        static int play_game(int[,] matriz, int n, int num_bombas)
        {
            int score=0, p1, p2, error_num=0;
            int[,] tela;
            // Matriz para exibir sem monstrar os locais das bombas.
            tela = new int[n, n];
            inicia(tela, n);

            while (error_num != 3){
                exibe_matriz(matriz, n);
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

                if ((n * n - num_bombas) * 3 == score){
                    exibe_matriz(matriz, n);
                    Console.WriteLine("JOGO ZERADO!");
                    break;
                }
            }
            exibe_matriz(matriz, n);
            Console.WriteLine("Você acertou 3 bombas.");
            return score;
        }
        static void Main(string[] args)
        {
            int[,] matriz;

            char play = 'S';
            while (play == 'S')
            {
                Console.WriteLine("Entre com o tamanho de N: ");
                int n = int.Parse(Console.ReadLine());
                matriz = new int[n, n];
                inicia(matriz, n);
                int num_bombas = gera_bombas(matriz, n);

                int score = play_game(matriz, n, num_bombas);
                Console.WriteLine("Score: {0}", score);
                Console.Write("Jogar Novamente? <S> se sim: ");
                play = char.Parse(Console.ReadLine().ToUpper());
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

