using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle(20);
            IShape square = new Square();
            IShape rectangle = new Rectangle();
            GraphicEditor editor = new GraphicEditor();
            Line line = new Line();
            editor.DrawShape(circle);
            editor.DrawShape(square);
            editor.DrawShape(rectangle);
            editor.DrawShape(line);
        }
    }
}
