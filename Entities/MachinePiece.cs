namespace backend.Entities
{
    public class MachinePiece
    {
        public int id { get; set; }
        public int machineId { get; set; }
        public Machine machine { get; set; }
        public int pieceId { get; set; }
        public Piece piece { get; set; }
        public int amount { get; set; }
    }
}