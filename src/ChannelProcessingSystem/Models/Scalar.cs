namespace ChannelProcessingSystem.Models
{
    public class Scalar
    {
        public string Identifier { get; set; }
        public float Value { get; set; }

        public override string ToString()
        {
            return $"{Identifier},{Value}";
        }
    }
}
