using System;

namespace WebApplication1.Models
{
    public class ListBoxItem : Object
    {
        public virtual string Text { get; set; }
        public virtual object Tag { get; set; }
        public virtual object Object { get; set; }
        public virtual string Name { get; set; }

        public ListBoxItem()
        {
            this.Text = string.Empty;
            this.Tag = null;
            this.Name = string.Empty;
            this.Object = null;
        }

        public ListBoxItem(string Text, string Name, object Tag, object Object)
        {
            this.Text = Text;
            this.Tag = Tag;
            this.Name = Name;
            this.Object = Object;
        }

        public ListBoxItem(object Object)
        {
            this.Text = Object.ToString();
            this.Name = Object.ToString();
            this.Object = Object;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
