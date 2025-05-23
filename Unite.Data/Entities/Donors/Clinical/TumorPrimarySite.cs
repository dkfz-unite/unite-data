﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Donors.Clinical;

public record TumorPrimarySite
{
    [Column("id")]
    public int Id { get; set; }

    [Column("value")]
    public string Value { get; set; }
}
