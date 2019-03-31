using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Spatecon;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(SuperEntryRenderer))]
    namespace Spatecon
    {
        public class SuperEntryRenderer : EntryRenderer
        {
        public SuperEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);
                if (e.OldElement == null)
                {
                    var nativeEditText = (global::Android.Widget.EditText)Control;
                    var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                    shape.Paint.Color = Xamarin.Forms.Color.Transparent.ToAndroid();
                    shape.Paint.SetStyle(Paint.Style.Stroke);
                    nativeEditText.Background = shape;
                }
            }
        }
    }


