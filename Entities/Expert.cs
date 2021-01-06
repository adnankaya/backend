using System.Collections.Generic;

namespace backend.Entities
{
    public class Expert
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }


        public List<Machine> machines { get; set; }
    }
}