using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        private IEnumerable<Type> types;
        public GraphicEditor()
        {
            var type = typeof(IShape);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
        }
        public void DrawShape(IShape shape)
        {
            GetShapes();
            if (shape.IsMatch(shape))
            {
                Console.WriteLine($"Drawing {shape.GetType().Name}");
            }
        }

        private void GetShapes()
        {
            var type = typeof(IShape);
            this.types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && type != p);
            ;
        }
    }
}
