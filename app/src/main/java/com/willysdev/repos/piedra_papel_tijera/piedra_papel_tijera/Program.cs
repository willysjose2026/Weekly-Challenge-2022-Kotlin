/*
 * Reto #25: PIEDRA, PAPEL, TIJERA
 * MEDIA | Publicación: 20 / 06 / 22 | Resolución: 27 / 06 / 22
 * 
 * Crea un programa que calcule quien gana más partidas al piedra,
 * papel, tijera.
 * - El resultado puede ser: "Player 1", "Player 2", "Tie" (empate)
 * - La función recibe un listado que contiene pares, representando cada jugada.
 * - El par puede contener combinaciones de "R" (piedra), "P" (papel)
 *   o "S" (tijera).
 * - Ejemplo. Entrada: [("R","S"), ("S","R"), ("P","S")]. Resultado: "Player 2".
 */
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Moves moves = new();
        List<string[][]> Rounds = new()
        {
            new string[][] {new string[] { moves.Rock, moves.Rock }},
            new string[][] {new string[] { moves.Rock, moves.Scissors }},
            new string[][] {new string[] { moves.Paper, moves.Scissors }},

            new string [][]
            {
                new string[] { moves.Rock, moves.Rock },
                new string[] { moves.Scissors, moves.Scissors},
                new string[] { moves.Paper, moves.Paper }
            },
            
            new string[][]
            {
                new string[] {moves.Rock, moves.Scissors},
                new string[] {moves.Scissors, moves.Paper},
                new string[] {moves.Scissors, moves.Rock}
            },

            new string[][]
            {
                new string[] {moves.Rock, moves.Paper},
                new string[] {moves.Scissors, moves.Rock},
                new string[] {moves.Paper, moves.Scissors},
            } 
        };

        foreach(var round in Rounds)
        {
            CalculateWinner(round);
        }
    }

    private static void CalculateWinner(string[][] rounds)
    {
        int player_one_counter = 0;
        int player_two_counter = 0;
        
        Moves moves = new();

        foreach (var round in rounds)
        {
            var player_one = round[0];
            var player_two = round[1];

            //the way I did it
            if (player_one == moves.Rock && player_two == moves.Scissors
                || player_one == moves.Paper && player_two == moves.Rock
                || player_one == moves.Scissors && player_two == moves.Paper)
                player_one_counter++;
            else if(player_two == moves.Rock && player_one == moves.Scissors
                || player_two == moves.Paper && player_one == moves.Rock
                || player_two == moves.Scissors && player_one == moves.Paper)
                player_two_counter++;
            

            //A better and cleaner way
            /*
            if(player_one != player_two)
            {
                if (player_one == moves.Rock && player_two == moves.Scissors
                    || player_one == moves.Paper && player_two == moves.Rock
                    || player_one == moves.Scissors && player_two == moves.Paper)
                    player_one_counter++;
                else
                    player_two_counter++;
            }*/

        }

        if (player_one_counter == player_two_counter)
            Console.WriteLine("It's a tie!!");
        else if (player_one_counter > player_two_counter)
            Console.WriteLine("Player 1 is the winner");
        else
            Console.WriteLine("Player 2 is the winner");
    }

    public readonly struct Moves
    {
        public Moves(){ Rock = "R"; Scissors = "S"; Paper = "P"; }
        public string Rock { get; }
        public string Scissors { get; }
        public string Paper { get; }
    }
}