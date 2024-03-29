﻿using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Entities.Genome.Abstractions;

public interface IDnaEntity
{
    Chromosome? ChromosomeId { get; set; }
    int? Start { get; set; }
    int? End { get; set; }
}
