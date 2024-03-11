using System.Reflection;
using System.Text;

namespace MauiApp2
{
    public class NamedColor
    {
        public string Name { private set; get; } = string.Empty;

        public string FriendlyName { private set; get; } = string.Empty;

        public Color Color { private set; get; } = new Color();

        // Expose the Color fields as properties
        public float? Red => Color.Red;
        public float? Green => Color.Green;
        public float? Blue => Color.Blue;

        // Static members
        static NamedColor()
        {

            List<NamedColor> all = [];
            StringBuilder stringBuilder = new();

            // Loop through the public static fields of the Color structure.
            foreach (FieldInfo fieldInfo in typeof(Colors).GetRuntimeFields())
            {
                if (fieldInfo.IsPublic &&
                    fieldInfo.IsStatic &&
                    fieldInfo.FieldType == typeof(Color))
                {
                    // Convert the name to a friendly name.
                    string name = fieldInfo.Name;
                    stringBuilder.Clear();
                    int index = 0;

                    foreach (char ch in name)
                    {
                        if (index != 0 && Char.IsUpper(ch))
                        {
                            stringBuilder.Append(' ');
                        }
                        stringBuilder.Append(ch);
                        index++;
                    }

                    // Instantiate a NamedColor object.
                    NamedColor namedColor = new()
                    {
                        Name = name,
                        FriendlyName = stringBuilder.ToString(),
                        Color = (Color)fieldInfo.GetValue(null) 
                };

                    // Add it to the collection.
                    all.Add(namedColor);
                }
            }
            all.TrimExcess();
            All = all;
        }

        public static IEnumerable<NamedColor> All { private set; get; }
    }
}
