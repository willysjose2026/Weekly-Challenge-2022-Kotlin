/*
 * Reto #18: TRES EN RAYA
 * DIFÍCIL | Publicación: 02/05/22 | Resolución: 09/05/22
 * Crea una función que analice una matriz 3x3 compuesta por "X" y "O"
 * y retorne lo siguiente:
 * - "X" si han ganado las "X"
 * - "O" si han ganado los "O"
 * - "Empate" si ha habido un empate
 * - "Nulo" si la proporción de "X", de "O", o de la matriz no es correcta.
 *   O si han ganado los 2.
 * Nota: La matriz puede no estar totalmente cubierta.
 * Se podría representar con un vacío "", por ejemplo.
 */

internal class Program
{
    private static void Main(string[] args)
    {
        List<string[][]> gameBoards = new()
        {
            new string[][]
            {
                new string []{"X","O","O"},
                new string []{"O","X","O"},
                new string []{"X","O","X"},
            },
            new string[][]
            {
                new string []{"O","O","O"},
                new string []{"X","X","O"},
                new string []{"X","O","X"},
            },
            new string[][]
            {
                new string []{"","O","X"},
                new string []{"X","X","O"},
                new string []{"O","O",""},
            },
            new string[][]
            {
                new string []{"O","X","X"},
                new string []{"O","X","O"},
                new string []{"O","O","X"},
            },
            new string[][]
            {
                new string []{"X","O","O"},
                new string []{"X","X","O"},
                new string []{"X","O","O"},
            },
            new string[][]
            {
                new string []{"O","O","X"},
                new string []{"O","X","O"},
                new string []{"X","X","X"},
            },
            new string[][]
            {
                new string []{"X","O","O"},
                new string []{"X","X","O"},
                new string []{"X","O","O"},
                new string []{"X","O","O"},
            },

            new string[][]
            {
                new string []{"X","O","O", ""},
                new string []{"X","X","O"},
                new string []{"X","O","O"},
                new string []{"X","O","O"},
            }
        };

        foreach (var gameboard in gameBoards)
        {
            Console.WriteLine(CheckGame(gameboard));
        }

    }

    private static string CheckGame(string[][] gameBoard)
    {
        int[][] winning_positions = new int[][]
        {
            new int []{0,1,2},
            new int []{3,4,5},
            new int []{6,7,8},

            new int []{0,3,6},
            new int []{1,4,7},
            new int []{2,5,8},

            new int []{0,4,8},
            new int []{2,4,6}
        };

        int number_columns_rows_in_gameBoard = 3;
        if (gameBoard.Length != number_columns_rows_in_gameBoard)
            return "nulo";

        foreach (var row in gameBoard)
        {
            if (row.Length != number_columns_rows_in_gameBoard)
                return "nulo";
        }

        List<string> positions_for_x_player = GetPlayerPositions("X", gameBoard);
        List<string> positions_for_o_player = GetPlayerPositions("O", gameBoard);

        var x_count = positions_for_x_player.Where(p => p.Equals("X")).Count();
        var o_count = positions_for_o_player.Where(p => p.Equals("O")).Count();

        if ((x_count - o_count) > 1 || (o_count - x_count) > 1)
            return "nulo";

        bool is_x_player_winner = IsPlayerWinner("X", positions_for_x_player, winning_positions);
        bool is_o_player_winner = IsPlayerWinner("O", positions_for_o_player, winning_positions);

        if (is_x_player_winner && is_o_player_winner)
            return "nulo";
        else if (!is_x_player_winner && !is_o_player_winner)
            return "empate";
        else if (is_x_player_winner)
            return "X";
        else
            return "O";
    }

    private static bool IsPlayerWinner(string player, List<string> player_positions, int[][] winning_positions)
    {
        foreach (var winning_position_row in winning_positions)
        {
            int player_flagged_positions = 0;
            foreach (int winning_position in winning_position_row)
            {
                if (player_positions[winning_position] == player)
                    player_flagged_positions++;
            }

            if (player_flagged_positions == 3)
                return true;
        }

        return false;
    }

    private static List<string> GetPlayerPositions(string player, string[][] gameBoard)
    {
        List<string> positions = new();

        for (var row_index = 0; row_index < gameBoard.Length; row_index++)
        {
            for (var cell_index = 0; cell_index < gameBoard[row_index].Length; cell_index++)
            {
                if (gameBoard[row_index][cell_index].ToUpper() == player)
                    positions.Add(player);
                else
                    positions.Add(string.Empty);
            }
        }

        return positions;
    }
}