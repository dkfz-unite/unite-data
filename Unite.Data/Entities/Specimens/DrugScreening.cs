namespace Unite.Data.Entities.Specimens;

public class DrugScreening
{
    public int Id { get; set; }
    public int SpecimenId { get; set; }
    public int DrugId { get; set; }

    public double? Dss { get; set; }
    public double? DssSelective { get; set; }
    public double? Gof { get; set; }
    public double? MinConcentration { get; set; }
    public double? MaxConcentration { get; set; }
    public double? AbsIC25 { get; set; }
    public double? AbsIC50 { get; set; }
    public double? AbsIC75 { get; set; }
    public double[] Inhibition { get; set; }


    public virtual Drug Drug { get; set; }
}
