using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class VolumeFilter : IFilter
    {
        public VolumeFilter(float amount)
        {
            if (amount < 0 || amount > 1)
            {
                ExceptionHelper.OutOfRange(nameof(amount), 0, 1, amount);
            }

            Value = amount;
        }

        public float Value { get; }

        // if(lt(t,10),1,max(1-(t-10)/5,0))
        // public string Expression { get; set; }

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public override string ToString() => Canonicalize();

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("volume(");
            sb.Append(Value);
            sb.Append(')');
        }

        public static VolumeFilter Create(in CallSyntax syntax)
        {
            return new VolumeFilter(Unit.Parse(syntax.Arguments[0].Value.ToString()));
        }
    }
}