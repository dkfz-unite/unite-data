namespace Unite.Data.Entities.Mutations
{
    public class ProteinDomain
    {
        public int Id { get; set; }

        public int ProteinId { get; set; }

        public string Type { get; set; }
        public string Symbol { get; set; }
        public int? Start { get; set; }
        public int? End { get; set; }

        public virtual Protein Protein { get; set; }

        public virtual ProteinDomainInfo Info { get; set; }
    }
}
