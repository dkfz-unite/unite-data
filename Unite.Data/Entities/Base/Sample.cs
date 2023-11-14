namespace Unite.Data.Entities.Base;

/// <summary>
/// Sample.
/// </summary> 
public abstract record Sample
{
    public virtual int Id { get; set; }
    public virtual string ReferenceId { get; set; }
    public virtual DateOnly? CreationDate { get; set; }
    public virtual int? CreationDay { get; set; }
}


/// <summary>
/// Typed sample.
/// <typeparamref name="T">Sample type.</typeparamref>
public abstract record Sample<TType> : Sample where TType : struct, Enum
{
    public virtual TType TypeId { get; set; }
}
