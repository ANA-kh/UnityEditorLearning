using UnityEngine;

namespace EditorFramework
{
    public class RectStringConverter : StringConverter<Rect>
    {
        public override bool TryConvert(string self, out Rect result)
        {
            var positionChars = self.Split(',');
            var position = new Rect
            {
                x = float.Parse(positionChars[0]),
                y = float.Parse(positionChars[1]),
                width = float.Parse(positionChars[2]),
                height = float.Parse(positionChars[3])
            };

            result = position;
            return true;
        }
    }
}