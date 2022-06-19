using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositeGift root = new CompositeGift("Box", 20);
            var child1 = new CompositeGift("2nd Box", 10);
            var child2 = new CompositeGift("3rd Box", 10);
            root.AddGift(child1);
            root.AddGift(child2);

            child1.AddGift(new LeafGift("Brandy", 10));
            child1.AddGift(new LeafGift("Brandy2", 8));
            child2.AddGift(new LeafGift("Whiskey", 15));
            child2.AddGift(new LeafGift("Whiskey2", 9));

            Console.WriteLine(root.CalculateTotalPrice());

        }
    }
}
