using System;

namespace Final
{
    class Program
    {
        static void jogador1(char[,] mat) //, char posicao
        {
            
            Console.Write("Jogador 1, Escolha uma posição: ");
            char posicao = Convert.ToChar(Console.ReadLine());
            while (posicao != 'a' || posicao != 'b' || posicao != 'c' || posicao != 'd' || posicao != 'e' || posicao != 'f' || posicao != 'g' || posicao != 'h' || posicao != 'i' || posicao=='l')
            {
                Console.Write("Jogador 1, Escolha uma posição: ");
                posicao = Convert.ToChar(Console.ReadLine());
            }

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] == posicao)
                    {
                        mat[i, j] = 'X';
                    }
                }
            }
        }
        static void jogador2(char[,] mat)//, char posicao
        {
            Console.Write("Jogador 2, Escolha uma posição: ");
            char posicao = Convert.ToChar(Console.ReadLine());

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] == posicao)
                    {
                        mat[i, j] = 'O';
                    }
                }
            }
        }

        static int VerificarLinha(char[,] matriz, char jogador)
        {
            int cont, a = 0;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                cont = 0;
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] == jogador)
                    {
                        cont++;
                    }
                }
                if (cont == 3)
                {
                    a = 1;
                }
            }

            if (a == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static int VerificarColuna(char[,] matriz, char jogador)
        {
            int cont, a = 0;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                cont = 0;
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[j, i] == jogador)
                    {
                        cont++;
                    }
                }
                if (cont == 3)
                {
                    a = 1;
                }
            }
            if (a == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static int VerificarDiagonalPrimaria(char[,] matriz, char jogador)
        {
            int cont = 0;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if (matriz[i, i] == jogador)
                {
                    cont++;
                }
            }
            if (cont == 3)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static int VerificarDiagonalSecundaria(char[,] matriz, char jogador)
        {
            int cont = 0, i, j;

            for (i = 0, j = 2; i < matriz.GetLength(0); i++, j--)
            {
                if (matriz[i, j] == jogador)
                {
                    cont++;
                }
            }
            if (cont == 3)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static void ImprimeVencedor(char jogador)
        {
            if (jogador == 'X')
            {
                Console.WriteLine("O jogador 1 foi o vencedor!");
            }
            else
            {
                Console.WriteLine("O jogador 2 foi o vencedor!");
            }

        }
        static void ImprimeMatriz(char[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(" {0} ", mat[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            char[,] matriz = new char[3, 3] { { 'a', 'b', 'c' }, { 'd', 'e', 'f' }, { 'g', 'h', 'i' } };
            //char posicao = 'l';
            char jog1 = 'X';
            char jog2 = 'O';


            Console.WriteLine("Que comecem os jogos...da velha claro!");
            ImprimeMatriz(matriz);
            //Jogada sem verificar
            jogador1(matriz);//, posicao
            ImprimeMatriz(matriz);
            jogador2(matriz);//, posicao
            ImprimeMatriz(matriz);
            jogador1(matriz);//, posicao
            ImprimeMatriz(matriz);
            jogador2(matriz);//, posicao
            ImprimeMatriz(matriz);
            //A partir desse momento é necessária a verificação

            jogador1(matriz);

            if (VerificarLinha(matriz, jog1) == 1 || VerificarColuna(matriz, jog1) == 1 || VerificarDiagonalPrimaria(matriz, jog1) == 1 || VerificarDiagonalSecundaria(matriz, jog1) == 1)
            {
                ImprimeMatriz(matriz);
                ImprimeVencedor(jog1);

            }
            else
            {
                ImprimeMatriz(matriz);

                jogador2(matriz);

                if (VerificarLinha(matriz, jog2) == 1 || VerificarColuna(matriz, jog2) == 1 || VerificarDiagonalPrimaria(matriz, jog2) == 1 || VerificarDiagonalSecundaria(matriz, jog2) == 1)
                {
                    ImprimeMatriz(matriz);
                    ImprimeVencedor(jog2);

                }

                else
                {
                    ImprimeMatriz(matriz);
                    jogador1(matriz);

                    if (VerificarLinha(matriz, jog1) == 1 || VerificarColuna(matriz, jog1) == 1 || VerificarDiagonalPrimaria(matriz, jog1) == 1 || VerificarDiagonalSecundaria(matriz, jog1) == 1)
                    {
                        ImprimeMatriz(matriz);
                        ImprimeVencedor(jog1);

                    }

                    else
                    {
                        ImprimeMatriz(matriz);

                        jogador2(matriz);

                        if (VerificarLinha(matriz, jog2) == 1 || VerificarColuna(matriz, jog2) == 1 || VerificarDiagonalPrimaria(matriz, jog2) == 1 || VerificarDiagonalSecundaria(matriz, jog2) == 1)
                        {
                            ImprimeMatriz(matriz);
                            ImprimeVencedor(jog2);

                        }
                        else
                        {
                            ImprimeMatriz(matriz);
                            jogador1(matriz);

                            if (VerificarLinha(matriz, jog1) == 1 || VerificarColuna(matriz, jog1) == 1 || VerificarDiagonalPrimaria(matriz, jog1) == 1 || VerificarDiagonalSecundaria(matriz, jog1) == 1)
                            {
                                ImprimeMatriz(matriz);
                                ImprimeVencedor(jog1);

                            }
                            else
                            {
                                Console.WriteLine("O jogo deu Velha!");
                            }
                        }
                    }
                }

            }




        }


    }
}
