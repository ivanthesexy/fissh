using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace fissh
{
    class MainWindow : Window
    {
        [UI] private Image crumbpic = null;
        [UI] private Button ok1 = null;
        [UI] private Button ok2 = null;
        [UI] private Button dont = null;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            using (var stream = new System.IO.MemoryStream(ExtractResource("crumb.jpeg")))
            {
                crumbpic.Pixbuf = new Gdk.Pixbuf(stream);
            }
            ok1.Clicked += Button1_Clicked;
            ok2.Clicked += Button1_Clicked;
            dont.Clicked += Button1_Clicked;
        }

        private static byte[] ExtractResource(string filename)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            using System.IO.Stream resFilestream = a.GetManifestResourceStream(filename);
            if (resFilestream == null) return null;
            byte[] ba = new byte[resFilestream.Length];
            resFilestream.Read(ba, 0, ba.Length);
            return ba;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            Application.Quit();
        }
    }
}
