using System;
using System.Collections.Generic;

namespace RevisaoPrimeirosPassos
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Aluno> alunos = new List<Aluno>();


            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        var nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            alunos.Add(new Aluno() { Nome = nome, Nota = nota });
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal!");
                        }

                        break;

                    case "2":
                        foreach(var item in alunos)
                        {
                            if (!string.IsNullOrEmpty(item?.Nome))
                            {
                                Console.WriteLine($"Aluno: {item.Nome} - Nota: {item.Nota}");
                            }
                            
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;

                        var nAlunos = 0;
                            
                        foreach(var item in alunos)
                        {
                            if (!string.IsNullOrEmpty(item?.Nome))
                            {
                                notaTotal = notaTotal + item.Nota;
                                nAlunos++;
                            }
                        }
                        

                        var mediaGeral = notaTotal / nAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Média Geral: {mediaGeral} - Conceito: {conceitoGeral}");



                        break;
                    default:
                            throw new ArgumentOutOfRangeException();
                        
                }

                 opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Inserir novo Aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
