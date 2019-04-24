using System;
using Native.Objects;

public class asyncCallbackWindowGetNonFixedInfos
{
    public struct TheseInfos
    {
        public bool enabled;
        public int height;
        public bool isTask;
        public int left;
        public byte opacity;
        public int top;
        public bool visible;
        public int width;
        public Native.Api.NativeStructs.Rect theRect;
        public string caption;
        public TheseInfos(bool enab, bool isTas, byte opac, ref Native.Api.NativeStructs.Rect r, string scap, bool isV)
        {
            enabled = enab;
            isTask = isTas;
            opacity = opac;
            height = r.Bottom - r.Top;
            width = r.Right - r.Left;
            top = r.Top;
            left = r.Left;
            theRect = r;
            caption = scap;
            visible = isV;
        }
    }

    // Totally sync retrieving of informations
    public static TheseInfos ProcessAndReturnLocal(IntPtr handle)
    {
        bool enabled = Window.IsWindowEnabled(handle);
        bool visible = Window.IsWindowVisible(handle);
        byte opacity = Window.GetWindowOpacityByHandle(handle);
        bool isTask = Window.IsWindowATask(handle);
        Native.Api.NativeStructs.Rect r = Window.GetWindowPositionAndSizeByHandle(handle);
        string s = Window.GetWindowCaption(handle);
        return new TheseInfos(enabled, isTask, opacity, ref r, s, visible);
    }
}

