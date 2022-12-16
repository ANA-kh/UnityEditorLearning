using UnityEngine;

namespace EditorFramework
{
    public enum AnchorType
    {
        UpperLeft = 0,
        UpperCenter = 1,
        UpperRight = 2,
        MiddleLeft = 3,
        MiddleCenter = 4,
        MiddleRight = 5,
        LowerLeft = 6,
        LowerCenter = 7,
        LowerRight = 8
    }
    
    public enum SplitType
    {
        Horizontal = 0,
        Vertical = 1
    }

    public static class RectExtension
    {
        public static Rect Zoom(this Rect rect, AnchorType type, float pixel)
        {
            return Zoom(rect,new Vector2(pixel, pixel),type);
        } 
        public static Rect Zoom(this Rect rect, Vector2 pixelOffset, AnchorType type = AnchorType.MiddleCenter)
        {
            float tempW = rect.width + pixelOffset.x;
            float tempH = rect.height + pixelOffset.y;
            switch (type)
            {
                case AnchorType.UpperLeft:
                    break;
                case AnchorType.UpperCenter:
                    rect.x -= (tempW - rect.width) / 2;
                    break;
                case AnchorType.UpperRight:
                    rect.x -= tempW - rect.width;
                    break;
                case AnchorType.MiddleLeft:
                    rect.y -= (tempH - rect.height) / 2;
                    break;
                case AnchorType.MiddleCenter:
                    rect.x -= (tempW - rect.width) / 2;
                    rect.y -= (tempH - rect.height) / 2;
                    break;
                case AnchorType.MiddleRight:
                    rect.y -= (tempH - rect.height) / 2;
                    rect.x -= tempW - rect.width;
                    break;
                case AnchorType.LowerLeft:
                    rect.y -= tempH - rect.height;
                    break;
                case AnchorType.LowerCenter:
                    rect.y -= tempH - rect.height;
                    rect.x -= (tempW - rect.width) / 2;
                    break;
                case AnchorType.LowerRight:
                    rect.y -= tempH - rect.height;
                    rect.x -= tempW - rect.width;
                    break;
            }
            rect.width = tempW;
            rect.height = tempH;
            return rect;
        }

        // public static Rect[] Split(this Rect self, SplitType splitType, float width, float padding = 0,
        //     bool justMid = true)
        // {
        //     if (splitType == SplitType.Vertical)
        //     {
        //         return self.VerticalSplit(width, padding, justMid);
        //     }
        //     else
        //     {
        //         return self.HorizontalSplit(width, padding, justMid);
        //     }
        // }
        //
        // public static Rect[] HorizontalSplit(this Rect self, float width, float padding = 0, bool justMid = true)
        // {
        //     if (justMid)
        //     {
        //         return new Rect[2]
        //         {
        //             self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding / 2f)),
        //             self.CutLeft(width).CutLeft(padding).CutLeft(-Mathf.CeilToInt(padding / 2f))
        //         };
        //     }
        //
        //     return new Rect[2]
        //     {
        //         new Rect(0, 0, 0, 0),
        //         new Rect(0, 0, 0, 0)
        //     };
        // }
        //
        // public static Rect[] VerticalSplit(this Rect self, float width, float padding = 0, bool justMid = true)
        // {
        //     if (justMid)
        //     {
        //         return new Rect[2]
        //         {
        //             self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding / 2f)),
        //             self.CutLeft(width).CutLeft(padding).CutLeft(-Mathf.CeilToInt(padding / 2f))
        //         };
        //     }
        //
        //     return new Rect[2]
        //     {
        //         new Rect(0, 0, 0, 0),
        //         new Rect(0, 0, 0, 0)
        //     };
        // }
        //
        // public static Rect VerticalSplitPaddingRect(this Rect self, float width, float padding = 0)
        // {
        //     var rect = self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding / 2f));
        //     rect.x += rect.width;
        //     rect.width = padding;
        //     return rect;
        // }
        
        public static Rect[] Split(this Rect r, SplitType type, float offset, float padding = 0, bool justMid = true)
        {
            switch (type)
            {
                case SplitType.Vertical:
                    return r.VerticalSplit(offset, padding, justMid);
                case SplitType.Horizontal:
                    return r.HorizontalSplit(offset, padding, justMid);
                default:
                    return default(Rect[]);
            }
        }
        public static Rect SplitRect(this Rect r, SplitType type, float offset, float padding = 0)
        {
            switch (type)
            {
                case SplitType.Vertical:
                    return r.VerticalSplitRect(offset, padding);
                case SplitType.Horizontal:
                    return r.HorizontalSplitRect(offset, padding);
                default:
                    return default(Rect);
            }
        }
        public static Rect[] VerticalSplit(this Rect r, float width, float padding = 0, bool justMid = true)
        {
            if (justMid)
                return new Rect[2]{
                r.CutRight((int)(r.width-width)).CutRight(padding).CutRight(-Mathf.CeilToInt(padding/2f)),
                r.CutLeft(width).CutLeft(padding).CutLeft(-Mathf.FloorToInt(padding/2f))
            };
            return new Rect[2]{
                r.CutRight((int)(r.width-width)).Cut(padding).CutRight(-Mathf.CeilToInt(padding/2f)),
                r.CutLeft(width).Cut(padding).CutLeft(-Mathf.FloorToInt(padding/2f))
            };
        }
        public static Rect[] HorizontalSplit(this Rect r, float height, float padding = 0, bool justMid = true)
        {
            if (justMid)
                return new Rect[2]{
                r.CutBottom((int)(r.height-height)).CutBottom(padding).CutBottom(-Mathf.CeilToInt(padding/2f)),
                r.CutTop(height).CutTop(padding).CutTop(-Mathf.FloorToInt(padding/2f))
                };
            return new Rect[2]{
                r.CutBottom((int)(r.height-height)).Cut(padding).CutBottom(-Mathf.CeilToInt(padding/2f)),
                r.CutTop(height).Cut(padding).CutTop(-Mathf.FloorToInt(padding/2f))
            };
        }
        public static Rect HorizontalSplitRect(this Rect r, float height, float padding = 0)
        {
            Rect rect = r.CutBottom((int)(r.height - height)).Cut(padding).CutBottom(-Mathf.CeilToInt(padding / 2f));
            rect.y += rect.height;
            rect.height = padding;
            return rect;
        }
        public static Rect VerticalSplitRect(this Rect r, float width, float padding = 0)
        {
            Rect rect = r.CutRight((int)(r.width - width)).Cut(padding).CutRight(-Mathf.CeilToInt(padding / 2f));
            rect.x += rect.width;
            rect.width = padding;
            return rect;
        }

        public static Rect CutRight(this Rect self, float pixels) //Rect 为Struct，即使是成员函数，也是按值传递
        {
            self.xMax -= pixels;
            return self;
        }

        public static Rect CutLeft(this Rect self, float pixels)
        {
            self.xMin += pixels;
            return self;
        }

        public static Rect CutTop(this Rect self, float pixels)
        {
            self.yMin += pixels;
            return self;
        }

        public static Rect CutBottom(this Rect self, float pixels)
        {
            self.yMax -= pixels;
            return self;
        }
        
        public static Rect Cut(this Rect r, float pixels)
        {
            return r.Margin(-pixels);
        }
        
        public static Rect Margin(this Rect r, float pixels)
        {
            r.xMax += pixels;
            r.xMin -= pixels;
            r.yMax += pixels;
            r.yMin -= pixels;
            return r;
        }
    }
}