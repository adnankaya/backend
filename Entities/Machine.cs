using System.Collections.Generic;

namespace backend.Entities
{
    public class Machine
    {
        public int Id { get; set; }
        public string name { get; set; }

        public int expertId { get; set; }

        public Expert Expert { get; set; }

        public List<MachinePiece> machinePieces { get; set; }
    }
}