using System.Collections.Generic;

namespace backend.Entities
{
    public class Piece
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<MachinePiece> machinePieces { get; set; }
    }
}