namespace Unite.Data.Utilities.Mutations
{
    public static class BasePairChangeParser
    {
        /// <summary>
        /// Prases base pair change to separate values.
        /// </summary>
        /// <param name="change">Base pair change string (e.g. A/Q)</param>
        /// <returns>Tuple(ReferenceBase, AlternateBase).</returns>
        public static (string ReferenceBase, string AlternateBase) Parse(string change)
        {
            var blocks = change.Split("/");

            var referenceBase = blocks.Length > 0 ? blocks[0] : null;
            var alternateBase = blocks.Length > 1 ? blocks[1] : null;

            return (referenceBase, alternateBase);
        }
    }
}
