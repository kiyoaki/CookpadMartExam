using System;

namespace Q1
{
    public class Box
    {
        public Box(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                throw new ArgumentNullException(nameof(inputText));
            }

            var splited = inputText.Split(':');
            if (splited.Length != 2)
            {
                throw new ArgumentException($"{nameof(inputText)}={inputText}");
            }

            if (long.TryParse(splited[0], out var id))
            {
                Id = id;
            }
            else
            {
                throw new ArgumentException($"{nameof(inputText)}={inputText}");
            }

            if (double.TryParse(splited[1], out var weight))
            {
                Weight = weight;
            }
            else
            {
                throw new ArgumentException($"{nameof(inputText)}={inputText}");
            }
        }

        public long Id { get; }
        public double Weight { get; }
    }
}
