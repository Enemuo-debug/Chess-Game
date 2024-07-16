using System;
using System.Collections.Generic;

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a new board
        Board newBoard = new Board();
        for (int i = 1; i <= newBoard.pieces.Length; i++) {
            string c = newBoard.pieces[i-1].kind;
            Console.WriteLine(c + $" {newBoard.pieces[i-1].color} {newBoard.pieces[i-1].GetPosition()}{newBoard.pieces[i-1].color}.");
            Console.WriteLine();
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}

// Creating a tuple Data Structure
class EnemuoTuple {
    private int x;
    private int y;
    // Create a constructor function
    public EnemuoTuple(int x, int y) {
        this.x = x;
        this.y = y;
    }
    public string String() {
        string output = $"X Coordinate - {x}, Y Coordinate - {y}, ";
        return output;
    }
}

class Pieces
{
    public string kind;
    public string color;
    public EnemuoTuple pos;
    static readonly Dictionary<string, string> Types = new Dictionary<string, string>
    {
        {"KING", "The Oga"},
        {"QUEEN", "The King's Wife"},
        {"KNIGHT", "The Unpredictable Killer"},
        {"ROOK", "Straight Killer"},
        {"BISHOP", "Diagonal Killer"},
        {"PAWN", "Small but Mighty"},
    };

    public Pieces(string type, int x, int y, int id)
    {

        if (Types.ContainsKey(type) && (id == 0 || id == 1 || id == 6 || id == 7))
        {
            kind = type;
            pos = new EnemuoTuple(x, y);
            if (id == 0 || id == 1) {
                this.color = "white";
            } else {
                this.color = "black";
            }
        }
        else
        {
            throw new ArgumentException("Invalid piece type");
        }
    }

    public string GetDescription()
    {
        return Types.TryGetValue(kind, out string description) ? description : "Unknown";
    }

    public string GetPosition()
    {
        return pos.String();
    }
}

class Cell 
{
    static char[] XAxis = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'};
    public string CellName;
    public Cell (int x, int y) {
        this.CellName = $"{XAxis[x]}{y}";
    }
}

class Board {
    public Cell[] cells = new Cell[64];
    public Pieces[] pieces= new Pieces[32];
    public string BoardName;
    public Board () {
        string [] OrderOfArrangement = { "ROOK", "KNIGHT", "BISHOP", "QUEEN", "KING", "BISHOP", "KNIGHT", "ROOK"};
        int index = 0;
        int pieceIndex = 0;
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                // Create a new cell
                Cell newCell = new Cell(i, j+1);  
                cells[index] = newCell;
                index++;
                if (i == 0 || i == 7) {
                    Pieces newPiece = new Pieces(OrderOfArrangement[j], j, i, i);
                    pieces[pieceIndex] = newPiece;
                    pieceIndex++;
                }
                if (i == 6 || i == 1 ) {
                    Pieces newPiece = new Pieces("PAWN", j, i, i);
                    pieces[pieceIndex] = newPiece;
                    pieceIndex++;
                }
            }
        }
        Console.WriteLine("Board Created Successfully");
        Console.WriteLine();
        Console.WriteLine();
    }
}